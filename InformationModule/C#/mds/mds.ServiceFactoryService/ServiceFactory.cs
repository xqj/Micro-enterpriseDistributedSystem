using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mds.ServiceFactoryService;
using mds.ServiceFactoryService.Config;
using mds.ServiceFactoryService.Model;

namespace mds.ConfigClient
{
   public class ServiceFactory
    {
        private static ServiceFactory _intance = new ServiceFactory();

        public static ServiceFactory Intance
        {
            get
            {
                return _intance;
            }
        }
        private Dictionary<int, Dictionary<string,SolutionServiceFactory>> _serviceData;
        private ServiceFactory()
        {
            _serviceData = new Dictionary<int, Dictionary<string, SolutionServiceFactory>>();
        }
        public T CreateService<T>(Guid solutionID,int appUserID)
        {
            T tobj = default(T);
            tobj = PlatformServiceFactory.Instance.GetService<T>(appUserID);
            if (!tobj.Equals(default(T))) return tobj;
            if (!_serviceData.ContainsKey(appUserID))            
            {
                var tr = FactoryServer.Intance.GetServices(solutionID, appUserID);
                if (tr.ActionResult)
                {
                    _serviceData.Add(appUserID, tr.Data.ToDictionary(a => a.InterfaceName, a=>a));
                }
            }
            var key = typeof(T).FullName;
           
            if (_serviceData[appUserID].ContainsKey(key))
            {
                var serviceData = _serviceData[appUserID][key];
                tobj = PlatformServiceFactory.Instance.GetService<T>(appUserID,string.Format(DefineTable.AssemblyServiceTmpl,serviceData.CompentServiceName,serviceData.CompentAssemblyName,serviceData.AssemblyVersion));
            }
            return tobj;
        }
    }
}
