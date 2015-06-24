using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using QLPM_DAL;
using System.Data;

namespace QLPM_BUS
{
    public class BUS_BCDoanhThu
    {
        public static void ThemDuLieu(BCDoanhThu bc)
        {
            DAL_BCDoanhThu.Them(bc);
        }

        public static DataTable LayDuLieu(string t)
        {
            return DAL_BCDoanhThu.LayDuLieu(t);
        }

        public static string LayDoanhThu(string t)
        {
            return DAL_BCDoanhThu.LayDoanhThu(t);
        }
    }
}
