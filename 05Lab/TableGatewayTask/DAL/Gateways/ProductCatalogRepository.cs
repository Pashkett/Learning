using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Gateways;
using DAL.Gateways.Interfaces;

namespace DAL.Gateways
{
    public class ProductCatalogRepository
    {
        private readonly string connection;

        private ICategoryTableGateway categoryTableGateway;
        private IProductCategoryTableGateway productCategoryTableGateway;
        private IProductTableGateway productTableGateway;
        private ISupplierTableGateway supplierTableGateway;

        public ProductCatalogRepository(string connection) => this.connection = connection;

        public ICategoryTableGateway CategoryTableGateway
        {
            get
            {
                if (categoryTableGateway == null)
                {
                    categoryTableGateway = new CategoryTableGateway(connection);
                }

                return categoryTableGateway;
            }
        }

        public IProductCategoryTableGateway ProductCategoryTableGateway
        {
            get
            {
                if (productCategoryTableGateway == null)
                {
                    productCategoryTableGateway = new ProductCategoryTableGateway(connection);
                }

                return productCategoryTableGateway;
            }
        }

        public IProductTableGateway ProductTableGateway
        {
            get
            {
                if (productTableGateway == null)
                {
                    productTableGateway = new ProductTableGateway(connection);
                }
                return productTableGateway;
            }
        }

        public ISupplierTableGateway SupplierTableGateway
        {
            get
            {
                if (supplierTableGateway == null)
                {
                    supplierTableGateway = new SupplierTableGateway(connection);
                }
                
                return supplierTableGateway;
            }
        }

        public void DisplayConnection()
        {
            ProductTableGateway productTable = new ProductTableGateway(connection);
        }
    }
}
