using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
