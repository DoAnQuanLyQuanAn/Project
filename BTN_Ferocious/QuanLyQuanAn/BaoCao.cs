using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyQuanAn
{
    public partial class BaoCao : Form
    {
        SqlConnection conn;
        public BaoCao()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string tem = @"OMEGA\THETASERVER";
            conn = new SqlConnection(@"Data Source="+tem+";Initial Catalog=QuanLyQuanAn;Integrated Security=True");
            conn.Open();
            string ngay1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string ngay2 = dateTimePicker2.Value.ToString("yyyy/MM/dd");
            SqlCommand cmd = new SqlCommand("usp_DoanhThu", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ngay1", SqlDbType.DateTime).Value = ngay1;
            cmd.Parameters.Add("@ngay2", SqlDbType.DateTime).Value = ngay2;
            cmd.Parameters.Add(new SqlParameter("@kq", SqlDbType.Float));
            cmd.Parameters["@kq"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string KQ = cmd.Parameters["@kq"].Value.ToString();
            conn.Close();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyQuanAnDataSet.ThanhToan' table. You can move, or remove it, as needed.
            this.ThanhToanTableAdapter.Fill(this.QuanLyQuanAnDataSet.ThanhToan);


            this.reportViewer1.RefreshReport();
        }
    }
}
