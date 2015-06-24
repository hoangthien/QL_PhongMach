using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using QLPM_DAL;

namespace QLPM_BUS
{
    public class BUS_CTBC
    {
        public static void Them(CTBCDoanhThu bc)
        {
            DAL_CTBC.Them(bc);
        }
    }
}
