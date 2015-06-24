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
    public class DAL_BCThuoc
    {
        public static void Them(BCThuoc bc)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_BCTHUOC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DonVi", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@SoLanDung", SqlDbType.Int);

            cmd.Parameters["@Thang"].Value = bc.Thang;
            cmd.Parameters["@TenThuoc"].Value = bc.TenThuoc;
            cmd.Parameters["@DonVi"].Value = bc.DonVi;
            cmd.Parameters["@SoLuong"].Value = bc.SoLuong;
            cmd.Parameters["@SoLanDung"].Value = bc.SoLanDung;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable LayDuLieu(string th)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_BCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Thang"].Value = th;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string LaySoLuong(string ten, string thang)
        {
            string tt = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_SL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenThuoc"].Value = ten;
            cmd.Parameters["@Thang"].Value = thang;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tt = dr[0].ToString();
            }
            con.Close();
            return tt;
        }

        public static string LaySoLan(string ten)
        {
            string tt = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_SLD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenThuoc"].Value = ten;
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
