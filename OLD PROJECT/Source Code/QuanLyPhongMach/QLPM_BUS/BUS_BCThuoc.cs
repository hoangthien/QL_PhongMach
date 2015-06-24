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
    public class BUS_BCThuoc
    {
        public static void Them(BCThuoc bc)
        {
            DAL_BCThuoc.Them(bc);
        }

        public static DataTable LayDuLieu(string th)
        {
            return DAL_BCThuoc.LayDuLieu(th);
        }

        public static string LaySoLuong(string t, string th)
        {
            return DAL_BCThuoc.LaySoLuong(t, th);
        }

        public static string LaySoLan(string t)
        {
            return DAL_BCThuoc.LaySoLan(t);
        }
    }
}
