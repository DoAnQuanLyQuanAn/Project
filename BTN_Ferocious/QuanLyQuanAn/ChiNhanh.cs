using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyQuanAn
{
    public class ChiNhanh
    {
        private string _TenChiNhanh;
        private string _DiaChi;
        private string _LienHe;
        private string _SoLuongBan;

        public string TenChiNhanh
        {
            get { return _TenChiNhanh; }
            set { _TenChiNhanh = value; }
        }

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        public string LienHe
        {
            get { return _LienHe; }
            set { _LienHe = value; }
        }
        public string SoLuongBan
        {
            get { return _SoLuongBan; }
            set { _SoLuongBan = value; }
        }
    }

    public class ThemMonAn
    {
        private string _DanhMuc;
        private string _Ten;
        private string _Gia;

        public string DanhMuc
        {
            get { return _DanhMuc; }
            set { _DanhMuc = value; }
        }

        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }

        public string Gia
        {
            get { return _Gia; }
            set { _Gia = value; }
        }
    }
    public class HoaDon
    {
        private string _DichVu;
        private string _DonGia;
        private string _SoLuong;

        public string DichVu
        {
            get { return _DichVu; }
            set { _DichVu = value; }
        }

        public string DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }

        public string SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
    }
    public class TaoHoaDon
    {
        private string _MaSo;
        private string _Ten;
        private string _SoLuong;
        private string _DiaChi;

        public string MaSo
        {
            get { return _MaSo; }
            set { _MaSo = value; }
        }
        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }
        public string SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
    }
    public class ThongTinKhachHang
    {
        private string _SDT;
        private string _DiaChi;
        private string _Email;

        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
