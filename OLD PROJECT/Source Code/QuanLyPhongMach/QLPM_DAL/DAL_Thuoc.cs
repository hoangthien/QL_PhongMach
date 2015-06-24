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
    public class DAL_Thuoc
    {
        public static void ThemMoi(Thuoc t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_TH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DonVi", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DonGia", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.Int);

            cmd.Parameters["@TenThuoc"].Value = t.TenThuoc;
            cmd.Parameters["@DonVi"].Value = t.DonVi;
            cmd.Parameters["@DonGia"].Value = t.DonGia;
            cmd.Parameters["@SoLuongTon"].Value = t.SoLuongTon;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Sua(Thuoc t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_TH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DonVi", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DonGia", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.Int);

            cmd.Parameters["@MaThuoc"].Value = t.MaThuoc;
            cmd.Parameters["@TenThuoc"].Value = t.TenThuoc;
            cmd.Parameters["@DonVi"].Value = t.DonVi;
            cmd.Parameters["@DonGia"].Value = t.DonGia;
            cmd.Parameters["@SoLuongTon"].Value = t.SoLuongTon;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Xoa(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("DELETE_TH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters["@MaThuoc"].Value = t;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateSLTon(string t, int sl)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_SLT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.Int);
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters["@SoLuongTon"].Value = sl;
            cmd.Parameters["@TenThuoc"].Value = t;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable LayDuLieu()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_TH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LayTenThuoc()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_TENTH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LayDonVi(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_TH_DV", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters["@MaThuoc"].Value = int.Parse(t);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string LayDonGia()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_TH_SL", con);
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

        public static string LaySoLuongTon()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_TH_SL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                t = dr[1].ToString();
            }
            con.Close();
            return t;
        }

        public static string LaySoThuoc()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_SOTHUOC", con);
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
    }
}
