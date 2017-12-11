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

        

        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            TenHienThi.Text = Message;
            //Đưa dữ liệu vào dataDSThucDon
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenMonAn, DonGia, SoLuongTrongKho FROM MONAN");
            dataDSThucDon.DataSource = tb;

            DataTable tb2 = new DataTable();
            tb2 = XuatHoaDon();
            dataThongTinHoaDon.DataSource = tb2;
            binding();
            
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
            MessageBox.Show("Chức Năng Hiện Chưa Có!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Hiện Chưa Có!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btNhanHoaDon_Click(object sender, EventArgs e)
        {
            XuatHoaDon();
        }

        //lay du lieu tu dataTable vao textbox
        public void binding()
        {
            tbDichVu.DataBindings.Clear();
            tbDichVu.DataBindings.Add("text", dataDSThucDon.DataSource, "TenMonAn");
            tbDonGia.DataBindings.Clear();
            tbDonGia.DataBindings.Add("text", dataDSThucDon.DataSource, "DonGia");
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
        }
        private DataTable XuatHoaDon()
        {
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT iHD.TenMonAn, iHD.DonGia, iHD.SoLuong FROM info_HOADON iHD, HOADON HD WHERE iHD.IDHoaDon = HD.ID");
            return tb;

        }
    }
}
