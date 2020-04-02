using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ProductsContext context;

        private IProductRepository productRepository;
        private ISupplierRepository supplierRepository;
        private ICategoryRepository categoryRepository;

        public UnitOfWork() => 
            this.context = new ProductsContext();

        public IProductRepository Products => 
            productRepository == null 
                               ? productRepository = new ProductRepository(context) 
                               : productRepository;

        public ISupplierRepository Suppliers =>
            supplierRepository == null
                                ? supplierRepository = new SupplierRepository(context)
                                : supplierRepository;

        public ICategoryRepository Categories =>
            categoryRepository == null
                                ? categoryRepository = new CategoryRepository(context)
                                : categoryRepository;

        public int Complete() => context.SaveChanges();

        public void Dispose() => context.Dispose();
    }
}
