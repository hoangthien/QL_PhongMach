using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class ToaThuoc
    {
        private int _MaToa;

        public int MaToa
        {
            get { return _MaToa; }
            set { _MaToa = value; }
        }
        private string _Thang;

        public string Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }
        private int _MaBN;

        public int MaBN
        {
            get { return _MaBN; }
            set { _MaBN = value; }
        }
        private int _MaPK;

        public int MaPK
        {
            get { return _MaPK; }
            set { _MaPK = value; }
        }
        private string _ThangToa;

        public string ThangToa
        {
            get { return _ThangToa; }
            set { _ThangToa = value; }
        }
    }
}
