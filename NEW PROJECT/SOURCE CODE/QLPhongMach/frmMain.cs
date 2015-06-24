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
    public partial class frmMain : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public void OnOff(Form frm)
        {
            frmMain f = (frmMain)frm;
            switch (PhanQuyen.ChucVu)
            {
                case "Admin":
                    {
                        f.menuDangNhap.Enabled = false;
                        f.menuQuanLy.Enabled = true;
                        f.menuThongKe.Enabled = true;
                        f.menuTimKiem.Enabled = true;
                        f.menuDoiMK.Enabled = true;
                        f.menuDangXuat.Enabled = true;
                        f.menuDoiThongTin.Enabled = true;
                        f.menuSoSach.Enabled = true;
                    } break;
                case "Điều Hành":
                    {
                        f.menuDangNhap.Enabled = false;
                        f.menuQuanLy.Enabled = false;
                        f.menuThongKe.Enabled = true;
                        f.menuTimKiem.Enabled = true;
                        f.menuDoiMK.Enabled = true;
                        f.menuDangXuat.Enabled = true;
                        f.menuDoiThongTin.Enabled = true;
                        f.menuSoSach.Enabled = true;
                    } break;
                default:
                    {
                        f.menuDangNhap.Enabled = true;
                        f.menuQuanLy.Enabled = false;
                        f.menuThongKe.Enabled = false;
                        f.menuTimKiem.Enabled = false;
                        f.menuDoiMK.Enabled = false;
                        f.menuDangXuat.Enabled = false;
                        f.menuDoiThongTin.Enabled = false;
                        f.menuSoSach.Enabled = false;
                    } break;

            }

        }

        private void menuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            //Dóng tất cả các form đang mở
            foreach (Form frm in this.MdiChildren)
                frm.Close();
            PhanQuyen.ChucVu = "";
            PhanQuyen.TenDangNhap = "";
            OnOff(this);
        }

        private void menuDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuDoiThongTin_Click(object sender, EventArgs e)
        {
            frmCapNhatThongTinND frm = new frmCapNhatThongTinND();
            frm.ShowDialog();
        }

        private void menuDong_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuNguoiDung_Click(object sender, EventArgs e)
        {
            frmQLNguoiDung frm = new frmQLNguoiDung();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuDSKhamBenh_Click(object sender, EventArgs e)
        {
            frmDanhSachKhamBenh frm = new frmDanhSachKhamBenh();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuPhieuKhamBenh_Click(object sender, EventArgs e)
        {
            frmPhieuKhamBenh frm = new frmPhieuKhamBenh();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuThuoc_Click(object sender, EventArgs e)
        {
            frmQLThuoc frm = new frmQLThuoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuBenhNhan_Click(object sender, EventArgs e)
        {

            frmDanhSachBenhNhan frm = new frmDanhSachBenhNhan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuHuongDan_Click(object sender, EventArgs e)
        {
            frmHuongDanSuDung frm = new frmHuongDanSuDung();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OnOff(this);
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                statusStrip1.Items[0].Text = this.ActiveMdiChild.Text;
            else
                statusStrip1.Items[0].Text = "Chương trình quản lý phòng mạch tư";
        }



        //private void menuDoanhThu_Click(object sender, EventArgs e)
        //{

        //}

        //private void menuSDThuoc_Click(object sender, EventArgs e)
        //{

        //}
    }
}
