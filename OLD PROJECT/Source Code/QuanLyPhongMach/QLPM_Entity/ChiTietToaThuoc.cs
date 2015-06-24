using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class ChiTietToaThuoc
    {
        private int _MaToa;

        public int MaToa
        {
            get { return _MaToa; }
            set { _MaToa = value; }
        }
        private int _MaThuoc;

        public int MaThuoc
        {
            get { return _MaThuoc; }
            set { _MaThuoc = value; }
        }
        private int _SoLuong;

        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private string _CachDung;

        public string CachDung
        {
            get { return _CachDung; }
            set { _CachDung = value; }
        }
    }
}
