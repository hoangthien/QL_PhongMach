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
    public class BUS_PhieuKham
    {
        public static void ThemDuLieu(PhieuKham pk)
        {
            DAL_PhieuKham.ThemMoi(pk);
        }

        public static void SuaDuLieu(PhieuKham pk)
        {
            DAL_PhieuKham.Sua(pk);
        }

        public static void XoaDuLieu(string pk)
        {
            DAL_PhieuKham.Xoa(pk);
        }

        public static DataTable LayDuLieu()
        {
            return DAL_PhieuKham.LayDuLieu();
        }

        public static DataTable LayThongTinBN()
        {
            return DAL_PhieuKham.LayThongTinBN();
        }

        public static string LayMaPK()
        {
            return DAL_PhieuKham.LayMaPK();
        }

        public static DataTable LayToa(int t)
        {
            return DAL_PhieuKham.LayToa(t);
        }

        public static string LayTenThuoc(string t)
        {
            return DAL_PhieuKham.LayTenThuoc(t);
        }

        public static DataTable LayNgay(string t)
        {
            return DAL_PhieuKham.LayNgay(t);
        }

        public static string LaySoBN(string t)
        {
            return DAL_PhieuKham.LaySoBenhNhan(t);
        }
    }
}
