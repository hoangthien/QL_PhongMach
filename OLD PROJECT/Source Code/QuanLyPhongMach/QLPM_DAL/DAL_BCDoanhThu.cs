using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using System.Data;
using System.Data.SqlClient;

namespace QLPM_DAL
{
    public class DAL_BCDoanhThu
    {
        public static void Them(BCDoanhThu bc)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("INSERT_BCDT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TongDoanhThu", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Thang"].Value = bc.Thang;
            cmd.Parameters["@TongDoanhThu"].Value = bc.TongDoanhThu;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable LayDuLieu(string t)
        {
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_THANG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Thang", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Thang"].Value = t;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string LayDoanhThu(string th)
        {
            string t = null;
            SqlConnection con = sqlConnectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SELECT_HD_TIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Ngay", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Ngay"].Value = th;
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
