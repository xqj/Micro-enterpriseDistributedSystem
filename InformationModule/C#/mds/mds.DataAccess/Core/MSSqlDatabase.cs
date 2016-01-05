using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
   
    internal   class MSSqlDatabaseFactory
    {
        internal static T GetDataByReader<T>(string connectionString, List<SqlParameter> parameters, string cmdText, CommandType cmdType, InitData<T> dataAction)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            var dataReader = cmd.ExecuteReader();
            T data = dataAction(dataReader);
            dataReader.Close();
            con.Close();
            return data;
        }


        internal static List<T> GetListByReader<T>(string connectionString, List<SqlParameter> parameters, string cmdText, CommandType cmdType, InitList<T> dataAction)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            var dataReader = cmd.ExecuteReader();
            List<T> data =dataAction(dataReader);
            dataReader.Close();
            con.Close();
            return data;
        }

        internal static int GetPrimarykey(string connectionString, List<SqlParameter> parameters, string cmdText, CommandType cmdType)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return r;
        }
        internal static int ExecuteNonQuery(string connectionString, List<SqlParameter> parameters, string cmdText, CommandType cmdType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            int r = cmd.ExecuteNonQuery();
            con.Close();
            return r;
        }
    }
}