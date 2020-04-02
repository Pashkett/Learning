using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Gateways.Interfaces;

namespace DAL.Gateways
{
    public class SupplierTableGateway : BaseGateway, ISupplierTableGateway
    {
        private const string getSupplierById = "GetSupplierById";
        private const string getAllSuppliers = "GetAllSuppliers";
        private const string updateSupplierNameById = "UpdateSupplierNameById";
        private const string deleteSupplierById = "DeleteSupplierById";
        private const string insertSupplier = "InsertSupplier";

        private readonly string connection;

        public SupplierTableGateway(string connection) : base(connection) =>
            this.connection = connection;

        public DataTable GetAllSuppliers() => SelectData<string>(getAllSuppliers);

        public DataTable GetSupplierById(int id)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("SupplierId", id);

            return SelectData(getSupplierById, parameters);
        }

        public void UpdateSupplierNameById(int id, string name)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add("SupplierId", id);
            parameters.Add("SupplierName", name);

            ModifyData(updateSupplierNameById, parameters);
        }

        public void DeleteSupplierById(int id)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("SupplierId", id);

            ModifyData(deleteSupplierById, parameters);
        }

        public void InsertSupplier(string name, string country, string city)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("SupplierName", name);
            parameters.Add("Country", country);
            parameters.Add("City", city);

            ModifyData(insertSupplier, parameters);
        }
    }
}
