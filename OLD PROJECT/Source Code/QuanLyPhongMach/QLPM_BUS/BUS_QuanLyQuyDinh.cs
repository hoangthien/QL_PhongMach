using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPM_Entity;
using QLPM_DAL;
using System.Data;

namespace QLPM_BUS
{
    public class BUS_QuanLyQuyDinh
    {
        public static void SuaBenhNhanToiDa(string ts)
        {
            DAL_QuanLyQuyDinh.SuaBenhNhanToiDa(ts);
        }

        public static void SuaThuocToiDa(string ts)
        {
            DAL_QuanLyQuyDinh.SuaThuocToiDa(ts);
        }

        public static void SuaTienKham(string ts)
        {
            DAL_QuanLyQuyDinh.SuaTienKham(ts);
        }

        public static void SuaLoaiBenh(string ts)
        {
            DAL_QuanLyQuyDinh.SuaLoaiBenh(ts);
        }

        public static void SuaDonVi(string ts)
        {
            DAL_QuanLyQuyDinh.SuaDonVi(ts);
        }

        public static void SuaCachDung(string ts)
        {
            DAL_QuanLyQuyDinh.SuaCachDung(ts);
        }

        public static string LayBNMax()
        {
            return DAL_QuanLyQuyDinh.LayBNMax();
        }

        public static DataTable LayLoaiBenh()
        {
            return DAL_QuanLyQuyDinh.LayLoaiBenh();
        }

        public static string LayLoaiThuoc()
        {
            return DAL_QuanLyQuyDinh.LayLoaiThuoc();
        }

        public static DataTable LayDonVi()
        {
            return DAL_QuanLyQuyDinh.LayDonVi();
        }

        public static DataTable LayCachDung()
        {
            return DAL_QuanLyQuyDinh.LayCachDung();
        }

        public static string LayTienKham()
        {
            return DAL_QuanLyQuyDinh.LayTienKham();
        }
    }
}
