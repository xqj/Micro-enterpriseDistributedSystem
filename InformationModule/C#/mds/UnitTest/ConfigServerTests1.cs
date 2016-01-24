using Microsoft.VisualStudio.TestTools.UnitTesting;
using mds.ConfigService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigService.Tests
{
    [TestClass()]
    public class ConfigServerTests1
    {
        [TestMethod()]
        public void AddComponentConfigForSolutionTest()
        {
            ConfigServer _server = new ConfigServer();
            var r = _server.AddComponentConfigForSolution(new Model.Solution_Component_Relation() {
                 ComponentConfigId=1,
                  CreateBy=1,
                   IsActive=true,
                    IsDelete=true,
                     SolutionId= "8bfd55bf-ad32-49a9-bece-db8d5262297e",
                      Version=1
            });
            Assert.IsTrue(r.ActionResult);
            Assert.IsTrue(r.Data > 0);
        }
    }
}