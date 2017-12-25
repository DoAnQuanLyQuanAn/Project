using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DBManagerBase
    {
        private string connectionString = @"Data Source=DESKTOP-87FU5ES;Initial Catalog=QuanLyQuanAn;Integrated Security=True;MultipleActiveResultSets=True";
        private SqlConnection connection;

        public SqlConnection Connection { get => connection; set => connection = value; }

        public void Open()
        {
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(connectionString);
                }
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
                Connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
