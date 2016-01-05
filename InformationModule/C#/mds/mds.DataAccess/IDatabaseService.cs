using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    public delegate T InitData<T>(DbDataReader dataReader);
    public delegate List<T> InitList<T>(DbDataReader dataReader);
    public interface IDatabaseService
    {
        T GetDataByReader<T>( List<DbParameter> parameters, string cmdText, InitData<T> dataAction, CommandType cmdType = CommandType.Text);
        List<T> GetListByReader<T>( List<DbParameter> parameters, string cmdText, InitList<T> dataAction, CommandType cmdType = CommandType.Text);
        int GetPrimarykey( List<DbParameter> parameters, string cmdText, CommandType cmdType= CommandType.Text);
        int ExecuteNonQuery( List<DbParameter> parameters, string cmdText, CommandType cmdType = CommandType.Text);
    }
}
