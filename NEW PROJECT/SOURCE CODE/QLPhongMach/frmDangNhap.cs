using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QLPhongMach
{
    public partial class frmDangNhap : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtNguoiDung.Focus();
            lbtTB.Text = "";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Kiểm tra tính đúng đắn khi đăng nhập hệ thống
            if (txtMatKhau.Text != "" && txtNguoiDung.Text != "")
            {
                string MatKhau = TroGiup.Md5(txtMatKhau.Text.Trim());
                ChiTietNguoiDung nd = NguoiDung.KTDangNhap(txtNguoiDung.Text.Trim(), MatKhau);
                if (nd != null)
                {

                    PhanQuyen.TenDangNhap = nd.TenDangNhap;
                    PhanQuyen.ChucVu = nd.ChucVu;
                    MessageBox.Show("Đăng nhập thành công");
                    frmMain f = new frmMain();
                    f.OnOff(this.ParentForm);
                    //this.DialogResult = DialogResult.OK;////Luu lại kết quả để form chính gọi
                    this.Close();
                }
                else
                {
                    txtMatKhau.Clear();
                    txtNguoiDung.Clear();
                    txtNguoiDung.Focus();
                    lbtTB.Text = "Đăng nhập bị lỗi!!";//Hiển thị thông báo lỗi
                }
            }
            else
            {
                txtMatKhau.Clear();
                txtNguoiDung.Clear();
                txtNguoiDung.Focus();
                lbtTB.Text = "Vui lòng nhập đầy đủ thông tin";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //Kiểm tra tính đúng đắn khi đăng nhập hệ thống
                if (txtMatKhau.Text != "" && txtNguoiDung.Text != "")
                {
                    string MatKhau = TroGiup.Md5(txtMatKhau.Text.Trim());
                    ChiTietNguoiDung nd = NguoiDung.KTDangNhap(txtNguoiDung.Text.Trim(), MatKhau);
                    if (nd != null)
                    {

                        PhanQuyen.TenDangNhap = nd.TenDangNhap;
                        PhanQuyen.ChucVu = nd.ChucVu;
                        MessageBox.Show("Đăng nhập thành công");
                        frmMain f = new frmMain();
                        f.OnOff(this.ParentForm);
                        //this.DialogResult = DialogResult.OK;////Luu lại kết quả để form chính gọi
                        this.Close();
                    }
                    else
                    {
                        txtMatKhau.Clear();
                        txtNguoiDung.Clear();
                        txtNguoiDung.Focus();
                        lbtTB.Text = "Đăng nhập bị lỗi!!";//Hiển thị thông báo lỗi
                    }
                }
                else
                {
                    txtMatKhau.Clear();
                    txtNguoiDung.Clear();
                    txtNguoiDung.Focus();
                    lbtTB.Text = "Vui lòng nhập đầy đủ thông tin";
                }
            }
        }
    }
}