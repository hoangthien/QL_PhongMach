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
    public class BUS_BenhNhan
    {
        public static void ThemDuLieu(BenhNhan bn)
        {
            DAL_BenhNhan.ThemMoi(bn);
        }

        public static void SuaDuLieu(BenhNhan bn)
        {
            DAL_BenhNhan.Sua(bn);
        }

        public static void XoaDuLieu(string bn)
        {
            DAL_BenhNhan.Xoa(bn);
        }

        public static DataTable LayDuLieu()
        {
            return DAL_BenhNhan.LayDuLieu();
        }

        public static DataTable LayDS()
        {
            return DAL_BenhNhan.LayDS();
        }

        public static DataTable TimTen(string t)
        {
            return DAL_BenhNhan.TimBenhNhan(t);
        }

        public static DataTable TimNgay(string t)
        {
            return DAL_BenhNhan.TimNgay(t);
        }
    }
}
