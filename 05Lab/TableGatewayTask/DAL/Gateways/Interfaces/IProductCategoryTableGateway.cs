using System.Data;

namespace DAL.Gateways.Interfaces
{
    public interface IProductCategoryTableGateway
    {
        void DeleteProductCategoryById(int id);
        DataTable GetAlProductlCategories();
        DataTable GetProductCategoryById(int id);
        void InsertProductCategory(int productId, int categoryId);
        void UpdateProductCategoryCategoryById(int id, int categoryId);
        void UpdateProductCategoryProductById(int id, int productId);
    }
}