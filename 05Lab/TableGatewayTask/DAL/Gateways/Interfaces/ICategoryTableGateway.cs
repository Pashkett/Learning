using System.Data;

namespace DAL.Gateways.Interfaces
{
    public interface ICategoryTableGateway
    {
        void DeleteCategoryById(int id);
        DataTable GetAllCategories();
        DataTable GetCategoryById(int id);
        DataTable GetCategoryByName(string name);
        void InsertCategory(string name);
        void UpdateCategoryNameById(int id, string name);
    }
}