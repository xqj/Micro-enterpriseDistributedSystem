using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using mds.DataAccess.Config;

namespace mds.ServiceFactoryService.Model
{
    [DataContract]
    public class ServiceFactoryServerConfig
    {
        [DataMember]
        public List<DataAccessConfiguration> DalConfigs { set; get; }
    }
}
