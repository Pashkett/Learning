using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Gateways.Interfaces;

namespace DAL.Gateways
{
    public class ProductTableGateway : BaseGateway, IProductTableGateway
    {
        private const string getProductById = "GetProductById";
        private const string getAllProducts = "GetAllProducts";
        private const string updatePriceById = "UpdateProductPriceByID";
        private const string deleteProductById = "DeleteProductById";
        private const string insertProduct = "InsertProduct";

        private readonly string connection;

        public ProductTableGateway(string connection) : base(connection) =>
            this.connection = connection;

        public DataTable GetAllProducts() => SelectData<string>(getAllProducts);

        public DataTable GetProductById(int id)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("ProductId", id);

            return SelectData(getProductById, parameters);
        }

        public void UpdatePriceById(int id, decimal price)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add("ProductId", id);
            parameters.Add("Price", price);

            ModifyData(updatePriceById, parameters);
        }

        public void DeleteProductById(int id)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("ProductId", id);

            ModifyData(deleteProductById, parameters);
        }

        public void InsertProduct(string name, decimal price, int supplier)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add("Name", name);
            parameters.Add("Price", price);
            parameters.Add("SupplierId", supplier);

            ModifyData(insertProduct, parameters);
        }
    }
}