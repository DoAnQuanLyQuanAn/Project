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
    public partial class QuanLyNhanVien : Form
    {
        string connectionST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cbBoPhan.Items.Add("Bộ Phận Quản Lý");
            cbBoPhan.Items.Add("Bộ Phận Tổng Đài");
            cbBoPhan.Items.Add("Bộ Phận Bán Hàng");
            cbBoPhan.Items.Add("Quản Lý Nhân Viên");

            DataTable tb = new DataTable();
            tb = ThemNhanVien();
            dataTaiKhoan.DataSource = tb;
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionST);
            connection.Open();
            if (cbBoPhan.SelectedItem == "Bộ Phận Quản Lý")
            {
                string query = "insert into TAI_KHOAN(UserName,PassWord,TenHienThi,LoaiTaiKhoan) values('" + tbUser.Text + "','" + tbNhapLai.Text + "','" + tbHoTen.Text + "',1)";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Đã Đăng Ký Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            }
            else if (cbBoPhan.SelectedItem == "Bộ Phận Tổng Đài")
            {
                string query = "insert into TAI_KHOAN(UserName,PassWord,TenHienThi,LoaiTaiKhoan) values('" + tbUser.Text + "','" + tbNhapLai.Text + "','" + tbHoTen.Text + "',2)";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Đã Đăng Ký Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            }
            else if (cbBoPhan.SelectedItem == "Bộ Phận Bán Hàng")
            {
                string query = "insert into TAI_KHOAN(UserName,PassWord,TenHienThi,LoaiTaiKhoan) values('" + tbUser.Text + "','" + tbNhapLai.Text + "','" + tbHoTen.Text + "',3)";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Đã Đăng Ký Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                string query = "insert into TAI_KHOAN(UserName,PassWord,TenHienThi,LoaiTaiKhoan) values('" + tbUser.Text + "','" + tbNhapLai.Text + "','" + tbHoTen.Text + "',4)";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Đã Đăng Ký Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            }
            connection.Close();

            SqlConnection connection2 = new SqlConnection(connectionST);
            connection2.Open();
            string query2 = "exec ThemNhanVien N'"+tbHoTen.Text+"','"+tbCMND.Text+"',N'"+tbQueQuan.Text+"','"+tbNgaySinh.Text+"'";
            SqlCommand command2 = new SqlCommand(query2,connection2);
            command2.ExecuteNonQuery();

            connection2.Close();
            tbCMND.Clear();
            tbHoTen.Clear();
            tbNgaySinh.Clear();
            tbNhapLai.Clear();
            tbPass.Clear();
            tbQueQuan.Clear();
            tbUser.Clear();

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int RowIndex = dataTaiKhoan.CurrentRow.Index;
            dataTaiKhoan.Rows.RemoveAt(RowIndex);
        }

        private DataTable ThemNhanVien()
        {
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TK.UserName,TK.PassWord,TK.TenHienThi,TK.LoaiTaiKhoan,NV.Ten,NV.CMND,NV.QueQuan,NV.NgaySinh FROM NhanVien NV, TAI_KHOAN TK WHERE NV.IDTaiKhoan = TK.ID");
            dataTaiKhoan.DataSource = tb;
            return tb;
        }

    }
}
