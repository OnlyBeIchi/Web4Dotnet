using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web4dotnet.Models
{
    public class DBConnection
    {
        string strCon;

        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["QuanlyLuatConnectionString"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}