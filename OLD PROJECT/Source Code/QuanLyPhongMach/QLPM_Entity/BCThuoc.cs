using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class BCThuoc
    {
        private string _Thang;

        public string Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }
        private string _DonVi;

        public string DonVi
        {
            get { return _DonVi; }
            set { _DonVi = value; }
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
        private int _SoLanDung;

        public int SoLanDung
        {
            get { return _SoLanDung; }
            set { _SoLanDung = value; }
        }
    }
}
