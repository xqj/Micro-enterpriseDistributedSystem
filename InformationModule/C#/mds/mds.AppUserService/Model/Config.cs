using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using mds.DataAccess.Config;

namespace mds.AppUserService.Model
{
    [DataContract]
    public class AppUserServerConfig
    {
        [DataMember]
        public List<DataAccessConfiguration> DalConfigs { set; get; }
    }
}
