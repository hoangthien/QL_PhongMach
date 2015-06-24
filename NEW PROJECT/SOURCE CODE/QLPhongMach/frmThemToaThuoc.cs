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
    public partial class frmThemToaThuoc : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmThemToaThuoc()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemToaThuoc_Load(object sender, EventArgs e)
        {
            cbxThuoc.DataSource = Thuoc.LayThuoc(0, Thuoc.DemThuoc());
            cbxThuoc.ValueMember = "MaThuoc";
            cbxThuoc.DisplayMember = "TenThuoc";
            txtDonVi.Text = Thuoc.LayDonViThuoc((int)cbxThuoc.SelectedValue);
            lblThongBao.Text = "";
        }

        private void cbxThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDonVi.Text = Thuoc.LayDonViThuoc((int)cbxThuoc.SelectedValue);
            }
            catch
            { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtCachDung.Text.Trim() != "" && txtSoLuong.Text.Trim() != "")
            {
                try
                {
                    int SoLuong = int.Parse(txtSoLuong.Text);//Kiểm tra tính đúng đắn của số lượng nhập vào
                    try
                    {
                        int MaPK = frmPhieuKhamBenh.MaPK;
                        int MaThuoc = (int)cbxThuoc.SelectedValue;
                        string CachDung = txtCachDung.Text;
                        ToaThuoc.ThemDuLieu(MaPK, MaThuoc, SoLuong, CachDung);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    catch
                    {
                        lblThongBao.Text = "Không thể thêm dữ liệu";
                    }
                }
                catch
                {
                    lblThongBao.Text = "Số lượng phải là một số nguyên";
                    txtSoLuong.Clear();
                    txtSoLuong.Focus();
                }
            }
            else
            {
                lblThongBao.Text = "Chưa nhập đủ dữ liệu";
                txtCachDung.Focus();
            }
        }

        
    }
}
