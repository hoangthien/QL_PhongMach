using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace QLPhongMach
{
    class DuLieu
    {
        SqlConnection conn;
        //Chuỗi kết nối
        public static readonly string constring = ConfigurationManager.ConnectionStrings["conectionString"].ConnectionString;

        public bool MoKetNoi()
        {
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DongKetNoi()
        {
            conn.Close();
        }
        
        //Lấy dữ liệu câu truy vấn sqlString
        public SqlDataReader LayDuLieu(string sqlString)
        {
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        //Cập nhật (thêm, xóa, sửa) dữ liệu theo câu truy vấn sqlString
        public int CapNhatDuLieu(string sqlString)
        {
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            int ret = cmd.ExecuteNonQuery();
            DongKetNoi();
            return ret;
        }
    }
}
