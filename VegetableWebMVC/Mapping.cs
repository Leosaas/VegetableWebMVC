using AutoMapper;
using Infrastructure.Entities;
using VegetableWebMVC.Models;

namespace VegetableWebMVC
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Add as many of these lines as you need to map your objects

            CreateMap<Unit, UnitViewModel>();
            CreateMap<UnitViewModel, Unit>();
            CreateMap<Product,ProductViewModel>();  
            CreateMap<ProductViewModel, Product>();
        }
    }
}
