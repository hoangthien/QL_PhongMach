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
    public class sqlConnectionData
    {
        public static SqlConnection KetNoi()
        {
            SqlConnection con = new SqlConnection("Data Source=NHULQ;Initial Catalog=QLPhongMach;Integrated Security=True");
            return con;
        }
    }

    public class DAL_BenhNhan
    {
        public static void ThemMoi(BenhNhan bn)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_BN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgaySinh", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SDT", SqlDbType.NChar, 11);

            cmd.Parameters["@TenBN"].Value = bn.TenBN;
            cmd.Parameters["@NgaySinh"].Value = bn.NgaySinh;
            cmd.Parameters["@GioiTinh"].Value = bn.GioiTinh;
            cmd.Parameters["@DiaChi"].Value = bn.DiaChi;
            cmd.Parameters["@SDT"].Value = bn.SDT;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Sua(BenhNhan bn)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("UPDATE_BN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgaySinh", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SDT", SqlDbType.NChar, 11);

            cmd.Parameters["@MaBN"].Value = bn.MaBN;
            cmd.Parameters["@TenBN"].Value = bn.TenBN;
            cmd.Parameters["@NgaySinh"].Value = bn.NgaySinh;
            cmd.Parameters["@GioiTinh"].Value = bn.GioiTinh;
            cmd.Parameters["@DiaChi"].Value = bn.DiaChi;
            cmd.Parameters["@SDT"].Value = bn.SDT;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Xoa(string bn)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("DELETE_BN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters["@MaBN"].Value = bn;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable LayDuLieu()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_BN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LayDS()
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_PK_DS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable TimBenhNhan(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SEARCH_BN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBN"].Value = t;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable TimNgay(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SEARCH_NG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayKham", SqlDbType.NVarChar, 50);
            cmd.Parameters["@NgayKham"].Value = t;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
