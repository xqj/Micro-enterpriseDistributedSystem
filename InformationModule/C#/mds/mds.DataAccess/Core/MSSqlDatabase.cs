using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    internal class MSSqlDatabaseFactory
    {
        protected  SqlDataReader GetDataReader(string connectionString, List<SqlParameter> parameters, string cmdText, CommandType cmdType)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            return cmd.ExecuteReader();
        }
        public delegate T initData<T>(SqlDataReader dataReader);

        protected  T GetDataByReader<T>(string connectionString, List<SqlParameter> parameters, string cmdText, CommandType cmdType, initData<T> dataAction)
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
        public delegate void initList<T>(SqlDataReader dataReader, List<T> result);

        protected  List<T> GetListByReader<T>(string connectionString, List<SqlParameter> parameters, string cmdText, CommandType cmdType, initList<T> dataAction)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            var dataReader = cmd.ExecuteReader();
            List<T> data = new List<T>();
            dataAction(dataReader, data);
            dataReader.Close();
            con.Close();
            return data;
        }

        protected  int GetPrimarykey(string connectionString, SqlParameter[] parameters, string cmdText, CommandType cmdType)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            cmd.CommandType = cmdType;
            con.Open();
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return r;
        }
        protected  int ExecuteNonQuery(string connectionString, List<SqlParameter> parameters, string cmdText, CommandType cmdType)
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