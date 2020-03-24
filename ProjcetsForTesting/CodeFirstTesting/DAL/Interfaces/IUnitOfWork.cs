using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }
        ICategoryRepository Categories { get; }
        int Complete();
    }
}
