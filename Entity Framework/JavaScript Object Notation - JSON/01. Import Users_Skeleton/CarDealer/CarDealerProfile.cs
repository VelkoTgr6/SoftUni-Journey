using AutoMapper;
using CarDealer.DTOs;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierDto,Supplier>();

            CreateMap<PartDto,Part>();

            CreateMap<CarDto, Car>();

            CreateMap<SaleDto,Sale>();
            
        }
    }
}
