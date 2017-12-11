using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanAn
{
    public partial class SignUp : Form
    {
        string connectinonST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        SqlConnection connection;
        SqlCommand command;
        public SignUp()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string userName = tbDangNhap.Text;
            string passWord = tbPass.Text;
            connection = new SqlConnection(connectinonST);
            connection.Open();

            string query = "SELECT COUNT(*) FROM TAI_KHOAN WHERE UserName = '"+userName+"' and PassWord = '"+passWord+"'";
            command = new SqlCommand(query,connection);
            int x = (int)command.ExecuteScalar();

            if (x > 0) // đăng nhập thành công
            {
                string query2 = "SELECT LoaiTaiKhoan FROM TAI_KHOAN WHERE UserName = '" + userName + "' and PassWord = '" + passWord + "'";
                SqlCommand command2 = new SqlCommand(query2,connection);
                int x2 = (int)command2.ExecuteScalar();
                //phân loại tài khoản
                if(x2 == 3)
                {
                    GiaoDienChinh gd = new GiaoDienChinh();
                    this.Hide();
                    gd.Message1 = userName;
                    gd.ShowDialog();
                    this.Show();
                }
                else if (x2 == 2)
                {
                    HoatDongTongDai hdtd = new HoatDongTongDai();
                    this.Hide();
                    hdtd.Message21 = userName;
                    hdtd.ShowDialog();
                    this.Show();
                }
                else if(x2 == 1)
                {
                    BoPhanQuanLy bpql = new BoPhanQuanLy();
                    this.Hide();
                    bpql.Message31 = userName;
                    bpql.ShowDialog();
                    this.Show();
                }
                else if (x2 == 4)
                {
                    QuanLyNhanVien qlnv = new QuanLyNhanVien();
                    this.Hide();
                    qlnv.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu!", "Lỗi Đăng Nhập", MessageBoxButtons.OK);
            }
            connection.Close();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Thoát Chương Trình
        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu như người dùng chọn cancel -> câu lệnh thoát sẽ k đc thực thi
            if (MessageBox.Show("Bạn Có Thật Sự Muốn Thoát?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
