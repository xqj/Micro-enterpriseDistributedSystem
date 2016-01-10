using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using mds.DataAccess.Config;

namespace mds.SecurityService.Model
{
    [DataContract]
    public class SecurityServerConfig
    {
        [DataMember]
        public List<DataAccessConfiguration> DalConfigs { set; get; }
    }
}
