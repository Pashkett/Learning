using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Profiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDTO>();
        }
    }
}
