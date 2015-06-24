using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using System.Data.SqlClient;
using System.Data;

namespace QLPM_DAL
{
    public class DAL_CTBC
    {
        public static void Them(CTBCDoanhThu bc)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_CTBC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgayKham", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SoBenhNhan", SqlDbType.Int);
            cmd.Parameters.Add("@DoanhThu", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TyLe", SqlDbType.Int);
            cmd.Parameters["@Thang"].Value = bc.Thang;
            cmd.Parameters["@NgayKham"].Value = bc.NgayKham;
            cmd.Parameters["@SoBenhNhan"].Value = bc.SoBenhNhan;
            cmd.Parameters["@DoanhThu"].Value = bc.DoanhThu;
            cmd.Parameters["@TyLe"].Value = bc.TyLe;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
