using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            string CustomerJson = File.ReadAllText("../../../Datasets/customers.json");
            string salesJson = File.ReadAllText("../../../Datasets/sales.json");

            //CompletePartCarTable(context);
            Console.WriteLine(ImportCars(context,carsJson));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cf => cf.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            SupplierDto[] supplierDtos = JsonConvert.DeserializeObject<SupplierDto[]>(inputJson);

            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            PartDto[] partDtos = JsonConvert.DeserializeObject<PartDto[]>(inputJson);

            Part[] parts = mapper.Map<Part[]>(partDtos);

            int[] suppliers = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            Part[] partsWithValidSuppliers = parts.Where(p => suppliers.Contains(p.SupplierId))
                .ToArray();



            context.Parts.AddRange(partsWithValidSuppliers);
            context.SaveChanges();

            return $"Successfully imported {partsWithValidSuppliers.Count()}.";

        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            SaleDto[] saleDtos = JsonConvert.DeserializeObject<SaleDto[]>(inputJson);

            Sale[] sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver,
                }).ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var cars = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count,
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);


            return json;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    }).ToArray()

                })
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerData = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    Sales = c.Sales.Select(s => new
                    {
                        CarId = s.CarId,
                        Parts = s.Car.PartsCars.Select(pc => new
                        {
                            PartPrice = pc.Part.Price
                        })
                    })
                })
                .ToList();


            var customers = customerData
                .Select(c => new
                {
                    fullName = c.FullName,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s => s.Parts.Sum(p => p.PartPrice))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesCars = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = s.Car,
                    customerName = s.Customer.Name,
                    discount = s.Discount,
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price)

                })
                .ToList();

            var sales = salesCars
                .Select(s => new
                {
                    car = new
                    {
                        s.car.Make,
                        s.car.Model,
                        s.car.TraveledDistance,
                    },
                    customerName = s.customerName,
                    discount = s.discount,
                    price = s.price,
                    priceWithDiscount = s.price * (1 - s.discount / 100)
                }).ToArray();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
        public static void CompletePartCarTable(CarDealerContext context)
        {
            // Retrieve existing cars and parts from the database
            var cars = context.Cars.ToList();
            var parts = context.Parts.ToList();

            var partsCarList = new List<PartCar>();

            foreach (var car in cars)
            {
                
            }

            // Add the partsCar list to the context
            context.PartsCars.AddRange(partsCarList);
            context.SaveChanges();
        }
    }
}