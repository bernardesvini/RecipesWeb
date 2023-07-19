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
        public static int GetMaxInt(string columnName, string tableName)
        {
            //TODO; Cuidado com o select max porque vai retornar null se nao tiver registros.
            string sql = "SELECT max(" + columnName + ") AS MAX_ID FROM " + tableName + ";";
            SqlDataReader dataReader = Execute(sql);
            if (dataReader.Read())
            {
                return Convert.ToInt32(dataReader["MAX_ID"]);
            }
            return -1;
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
