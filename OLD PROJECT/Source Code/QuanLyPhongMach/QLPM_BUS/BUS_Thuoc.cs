using QLPM_Entity;
using QLPM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLPM_BUS
{
    public class BUS_Thuoc
    {
        public static void ThemDuLieu(Thuoc t)
        {
            
            DAL_Thuoc.ThemMoi(t);
        }

        public static void SuaDuLieu(Thuoc t)
        {
            DAL_Thuoc.Sua(t);
        }

        public static void XoaDuLieu(string t)
        {
            DAL_Thuoc.Xoa(t);
        }

        public static void UpdateSLTon(string t, int sl)
        {
            DAL_Thuoc.UpdateSLTon(t, sl);
        }

        public static DataTable LayDuLieu()
        {
            return DAL_Thuoc.LayDuLieu();
        }

        public static DataTable LayTenThuoc()
        {
            return DAL_Thuoc.LayTenThuoc();
        }

        public static DataTable LayDonVi(string t)
        {
            return DAL_Thuoc.LayDonVi(t);
        }

        public static string LaySoThuoc()
        {
            return DAL_Thuoc.LaySoThuoc();
        }
    }
}
