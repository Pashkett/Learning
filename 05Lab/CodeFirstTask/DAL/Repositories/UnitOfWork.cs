using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ProductsContext context;

        public UnitOfWork()
        {
            this.context = new ProductsContext();
            Products = new ProductRepository(context);
            Suppliers = new SupplierRepository(context);
            Categories = new CategoryRepository(context);
        }

        public IProductRepository Products { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public int Complete() => context.SaveChanges();

        public void Dispose() => context.Dispose();
    }
}
