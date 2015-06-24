using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class ThamSo
    {
        private string _BNMax;

        public string BNMax
        {
            get { return _BNMax; }
            set { _BNMax = value; }
        }
        private string _LoaiBenh;

        public string LoaiBenh
        {
            get { return _LoaiBenh; }
            set { _LoaiBenh = value; }
        }
        private string _DonVi;

        public string DonVi
        {
            get { return _DonVi; }
            set { _DonVi = value; }
        }
        private string _CachDung;

        public string CachDung
        {
            get { return _CachDung; }
            set { _CachDung = value; }
        }
        private string _TienKham;

        public string TienKham
        {
            get { return _TienKham; }
            set { _TienKham = value; }
        }
        private string _LoaiThuoc;

        public string LoaiThuoc
        {
            get { return _LoaiThuoc; }
            set { _LoaiThuoc = value; }
        }
    }
}
