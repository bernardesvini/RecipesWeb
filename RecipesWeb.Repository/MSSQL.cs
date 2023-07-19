using System;
using System.Data.SqlClient;

namespace RecipesWeb.Repository
{
    public static class MSSQL
    {
        private static readonly string _connectionString = @"Server=VINICIUS\SQLEXPRESS01;Database=RecipesSystem;Trusted_Connection=True;";
        private static readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        private static bool _isClosed = true;

        public static SqlDataReader Execute(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteReader();
        }

        public static int ExecuteNonQuery(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }


        private static void HangUpCall()
        {
            if (_isClosed)
            {
                _sqlConnection.Open();
                _isClosed = !_isClosed;
            }
            else
            {
                _sqlConnection.Close();
                _sqlConnection.Open();
            }
        }
    }
}
