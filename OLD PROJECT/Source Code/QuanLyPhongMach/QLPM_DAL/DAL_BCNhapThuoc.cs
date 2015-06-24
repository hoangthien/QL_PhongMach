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
    public class DAL_BCNhapThuoc
    {
        public static void Them(BCNhapThuoc bc)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_BCNTH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgayNhap", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@ThanhTien", SqlDbType.NVarChar, 50);

            cmd.Parameters["@Thang"].Value = bc.Thang;
            cmd.Parameters["@NgayNhap"].Value = bc.NgayNhap;
            cmd.Parameters["@TenThuoc"].Value = bc.TenThuoc;
            cmd.Parameters["@SoLuong"].Value = bc.SoLuong;
            cmd.Parameters["@ThanhTien"].Value = bc.ThanhTien;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
