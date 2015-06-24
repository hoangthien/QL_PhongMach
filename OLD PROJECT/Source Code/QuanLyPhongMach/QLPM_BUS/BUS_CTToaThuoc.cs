using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using QLPM_DAL;

namespace QLPM_BUS
{
    public class BUS_CTToaThuoc
    {
        public static void ThemDuLieu(ChiTietToaThuoc t)
        {
            DAL_CTToaThuoc.ThemMoi(t);
        }

        public static void SuaDuLieu(ChiTietToaThuoc t)
        {
            DAL_CTToaThuoc.Sua(t);
        }

        public static void XoaDuLieu(string th)
        {
            DAL_CTToaThuoc.Xoa(th);
        }

        public static string DemThuoc()
        {
            return DAL_CTToaThuoc.DemThuoc();
        }

        public static string LaySLTon(string t)
        {
            return DAL_CTToaThuoc.LaySLTon(t);
        }
    }
}
