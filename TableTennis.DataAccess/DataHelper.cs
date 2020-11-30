using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TableTennis.DataAccess.CommonModel;

namespace TableTennis.DataAccess
{
    public class DataHelper
    {
        private static SqlCommand GetCommand(string query, List<SqlCommandParameter> sqlCommandParameterList, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = con;
            if (sqlCommandParameterList != null)
            {
                if (sqlCommandParameterList.Count > 0)
                {
                    foreach (var item in sqlCommandParameterList)
                    {
                        cmd.Parameters.AddWithValue(item.ParameterName, item.ParameterValue);
                    }
                }
            }
            return cmd;
        }
        private static SqlCommand GetCommandWithOutputParameter(string query, List<SqlCommandParameter> sqlCommandParameterList, List<SqlCommandOutputParameter> sqlCommandOutputParameterList, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = con;
            if (sqlCommandParameterList != null)
            {
                if (sqlCommandParameterList.Count > 0)
                {
                    foreach (var item in sqlCommandParameterList)
                    {
                        cmd.Parameters.AddWithValue(item.ParameterName, item.ParameterValue);
                    }
                }
            }
            if (sqlCommandOutputParameterList != null)
            {
                if (sqlCommandOutputParameterList.Count > 0)
                {
                    foreach (var item in sqlCommandOutputParameterList)
                    {
                        if (item.SqlDbType == SqlDbType.VarChar || item.SqlDbType == SqlDbType.NVarChar)
                        {
                            cmd.Parameters.Add(item.ParameterName, item.SqlDbType, item.Size).Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            cmd.Parameters.Add(item.ParameterName, item.SqlDbType).Direction = ParameterDirection.Output;
                        }
                    }
                }
            }

            return cmd;
        }

        public static int ExecuteNonQuery(string query, List<SqlCommandParameter> sqlCommandParameterList, string connectionString)
        {
            var cmd = GetCommand(query, sqlCommandParameterList, connectionString);
            int NoOfRowsEffected = -1;
            NoOfRowsEffected = cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd.Connection.Close();
            return NoOfRowsEffected;
        }
        public static object ExecuteScalar(string query, List<SqlCommandParameter> sqlCommandParameterList, string connectionString)
        {
            var cmd = GetCommand(query, sqlCommandParameterList, connectionString);
            object value = -1;
            value = cmd.ExecuteScalar();
            cmd.Dispose();
            cmd.Connection.Close();
            return value;
        }
        public static DataTable DataTable(string query, string connectionString)
        {
            var cmd = GetCommand(query, null, connectionString);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            cmd.Dispose();
            cmd.Connection.Close();
            return dt;
        }
        //public static SqlDataReader ExecuteReader(string query, string connectionString)
        //{
        //    var cmd = GetCommand(query, null, connectionString);
        //    SqlDataReader rdr;
        //    rdr = cmd.ExecuteReader();
        //    cmd.Dispose();
        //    cmd.Connection.Close();
        //    return rdr;
        //}
        public static DataTable ExecuteStoredProcedureReader(string spName, List<SqlCommandParameter> sqlCommandParameterList, string connectionString)
        {
            var cmd = GetCommand(spName, sqlCommandParameterList, connectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            cmd.Dispose();
            cmd.Connection.Close();
            return dt;

        }
        public static int ExecuteStoredProcedureNonQuery(string query, List<SqlCommandParameter> sqlCommandParameterList, string connectionString)
        {
            var cmd = GetCommand(query, sqlCommandParameterList, connectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            int NoOfRowsEffected = -1;
            NoOfRowsEffected = cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd.Connection.Close();
            return NoOfRowsEffected;
        }
        public static object ExecuteStoredProcedureScalar(string query, List<SqlCommandParameter> sqlCommandParameterList, string connectionString)
        {
            var cmd = GetCommand(query, sqlCommandParameterList, connectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            object value = -1;
            value = cmd.ExecuteScalar();
            cmd.Dispose();
            cmd.Connection.Close();
            return value;
        }
        public static SqlCommand ExecuteStoredProcedureNonQueryWithOutputParameter(string query, List<SqlCommandParameter> sqlCommandParameterList, List<SqlCommandOutputParameter> sqlCommandOutputParameterList, string connectionString)
        {
            var cmd = GetCommandWithOutputParameter(query, sqlCommandParameterList, sqlCommandOutputParameterList, connectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return cmd;
        }
        public static SqlDataAdapter DataAdapter(string query, List<SqlCommandParameter> sqlCommandParameterList, string connectionString)
        {
            var cmd = GetCommand(query, sqlCommandParameterList, connectionString);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Dispose();
            cmd.Connection.Close();
            return da;
        }
    }
}
