using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLyQuanAn
{
    public class Table
    {
        public Table(int id, string tenban, string tinhtrang)
        {
            this.ID = id;
            this.TenBan = tenban;
            this.TinhTrang = tinhtrang;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.TenBan = row["TenBan"].ToString();
            this.TinhTrang = row["TinhTrang"].ToString();
        }

        private string _TinhTrang;

        public string TinhTrang
        {
            get { return _TinhTrang; }
            set { _TinhTrang = value; }
        }

        private string _TenBan;

        public string TenBan
        {
            get { return _TenBan; }
            set { _TenBan = value; }
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
