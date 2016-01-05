using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigClient
{
   public class ConfigClientFactory
    {
        private static ConfigClientFactory _instance = new ConfigClientFactory();

        public static ConfigClientFactory Instance
        {
            get
            {
                return _instance;
            }

        }        
        private ConfigClientFactory() {
            _gobalConfigClient = null;
        }
        private ConfigServiceClient _gobalConfigClient;
        public ConfigServiceClient GetConfigClient()
        {
            if (_gobalConfigClient == null)
            {
                _gobalConfigClient = new ConfigServiceClient();
                _gobalConfigClient.RunInAppStartInit();
            }
            return _gobalConfigClient;
        }
    }
}
