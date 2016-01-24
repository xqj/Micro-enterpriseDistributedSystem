using Microsoft.VisualStudio.TestTools.UnitTesting;
using mds.ConfigService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.BaseModel;
using mds.DataAccess.Config;
using mds.Util;
using mds.ConfigService.Model;

namespace mds.ConfigService.Tests
{
    [TestClass()]
    public class ConfigServerTests
    {

        [TestMethod()]
        public void CreateComponentTest()
        {
            ConfigServer _server = new ConfigServer();
            var r = _server.CreateComponent(new Component()
            {
                ComponentID = 1001,
                ComponentName = "配置服务"
            });
            Assert.IsTrue(r.ActionResult);
            Assert.IsTrue(r.Data > 0);
        }

        [TestMethod()]
        public void CreateComponentConfigTest()
        {
            ConfigServerConfig csc = new ConfigServerConfig()
            {
                DalConfigs = new List<DataAccessConfiguration>()
            };
            csc.DalConfigs.Add(new DataAccessConfiguration()
            {
                ConnectionName = "SolutionConfiguration",
                DatabaseConnection = "Data Source=192.168.100.4;Initial Catalog=systembase;Persist Security Info=True;User ID=webuser;password=123456",
                DatabaseType = EnumDatabaseType.MySql,
                Multiple = false
            });
            csc.DalConfigs.Add(new DataAccessConfiguration()
            {
                ConnectionName = "ComponentConnection",
                DatabaseConnection = "Data Source=192.168.100.4;Initial Catalog=systembase;Persist Security Info=True;User ID=webuser;password=123456",
                DatabaseType = EnumDatabaseType.MySql,
                Multiple = false
            });
            csc.DalConfigs.Add(new DataAccessConfiguration()
            {
                ConnectionName = "ComponentConfiguration",
                DatabaseConnection = "Data Source=192.168.100.4;Initial Catalog=systembase;Persist Security Info=True;User ID=webuser;password=123456",
                DatabaseType = EnumDatabaseType.MySql,
                Multiple = false
            });
            ConfigServer _server = new ConfigServer();
            var r = _server.CreateComponentConfig(new ComponentConfiguration()
            {
                ComponentId = 1001,
                Content = XmlConfigSerializer.Instance.ToXml<ConfigServerConfig>(csc),
                Environment = 1,
                CreateBy = 1,
                IsActive = true,
                Enable = true,
                IsDebug = false,
                IsDelete = false,
                Signature = "无签名",
                Version = 1
            });
            Assert.IsTrue(r.ActionResult);
            Assert.IsTrue(r.Data > 0);
        }

        [TestMethod()]
        public void CreateSolutionTest()
        {
            ConfigServer _server = new ConfigServer();
            var r = _server.CreateSolution(new SolutionConfiguration()
            {
                Version = 1,
                Content = "",
                Environment = 1,
                Enable = true,
                IsActive = true,
                IsDelete = false,
                IsFile = true,
                CreateBy = 1,
                IsRemote = false,
                SolutionId = Guid.NewGuid(),
                SolutionName = "配置服务解决方案"
            });
            Assert.IsTrue(r.ActionResult);
            Assert.IsTrue(r.Data > 0);
        }

       
    }
}