using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Gateways.Interfaces;

namespace DAL.Gateways
{
    public class CategoryTableGateway : BaseGateway, ICategoryTableGateway
    {
        private const string getCategoryById = "GetCategoryById";
        private const string getCategoryByName = "GetCategoryByName";
        private const string getAllCategories = "GetAllCategories";
        private const string updateCategoryNameById = "UpdateCategoryNameById";
        private const string deleteCategoryById = "DeleteCategoryById";
        private const string insertCategory = "InsertCategory";

        private readonly string connection;

        public CategoryTableGateway(string connection) : base(connection) =>
            this.connection = connection;

        public DataTable GetAllCategories() => SelectData<string>(getAllCategories);

        public DataTable GetCategoryById(int id)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("CategoryId", id);

            return SelectData(getCategoryById, parameters);
        }

        public DataTable GetCategoryByName(string name)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CategoryId", name);

            return SelectData(getCategoryByName, parameters);
        }

        public void UpdateCategoryNameById(int id, string name)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add("CategoryId", id);
            parameters.Add("Name", name);

            ModifyData(updateCategoryNameById, parameters);
        }

        public void DeleteCategoryById(int id)
        {
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("CategoryId", id);

            ModifyData(deleteCategoryById, parameters);
        }

        public void InsertCategory(string name)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Name", name);

            ModifyData(insertCategory, parameters);
        }
    }
}