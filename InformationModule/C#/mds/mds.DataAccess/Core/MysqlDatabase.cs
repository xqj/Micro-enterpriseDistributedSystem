using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    public class MysqlDatabaseFactory
    {
        protected  MySqlDataReader GetDataReader(string connectionString, List<MySqlParameter> parameters, string cmdText, CommandType cmdType)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            return cmd.ExecuteReader();
        }
        public delegate T initData<T>(MySqlDataReader dataReader);

        protected  T GetDataByReader<T>(string connectionString, List<MySqlParameter> parameters, string cmdText, CommandType cmdType, initData<T> dataAction)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
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
        public delegate void initList<T>(MySqlDataReader dataReader, List<T> result);

        protected  List<T> GetListByReader<T>(string connectionString, List<MySqlParameter> parameters, string cmdText, CommandType cmdType, initList<T> dataAction)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
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

        protected  int GetPrimarykey(string connectionString, MySqlParameter[] parameters, string cmdText, CommandType cmdType)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            cmd.CommandType = cmdType;
            con.Open();
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return r;
        }
        protected  int ExecuteNonQuery(string connectionString, List<MySqlParameter> parameters, string cmdText, CommandType cmdType)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
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