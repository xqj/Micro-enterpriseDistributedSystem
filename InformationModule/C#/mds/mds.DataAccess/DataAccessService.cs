using mds.DataAccess.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    public class DataAccessService
    {
        private DataAccessConfiguration _config;
        public DataAccessService(DataAccessConfiguration config) {
            config = _config;
        }
        public IDatabaseService CreateDataService() {
            switch (_config.DatabaseType)
            {
                case EnumDatabaseType.MySql:
                    return new MysqlService(_config);
                case EnumDatabaseType.SqlServer:
                    return new MSSqlService(_config);
                default:
                    return null;
            }
            
        }
    }
}
