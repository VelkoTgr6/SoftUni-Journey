using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string inputSuppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, inputSuppliersXml));

            string inputPartsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context,inputPartsXml));

            string importCarsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, importCarsXml));

            string importCustomersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context,importCustomersXml));

            string importSalesXml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context,importSalesXml));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }
        //Imports
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            //1.Create Xml serializer
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDTO[]), new XmlRootAttribute("Suppliers"));

            //2. Deserialize
            using var reader = new StringReader(inputXml);
            ImportSupplierDTO[] importSupplierDTOs = (ImportSupplierDTO[])xmlSerializer.Deserialize(reader);

            //3.Map
            var mapper = GetMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(importSupplierDTOs);

            //4.Add to EF context
            context.AddRange(suppliers);

            //5.Commint changes to DB
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartsDTO[]), new XmlRootAttribute("Parts"));

            using var reader = new StringReader(inputXml);
            ImportPartsDTO[] importPartsDTOs = (ImportPartsDTO[])xmlSerializer.Deserialize(reader);

            var supplierIds = context.Suppliers
                .Select(p => p.Id)
                .ToArray();

            var mapper = GetMapper();

            Part[] parts = mapper.Map<Part[]>(importPartsDTOs
                .Where(p => supplierIds.Contains(p.SupplierId)));

            context.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //Imports Also Mapping Table(PartCar)!!
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarsDTO[]), new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);

            ImportCarsDTO[] importCarsDTOs = (ImportCarsDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            List<Car> cars = new List<Car>();

            foreach (var carDTO in importCarsDTOs)
            {
                //1.Map Car Entity: We map each carDTO to a Car entity using the mapper.
                Car car = mapper.Map<Car>(carDTO);

                //2.Retrieve Part IDs: Extract distinct part IDs from the DTO.
                int[] carPartIds = carDTO.PartsIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                //3.Check for Existing Parts: Query the database to find which part IDs actually exist.
                var existingPartIds = context.Parts
                    .Where(p => carPartIds.Contains(p.Id))
                    .Select(p => p.Id)
                    .ToArray();

                //4.Create PartCar Entities: -> Create PartCar entities only for those parts that exist in the database.
                var carParts = new List<PartCar>();

                //5.Associate Parts with Car: Associate the valid PartCar entities with the Car entity
                foreach (var id in existingPartIds)
                {
                    carParts.Add(new PartCar
                    {
                        Car = car,
                        PartId = id
                    });
                }

                //6.Add and Save Cars: Add the list of Car entities to the context and save changes
                car.PartsCars = carParts;
                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDTO[]), new XmlRootAttribute("Customers"));

            using var reader = new StringReader(inputXml);

            ImportCustomerDTO[] importCustomerDTOs = (ImportCustomerDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();

            Customer[] customers = mapper.Map<Customer[]>(importCustomerDTOs);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSalesDTO[]), new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);

            ImportSalesDTO[] importSalesDTOs = (ImportSalesDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();

            var carIds = context.Cars
                .Select(x => x.Id)
                .ToArray();

            Sale[] sales = mapper.Map<Sale[]>(importSalesDTOs
                .Where(s => carIds.Contains(s.CarId)));

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";

        }

        //Exports
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var distance = 2_000_000;

            var mapper = GetMapper();

            var carsWithDistance = context.Cars
                .Where(c => c.TraveledDistance > distance)
                .OrderBy(c => c.Make)
                    .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarsWithDistance>(mapper.ConfigurationProvider)
                .ToArray();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistance[]), new XmlRootAttribute("cars"));

            //var xsn = new XmlSerializerNamespaces();
            //xsn.Add(string.Empty, string.Empty);

            //StringBuilder stringBuilder = new StringBuilder();

            //using (StringWriter sw = new StringWriter(stringBuilder))
            //{
            //    xmlSerializer.Serialize(sw, carsWithDistance, xsn);
            //}


            return SerializeToXml(carsWithDistance, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var make = "BMW";

            var mapper = GetMapper();

            var bmws = context.Cars
                .Where(c => c.Make == make)
                .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportCarsFromMake>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsFromMake[]), new XmlRootAttribute("cars"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter sw = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(sw, bmws, xsn);
            }

            return stringBuilder.ToString().TrimEnd();
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var mapper = GetMapper();

            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportLocalSuppliers>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliers[]), new XmlRootAttribute("suppliers"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter sw = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(sw, localSuppliers, xsn);
            }

            return stringBuilder.ToString().TrimEnd();
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var mapper = GetMapper();

            var cars = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                    .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarsWithParts
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars.Select(pc => new ExportCarParts
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithParts[]), new XmlRootAttribute("cars"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, cars, xsn);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithSales = context.Customers
                 .Where(c => c.Sales.Any())
                 .Select(c => new
                 {
                     c.Name,
                     BoughtCars = c.Sales.Count(),
                     IsYoungDriver = c.IsYoungDriver,
                     Sales = c.Sales.Select(s => s.Car.PartsCars.Select(pc => pc.Part.Price)).ToList(),
                     Discount=c.Sales.FirstOrDefault(s=>s.CustomerId==c.Id)
                 })
                 .ToList() // Execute the query and bring the data into memory
                 .Select(c => new ExportCustomersWithSales
                 {
                     Name = c.Name,
                     BoughtCars = c.BoughtCars,
                     SpentMoney = c.Sales.Sum(carParts => carParts.Sum(price => c.IsYoungDriver ? price * 0.95m  : price))
                 })
                 .OrderByDescending(x => x.SpentMoney)
                 .ToArray();




            return SerializeToXml<ExportCustomersWithSales[]>(customersWithSales, "customers");
        }
        //Generic method to serialize DTO's XML
        private static string SerializeToXml<T>(T dto, string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(sw, dto, xsn);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new 
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance,
                    Discount=s.Discount,
                    CusomerName=s.Customer.Name,
                    CalculatedDiscount = s.Discount * 0.01m,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceCalculation = ((s.Car.PartsCars.Sum(pc => pc.Part.Price))* s.Discount * 0.01m),
                    PriceWithDiscount= s.Car.PartsCars.Sum(pc => pc.Part.Price)-((s.Car.PartsCars.Sum(pc => pc.Part.Price)) * s.Discount * 0.01m) 
                })
                .ToArray()
                .Select(s=>new ExportSalesWithDiscount
                {
                    Car=new CarDTO
                    {
                        Make = s.Make,
                        Model = s.Model,
                        TraveledDistance = s.TraveledDistance
                    },
                    Discount=s.Discount,
                    Name=s.CusomerName,
                    Price=s.Price,
                    PriceWithDiscount=s.PriceWithDiscount
                })
                .ToArray();

            return SerializeToXml(sales, "sales");
        }
    }
}