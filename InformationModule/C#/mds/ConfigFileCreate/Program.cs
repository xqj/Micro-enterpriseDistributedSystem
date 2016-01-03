using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.BaseModel;
using mds.DataAccess.Config;
using mds.Util;

namespace ConfigFileCreate
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Github\Micro-enterpriseDistributedSystem\InformationModule\C#\mds\UnitTest\Config";
            SolutionConfiguration sc = new SolutionConfiguration()
            {
                Components = new List<ComponentConfiguration>(),
                Content = "",
                Enable = true,
                Environment = 0,
                ID = 1,
                IsFile = true,
                IsRemote = false,
                SolutionId = Guid.NewGuid(),
                SolutionName = "方案名称",
                Version = 1
            };
            ConfigServerConfig csc = new ConfigServerConfig() {
                DalConfigs = new List<DataAccessConfiguration>()
            };
            csc.DalConfigs.Add(new DataAccessConfiguration() {
                 ConnectionName="systembase",
                  DatabaseConnection= "Data Source=192.168.100.4;Initial Catalog=socialsite;Persist Security Info=True;User ID=dbuss;password=123456",
                   DatabaseType=EnumDatabaseType.MySql,
                    Multiple=false
            });
            sc.Components.Add(new ComponentConfiguration() {
                 Version=1,
                  Status=1,
                   ComponentConfigId=1,
                    ComponentId=1001,
                     Content= XmlConfigSerializer.Instance.ToXml<ConfigServerConfig>(csc),
                      Enable=true,
                       Environment=1,
                        IsDebug=false,
                         Signature="软件签名"
            });
            XmlConfigSerializer.Instance.Serializer(path + "\\RemoteConfig.xml",sc);
        }
    }
}
