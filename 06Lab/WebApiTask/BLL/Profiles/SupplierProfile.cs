using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>();
        }
    }
}
