using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
    static class ConnectionManager
    {
        public static SqlConnection SqlCN;

        static ConnectionManager()
        {
            SqlCN = new SqlConnection();
            SqlCN.ConnectionString = ConfigurationManager.ConnectionStrings["NorthEastCN"].ConnectionString;
        }

    }
}
