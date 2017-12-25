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
    public partial class FrmSuaLichSu : Form
    {
        int ID;

        public FrmSuaLichSu(int id)
        {
            this.ID = id;
            InitializeComponent();

            DBManager dBManager = new DBManager();
            dBManager.Open();

            string sqlGetMonAn = "SELECT* FROM MONAN";
            SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlGetMonAn);

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
            }

            reader.Close();
            string sqlGetLoaiMonAn = "SELECT* FROM LOAI_MONAN";
            reader = dBManager.GetReader(CommandType.Text, sqlGetLoaiMonAn);
            while (reader.Read())
            {
                this.cbLoaiMonAn.Items.Add(reader["ID"].ToString() + " - " + reader["TenLoai"]);
            }
            reader.Close();

            dBManager.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string tenKH = this.tbTenKH.Text.ToString();
            string diaChi = this.tbDCKH.Text.ToString();
            string SDT = this.tbSDT.Text.ToString();

            if (tenKH != "" && diaChi != "" && SDT != "")
            {
                int IDMonAn = this.cbTenMonAn.SelectedIndex + 1;
                int IDChiNhanh = this.cbChiNhanh.SelectedIndex + 1;
                int SoLuong = int.Parse(this.tbSL.Text.ToString());

                string sqlGetDonHang = "SELECT IDKhachHang, IDMonAn, IDChiNhanh FROM DONHANG_TONGDAI_LICHSU WHERE ID = @ID";
                DBManager dBManager = new DBManager();
                dBManager.Open();

                SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlGetDonHang, new SqlParameter { ParameterName = "@ID", Value = this.ID });
                while (reader.Read())
                {
                    if (int.Parse(reader[1].ToString()) == IDMonAn)
                    {
                        string sqlUpdateDonHang = "UPDATE DONHANG_TONGDAI_LICHSU SET " +
                                "IDChiNhanh = @IDChiNhanh, SoLuong = @SoLuong WHERE ID = @ID";
                        dBManager.ExecuteNonQuery(CommandType.Text, sqlUpdateDonHang,
                            new SqlParameter { ParameterName = "@IDChiNhanh", Value = IDChiNhanh },
                            new SqlParameter { ParameterName = "@SoLuong", Value = SoLuong },
                            new SqlParameter { ParameterName = "@ID", Value = this.ID });
                    }
                    else if (int.Parse(reader[2].ToString()) == IDChiNhanh)
                    {
                        string sqlUpdateDonHang = "UPDATE DONHANG_TONGDAI_LICHSU SET IDMonAn = @IDMonAn, " +
                                    " SoLuong = @SoLuong WHERE ID = @ID";
                        dBManager.ExecuteNonQuery(CommandType.Text, sqlUpdateDonHang,
                            new SqlParameter { ParameterName = "@IDMonAn", Value = IDMonAn },
                            new SqlParameter { ParameterName = "@SoLuong", Value = SoLuong },
                            new SqlParameter { ParameterName = "@ID", Value = this.ID });
                    }
                    else if (int.Parse(reader[1].ToString()) == IDMonAn && int.Parse(reader[2].ToString()) == IDChiNhanh)
                    {
                        string sqlUpdateDonHang = "UPDATE DONHANG_TONGDAI_LICHSU SET  " +
                                                " SoLuong = @SoLuong WHERE ID = @ID";
                        dBManager.ExecuteNonQuery(CommandType.Text, sqlUpdateDonHang,
                            new SqlParameter { ParameterName = "@SoLuong", Value = SoLuong },
                            new SqlParameter { ParameterName = "@ID", Value = this.ID });
                    }
                    else
                    {
                        string sqlUpdateDonHang = "UPDATE DONHANG_TONGDAI_LICHSU SET IDMonAn = @IDMonAn, " +
                                        "IDChiNhanh = @IDChiNhanh, SoLuong = @SoLuong WHERE ID = @ID";
                        dBManager.ExecuteNonQuery(CommandType.Text, sqlUpdateDonHang,
                            new SqlParameter { ParameterName = "@IDMonAn", Value = IDMonAn },
                            new SqlParameter { ParameterName = "@IDChiNhanh", Value = IDChiNhanh },
                            new SqlParameter { ParameterName = "@SoLuong", Value = SoLuong },
                            new SqlParameter { ParameterName = "@ID", Value = this.ID });
                    }

                    string sqlUpdateKH = "UPDATE KHACHHANG SET TenKH = @TenKH, DiaChi = @DiaChi, SDT = @SDT WHERE ID = @IDKhachHang";
                    dBManager.ExecuteNonQuery(CommandType.Text, sqlUpdateKH,
                        new SqlParameter { ParameterName = "@TenKH", Value = tenKH },
                        new SqlParameter { ParameterName = "@DiaChi", Value = diaChi },
                        new SqlParameter { ParameterName = "@SDT", Value = SDT },
                        new SqlParameter { ParameterName = "@IDKhachHang", Value = reader[0] });
                }

                dBManager.Close();

                MessageBox.Show("Thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void cbTenMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDMonAn = this.cbTenMonAn.SelectedIndex + 1;
            string sqlGetDonGia = "SELECT DonGia FROM MONAN WHERE ID = @ID";
            DBManager dBManager = new DBManager();
            dBManager.Open();

            SqlDataReader reader = dBManager.GetReader(CommandType.Text, sqlGetDonGia,
                new SqlParameter { ParameterName = "@ID", Value = IDMonAn });
            while (reader.Read())
            {
                this.tbDonGia.Text = reader["DonGia"].ToString();
            }

            reader.Close();
            dBManager.Close();
        }
    }
}
