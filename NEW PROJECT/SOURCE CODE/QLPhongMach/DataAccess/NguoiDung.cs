using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace QLPhongMach
{
    class NguoiDung
    {
        //Thêm người dùng mới
        public static void ThemNguoiDung(string TenND, string NgaySinh, int GioiTinh, string DiaChi, string SDT, string TenDangNhap, string MatKhau, string ChucVu)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "insert NguoiDung(TenND,NgaySinh,GioiTinh ,DiaChi ,SDT ,TenDangNhap,MatKhau,ChucVu) values(N'" + TenND + "','" + NgaySinh + "'," + GioiTinh + ",N'" + DiaChi + "','" + SDT + "','" + TenDangNhap + "','" + MatKhau + "',N'" + ChucVu + "')";
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Xóa người dùng
        public static void XoaNguoiDung(string TenDangNhap)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Delete from NguoiDung where TenDangNhap = '" + TenDangNhap + "'";
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Cập nhật thông tin người dùng
        public static void CapNhatThongTin(string TenDangNhap, string TenND, string NgaySinh, int GioiTinh, string DiaChi, string SDT)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Update NguoiDung set TenND = N'" + TenND + "', NgaySinh = '" + NgaySinh + "',GioiTinh = " + GioiTinh + ", DiaChi = N'" + DiaChi + "', SDT = '" + SDT + "' where TenDangNhap = '" + TenDangNhap + "'";
                dl.CapNhatDuLieu(sqlString);
            }
        }
        //Lấy thông tin người dùng dựa vào tenDN
        public static ChiTietNguoiDung LayThongTin(string TenDangNhap)
        {
            ChiTietNguoiDung nd = new ChiTietNguoiDung();
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Select TenND, NgaySinh, GioiTinh, DiaChi, SDT, TenDangNhap, ChucVu from NguoiDung where TenDangNhap = '" + TenDangNhap + "'";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    nd = new ChiTietNguoiDung(0, dr["TenDangNhap"].ToString(), dr["ChucVu"].ToString(), dr["TenND"].ToString(), dr["NgaySinh"].ToString(), (bool)dr["GioiTinh"], dr["DiaChi"].ToString(), dr["SDT"].ToString());
                }
                dl.DongKetNoi();
            }
            return nd;
        }
        //Lấy dữ liệu của người dùng
        public static List<ChiTietNguoiDung> LayDSNguoiDung()
        {
            List<ChiTietNguoiDung> nd = new List<ChiTietNguoiDung>();
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Select row_number() over(order by TenND) as STT, TenND,ChucVu, NgaySinh, GioiTinh, DiaChi, SDT, TenDangNhap from NguoiDung";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                while (dr.Read())
                {
                    nd.Add(new ChiTietNguoiDung(int.Parse(dr["STT"].ToString()), dr["TenDangNhap"].ToString(), dr["ChucVu"].ToString(), dr["TenND"].ToString(), dr["NgaySinh"].ToString(), (bool)dr["GioiTinh"], dr["DiaChi"].ToString(), dr["SDT"].ToString()));
                }
                dl.DongKetNoi();
            }
            return nd;
        }
        //Đổi mật khẩu mới cho người dùng
        public static int DoiMatKhau(string TenDangNhap, string MatKhauMoi, string MatKhauCu)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "Update NguoiDung set MatKhau = '" + MatKhauMoi + "' where TenDangNhap = '" + TenDangNhap + "' and MatKhau = '" + MatKhauCu + "'";
                return dl.CapNhatDuLieu(sqlString);
            }
            return 0;
        }
        //Kiểm tra đăng nhập
        public static ChiTietNguoiDung KTDangNhap(string TenDangNhap, string MatKhau)
        {
            DuLieu dl = new DuLieu();
            if (dl.MoKetNoi())
            {
                string sqlString = "select MaND, TenDangNhap,ChucVu from NguoiDung where TenDangNhap = '" + TenDangNhap + "' and MatKhau = '" + MatKhau + "'";
                SqlDataReader dr = dl.LayDuLieu(sqlString);
                if (dr.Read())
                {
                    return new ChiTietNguoiDung(0, dr["TenDangNhap"].ToString(), dr["ChucVu"].ToString(), "", "", true, "", "");
                }
            }
            return null;
        }
    }
}
