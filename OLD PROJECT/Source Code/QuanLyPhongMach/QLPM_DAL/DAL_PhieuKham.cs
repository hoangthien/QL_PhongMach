using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using System.Data;

namespace QLPM_DAL
{
    public class DAL_PhieuKham
    {
        public static void ThemMoi(PhieuKham pk)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_PK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayKham", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TrieuChung", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@ChuanDoan", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TienKham", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);

            cmd.Parameters["@NgayKham"].Value = pk.NgayKham;
            cmd.Parameters["@TrieuChung"].Value = pk.TrieuChung;
            cmd.Parameters["@ChuanDoan"].Value = pk.ChuanDoan;
            cmd.Parameters["@TienKham"].Value = pk.TienKham;
            cmd.Parameters["@MaBN"].Value = pk.MaBN;
            cmd.Parameters["@Thang"].Value = pk.Thang;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Sua(PhieuKham pk)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_PK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPK", SqlDbType.Int);
            cmd.Parameters.Add("@NgayKham", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TrieuChung", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@ChuanDoan", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TienKham", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MaPK"].Value = pk.MaPK;
            cmd.Parameters["@NgayKham"].Value = pk.NgayKham;
            cmd.Parameters["@TrieuChung"].Value = pk.TrieuChung;
            cmd.Parameters["@ChuanDoan"].Value = pk.ChuanDoan;
            cmd.Parameters["@TienKham"].Value = pk.TienKham;
            cmd.Parameters["@MaBN"].Value = pk.MaBN;
            cmd.Parameters["@Thang"].Value = pk.Thang;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Xoa(string pk)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("DELETE_PK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPK", SqlDbType.Int);
            cmd.Parameters["@MaPK"].Value = pk;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static string LayMaPK()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_MAPK", con);
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

        public static DataTable LayDuLieu()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_PK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LayThongTinBN()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_PK_BN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LayToa(int t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_PK_TOA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPK", SqlDbType.Int);
            cmd.Parameters["@MaPK"].Value = t;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string LayTenThuoc(string t)
        {
            string tt = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_PK_TH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPK", SqlDbType.Int);
            cmd.Parameters["@MaPK"].Value = t;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tt = dr[0].ToString();
            }
            con.Close();
            return tt;
        }

        public static DataTable LayNgay(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_PK_NG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBN"].Value = t;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string LaySoBenhNhan(string t)
        {
            string tt = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_SOBN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayKham", SqlDbType.NVarChar, 50);
            cmd.Parameters["@NgayKham"].Value = t;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tt = dr[0].ToString();
            }
            con.Close();
            return tt;
        }
    }
}
