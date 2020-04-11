using DAL.Interfaces;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ProductsContext context;

        private IProductRepository productRepository;
        private ISupplierRepository supplierRepository;
        private ICategoryRepository categoryRepository;

        public UnitOfWork(ProductsContext context) => this.context = context;

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

        public async Task<int> CompleteAsync() => await context.SaveChangesAsync();

        public void Dispose() => context.Dispose();
    }
}
