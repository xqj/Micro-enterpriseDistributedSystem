using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{

    internal  class MysqlDatabaseFactory
    {
        internal static T GetDataByReader<T>(string connectionString, List<MySqlParameter> parameters, string cmdText, CommandType cmdType, InitData<T> dataAction)
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


        internal static List<T> GetListByReader<T>(string connectionString, List<MySqlParameter> parameters, string cmdText, CommandType cmdType, InitList<T> dataAction)
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

        internal static int GetPrimarykey(string connectionString, List<MySqlParameter> parameters, string cmdText, CommandType cmdType)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            int r = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return r;
        }
        internal static int ExecuteNonQuery(string connectionString, List<MySqlParameter> parameters, string cmdText, CommandType cmdType)
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