using System;
using Autofac;
using BusinessLogicLayer;


namespace TableGatewayTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IProductService>();
                service.GetAllProductsByCategory("commodo");
                
                Console.WriteLine(new string('=', 20));

                service.GetAllProductsBySupplier("OLYMPIX");

            }

            Console.ReadLine();
        }
    }
}
