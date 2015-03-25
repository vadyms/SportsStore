using Domain.Entities;
using Domain.Abstract;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
           return controllerType == null
               ? null
               : (IController) ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //here located additionall links
            mock.Setup(m => m.Products).Returns(new List<Product> {
                new Product {Name = "Football", Price = 25},
                new Product {Name = "Surf board", Price = 179},
                new Product {Name = "Running shoes", Price = 95}
            }.AsQueryable());
        }
    }
}