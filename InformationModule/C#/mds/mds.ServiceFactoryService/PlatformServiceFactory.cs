using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ServiceFactoryService
{
    internal class PlatformServiceFactory
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
        /// <summary>
        /// 获取服务，获取不到创建服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appUserID"></param>
        /// <param name="compentFullServiceName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 只获取不创建服务实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appUserID"></param>
        /// <returns></returns>
        public T GetService<T>(int appUserID)
        {
            Type interfaceType = typeof(T);
            var interfaceName = interfaceType.ToString();
            var serviceKey = string.Format("{0}_{1}", interfaceName, appUserID.ToString());
            T service = default(T);
            if (_servicecontainer.ContainsKey(serviceKey))
            {
                service= (T)_servicecontainer[serviceKey];
            }
            return service;
        }
        /// <summary>
        /// 获取服务，获取不到创建服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="compentFullServiceName"></param>
        /// <returns></returns>
        public T GetService<T>(string compentFullServiceName)
        {
            if (!string.IsNullOrEmpty(compentFullServiceName))
            {
                Type classObject = Type.GetType(compentFullServiceName, true);
                return (T)Activator.CreateInstance(classObject);
            }
            return default(T);
        }
    }
}
