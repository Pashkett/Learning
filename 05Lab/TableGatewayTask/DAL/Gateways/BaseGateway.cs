using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace DAL.Gateways
{
    public abstract class BaseGateway
    {
        protected readonly string connectionString;

        protected BaseGateway(string connection) => 
            connectionString = connection;

        protected DataTable SelectData<TValue>(string proc,
            Dictionary<string, TValue> paramsWithValues = null,
            bool isProcedure = true)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command;

                if (isProcedure)
                    command = new SqlCommand(proc, connection) { CommandType = CommandType.StoredProcedure};
                else
                    command = new SqlCommand(proc, connection);
                
                if (paramsWithValues != null)
                {
                    foreach (var pair in paramsWithValues)
                    {
                        command.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                }

                adapter.SelectCommand = command;
                adapter.Fill(table);

                return table;
            }
        }

        protected void ModifyData<TValue>(string proc,
            Dictionary<string, TValue> paramsWithValues,
            bool isProcedure = true)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command;

                if (isProcedure)
                    command = new SqlCommand(proc, connection) { CommandType = CommandType.StoredProcedure };
                else
                    command = new SqlCommand(proc, connection);

                if (paramsWithValues.Count(k => k.Key != null) > 0)
                {
                    foreach (var pair in paramsWithValues)
                    {
                        command.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                }

                command.ExecuteNonQuery();
            }
        }

    }
}
