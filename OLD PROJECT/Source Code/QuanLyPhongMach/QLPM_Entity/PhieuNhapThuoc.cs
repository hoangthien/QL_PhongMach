using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class PhieuNhapThuoc
    {
        private int _MaPhieu;

        public int MaPhieu
        {
            get { return _MaPhieu; }
            set { _MaPhieu = value; }
        }
        private string _NgayNhap;

        public string NgayNhap
        {
            get { return _NgayNhap; }
            set { _NgayNhap = value; }
        }
        private string _TongTien;

        public string TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }
        private string _Thang;

        public string Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }
    }
}
