using mds.DataAccess.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    public class MysqlService :  IDatabaseService
    {
        private DataAccessConfiguration _config;
        public MysqlService(DataAccessConfiguration config)
        {
            _config = config;
        }
        private List<MySqlParameter> ParseParameter(List<System.Data.Common.DbParameter> parameters)
        {
            var list = new List<MySqlParameter>();
            if (parameters == null) return list;
            parameters.ForEach(a => {
                list.Add(new MySqlParameter() { DbType = a.DbType, ParameterName = a.ParameterName, Value = a.Value });
            });
            return list;
        }
        public T GetDataByReader<T>(List<System.Data.Common.DbParameter> parameters, string cmdText, System.Data.CommandType cmdType, InitData<T> dataAction)
        {
            return MysqlDatabaseFactory.GetDataByReader<T>(_config.DatabaseConnection, ParseParameter(parameters), cmdText, cmdType, dataAction);
        }



        public List<T> GetListByReader<T>(List<System.Data.Common.DbParameter> parameters, string cmdText, System.Data.CommandType cmdType, InitList<T> dataAction)
        {
            return MysqlDatabaseFactory.GetListByReader<T>(_config.DatabaseConnection, ParseParameter(parameters), cmdText, cmdType, dataAction);
        }

        public int GetPrimarykey(List<System.Data.Common.DbParameter> parameters, string cmdText, System.Data.CommandType cmdType)
        {
            return MysqlDatabaseFactory.GetPrimarykey(_config.DatabaseConnection, ParseParameter(parameters), cmdText, cmdType);
        }

        public int ExecuteNonQuery(List<System.Data.Common.DbParameter> parameters, string cmdText, System.Data.CommandType cmdType)
        {
            return MysqlDatabaseFactory.ExecuteNonQuery(_config.DatabaseConnection, ParseParameter(parameters), cmdText, cmdType);
        }
    }
}
