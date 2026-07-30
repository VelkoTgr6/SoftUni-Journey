using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDTO, Supplier>();
            CreateMap<ImportPartsDTO, Part>();
            CreateMap<ImportCarsDTO, Car>();
            CreateMap<ImportCustomerDTO, Customer>();
            CreateMap<ImportSalesDTO,Sale>();

            //Export
            CreateMap<Car,ExportCarsWithDistance>();
            CreateMap<Car,ExportCarsFromMake>();
            CreateMap<Supplier, ExportLocalSuppliers>();
            CreateMap<Customer, ExportCustomersWithSales>();
            CreateMap<Sale, ExportCustomersWithSales>();
        }
    }
}
