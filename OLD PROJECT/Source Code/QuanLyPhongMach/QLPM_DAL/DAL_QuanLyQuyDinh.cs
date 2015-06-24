using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLPM_Entity;
using System.Data.SqlClient;

namespace QLPM_DAL
{
    public class DAL_QuanLyQuyDinh
    {
        public static void SuaBenhNhanToiDa(string ts)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_MAXBN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BNMax", SqlDbType.NVarChar, 50);
            cmd.Parameters["@BNMax"].Value = ts;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SuaThuocToiDa(string ts)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_LOAITHUOC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoaiThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters["@LoaiThuoc"].Value = ts;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SuaTienKham(string ts)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_TIENKHAM", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TienKham", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TienKham"].Value = ts;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SuaLoaiBenh(string ts)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_LOAIBENH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoaiBenh", SqlDbType.NVarChar, 50);
            cmd.Parameters["@LoaiBenh"].Value = ts;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SuaDonVi(string ts)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_DONVI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DonVi", SqlDbType.NVarChar, 50);
            cmd.Parameters["@DonVi"].Value = ts;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SuaCachDung(string ts)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_CACHDUNG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CachDung", SqlDbType.NVarChar, 50);
            cmd.Parameters["@CachDung"].Value = ts;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static string LayBNMax()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_MAXBN", con);
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

        public static DataTable LayLoaiBenh()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_LOAIBENH", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string LayLoaiThuoc()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_LOAITHUOC", con);
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

        public static DataTable LayDonVi()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_DONVI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LayCachDung()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_CACHDUNG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string LayTienKham()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_TIENKHAM", con);
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
