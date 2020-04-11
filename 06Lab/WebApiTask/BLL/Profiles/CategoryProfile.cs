using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}
