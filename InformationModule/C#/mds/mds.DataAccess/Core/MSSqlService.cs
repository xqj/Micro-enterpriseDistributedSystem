using mds.DataAccess.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    public class MSSqlService :  IDatabaseService
    {
        private DataAccessConfiguration _config;
        public MSSqlService(DataAccessConfiguration config)
        {
            _config = config;
        }
        private List<System.Data.SqlClient.SqlParameter> ParseParameter(List<System.Data.Common.DbParameter> parameters)
        {
            var list=new List<System.Data.SqlClient.SqlParameter>();
            if (parameters == null) return list;
            parameters.ForEach(a => {
                list.Add(new System.Data.SqlClient.SqlParameter() { DbType=a.DbType, ParameterName=a.ParameterName, Value=a.Value });
            });
            return list;
        }
        public T GetDataByReader<T>( List<System.Data.Common.DbParameter> parameters, string cmdText, InitData<T> dataAction, System.Data.CommandType cmdType= System.Data.CommandType.Text)
        {
            return MSSqlDatabaseFactory.GetDataByReader<T>(_config.DatabaseConnection, ParseParameter(parameters), cmdText, cmdType, dataAction);
        }

       

        public List<T> GetListByReader<T>( List<System.Data.Common.DbParameter> parameters, string cmdText, InitList<T> dataAction, System.Data.CommandType cmdType = System.Data.CommandType.Text)
        {
            return MSSqlDatabaseFactory.GetListByReader<T>(_config.DatabaseConnection, ParseParameter(parameters), cmdText, cmdType, dataAction);
        }

        public int GetPrimarykey( List<System.Data.Common.DbParameter> parameters, string cmdText, System.Data.CommandType cmdType = System.Data.CommandType.Text)
        {
            return MSSqlDatabaseFactory.GetPrimarykey(_config.DatabaseConnection,ParseParameter(parameters), cmdText, cmdType);
        }

        public int ExecuteNonQuery( List<System.Data.Common.DbParameter> parameters, string cmdText, System.Data.CommandType cmdType = System.Data.CommandType.Text)
        {
            return MSSqlDatabaseFactory.ExecuteNonQuery(_config.DatabaseConnection, ParseParameter(parameters), cmdText, cmdType);
        }
    }
}
