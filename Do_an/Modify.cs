using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient; 

namespace Do_an
{
    internal class Modify
    {
        public Modify() { }

        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public List<TaiKhoan> TaiKhoans(string query)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();

            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return taiKhoans; 
        }
        public void Command(string query)
        {
            using (SqlConnection sqlConn = Connection.GetSqlConnection())
            {
                sqlConn.Open();
                sqlCommand = new SqlCommand(query, sqlConn);
                sqlCommand.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
    }
}
