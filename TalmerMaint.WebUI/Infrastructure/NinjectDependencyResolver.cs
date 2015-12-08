using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using TalmerMaint.Domain.Abstract;
using TalmerMaint.Domain.Entities;
using TalmerMaint.Domain.Concrete;

namespace TalmerMaint.WebUI.Infrastructure
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
            /* ---- Mock Library for Testing Controller with fake info
            Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
             mock.Setup(m => m.Locations).Returns(new List<Location>
             {
                 new Location {Title = "Bad Axe", Subtitle= "A Bad Axe Production", Address1 = "124 n. Ave." },
                 new Location {Title = "Bad Axe2", Subtitle= "A Bad Axe Production2", Address1 = "125 n. Ave.", Address2 = "Suite 201", AtmOnly=true, City="Bad Axe", Description= "A Bad Axe Atm in the middle of Bad Axe", Latitude=42.333333, Longitude=-131.9999, ManagerName="Suzy Q", State="MI", Zip="153398", NoAtm=false },
                 new Location {Title = "Bad Axe3", Subtitle= "A Bad Axe Production3", Address1 = "126 n. Ave." }
             });
             kernel.Bind<ILocationRepository>().ToConstant(mock.Object);
             */
            kernel.Bind<ILocationRepository>().To<EFLocationRepository>();
            kernel.Bind<IDbChangeLog>().To<EFDbChangeLog>();
        }
    }
}