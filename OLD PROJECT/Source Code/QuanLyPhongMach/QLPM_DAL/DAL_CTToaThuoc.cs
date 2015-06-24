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
    public class DAL_CTToaThuoc
    {
        public static void ThemMoi(ChiTietToaThuoc t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_CTTT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaToa", SqlDbType.Int);
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@CachDung", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MaToa"].Value = t.MaToa;
            cmd.Parameters["@MaThuoc"].Value = t.MaThuoc;
            cmd.Parameters["@SoLuong"].Value = t.SoLuong;
            cmd.Parameters["@CachDung"].Value = t.CachDung;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Sua(ChiTietToaThuoc t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_CTTT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaToa", SqlDbType.Int);
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@CachDung", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MaToa"].Value = t.MaToa;
            cmd.Parameters["@MaThuoc"].Value = t.MaThuoc;
            cmd.Parameters["@SoLuong"].Value = t.SoLuong;
            cmd.Parameters["@CachDung"].Value = t.CachDung;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Xoa(string th)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("DELETE_CTTT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaToa", SqlDbType.Int);
            cmd.Parameters["@MaToa"].Value = th;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static string DemThuoc()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_CTTT_C", con);
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

        public static string LaySLTon(string tt)
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_CTTT_SL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenThuoc"].Value = tt;
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
