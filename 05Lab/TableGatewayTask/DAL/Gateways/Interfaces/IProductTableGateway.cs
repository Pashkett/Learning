using System.Data;

namespace DAL.Gateways.Interfaces
{
    public interface IProductTableGateway
    {
        void DeleteProductById(int id);
        DataTable GetAllProducts();
        DataTable GetProductById(int id);
        void InsertProduct(string name, decimal price, int supplier);
        void UpdatePriceById(int id, decimal price);
    }
}