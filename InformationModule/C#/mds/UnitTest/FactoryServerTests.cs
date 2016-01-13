using Microsoft.VisualStudio.TestTools.UnitTesting;
using mds.ServiceFactoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ServiceFactoryService.Tests
{
    [TestClass()]
    public class FactoryServerTests
    {
        [TestMethod()]
        public void CreateServicesTest()
        {
           var r= FactoryServer.Intance.CreateServices(Guid.Parse("8bfd55bf-ad32-49a9-bece-db8d5262297e"), 1);
            Assert.IsTrue(r.ActionResult);
        }
    }
}