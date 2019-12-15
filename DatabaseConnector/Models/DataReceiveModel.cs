using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseConnector.Models
{
    public class DataReceiveModel
    {
        public string DatabaseServer { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SQL_Query { get; set; }
    }
}