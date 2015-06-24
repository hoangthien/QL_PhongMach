using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using QLPM_DAL;

namespace QLPM_BUS
{
    public class BUS_ToaThuoc
    {
        public static void ThemDuLieu(ToaThuoc t)
        {

            DAL_ToaThuoc.ThemMoi(t);
        }

        public static void SuaDuLieu(ToaThuoc t)
        {
            DAL_ToaThuoc.Sua(t);
        }

        public static void XoaDuLieu(string t)
        {
            DAL_ToaThuoc.XoaMaPK(t);
        }

        public static string LayMaToa()
        {
            return DAL_ToaThuoc.LayMaToa();
        }

        public static string MaToa(string t)
        {
            return DAL_ToaThuoc.MaToa(t);
        }
    }
}
