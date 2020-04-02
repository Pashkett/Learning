using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Gateways.Interfaces;

namespace DAL.Gateways
{
    public class ProductCategoryTableGateway : BaseGateway, IProductCategoryTableGateway
    {
        private const string getProductCategoryById = "GetProductCategoryById";
        private const string getAllProductCategories = "GetAllProductCategories";
        private const string updateProductCategoryCategoryById = "UpdateProductCategoryCategoryById";
        private const string updateProductCategoryProductById = "UpdateProductCategoryProducteById";
        private const string deleteProductCategoryById = "DeleteCategoryById";
        private const string insertProductCategory = "InsertCategory";

        private readonly string connection;

        public ProductCategoryTableGateway(string connection) : base(connection) =>
            this.connection = connection;

        public DataTable GetAlProductlCategories() => SelectData<string>(getAllProductCategories);

        public DataTable GetProductCategoryById(int id)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("ProductCategoryId", id);

            return SelectData(getProductCategoryById, parameters);
        }

        public void UpdateProductCategoryProductById(int id, int productId)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("ProductCategoryId", id);
            parameters.Add("ProductId", productId);

            ModifyData(updateProductCategoryProductById, parameters);
        }

        public void UpdateProductCategoryCategoryById(int id, int categoryId)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("ProductCategoryId", id);
            parameters.Add("CategoryId", categoryId);

            ModifyData(updateProductCategoryCategoryById, parameters);
        }

        public void DeleteProductCategoryById(int id)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("ProductCategoryId", id);

            ModifyData(deleteProductCategoryById, parameters);
        }

        public void InsertProductCategory(int productId, int categoryId)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("ProductId", productId);
            parameters.Add("CategoryId", categoryId);

            ModifyData(insertProductCategory, parameters);
        }
    }
}
