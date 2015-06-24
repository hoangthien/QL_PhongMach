using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class CTNhapThuoc
    {
        private int _MaPhieu;

        public int MaPhieu
        {
            get { return _MaPhieu; }
            set { _MaPhieu = value; }
        }
        private int _MaThuoc;

        public int MaThuoc
        {
            get { return _MaThuoc; }
            set { _MaThuoc = value; }
        }
        private string _SoLuong;

        public string SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private string _DonGiaNhap;

        public string DonGiaNhap
        {
            get { return _DonGiaNhap; }
            set { _DonGiaNhap = value; }
        }
        private string _ThanhTien;

        public string ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
    }
}
