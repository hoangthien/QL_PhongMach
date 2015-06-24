using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLPhongMach
{
    public partial class frmDoiMatKhau : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Lầy dữ liệu từ các textbox
            string MKCu = txtMKCu.Text.Trim();
            string MKMoi = txtMKMoi.Text.Trim();
            string NhapLaiMK = txtNhapLaiMK.Text.Trim();
            //Kiểm tra dữ liệu trước khi đổi mật khẩu
            if (MKCu != "" && MKMoi != "" && NhapLaiMK != "")
            {
                if (MKMoi != NhapLaiMK)
                {
                    lblThongBao.Text = "Mật khẩu xác nhận không đúng";
                }
                else
                {
                    MKCu = TroGiup.Md5(MKCu);
                    MKMoi = TroGiup.Md5(MKMoi);
                    if (NguoiDung.DoiMatKhau(PhanQuyen.TenDangNhap, MKMoi, MKCu) > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công");
                        PhanQuyen.ChucVu = "";
                        PhanQuyen.TenDangNhap = "";
                        frmMain f = new frmMain();
                        f.OnOff(this.ParentForm);
                        this.Close();
                    }
                    else
                    {
                        lblThongBao.Text = "Đổi mật khẩu bị lỗi";
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNhapLaiMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lầy dữ liệu từ các textbox
            string MKCu = txtMKCu.Text.Trim();
            string MKMoi = txtMKMoi.Text.Trim();
            string NhapLaiMK = txtNhapLaiMK.Text.Trim();
            //Kiểm tra dữ liệu trước khi đổi mật khẩu
            if (MKCu != "" && MKMoi != "" && NhapLaiMK != "")
            {
                if (MKMoi != NhapLaiMK)
                {
                    lblThongBao.Text = "Mật khẩu xác nhận không đúng";
                }
                else
                {
                    MKCu = TroGiup.Md5(MKCu);
                    MKMoi = TroGiup.Md5(MKMoi);
                    if (NguoiDung.DoiMatKhau(PhanQuyen.TenDangNhap, MKMoi, MKCu) > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công");
                        PhanQuyen.ChucVu = "";
                        PhanQuyen.TenDangNhap = "";
                        frmMain f = new frmMain();
                        f.OnOff(this.ParentForm);
                        this.Close();
                    }
                    else
                    {
                        lblThongBao.Text = "Đổi mật khẩu bị lỗi";
                    }
                }
            }
        }

    }
}
