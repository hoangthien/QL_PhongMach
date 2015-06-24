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
    public class BUS_NhapThuoc
    {
        public static void ThemPhieu(PhieuNhapThuoc nt)
        {
            DAL_NhapThuoc.Them(nt);
        }

        public static void ThemChiTiet(CTNhapThuoc ct)
        {
            DAL_NhapThuoc.ThemChiTiet(ct);
        }

        public static string LayMaPhieu()
        {
            return DAL_NhapThuoc.LayMaPhieu();
        }

        public static string LayMaThuoc(string t)
        {
            return DAL_NhapThuoc.LayMaThuoc(t);
        }

        public static DataTable LayDuLieu(string t)
        {
            return DAL_NhapThuoc.LayDuLieu(t);
        }
    }
}
