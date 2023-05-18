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
            //Unit
            CreateMap<Unit, UnitViewModel>();
            CreateMap<UnitViewModel, Unit>();
            //Product
            CreateMap<Product,ProductViewModel>();  
            CreateMap<ProductViewModel, Product>();
            //Category
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            //Account
            CreateMap<Account, AccountViewModel>();
            CreateMap<AccountViewModel, Account>();
            //User
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
