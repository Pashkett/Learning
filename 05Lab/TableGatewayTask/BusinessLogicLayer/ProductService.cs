using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Persistence.Interfaces;

namespace BusinessLogicLayer
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        public void GetAllProductsByCategory(string name)
        {
            var productsByCategories =
                from products in unitOfWork.ProductRepository.GetAll()
                join productCategory in unitOfWork.ProductCategoryRepository.GetAll() 
                    on products.ProductId equals productCategory.ProductId
                join categories in unitOfWork.CategoryRepository.GetByName(name) 
                    on productCategory.CategoryId equals categories.CategoryId
                select new { productName = products.Name, categoryName = categories.Name };
                

            foreach (var product in productsByCategories)
            {
                Console.WriteLine($"{product.productName} {product.categoryName}");
            }
        }

        public void GetAllProductsBySupplier(string supplierName)
        {
            var productsBySuppliers =
                from products in unitOfWork.ProductRepository.GetAll()
                join suppliers in unitOfWork.SupplierRepository.GetByName(supplierName)
                    on products.SupplierId equals suppliers.SupplierId
                select new { products.Name, suppliers.SupplierName };

            foreach (var product in productsBySuppliers)
            {
                Console.WriteLine($"{product.Name} {product.SupplierName}");
            }
        }
    }
}
