using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st
{
    class Database
    {
        public static SqlConnection ConnectDb()
        {
            string connectionString = @"Data Source=AVRAAM-LAPTOP\SQLEXPRESS;Initial Catalog=AssignmentBC9db;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }
}
