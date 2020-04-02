using System;
using System.Configuration;
using DataAccessLayer.Persistence.Interfaces;

namespace DataAccessLayer.Persistence
{
    public class AdoNetUnitOfWork : IUnitOfWork
    {
        const string ConnectionStringName = "DefaultConnection";

        private bool disposedValue = false;
        private AdoNetContext context;

        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;
        private ISupplierRepository supplierRepository;
        private IProductCategoryRepository productCategoryRepository;

        public AdoNetUnitOfWork()
        {
            var connectionString = 
                ConfigurationManager
                    .ConnectionStrings[ConnectionStringName]
                    .ConnectionString;

            context = new AdoNetContext(connectionString, true);
        }

        public ICategoryRepository CategoryRepository =>
            categoryRepository ?? (categoryRepository = new CategoryRepository(context));

        public IProductRepository ProductRepository => 
            productRepository ?? (productRepository = new ProductRepository(context));

        public ISupplierRepository SupplierRepository => 
            supplierRepository ?? (supplierRepository = new SupplierRepository(context));

        public IProductCategoryRepository ProductCategoryRepository => 
            productCategoryRepository ?? (productCategoryRepository = new ProductCategoryRepository(context));

        public void Commit()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
