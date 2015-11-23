using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    public delegate T InitData<T>(DbDataReader dataReader);
    public delegate void InitList<T>(DbDataReader dataReader, List<T> result);
    public interface IDatabaseService
    {
        T GetDataByReader<T>( List<DbParameter> parameters, string cmdText, CommandType cmdType, InitData<T> dataAction);
        List<T> GetListByReader<T>( List<DbParameter> parameters, string cmdText, CommandType cmdType, InitList<T> dataAction);
        int GetPrimarykey( List<DbParameter> parameters, string cmdText, CommandType cmdType);
        int ExecuteNonQuery( List<DbParameter> parameters, string cmdText, CommandType cmdType);
    }
}
