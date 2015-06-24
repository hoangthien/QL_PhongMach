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
    public class DAL_ToaThuoc
    {
        public static void ThemMoi(ToaThuoc t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_TT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayKeToa", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@MaPK", SqlDbType.Int);
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);

            cmd.Parameters["@NgayKeToa"].Value = t.Thang;
            cmd.Parameters["@MaBN"].Value = t.MaBN;
            cmd.Parameters["@MaPK"].Value = t.MaPK;
            cmd.Parameters["@Thang"].Value = t.ThangToa;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Sua(ToaThuoc t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_TT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaToa", SqlDbType.Int);
            cmd.Parameters.Add("@NgayKeToa", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@MaPK", SqlDbType.Int);
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MaToa"].Value = t.MaToa;
            cmd.Parameters["@NgayKeToa"].Value = t.Thang;
            cmd.Parameters["@MaBN"].Value = t.MaBN;
            cmd.Parameters["@MaPK"].Value = t.MaPK;
            cmd.Parameters["@Thang"].Value = t.ThangToa;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Xoa(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("DELETE_TT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaToa", SqlDbType.Int);
            cmd.Parameters["@MaToa"].Value = t;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void XoaMaPK(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("DELETE_TT_PK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPK", SqlDbType.Int);
            cmd.Parameters["@MaPK"].Value = t;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static string LayMaToa()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_MATOA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                t = dr[0].ToString();
            }
            con.Close();
            return t;
        }

        public static string MaToa(string pk)
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_MATOA_PK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPK", SqlDbType.Int);
            cmd.Parameters["@MaPK"].Value = int.Parse(pk);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                t = dr[0].ToString();
            }
            con.Close();
            return t;
        }
    }
}
