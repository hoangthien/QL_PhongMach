using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;

namespace QLPhongMach
{
    class TroGiup
    {
        //Lấy ra chỉ số trang hiện hành
        public static int PageIndex(int startRowIndex, int maxRows)
        {
            if (maxRows <= 0)
                return 0;
            return (int)Math.Floor((double)(startRowIndex) / (double) maxRows);
        }
        //Lấy ra số trang
        public static int GetPage(int pageSize, int pageCount)
        {
            if (pageCount < 0)
                return 0;
            return (pageCount % pageSize == 0) ? (pageCount / pageSize) - 1 : (int)Math.Floor((double)(pageCount/pageSize));
        }
        public static int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);//Kich thuoc trang chua bao nhieu phan tu con
        public static int soBNToiDa = int.Parse(ConfigurationManager.AppSettings["SoBenhNhan"]);
        //Hàm cập nhật số bệnh nhân xuống file config
        public static bool CapNhapSoBenhNhanToiDa(int soBN)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["SoBenhNhan"].Value = soBN.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                soBNToiDa = int.Parse(ConfigurationManager.AppSettings["SoBenhNhan"]);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Hàm mã hóa mật khẩu
        public static string Md5(string passWord)
        {
            MD5 md = MD5.Create();
            byte[] arr = Encoding.ASCII.GetBytes(passWord);
            byte[] hash = md.ComputeHash(arr);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }   

}
