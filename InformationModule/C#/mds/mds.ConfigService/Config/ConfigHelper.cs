﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.BaseModel;
using mds.ConfigClient;
using mds.DataAccess.Config;
using mds.Util;

namespace mds.ConfigService.Config
{
   internal class ConfigHelper
    {
        private static ComponentConfiguration _compoentConfig;
        private static ConfigServiceClient _configService;
        private static ConfigServerConfig _config;
        static ConfigHelper()
        {
            _configService = ConfigClientFactory.Instance.GetConfigClient();
            _compoentConfig = _configService.GetComponentConfig(DefineTable.ComponentID);//不进行null检查保证配置初始化出现问题时爆出异常
            _config= XmlConfigSerializer.Instance.FromXml<ConfigServerConfig>(_compoentConfig.Content);//不进行null检查保证配置初始化出现问题时爆出异常
        }

        internal static DataAccessConfiguration GetDalConfig(object componentConnectionName)
        {
            throw new NotImplementedException();
        }

        public static ConfigServerConfig GetConfig()
        {
            return _config;
        }
        public static DataAccessConfiguration GetDalConfig(string connectionName)
        {
            var r= _config.DalConfigs.Find(c => c.ConnectionName == connectionName);
            if (r == null)
                throw new Exception("无法获取数据连接配置");
            return r;
        }
    }
}
