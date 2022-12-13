﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            /*  Mock<IProductRepository> mock = new Mock<IProductRepository>();
              mock.Setup(m => m.Products).Returns(new List<Product>
              {
                  new Product { Name = "Piłka nożna", Price = 25 },
                  new Product { Name = "Deska surfingowa", Price = 179 },
                  new Product { Name = "Buty do biegania", Price = 95 }
              });
              kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            */

            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }


}