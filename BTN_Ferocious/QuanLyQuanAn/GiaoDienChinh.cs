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
        string connectinonST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        public GiaoDienChinh()
        {
            InitializeComponent();
            LoadTable();
        }
        void LoadTable()
        {
            List<Table> tablelist = LoadTablelist();
            //với mỗi table nằm trong tablelist chúng ta tạo 1 button để hiển thị bàn ăn
            foreach (Table item in tablelist)
            {
                Button bt = new Button()
                {
                    Width = 70,
                    Height = 70
                };
                bt.Text = item.TenBan + Environment.NewLine /*xuong dong*/ + item.TinhTrang;
                bt.Click += new EventHandler(bt_Click);
                bt.Tag = item;
                switch (item.TinhTrang)
                {
                    case "Trống":
                        bt.BackColor = Color.White;
                        break;
                    default:
                        bt.BackColor = Color.Aqua;
                        break;
                }
                dsachBanAn.Controls.Add(bt);
            }
        }

        
        
        public List<Table> LoadTablelist()
        {
            List<Table> tablelst = new List<Table>();
            SqlConnection connection = new SqlConnection(connectinonST);
            connection.Open();
            string query = "SELECT * FROM BAN_AN";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            //đổ dữ liệu từ csdl vào dsBanAn
            DataTable dsBanAn = new DataTable();
            adapter.Fill(dsBanAn);
            //cho mỗi dataRow trong dsBanAn chúng ta lấy ra từng dòng
            foreach (DataRow item in dsBanAn.Rows)
            {
                Table table = new Table(item);
                tablelst.Add(table);
            }
            return tablelst;
        }
        

        //Lấy tên người đăng nhập
        private string Message;
        public string Message1
        {
          get { return Message; }
          set { Message = value; }
        }


        DataTable tb2 = new DataTable();
        DataView view;
        DataView viewTimKiem;
        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            TenHienThi.Text = Message;
            //Đưa dữ liệu vào dataDSThucDon
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn, DonGia, SoLuongTrongKho FROM MONAN");
            viewTimKiem = new DataView(tb);
            dataDSThucDon.DataSource = viewTimKiem;

            
            tb2 = XuatHoaDon();
            view = new DataView(tb2);
            dataThongTinHoaDon.DataSource = view;
            binding();
            binding2();
            
        }

        //hàm tính tổng thu khi đã giảm giá
        private double phanthu(double a, double b)
        {
            double x;
            x = a * (b / 100);
            return x;
        }

        private void btPhanThu_Click(object sender, EventArgs e)
        {
            double a = double.Parse(tbTongGia.Text);
            double b = double.Parse(tbGiamGia.Text);
            double x = a - phanthu(a, b);
            tbPhanThu.Text = x.ToString();
        }

        private void btInXuongBep_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã gửi xuống bếp!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectinonST);
            connection.Open();

            string query = "DELETE FROM info_HOADON";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Đã Thanh Toán, Xác Nhận Xóa Hóa Đơn!", "Thông Báo", MessageBoxButtons.OK);
            connection.Close();

            SqlConnection connection2 = new SqlConnection(connectinonST);
            connection2.Open();

            string query2 = "DELETE FROM DONHANG_TONGDAI";
            SqlCommand command2 = new SqlCommand(query2, connection2);
            command2.ExecuteNonQuery();
            connection2.Close();
            tb2.Clear();

            SqlConnection connection3 = new SqlConnection(connectinonST);
            connection3.Open();

            string query3 = "UPDATE BAN_AN SET TinhTrang = N'Trống' WHERE ID = '" + tbBan.Text + "'";
            SqlCommand command3 = new SqlCommand(query3, connection3);
            command3.ExecuteNonQuery();
            connection3.Close();
        }

        private void btNhanHoaDon_Click(object sender, EventArgs e)
        {
            
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn, DonGia, SoLuong, DiaChi FROM DONHANG_TONGDAI");
            view = new DataView(tb);
            dataThongTinHoaDon.DataSource = view;
        }

        //lay du lieu tu dataTable vao textbox
        public void binding()
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
            
        }

        private void tbDichVu_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void btCapNhap_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectinonST);
            connection.Open();

            string query = "exec Gui1 N'" + tbDichVu.Text + "', '" + tbSoLuong.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Đã Thêm Thành Công!","Thông Báo",MessageBoxButtons.OK);
            connection.Close();
            XuatHoaDon();
            DataRow new1 = tb2.NewRow();
            new1[0] = tbDichVu.Text;
            new1[1] = tbDonGia.Text;
            new1[2] = tbSoLuong.Text;
            tb2.Rows.Add(new1);

            SqlConnection connection2 = new SqlConnection(connectinonST);
            connection2.Open();

            string query2 = "UPDATE BAN_AN SET TinhTrang = N'Có Người' WHERE ID = '"+tbBan.Text+"'";
            SqlCommand command2 = new SqlCommand(query2, connection2);
            command2.ExecuteNonQuery();
            connection2.Close();
        }
        private DataTable XuatHoaDon()
        {
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT iHD.TenMonAn, iHD.DonGia, iHD.SoLuong FROM info_HOADON iHD, HOADON HD WHERE iHD.IDHoaDon = HD.ID");
            return tb;

        }
        private DataTable tinhtong()
        {
            int s = dataThongTinHoaDon.Rows.Count;
            double DonGia = 0;
            
            for (int i = 0; i < s - 1; i++)
            {
               DonGia += double.Parse(dataThongTinHoaDon.Rows[i].Cells["DonGia"].Value.ToString()) * int.Parse(dataThongTinHoaDon.Rows[i].Cells["SoLuong"].Value.ToString());
                
            }
            DataTable gv = new DataTable();
            gv.Columns.Add("tien");
            DataRow new1 = gv.NewRow();
            new1[0] = DonGia;
            gv.Rows.Add(new1);
            return gv;
            
        }
        void showbill(int id)
        {
            tb2.Clear();
        }
        void bt_Click(object sender, EventArgs e)
        {
            int IDBanAn = ((sender as Button).Tag as Table).ID;
            showbill(IDBanAn);
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn, DonGia, SoLuongTrongKho FROM MONAN WHERE TenMonAn like N'" + tbTimKiem.Text + "%'");
            viewTimKiem = new DataView(tb);
            dataDSThucDon.DataSource = viewTimKiem;
        }
        void textCommit()
        {
        }
    }
}
