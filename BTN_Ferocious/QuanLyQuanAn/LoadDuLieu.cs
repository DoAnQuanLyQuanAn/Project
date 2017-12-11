using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyQuanAn
{
    class LoadDuLieu
    {
        public static DataTable docDuLieu(string query)
        {
            string connectionST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
            SqlConnection connection;
            connection = new SqlConnection(connectionST);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable tb = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tb);
            connection.Close();
            return tb;
        }
    }
}
