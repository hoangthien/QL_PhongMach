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
    public class DAL_NhapThuoc
    {
        public static void Them(PhieuNhapThuoc nt)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_PNT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayNhap", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TongTien", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);

            cmd.Parameters["@NgayNhap"].Value = nt.NgayNhap;
            cmd.Parameters["@TongTien"].Value = nt.TongTien;
            cmd.Parameters["@Thang"].Value = nt.Thang;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void ThemChiTiet(CTNhapThuoc ct)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_CTNT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPhieu", SqlDbType.Int);
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@ThanhTien", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MaPhieu"].Value = ct.MaPhieu;
            cmd.Parameters["@MaThuoc"].Value = ct.MaThuoc;
            cmd.Parameters["@SoLuong"].Value = ct.SoLuong;
            cmd.Parameters["@ThanhTien"].Value = ct.ThanhTien;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static string LayMaPhieu()
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_MAPNT", con);
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

        public static string LayMaThuoc(string tt)
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_MATHUOC", con);
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

        public static DataTable LayDuLieu(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_BCPNT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Thang"].Value = t;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
