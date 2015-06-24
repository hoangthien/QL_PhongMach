using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class HoaDon
    {
        private int _MaHD;

        public int MaHD
        {
            get { return _MaHD; }
            set { _MaHD = value; }
        }
        private string _Thang;

        public string Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }
        private int _TienThuoc;

        public int TienThuoc
        {
            get { return _TienThuoc; }
            set { _TienThuoc = value; }
        }
        private int _MaToa;

        public int MaToa
        {
            get { return _MaToa; }
            set { _MaToa = value; }
        }
    }
}
