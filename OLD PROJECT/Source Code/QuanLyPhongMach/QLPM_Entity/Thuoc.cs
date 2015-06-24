using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class Thuoc
    {
        private int _MaThuoc;

        public int MaThuoc
        {
            get { return _MaThuoc; }
            set { _MaThuoc = value; }
        }
        private string _TenThuoc;

        public string TenThuoc
        {
            get { return _TenThuoc; }
            set { _TenThuoc = value; }
        }
        private string _DonVi;

        public string DonVi
        {
            get { return _DonVi; }
            set { _DonVi = value; }
        }
        private string _DonGia;

        public string DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        private string _SoLuongTon;

        public string SoLuongTon
        {
            get { return _SoLuongTon; }
            set { _SoLuongTon = value; }
        }
    }
}
