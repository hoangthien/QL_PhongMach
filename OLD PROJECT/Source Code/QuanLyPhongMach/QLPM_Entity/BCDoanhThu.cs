using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class BCDoanhThu
    {
        private string _Thang;

        public string Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }
        private string _TongDoanhThu;

        public string TongDoanhThu
        {
            get { return _TongDoanhThu; }
            set { _TongDoanhThu = value; }
        }
    }
}
