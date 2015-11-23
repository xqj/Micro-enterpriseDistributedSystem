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
        private IDatabaseService _service;
        public DataAccessService(DataAccessConfiguration config) {
            config = _config;
        }
        /// <summary>
        /// 创建数据服务对象，非单例
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 创建单例对象
        /// </summary>
        /// <returns></returns>
        public IDatabaseService CreateIntance()
        {
            if (_service == null) _service = CreateDataService();
            return _service;
        }
    }
}
