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
    public partial class HoatDongTongDai : Form
    {
        string connectinonST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";

        public HoatDongTongDai()
        {
            InitializeComponent();
        }

        private string Message2;

        public string Message21
        {
            get { return Message2; }
            set { Message2 = value; }
        }
        

        private void HoatDongTongDai_Load(object sender, EventArgs e)
        {
            lbname2.Text = Message2;
            //Đưa Dữ liệu vào cbMonAn
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn From MONAN");
            cbMonAn.DisplayMember = "TenMonAn";
            cbMonAn.ValueMember = "ID";
            cbMonAn.DataSource = tb;
            //Đưa dữ liệu vào cbChonChiNhanh
            DataTable tb2 = new DataTable();
            tb2 = LoadDuLieu.docDuLieu("SELECT TenCN From CHI_NHANH");
            cbChonChiNhanh.DisplayMember = "TenCN";
            cbChonChiNhanh.ValueMember = "ID";
            cbChonChiNhanh.DataSource = tb2;
            //Đưa dữ liệu vào cbChiNhanh2
            DataTable tb3 = new DataTable();
            tb3 = LoadDuLieu.docDuLieu("SELECT TenCN From CHI_NHANH");
            cbChiNhanh2.DisplayMember = "TenCN";
            cbChiNhanh2.ValueMember = "ID";
            cbChiNhanh2.DataSource = tb3;
            //Đưa dữ liệu vào dataDonHang
            DataTable tb4 = new DataTable();
            tb4 = ThemDonHang();
            dataDonHang.DataSource = tb4;
            //Đưa dữ liệu vào dataLuu
            DataTable tb5 = new DataTable();
            tb5 = LuuKH();
            dataLuu.DataSource = tb5;
        }
        
        private void btGui_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectinonST);
            connection.Open();

            string query = "exec Gui1 N'"+cbMonAn.Text+"', '"+tbSL.Text+"'";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Đã Gửi Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            connection.Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int RowIndex = dataDonHang.CurrentRow.Index;
            dataDonHang.Rows.RemoveAt(RowIndex);
        }

        private void btGui2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Hiện Chưa Có!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            int RowIndex = dataDonHangWeb.CurrentRow.Index;
            dataDonHangWeb.Rows.RemoveAt(RowIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Hiện Chưa Có!", "Thông Báo", MessageBoxButtons.OK);
        }

        

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectinonST);
            connection.Open();
            string query = "exec TaoDonHang_TongDai '" + cbMonAn.Text + "', '" + tbSL.Text + "', '" + tbDiaChi.Text + "', '" + cbChonChiNhanh.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            connection.Close();
            //Đưa dũ liệu vào dataDonHang
            ThemDonHang();
            tbSL.Clear();
            tbDiaChi.Clear();
        }
        private DataTable ThemDonHang()
        {
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn, SoLuong, DiaChi From DONHANG_TONGDAI");
            dataDonHang.DataSource = tb;
            return tb;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectinonST);
            connection.Open();
            string query = "exec LuuKH '" + tbTenKhachHang.Text + "', '" + tbSDT.Text + "', '" + tbDC.Text + "', '" + tbMuaHang.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            connection.Close();
            LuuKH();
            tbTenKhachHang.Clear();
            tbSDT.Clear();
            tbDC.Clear();
            tbMuaHang.Clear();
        }
        private DataTable LuuKH()
        {
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenKH, SDT, DiaChi, SoLanMuaHang From KHACHHANG");
            dataLuu.DataSource = tb;
            return tb;
        }


    }
}