using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using System.Data.SqlClient;

namespace QLPM_DAL
{
    public class DAL_HoaDon
    {
        public static void ThemMoi(HoaDon hd)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_HD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayBan", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TienThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@MaToa", SqlDbType.Int);
            cmd.Parameters["@NgayBan"].Value = hd.Thang;
            cmd.Parameters["@TienThuoc"].Value = hd.TienThuoc;
            cmd.Parameters["@MaToa"].Value = hd.MaToa;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Sua(HoaDon hd)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_HD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHD", SqlDbType.Int);
            cmd.Parameters.Add("@NgayBan", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TienThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@MaToa", SqlDbType.Int);
            cmd.Parameters["@MaHD"].Value = hd.MaHD;
            cmd.Parameters["@NgayBan"].Value = hd.Thang;
            cmd.Parameters["@TienThuoc"].Value = hd.TienThuoc;
            cmd.Parameters["@MaToa"].Value = hd.MaToa;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Xoa(string hd)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("DELETE_HD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHD", SqlDbType.Int);
            cmd.Parameters["@MaHD"].Value = hd;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable LayDuLieu()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_HD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable ThongTinToa(string t, string ng)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_HD_TT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgayKham", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBN"].Value = t;
            cmd.Parameters["@NgayKham"].Value = ng;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;   
        }

        public static string LayMaToa(string t, string ng)
        {
            string toa = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_HD_MATOA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgayKham", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBN"].Value = t;
            cmd.Parameters["@NgayKham"].Value = ng;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                toa = dr[0].ToString();
            }
            con.Close();
            return toa;
        }
    }
}
