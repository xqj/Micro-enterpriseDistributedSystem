using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ServiceFactoryService
{
    public class PlatformServiceFactory
    {
        private static Dictionary<string, Object> _servicecontainer;
        private static PlatformServiceFactory _instance = new PlatformServiceFactory();
        public static PlatformServiceFactory Instance
        {
            get
            {
                return _instance;
            }
        }
        private PlatformServiceFactory()
        {
            _servicecontainer = new Dictionary<string, object>();
        }
        public T GetService<T>(int appUserID, string compentFullServiceName)
        {
            Type interfaceType = typeof(T);
            var interfaceName = interfaceType.ToString();
            var serviceKey = string.Format("{0}_{1}", interfaceName, appUserID.ToString());
            if (!_servicecontainer.ContainsKey(serviceKey))
            {
                if (!string.IsNullOrEmpty(compentFullServiceName))
                {
                    Type classObject = Type.GetType(compentFullServiceName, true);
                    var serviceClass = Activator.CreateInstance(classObject);
                    _servicecontainer.Add(serviceKey, serviceClass);
                }
            }
            return (T)_servicecontainer[serviceKey];
        }
        public T GetService<T>(string compentFullServiceName)
        {
            Type interfaceType = typeof(T);
            var interfaceName = interfaceType.ToString();
            if (!string.IsNullOrEmpty(compentFullServiceName))
            {
                Type classObject = Type.GetType(compentFullServiceName, true);
                return (T)Activator.CreateInstance(classObject);
            }
            return default(T);
        }
    }
}
