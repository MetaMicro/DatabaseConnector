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
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandText = sqlCommand;
                conn.Open();
                da.Fill(ds);
            }

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
            DataSet ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = conn.CreateCommand())
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandText = sqlCommand;
                conn.Open();
                da.Fill(ds);
            }

            return ds;
        }
    }
}