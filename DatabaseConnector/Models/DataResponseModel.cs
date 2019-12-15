using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DatabaseConnector.Models
{
    public class DataResponseModel
    {
        public Dictionary<string, DataTable> Tables { get; set; }
        public string Message { get; set; }

        public DataResponseModel()
        {
            Tables = new Dictionary<string, DataTable>();
        }
    }
}