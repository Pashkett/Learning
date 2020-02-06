using System;
using System.Collections.Generic;

namespace CustomArray
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CustomArray<int> customArray = new CustomArray<int>();

            foreach (var item in customArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
