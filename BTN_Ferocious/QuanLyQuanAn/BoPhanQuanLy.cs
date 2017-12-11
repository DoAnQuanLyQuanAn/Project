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
    public partial class BoPhanQuanLy : Form
    {
        string connectinonST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";

        DataTable cboxMonAn = new DataTable();

        public BoPhanQuanLy()
        {
            InitializeComponent();
        }

        private string Message3;

        public string Message31
        {
            get { return Message3; }
            set { Message3 = value; }
        }

        
        private void BoPhanQuanLy_Load(object sender, EventArgs e)
        {
            Ten.Text = Message3;
            //Đưa dữ liệu vào combobox danh mục
            DataTable tb = new DataTable();
            tb = LoadDuLieu.docDuLieu("SELECT TenLoai From LOAI_MONAN");
            cbDanhMuc.DisplayMember = "TenLoai";
            cbDanhMuc.ValueMember = "ID";
            cbDanhMuc.DataSource = tb;

            //Đưa dữ liệu vào combobox danh mục 2
            DataTable tb2 = new DataTable();
            tb2 = LoadDuLieu.docDuLieu("SELECT TenLoai From LOAI_MONAN");
            cbDanhMuc2.DisplayMember = "TenLoai";
            cbDanhMuc2.ValueMember = "ID";
            cbDanhMuc2.DataSource = tb2;

            //Đưa dữ liệu vào combobox chi nhánh
            DataTable tb3 = new DataTable();
            tb3 = LoadDuLieu.docDuLieu("SELECT TenCN From CHI_NHANH");
            cbChiNhanh.DisplayMember = "TenCN";
            cbChiNhanh.ValueMember = "ID";
            cbChiNhanh.DataSource = tb3;

            //Đưa dữ liệu vào datagirdview dataviewChiNhanh
            DataTable tb4 = new DataTable();
            tb4 = LoadDuLieu.docDuLieu("SELECT TenCN, DiaChi, LienHe, SoLuongBan FROM CHI_NHANH");
            dataviewChiNhanh.DataSource = tb4;

            //Đưa dữ liệu vào datadsMonAn
            DataTable tb5 = new DataTable();
            tb5 = LoadDuLieu.docDuLieu("SELECT L.TenLoai, MA.TenMonAn, MA.DonGia FROM MONAN MA, LOAI_MONAN L WHERE MA.IDLoaiMonAn = L.ID");
            dataDSMonAn.DataSource = tb5;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            
        }

        private void btThemMonAn_Click(object sender, EventArgs e)
        {
            
        }

        private void cbDanhMuc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMonAn.Items.Clear();
            if (cbDanhMuc2.SelectedItem == "Tôm")
            {
                DataTable tb = new DataTable();
                tb = LoadDuLieu.docDuLieu("SELECT MA.TenMonAn From MONAN MA, LOAI_MONAN L WHERE L.TenLoai = N'Tôm' and L.ID = MA.IDLoaiMonAn");
                cbMonAn.DisplayMember = "TenMonAn";
                cbMonAn.ValueMember = "ID";
                cbMonAn.DataSource = tb;
            }
            else if (cbDanhMuc2.SelectedItem == "Cá")
            {
                DataTable tb = new DataTable();
                tb = LoadDuLieu.docDuLieu("SELECT MA.TenMonAn From MONAN MA, LOAI_MONAN L WHERE L.TenLoai = N'Cá' and L.ID = MA.IDLoaiMonAn");
                cbMonAn.DisplayMember = "TenMonAn";
                cbMonAn.ValueMember = "ID";
                cbMonAn.DataSource = tb;
            }
            else if (cbDanhMuc2.SelectedItem == "Cua")
            {
                DataTable tb = new DataTable();
                tb = LoadDuLieu.docDuLieu("SELECT MA.TenMonAn From MONAN MA, LOAI_MONAN L WHERE L.TenLoai = N'Cua' and L.ID = MA.IDLoaiMonAn");
                cbMonAn.DisplayMember = "TenMonAn";
                cbMonAn.ValueMember = "ID";
                cbMonAn.DataSource = tb;
            }
            else if (cbDanhMuc2.SelectedItem == "Gà")
            {
                DataTable tb = new DataTable();
                tb = LoadDuLieu.docDuLieu("SELECT MA.TenMonAn From MONAN MA, LOAI_MONAN L WHERE L.TenLoai = N'Gà' and L.ID = MA.IDLoaiMonAn");
                cbMonAn.DisplayMember = "TenMonAn";
                cbMonAn.ValueMember = "ID";
                cbMonAn.DataSource = tb;
            }
            else if (cbDanhMuc2.SelectedItem == "Bầu")
            {
                DataTable tb = new DataTable();
                tb = LoadDuLieu.docDuLieu("SELECT MA.TenMonAn From MONAN MA, LOAI_MONAN L WHERE L.TenLoai = N'Bầu' and L.ID = MA.IDLoaiMonAn");
                cbMonAn.DisplayMember = "TenMonAn";
                cbMonAn.ValueMember = "ID";
                cbMonAn.DataSource = tb;
            }
            else if (cbDanhMuc2.SelectedItem == "Nai")
            {
                DataTable tb = new DataTable();
                tb = LoadDuLieu.docDuLieu("SELECT MA.TenMonAn From MONAN MA, LOAI_MONAN L WHERE L.TenLoai = N'Nai' and L.ID = MA.IDLoaiMonAn");
                cbMonAn.DisplayMember = "TenMonAn";
                cbMonAn.ValueMember = "ID";
                cbMonAn.DataSource = tb;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btXoaChiNhanh_Click(object sender, EventArgs e)
        {
            int RowIndex = dataviewChiNhanh.CurrentRow.Index;
            dataviewChiNhanh.Rows.RemoveAt(RowIndex);
        }

        private void btSuaChiNhanh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng hiện chưa có!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btBaoCao_Click(object sender, EventArgs e)
        {
            BaoCao bc = new BaoCao();
            this.Hide();
            bc.ShowDialog();
            this.Show();
        }

    }
}

