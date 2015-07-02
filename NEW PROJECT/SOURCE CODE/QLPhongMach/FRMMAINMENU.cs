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
    public partial class FRMMAINMENU : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FRMMAINMENU()
        {
            InitializeComponent();
        }

        public void OnOff(Form frm)
        {
            FRMMAINMENU f = (FRMMAINMENU)frm;
            switch (PhanQuyen.ChucVu)
            {
                case "Admin":
                    {
                        f.btnDangNhap.Enabled = false;
                        f.btnDangXuat.Enabled = true;
                        f.btnDoiMatKhau.Enabled = true;
                        f.btnThayDoiThongTinCaNhan.Enabled = true;
                        f.btnQLNguoiDung.Enabled = true;
                        f.btnSuDungThuoc.Enabled = true;
                        f.btnDoanhThu.Enabled = true;
                        f.btBenhNhan.Enabled = true;
                        f.btnPhieuKham.Enabled = true;
                        f.btnHoaDonThanhToan.Enabled = true;
                        f.btnTimKiemBN.Enabled = true;
                        f.btnThuoc.Enabled = true;
                        f.btnToaThuoc.Enabled = true;
                    } break;
                case "Điều Hành":
                    {
                        f.btnDangNhap.Enabled = false;
                        f.btnDangXuat.Enabled = true;
                        f.btnDoiMatKhau.Enabled = true;
                        f.btnThayDoiThongTinCaNhan.Enabled = true;
                        f.btnQLNguoiDung.Enabled = false;
                        f.btnSuDungThuoc.Enabled = false;
                        f.btnDoanhThu.Enabled = false;
                        f.btBenhNhan.Enabled = true;
                        f.btnPhieuKham.Enabled = true;
                        f.btnHoaDonThanhToan.Enabled = true;
                        f.btnTimKiemBN.Enabled = true;
                        f.btnThuoc.Enabled = true;
                        f.btnToaThuoc.Enabled = true;
                    } break;
                default:
                    {
                        f.btnDangNhap.Enabled = true;
                        f.btnDangXuat.Enabled = false;
                        f.btnDoiMatKhau.Enabled = false;
                        f.btnThayDoiThongTinCaNhan.Enabled = false;
                        f.btnQLNguoiDung.Enabled = false;
                        f.btnSuDungThuoc.Enabled = false;
                        f.btnDoanhThu.Enabled = false;
                        f.btBenhNhan.Enabled = false;
                        f.btnPhieuKham.Enabled = false;
                        f.btnHoaDonThanhToan.Enabled = false;
                        f.btnTimKiemBN.Enabled = false;
                        f.btnThuoc.Enabled = false;
                        f.btnToaThuoc.Enabled = false;
                    } break;
            }

        }

        private void FRMMAINMENU_Load(object sender, EventArgs e)
        {
            OnOff(this);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //Dóng tất cả các form đang mở
            foreach (Form frm in this.MdiChildren)
                frm.Close();
            PhanQuyen.ChucVu = "";
            PhanQuyen.TenDangNhap = "";
            OnOff(this);
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnThayDoiThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmCapNhatThongTinND frm = new frmCapNhatThongTinND();
            frm.ShowDialog();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btBenhNhan_Click(object sender, EventArgs e)
        {
            frmDanhSachKhamBenh frm = new frmDanhSachKhamBenh();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPhieuKham_Click(object sender, EventArgs e)
        {
            frmPhieuKhamBenh frm = new frmPhieuKhamBenh();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnThuoc_Click(object sender, EventArgs e)
        {
            frmQLThuoc frm = new frmQLThuoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnToaThuoc_Click(object sender, EventArgs e)
        {
            frmThemToaThuoc frm = new frmThemToaThuoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnSuDungThuoc_Click(object sender, EventArgs e)
        {

            frmBaoCaoThuoc frm = new frmBaoCaoThuoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            frmBCDoanhThuTheoNgay frm = new frmBCDoanhThuTheoNgay();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnHuongDanSuDung_Click(object sender, EventArgs e)
        {
            frmHuongDanSuDung frm = new frmHuongDanSuDung();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnHoaDonThanhToan_Click(object sender, EventArgs e)
        {
            frmHoaDonThanhToan frm = new frmHoaDonThanhToan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnTimKiemBN_Click(object sender, EventArgs e)
        {
            frmDanhSachBenhNhan frm = new frmDanhSachBenhNhan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnQLNguoiDung_Click(object sender, EventArgs e)
        {

            frmQLNguoiDung frm = new frmQLNguoiDung();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
