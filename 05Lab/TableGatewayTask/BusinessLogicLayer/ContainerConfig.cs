using Autofac;
using DataAccessLayer.Persistence;
using DataAccessLayer.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<AdoNetUnitOfWork>().As<IUnitOfWork>();

            return builder.Build();
        }
    }
}
