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
    public partial class GiaoDienChinh : Form
    {
        string connectinonST = @"Data Source=.;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        //string connectinonST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";

        //Lấy tên người đăng nhập
        private string Message;
        public string Message1
        {
          get { return Message; }
          set { Message = value; }
        }
        public GiaoDienChinh()
        {
            InitializeComponent();
        }
        DataTable tb2 = new DataTable();
        DataView view;
        DataView viewTimKiem;
        public int x = 1;
        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            TenHienThi.Text = Message;
            //Đưa dữ liệu vào dataDSThucDon
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn, DonGia FROM MONAN");
            viewTimKiem = new DataView(tb);
            dataDSThucDon.DataSource = viewTimKiem;

            DataTable tb1 = new DataTable();
            tb1 = LoadDuLieu.docDuLieu("select tenMon,donGia,soLuong from HOADON where idBan=" + x.ToString());
            tb1.Columns[0].ColumnName = "Tên Món";
            tb1.Columns[1].ColumnName = "Đơn Giá";
            tb1.Columns[2].ColumnName = "Số Lượng";
            dataThongTinHoaDon.DataSource = tb1;
            /*tb2 = XuatHoaDon();
            view = new DataView(tb2);
            dataThongTinHoaDon.DataSource = view;
            binding();
            binding2();*/
        }

        //hàm tính tổng thu khi đã giảm giá

        private void btInXuongBep_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã gửi xuống bếp!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectinonST);
            connection.Open();

        }

        private void btNhanHoaDon_Click(object sender, EventArgs e)
        {
            
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn, DonGia, SoLuong, DiaChi FROM DONHANG_TONGDAI");
            view = new DataView(tb);
            dataThongTinHoaDon.DataSource = view;
        }

        //lay du lieu tu dataTable vao textbox
        /*public void binding()
        {
            tbDichVu.DataBindings.Clear();
            tbDichVu.DataBindings.Add("text", dataDSThucDon.DataSource, "TenMonAn");
            tbDonGia.DataBindings.Clear();
            tbDonGia.DataBindings.Add("text", dataDSThucDon.DataSource, "DonGia");
        }
        public void binding2()
        {
            DataGridView tien = new DataGridView();
            tien.DataSource = tinhtong();
            tbTongGia.DataBindings.Clear();
            tbTongGia.DataBindings.Add("text", tien.DataSource, "tien");
            
        }*/

        double tt;
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn, DonGia FROM MONAN WHERE TenMonAn like N'" + tbTimKiem.Text + "%'");
            viewTimKiem = new DataView(tb);
            dataDSThucDon.DataSource = viewTimKiem;
        }
        void loadHoaDon()
        {
            DataTable tb1 = new DataTable();
            tb1 = LoadDuLieu.docDuLieu("select tenMon,donGia,soLuong from HOADON where idBan=" + x.ToString());
            tb1.Columns[0].ColumnName = "Tên Món";
            tb1.Columns[1].ColumnName = "Đơn Giá";
            tb1.Columns[2].ColumnName = "Số Lượng";
            dataThongTinHoaDon.DataSource = tb1;
            int n=dataThongTinHoaDon.RowCount;
            if (n == 0) tbTongGia.Text = "0";
            else
            {
                tt = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    tt = tt + double.Parse(dataThongTinHoaDon.Rows[i].Cells[1].Value.ToString()) * int.Parse(dataThongTinHoaDon.Rows[i].Cells[2].Value.ToString());
                }
                tt = tt - tt * double.Parse(comboBox1.Text) / 100;
                Math.Round(tt);
                
                tbTongGia.Text = tt.ToString("#,###");
            }
            
        }
        private void btBan1_Click(object sender, EventArgs e)
        {
            x = 1;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan2_Click(object sender, EventArgs e)
        {
            x = 2;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();

        }

        private void btBan3_Click(object sender, EventArgs e)
        {
            x = 3;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan4_Click(object sender, EventArgs e)
        {
            x = 4;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan5_Click(object sender, EventArgs e)
        {
            x = 5;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan6_Click(object sender, EventArgs e)
        {
            x = 6;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan7_Click(object sender, EventArgs e)
        {
            x = 7;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan8_Click(object sender, EventArgs e)
        {
            x = 8;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan9_Click(object sender, EventArgs e)
        {
            x = 9;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }
        private void btBan10_Click_1(object sender, EventArgs e)
        {
            x = 10;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }
        private void btBan11_Click(object sender, EventArgs e)
        {
            x = 11;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan12_Click(object sender, EventArgs e)
        {
            x = 12;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan13_Click(object sender, EventArgs e)
        {
           x = 13;
           label4.Text = "BÀN " + x.ToString();
           loadHoaDon();
        }

        private void btBan14_Click(object sender, EventArgs e)
        {
            x = 14;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }

        private void btBan15_Click(object sender, EventArgs e)
        {
            x = 15;
            label4.Text = "BÀN " + x.ToString();
            loadHoaDon();
        }


        private void btMoBan_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(connectinonST);
            a.Open();
            SqlCommand cmd = new SqlCommand("update BAN_AN set TinhTrang=N'Đang mở' where ID=" + x.ToString(), a);
            cmd.ExecuteNonQuery();
            switch (x)
            {
                case 1:
                    btBan1.BackColor = Color.Blue;
                    break;
                case 2:
                    btBan2.BackColor = Color.Blue;
                    break;
                case 3:
                    btBan3.BackColor = Color.Blue;
                    break;
                case 4:
                    btBan4.BackColor = Color.Blue;
                    break;
                case 5:
                    btBan5.BackColor = Color.Blue;
                    break;
                case 6:
                    btBan6.BackColor = Color.Blue;
                    break;
                case 7:
                    btBan7.BackColor = Color.Blue;
                    break;
                case 8:
                    btBan8.BackColor = Color.Blue;
                    break;
                case 9:
                    btBan9.BackColor = Color.Blue;
                    break;
                case 10:
                    btBan10.BackColor = Color.Blue;
                    break;
                case 11:
                    btBan11.BackColor = Color.Blue;
                    break;
                case 12:
                    btBan12.BackColor = Color.Blue;
                    break;
                case 13:
                    btBan13.BackColor = Color.Blue;
                    break;
                case 14:
                    btBan14.BackColor = Color.Blue;
                    break;
                case 15:
                    btBan15.BackColor = Color.Blue;
                    break;
            }
            a.Close();
        }

        private void btDongBan_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(connectinonST);
            a.Open();
            SqlCommand cmd = new SqlCommand("update BAN_AN set TinhTrang=N'Đang đóng' where ID=" + x.ToString(), a);
            cmd.ExecuteNonQuery();
            switch (x)
            {
                case 1:
                    btBan1.BackColor = Color.Gray;
                    break;
                case 2:
                    btBan2.BackColor = Color.Gray;
                    break;
                case 3:
                    btBan3.BackColor = Color.Gray;
                    break;
                case 4:
                    btBan4.BackColor = Color.Gray;
                    break;
                case 5:
                    btBan5.BackColor = Color.Gray;
                    break;
                case 6:
                    btBan6.BackColor = Color.Gray;
                    break;
                case 7:
                    btBan7.BackColor = Color.Gray;
                    break;
                case 8:
                    btBan8.BackColor = Color.Gray;
                    break;
                case 9:
                    btBan9.BackColor = Color.Gray;
                    break;
                case 10:
                    btBan10.BackColor = Color.Gray;
                    break;
                case 11:
                    btBan11.BackColor = Color.Gray;
                    break;
                case 12:
                    btBan12.BackColor = Color.Gray;
                    break;
                case 13:
                    btBan13.BackColor = Color.Gray;
                    break;
                case 14:
                    btBan14.BackColor = Color.Gray;
                    break;
                case 15:
                    btBan15.BackColor = Color.Gray;
                    break;
            }
            a.Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(connectinonST);
            a.Open();
            string query = "insert into HOADON values(" + x.ToString() + ",N'" + dataDSThucDon.CurrentRow.Cells[0].Value.ToString() + "','" + dataDSThucDon.CurrentRow.Cells[1].Value.ToString()+"',"+soLuong.Value.ToString()+",'"+dateTimePicker1.Value.ToString("yyyy/MM/dd")+"')";
            SqlCommand cmd = new SqlCommand(query, a);
            cmd.ExecuteNonQuery();
            a.Close();
            loadHoaDon();
            soLuong.Value = 1;

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            tt = tt - tt * double.Parse(comboBox1.Text) / 100;
            Math.Round(tt);

            tbTongGia.Text = tt.ToString("#,###");
        }

    }
}
