using Microsoft.VisualStudio.TestTools.UnitTesting;
using mds.ConfigService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigService.Tests
{
    [TestClass()]
    public class ConfigServerTests2
    {
        [TestMethod()]
        public void GetCompleteSolutionTest()
        {
            ConfigServer _server = new ConfigServer();
            var r = _server.GetCompleteSolution(Guid.Parse("8bfd55bf-ad32-49a9-bece-db8d5262297e"));
            Assert.IsTrue(r.ActionResult);
            Assert.IsNotNull(r.Data);
            Assert.IsNotNull(r.Data.Components);
            Assert.IsTrue(r.Data.Components.Count > 0);
        }
    }
}