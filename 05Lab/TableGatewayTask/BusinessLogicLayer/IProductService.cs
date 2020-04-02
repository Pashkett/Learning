using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IProductService
    {
        void GetAllProductsByCategory(string name);
        void GetAllProductsBySupplier(string name);
    }
}