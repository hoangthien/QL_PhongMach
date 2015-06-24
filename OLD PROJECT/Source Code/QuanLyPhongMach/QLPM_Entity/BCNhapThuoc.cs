using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class BCNhapThuoc
    {
        private string _Thang;

        public string Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }
        private string _NgayNhap;

        public string NgayNhap
        {
            get { return _NgayNhap; }
            set { _NgayNhap = value; }
        }
        private string _TenThuoc;

        public string TenThuoc
        {
            get { return _TenThuoc; }
            set { _TenThuoc = value; }
        }
        private int _SoLuong;

        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private string _ThanhTien;

        public string ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
    }
}
