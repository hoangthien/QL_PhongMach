using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using QLPM_DAL;

namespace QLPM_BUS
{
    public class BUS_BCNhapThuoc
    {
        public static void Them(BCNhapThuoc bc)
        {
            DAL_BCNhapThuoc.Them(bc);
        }
    }
}
