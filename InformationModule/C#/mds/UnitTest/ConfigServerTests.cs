using Microsoft.VisualStudio.TestTools.UnitTesting;
using mds.ConfigService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.BaseModel;

namespace mds.ConfigService.Tests
{
    [TestClass()]
    public class ConfigServerTests
    {
        private static ConfigServer _server = new ConfigServer();
        [TestMethod()]
        public void CreateComponentTest()
        {
            var r = _server.CreateComponent(new Component() {
                 ComponentID=1,
                  ComponentName="unitest1"
            });
            Assert.IsTrue(r.ActionResult);
            Assert.IsTrue(r.Data > 0);
        }
    }
}