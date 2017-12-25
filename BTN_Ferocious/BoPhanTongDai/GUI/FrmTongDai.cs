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
using System.Data;
using System.Data.SqlClient;

namespace BoPhanTongDai.GUI
{
    public partial class FrmTongDai : Form
    {
        int dtgrRow;

        public FrmTongDai()
        {
            InitializeComponent();
            this.LoadHistory();
        }

        private void FrmTongDai_Load(object sender, EventArgs e)
        {
            DBManager dBManager = new DBManager();
            dBManager.Open();

            string sqlGetMonAn = "SELECT* FROM MONAN";
            SqlDataReader reader =  dBManager.GetReader(CommandType.Text, sqlGetMonAn);
            
            while (reader.Read())
            {
                this.cbTenMonAn.Items.Add(reader["ID"].ToString() + " - " + reader["TenMonAn"]);
            }
            reader.Close();

            string sqlGetChiNhanh = "SELECT* FROM CHI_NHANH";
            reader = dBManager.GetReader(CommandType.Text, sqlGetChiNhanh);
            while (reader.Read())
            {
                this.cbChiNhanh.Items.Add(reader["ID"].ToString() + " - " + reader["TenCN"].ToString() + " - " + reader["DiaChi"]);
                this.cbChiNhanhWeb.Items.Add(reader["ID"].ToString() + " - " + reader["TenCN"].ToString() + " - " + reader["DiaChi"]);
            }

            reader.Close();
            string sqlGetLoaiMonAn = "SELECT* FROM LOAI_MONAN";
            reader = dBManager.GetReader(CommandType.Text, sqlGetLoaiMonAn);
            while (reader.Read())
            {
                this.cbLoaiMonAn.Items.Add(reader["ID"].ToString() + " - " + reader["TenLoai"]);
            }
            reader.Close();

            this.dtpkNgayLap.Enabled = false;
            this.dtpkNgayLap.Value = DateTime.Now;

            dBManager.Close();
        }

        void LoadHistory()
        {
            DBManager dBManager = new DBManager();
            dBManager.Open();

            this.dtgrLichSu.ForeColor = Color.Black;
            string sqlSelectDonHang = "SELECT* FROM DONHANG_TONGDAI_LICHSU";
            SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlSelectDonHang);
            while (reader.Read())
            {
                int STT = int.Parse(reader["ID"].ToString());
                int IDChiNhanh = int.Parse(reader["IDChiNhanh"].ToString());
                int IDMonAn = int.Parse(reader["IDMonAn"].ToString());
                int SoLuong = int.Parse(reader["SoLuong"].ToString());
                string NgayLap = reader["NgayLap"].ToString();
                int IDKhachHang = int.Parse(reader["IDKhachHang"].ToString());

                DataGridViewRow row = (DataGridViewRow)this.dtgrLichSu.Rows[0].Clone();
                row.Cells[0].Value = STT;
                string sqlGetKHWeb = "SELECT TenKH, DiaChi, SDT FROM KHACHHANG WHERE ID = @IDKhachHang";
                SqlDataReader dataReader = dBManager.GetReader(CommandType.Text, sqlGetKHWeb, new SqlParameter { ParameterName = "@IDKhachHang", Value = IDKhachHang });
                while (dataReader.Read())
                {
                    row.Cells[1].Value = dataReader[0];
                    row.Cells[2].Value = dataReader[1];
                    row.Cells[3].Value = dataReader[2];
                }

                string sqlGetMonAnWeb = "SELECT L.TenLoai, MA.TenMonAn, MA.DonGia FROM MONAN MA, LOAI_MONAN L WHERE MA.ID = @IDMonAn AND MA.IDLoaiMonAn = L.ID";
                dataReader = dBManager.GetReader(CommandType.Text, sqlGetMonAnWeb, new SqlParameter { ParameterName = "@IDMonAn", Value = IDMonAn });
                while (dataReader.Read())
                {
                    row.Cells[4].Value = dataReader[0];
                    row.Cells[5].Value = dataReader[1];
                    row.Cells[6].Value = dataReader[2];
                }

                row.Cells[7].Value = NgayLap;
                row.Cells[8].Value = SoLuong;

                string sqlGetChiNhanhWeb = "SELECT TenCN FROM CHI_NHANH WHERE ID = @IDChiNhanh";
                dataReader = dBManager.GetReader(CommandType.Text, sqlGetChiNhanhWeb, new SqlParameter { ParameterName = "@IDChiNhanh", Value = IDChiNhanh });
                while (dataReader.Read())
                {
                    row.Cells[9].Value = dataReader[0];
                }

                this.dtgrLichSu.Rows.Add(row);
            }

