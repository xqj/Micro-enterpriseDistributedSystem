using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using mds.DataAccess.Config;
namespace mds.ConfigService.Model
{
    [DataContract]
    public class ConfigServerConfig
    {
        [DataMember]
        public List<DataAccessConfiguration> DalConfigs { set; get; }
    }

}