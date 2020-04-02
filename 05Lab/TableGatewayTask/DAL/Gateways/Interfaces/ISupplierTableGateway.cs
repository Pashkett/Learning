using System.Data;

namespace DAL.Gateways.Interfaces
{
    public interface ISupplierTableGateway
    {
        void DeleteSupplierById(int id);
        DataTable GetAllSuppliers();
        DataTable GetSupplierById(int id);
        void InsertSupplier(string name, string country, string city);
        void UpdateSupplierNameById(int id, string name);
    }
}