            dBManager.Close();
        }

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            string tenKH = this.tbTenKH.Text.ToString();
            string diaChiKH = this.tbDCKH.Text.ToString();
            string sdtKH = this.tbSDT.Text.ToString();
            string loaiMonAn = this.cbLoaiMonAn.Text.ToString();
            string tenMonAn = this.cbTenMonAn.Text.ToString();
            string donGia = this.tbDonGia.Text.ToString();
            string soLuong = this.tbSL.Text.ToString();
            string chiNhanh = this.cbChiNhanh.Text.ToString();
            string ngayLap = this.dtpkNgayLap.Value.ToString();


            if(tenKH != "" && diaChiKH != "" && sdtKH != "" && loaiMonAn != "" 
                && tenMonAn != "" && donGia != "" && soLuong != "" && chiNhanh != "")
            {
                string sqlThemKhachHang = "INSERT INTO KHACHHANG VALUES(@tenKH, @sdt, @diaChi)";
                DBManager dBManager = new DBManager();
                dBManager.Open();
                dBManager.ExecuteNonQuery(CommandType.Text, sqlThemKhachHang, 
                    new SqlParameter {ParameterName = "@tenKH", Value = tenKH },
                    new SqlParameter { ParameterName = "@sdt", Value = sdtKH},
                    new SqlParameter { ParameterName = "@diaChi", Value = diaChiKH});

                int IDChiNhanh = this.cbChiNhanh.SelectedIndex + 1;
                int IDMonAn = this.cbTenMonAn.SelectedIndex + 1;

                string sqlGetIDKH = "SELECT* FROM KHACHHANG";
                SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlGetIDKH);
                int IDKhachHang = 0; 
                while (reader.Read())
                {
                    IDKhachHang++;
                }
                reader.Close();

                string sqlTaoDonHang = "INSERT INTO DONHANG_TONGDAI_LICHSU VALUES(@IDKhachHang, @IDMonAn, @IDChiNhanh, @SoLuong, @NgayLap)";
                dBManager.ExecuteNonQuery(CommandType.Text, sqlTaoDonHang,
                    new SqlParameter { ParameterName = "@IDKhachHang", Value = IDKhachHang },
                    new SqlParameter { ParameterName = "@IDMonAn", Value = IDMonAn },
                    new SqlParameter { ParameterName = "@IDChiNhanh", Value=IDChiNhanh},
                    new SqlParameter { ParameterName="@SoLuong", Value=soLuong},
                    new SqlParameter { ParameterName="@NgayLap", Value=ngayLap});

                dBManager.Close();

                MessageBox.Show("Thành Công");

                this.tbTenKH.Clear();
                this.tbSDT.Clear();
                this.tbDonGia.Clear();
                this.tbDCKH.Clear();
                this.cbChiNhanh.ResetText();
                this.cbLoaiMonAn.ResetText();
                this.cbTenMonAn.ResetText();
                this.tbSL.Clear();

                this.dtgrLichSu.Rows.Clear();
                this.LoadHistory();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void cbTenMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDMonAn = this.cbTenMonAn.SelectedIndex + 1;
            string sqlGetDonGia = "SELECT DonGia FROM MONAN WHERE ID = @ID";
            DBManager dBManager = new DBManager();
            dBManager.Open();

            SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlGetDonGia, 
                new SqlParameter { ParameterName = "@ID", Value = IDMonAn});
            while (reader.Read())
            {
                this.tbDonGia.Text = reader["DonGia"].ToString();
            }
            
            reader.Close();
            dBManager.Close();
        }

        void LoadFromWeb()
        {
            //datagridview web
            DBManager dBManager = new DBManager();
            dBManager.Open();

            this.dtgrDonHangWeb.ForeColor = Color.Black;
            string sqlSelectDonHang = "SELECT* FROM DONHANG_TONGDAI";
            SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlSelectDonHang);
            while (reader.Read())
            {
                int STT = int.Parse(reader["ID"].ToString());
                int IDChiNhanh = int.Parse(reader["IDChiNhanh"].ToString());
                int IDMonAn = int.Parse(reader["IDMonAn"].ToString());
                int SoLuong = int.Parse(reader["SoLuong"].ToString());
                string NgayLap = reader["NgayLap"].ToString();
                int IDKhachHang = int.Parse(reader["IDKhachHang"].ToString());
                int IDTrangThai = int.Parse(reader["IDTrangThai"].ToString());

                DataGridViewRow row = (DataGridViewRow)this.dtgrDonHangWeb.Rows[0].Clone();
                row.Cells[0].Value = STT;
                string sqlGetKHWeb = "SELECT TenKH, DiaChi, SDT FROM KHACHHANG WHERE ID = @IDKhachHang";
                SqlDataReader dataReader = dBManager.GetReader(CommandType.Text, sqlGetKHWeb, new SqlParameter { ParameterName = "@IDKhachHang", Value = IDKhachHang });
                while (dataReader.Read())
                {
                    row.Cells[1].Value = dataReader[0];
                    row.Cells[2].Value = dataReader[1];
                    row.Cells[3].Value = dataReader[2];
                }

                string sqlGetMonAnWeb = "SELECT L.TenLoai, MA.TenMonAn, MA.DonGia FROM MONAN MA, LOAI_MONAN L WHERE MA.ID = @IDMonAn AND MA.IDLoaiMonAn = L.ID";
                dataReader = dBManager.GetReader(CommandType.Text, sqlGetMonAnWeb, new SqlParameter { ParameterName = "@IDMonAn", Value = IDMonAn });
                while (dataReader.Read())
                {
                    row.Cells[4].Value = dataReader[0];
                    row.Cells[5].Value = dataReader[1];
                    row.Cells[6].Value = dataReader[2];
                }

                row.Cells[7].Value = SoLuong;

                string sqlGetChiNhanhWeb = "SELECT TenCN FROM CHI_NHANH WHERE ID = @IDChiNhanh";
                dataReader = dBManager.GetReader(CommandType.Text, sqlGetChiNhanhWeb, new SqlParameter { ParameterName = "@IDChiNhanh", Value = IDChiNhanh });
                while (dataReader.Read())
                {
                    row.Cells[8].Value = dataReader[0];
                }

                row.Cells[9].Value = NgayLap;

                string sqlGetTrangThai = "SELECT TenTrangThai FROM TRANG_THAI_DON_HANG WHERE ID = @IDTrangThai";
                dataReader = dBManager.GetReader(CommandType.Text, sqlGetTrangThai, new SqlParameter { ParameterName = "@IDTrangThai", Value = IDTrangThai });
                while (dataReader.Read())
                {
                    row.Cells[10].Value = dataReader[0];
                }

                this.dtgrDonHangWeb.Rows.Add(row);
            }

            dBManager.Close();
        }

        private void btnLoadWeb_Click(object sender, EventArgs e)
        {
            this.dtgrDonHangWeb.Rows.Clear();
            this.LoadFromWeb();
        }

        private void btnXoaWeb_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.dtgrDonHangWeb.Rows[this.dtgrRow].Cells[0].Value.ToString());
            string sqlDelete = "DELETE FROM DONHANG_TONGDAI WHERE ID = @ID";
            DBManager dBManager = new DBManager();
            dBManager.Open();
            dBManager.ExecuteNonQuery(CommandType.Text, sqlDelete, new SqlParameter { ParameterName="@ID", Value=ID});
            dBManager.Close();

            this.dtgrDonHangWeb.Rows.RemoveAt(this.dtgrRow);
        }

        private void dtgrDonHangWeb_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = int.Parse(this.dtgrDonHangWeb.Rows[this.dtgrRow].Cells[0].Value.ToString());
            FrmSuaDHWeb frmSuaDHWeb = new FrmSuaDHWeb(ID);
            frmSuaDHWeb.ShowDialog();
            this.dtgrDonHangWeb.Rows.Clear();

            //reload
            LoadFromWeb();
        }

        private void dtgrDonHangWeb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgrRow = this.dtgrDonHangWeb.CurrentCell.RowIndex;
        }

        private void btnXacNhanWeb_Click(object sender, EventArgs e)
        {
            string chiNhanh = this.cbChiNhanhWeb.Text.ToString();
            if (chiNhanh != "")
            {
                int IDChiNhanh = this.cbChiNhanhWeb.SelectedIndex + 1;
                int ID = int.Parse(this.dtgrDonHangWeb.Rows[this.dtgrRow].Cells[0].Value.ToString());

                string sqlGetDonHang = "SELECT IDChiNhanh, IDTrangThai FROM DONHANG_TONGDAI WHERE ID = @ID";

                DBManager dBManager = new DBManager();
                dBManager.Open();

                SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlGetDonHang, 
                    new SqlParameter { ParameterName = "@ID", Value = ID });

                while(reader.Read())
                {
                    if(IDChiNhanh != int.Parse(reader[0].ToString()))
                    {
                        string sql = "UPDATE DONHANG_TONGDAI SET IDChiNhanh = @IDChiNhanh WHERE ID = @ID";
                        dBManager.ExecuteNonQuery(CommandType.Text, sql, new SqlParameter { ParameterName="@IDChiNhanh", Value=IDChiNhanh },
                            new SqlParameter { ParameterName="@ID", Value = ID});
                    }
                    if(int.Parse(reader[1].ToString()) != 2)
                    {
                        string sql = "UPDATE DONHANG_TONGDAI SET IDTrangThai = 2 WHERE ID = @ID";
                        dBManager.ExecuteNonQuery(CommandType.Text, sql,
                            new SqlParameter { ParameterName = "@ID", Value = ID });
                    }
                }

                MessageBox.Show("Xử lý thành công");
                this.dtgrDonHangWeb.Rows.Clear();
                this.LoadFromWeb();

                dBManager.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Chi Nhánh");
            }
        }

        private void btnSuaWeb_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.dtgrDonHangWeb.Rows[this.dtgrRow].Cells[0].Value.ToString());
            FrmSuaDHWeb frmSuaDHWeb = new FrmSuaDHWeb(ID);
            frmSuaDHWeb.ShowDialog();
            this.dtgrDonHangWeb.Rows.Clear();

            //reload
            LoadFromWeb();
        }

        private void btnXoaLichSu_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.dtgrLichSu.Rows[this.dtgrRow].Cells[0].Value.ToString());
            string sqlDelete = "DELETE FROM DONHANG_TONGDAI_LICHSU WHERE ID = @ID";
            DBManager dBManager = new DBManager();
            dBManager.Open();
            dBManager.ExecuteNonQuery(CommandType.Text, sqlDelete, new SqlParameter { ParameterName = "@ID", Value = ID });
            dBManager.Close();

            this.dtgrLichSu.Rows.RemoveAt(this.dtgrRow);
        }

        private void btnSuaLichSu_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.dtgrLichSu.Rows[this.dtgrRow].Cells[0].Value.ToString());
            FrmSuaLichSu frmSuaLS = new FrmSuaLichSu(ID);
            frmSuaLS.ShowDialog();
            this.dtgrLichSu.Rows.Clear();

            //reload
            LoadHistory();
        }

        private void btTimKiemLS_Click(object sender, EventArgs e)
        {
            this.dtgrLichSu.Rows.Clear();

            string SDT = this.tbSDTLS.Text.ToString();
            string sqlSearch = "SELECT ID FROM KHACHHANG WHERE SDT = @SDT";
            DBManager dBManager = new DBManager();
            dBManager.Open();

            SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlSearch,
                new SqlParameter { ParameterName = "@SDT", Value = SDT });

            while (reader.Read())
            {
                this.dtgrLichSu.ForeColor = Color.Black;
                int ID = int.Parse(reader["ID"].ToString());
                string sqlSelectDonHang = "SELECT* FROM DONHANG_TONGDAI_LICHSU WHERE IDKhachHang = @ID";
                SqlDataReader reader1 = dBManager.GetReader(CommandType.Text, sqlSelectDonHang,
                    new SqlParameter { ParameterName = "@ID", Value = ID });

                while (reader1.Read())
                {
                    int STT = int.Parse(reader1["ID"].ToString());
                    int IDChiNhanh = int.Parse(reader1["IDChiNhanh"].ToString());
                    int IDMonAn = int.Parse(reader1["IDMonAn"].ToString());
                    int SoLuong = int.Parse(reader1["SoLuong"].ToString());
                    string NgayLap = reader1["NgayLap"].ToString();
                    int IDKhachHang = int.Parse(reader1["IDKhachHang"].ToString());

                    DataGridViewRow row = (DataGridViewRow)this.dtgrLichSu.Rows[0].Clone();
                    row.Cells[0].Value = STT;
                    string sqlGetKHWeb = "SELECT TenKH, DiaChi, SDT FROM KHACHHANG WHERE ID = @IDKhachHang";
                    SqlDataReader dataReader = dBManager.GetReader(CommandType.Text, sqlGetKHWeb, new SqlParameter { ParameterName = "@IDKhachHang", Value = IDKhachHang });
                    while (dataReader.Read())
                    {
                        row.Cells[1].Value = dataReader[0];
                        row.Cells[2].Value = dataReader[1];
                        row.Cells[3].Value = dataReader[2];
                    }

                    string sqlGetMonAnWeb = "SELECT L.TenLoai, MA.TenMonAn, MA.DonGia FROM MONAN MA, LOAI_MONAN L WHERE MA.ID = @IDMonAn AND MA.IDLoaiMonAn = L.ID";
                    dataReader = dBManager.GetReader(CommandType.Text, sqlGetMonAnWeb, new SqlParameter { ParameterName = "@IDMonAn", Value = IDMonAn });
                    while (dataReader.Read())
                    {
                        row.Cells[4].Value = dataReader[0];
                        row.Cells[5].Value = dataReader[1];
                        row.Cells[6].Value = dataReader[2];
                    }

                    row.Cells[7].Value = NgayLap;
                    row.Cells[8].Value = SoLuong;

                    string sqlGetChiNhanhWeb = "SELECT TenCN FROM CHI_NHANH WHERE ID = @IDChiNhanh";
                    dataReader = dBManager.GetReader(CommandType.Text, sqlGetChiNhanhWeb, new SqlParameter { ParameterName = "@IDChiNhanh", Value = IDChiNhanh });
                    while (dataReader.Read())
                    {
                        row.Cells[9].Value = dataReader[0];
                    }

                    this.dtgrLichSu.Rows.Add(row);
                }
            }
            dBManager.Close();
        }

        private void btnReLoadLichSu_Click(object sender, EventArgs e)
        {
            this.dtgrLichSu.Rows.Clear();
            this.LoadHistory();
        }
    }
}
