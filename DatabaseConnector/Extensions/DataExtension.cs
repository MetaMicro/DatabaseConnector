using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DatabaseConnector.Extensions
{
    /// <summary>
    /// Class used for methods regarding Data
    /// </summary>
    public class DataExtension
    {
        /// <summary>
        /// This method can connect with the database and retrieve the entire dataset.
        /// </summary>
        /// <param name="sqlCommand">The sql query to execute</param>
        /// <param name="connectionString"></param>
        /// <returns>A DataSet Object with all responses from the server</returns>
        public static DataSet GetDataSetSQL(string connectionString, string sqlCommand)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlCommand;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }

        /// <summary>
        /// This method can connect with the database and retrieve the entire dataset.
        /// </summary>
        /// <param name="sqlCommand">The sql query to execute</param>
        /// <param name="connectionString"></param>
        /// <returns>A DataSet Object with all responses from the server</returns>
        public static DataSet GetDataSetMySQL(string connectionString, string sqlCommand)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlCommand;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
    }
}