using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_DAL;
using QLPM_Entity;
using System.Data;

namespace QLPM_BUS
{
    public class BUS_HoaDon
    {
        public static void ThemDuLieu(HoaDon hd)
        {
            DAL_HoaDon.ThemMoi(hd);
        }

        public static void SuaDuLieu(HoaDon hd)
        {
            DAL_HoaDon.Sua(hd);
        }

        public static void XoaDuLieu(string hd)
        {
            DAL_HoaDon.Xoa(hd);
        }

        public static DataTable LayDuLieu()
        {
            return DAL_HoaDon.LayDuLieu();
        }

        public static DataTable LayToa(string t, string ng)
        {
            return DAL_HoaDon.ThongTinToa(t, ng);
        }

        public static string LayMaToa(string t, string ng)
        {
            return DAL_HoaDon.LayMaToa(t, ng);
        }
    }
}
