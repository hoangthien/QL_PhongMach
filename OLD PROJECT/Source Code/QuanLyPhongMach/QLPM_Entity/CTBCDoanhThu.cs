using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPM_Entity
{
    public class CTBCDoanhThu
    {
        private string _Thang;

        public string Thang
        {
            get { return _Thang; }
            set { _Thang = value; }
        }
        private string _NgayKham;

        public string NgayKham
        {
            get { return _NgayKham; }
            set { _NgayKham = value; }
        }
        private int _SoBenhNhan;

        public int SoBenhNhan
        {
            get { return _SoBenhNhan; }
            set { _SoBenhNhan = value; }
        }
        private string _DoanhThu;

        public string DoanhThu
        {
            get { return _DoanhThu; }
            set { _DoanhThu = value; }
        }
        private float _TyLe;

        public float TyLe
        {
            get { return _TyLe; }
            set { _TyLe = value; }
        }
    }
}
