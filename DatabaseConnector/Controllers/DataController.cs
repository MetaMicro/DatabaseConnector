using DatabaseConnector.Extensions;
using DatabaseConnector.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace DatabaseConnector.Controllers
{
    /// <summary>
    /// This class can setup and execute sql query's on remote databases (or local ones)
    /// </summary>
    [RoutePrefix("api/Data")]
    public class DataController : ApiController
    {
        /// <summary>
        /// SQL Connector method, this method can execute the provided command and return its response
        /// </summary>
        /// <param name="model">Data receive model containing connection info and the sql command</param>
        /// <returns>Returns a DataResponseModel as a httpResponseMessage containing all the data in json format</returns>
        [HttpPost]
        [Route("Sql")]
        public HttpResponseMessage SqlConnector(DataReceiveModel model)
        {         
            SqlConnectionStringBuilder connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = model.DatabaseServer;
            connStringBuilder.InitialCatalog = model.DatabaseName;
            connStringBuilder.UserID = model.Username;
            connStringBuilder.IntegratedSecurity = false;
            connStringBuilder.Password = model.Password;

            try
            {
                DataSet CommandResult = DataExtension.GetDataSetSQL(connStringBuilder.ConnectionString, model.SQL_Query);

                //because the default DataSet doesnt convert the result tables into a list we have to do this by hand
                DataResponseModel responseObject = new DataResponseModel { Message = "Data successfully retrieved" };
                foreach (DataTable table in CommandResult.Tables)
                    responseObject.Tables.Add(table.TableName, table);

                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK);
                res.Content = new StringContent(JsonConvert.SerializeObject(responseObject), Encoding.UTF8, "text/json");
                return res;
            }
            catch(Exception e)
            {           
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.InternalServerError);
                res.Content = new StringContent(e.Message, Encoding.UTF8, "text/json");
                return res;
            }
        }

        /// <summary>
        /// MySQL Connector method, this method can execute the provided command and return its response
        /// </summary>
        /// <param name="model">Data receive model containing connection info and the sql command</param>
        /// <returns>Returns a DataResponseModel as a httpResponseMessage containing all the data in json format</returns>
        [HttpPost]
        [Route("MySql")]
        public HttpResponseMessage MySqlConnector(DataReceiveModel model)
        {
            MySqlConnectionStringBuilder connStringBuilder = new MySqlConnectionStringBuilder();
            connStringBuilder.Server = model.DatabaseServer;
            connStringBuilder.Database = model.DatabaseName;
            connStringBuilder.UserID = model.Username;
            connStringBuilder.IntegratedSecurity = false;
            connStringBuilder.Password = model.Password;

            try
            {
                DataSet CommandResult = DataExtension.GetDataSetMySQL(connStringBuilder.ConnectionString, model.SQL_Query);

                //because the default DataSet doesnt convert the result tables into a list we have to do this by hand
                DataResponseModel responseObject = new DataResponseModel { Message = "Data successfully retrieved" };
                foreach (DataTable table in CommandResult.Tables)
                    responseObject.Tables.Add(table.TableName, table);

                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK);
                res.Content = new StringContent(JsonConvert.SerializeObject(responseObject), Encoding.UTF8, "text/json");
                return res;
            }
            catch (Exception e)
            {
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.InternalServerError);
                res.Content = new StringContent(e.Message, Encoding.UTF8, "text/json");
                return res;
            }
        }
    }
}
