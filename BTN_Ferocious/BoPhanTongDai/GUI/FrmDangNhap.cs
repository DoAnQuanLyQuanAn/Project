using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using System.Data.SqlClient;
using System.Data;

namespace BoPhanTongDai.GUI
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DBManager db = new DBManager();
            db.Open();

            string ten = this.tbTenDangNhap.Text.ToString();
            string pass = this.tbMatKhau.Text.ToString();

            string sqlDangNhap = "SELECT* FROM TAI_KHOAN WHERE UserName = @ten AND PassWord = @pass";
            SqlDataReader reader =  db.GetReader(CommandType.Text, sqlDangNhap, new SqlParameter { ParameterName = "@ten", Value = ten },
                new SqlParameter { ParameterName="@pass", Value = pass});
            int n = 0;
            while (reader.Read())
            {
                n++;
            }
            if(n > 0)
            {
                this.Hide();
                FrmTongDai frmTongDai = new FrmTongDai();
                frmTongDai.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoạc mật khẩu không đúng");
            }
            reader.Close();

            db.Close();
        }
    }
}
