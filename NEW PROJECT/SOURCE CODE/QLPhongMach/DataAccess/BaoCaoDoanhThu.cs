using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QLPhongMach
{
    class BaoCaoDoanhThu
    {
        //Lấy dữ liệu cho form báo cáo doanh thu
        public static List<ChiTietBaoCaoDoanhThu> LayDuLieu(int thang, int nam)
        {
            SqlConnection conn;
            conn = new SqlConnection(DuLieu.constring);
            List<ChiTietBaoCaoDoanhThu> bc = new List<ChiTietBaoCaoDoanhThu>();
            SqlCommand cmd = new SqlCommand("BCDoanhThu", conn);
            //Lấy dữ liệu từ storedProce
            cmd.CommandType = CommandType.StoredProcedure;
            //Các parameter cua proce
            cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    bc.Add(new ChiTietBaoCaoDoanhThu(int.Parse(dr["STT"].ToString()), dr["NgayKham"].ToString(), (int)dr["SoBN"], (int)dr["DoanhThu"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return bc;
        }
        
    }
}
