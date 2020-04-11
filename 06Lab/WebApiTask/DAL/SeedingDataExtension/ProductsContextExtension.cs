using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace DAL.SeedingDataExtension
{
    public static class ProductsContextExtensionSeed
    {
        public static List<T> SeedData<T>(string fileName)
        {
            List<T> data = new List<T>();

            string filePath = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "DAL", "SeedingData", fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    string file = File.ReadAllText(filePath);
                    data = JsonSerializer.Deserialize<List<T>>(file);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new Exception("Files not found");
            }

            return data;
        }
    }
}