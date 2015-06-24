using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class PhieuKham
    {
        private int _MaPK;

        public int MaPK
        {
            get { return _MaPK; }
            set { _MaPK = value; }
        }
        private string _NgayKham;

        public string NgayKham
        {
            get { return _NgayKham; }
            set { _NgayKham = value; }
        }
        private string _TrieuChung;

        public string TrieuChung
        {
            get { return _TrieuChung; }
            set { _TrieuChung = value; }
        }
        private string _ChuanDoan;

        public string ChuanDoan
        {
            get { return _ChuanDoan; }
            set { _ChuanDoan = value; }
        }
        private string _TienKham;

        public string TienKham
        {
            get { return _TienKham; }
            set { _TienKham = value; }
        }
        private int _MaBN;

        public int MaBN
        {
            get { return _MaBN; }
            set { _MaBN = value; }
        }

        private string _Thang;

        public string Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }
    }
}
