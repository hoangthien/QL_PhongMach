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
    public partial class frmHoaDonThanhToan : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmHoaDonThanhToan()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            ChiTietHoaDon dh = HoaDon.LayHoaDon(frmPhieuKhamBenh.MaPK);
            txtHoTen.Text = dh.TenBN;
            txtTienKham.Text = dh.TienKham.ToString();
            txtTienThuoc.Text = dh.TienThuoc.ToString();
        }
        int tienThuoc;
        private void frmHoaDonThanhToan_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            LoadData();
            tienThuoc = int.Parse(txtTienThuoc.Text.ToString());
            if (tienThuoc == 0)
            {
                ckbSuDungThuoc.Checked = false;
            }
        }

        private void ckbSuDungThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSuDungThuoc.Checked == true)
            {
                txtTienThuoc.Text = tienThuoc.ToString();
            }
            else
            {
                txtTienThuoc.Text = "0";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon.CapNhapHoaDon(frmPhieuKhamBenh.MaPK, int.Parse(txtTienThuoc.Text), int.Parse(txtTienKham.Text));
                this.Close();
            }
            catch
            {
                lblThongBao.Text = "Dữ liệu nhập vào không hợp lệ";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
