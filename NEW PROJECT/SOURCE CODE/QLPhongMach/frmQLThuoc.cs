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
    public partial class frmQLThuoc : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmQLThuoc()
        {
            InitializeComponent();
        }
        private int pageIndex = 0;
        private int count = 0;

        void LoadData()
        {

            dgvDSThuoc.DataSource = Thuoc.LayThuoc(pageIndex, TroGiup.pageSize);
            dgvDSThuoc.Columns[0].Visible = false;
            dgvDSThuoc.Columns[1].HeaderText = "Tên thuốc";
            dgvDSThuoc.Columns[2].HeaderText = "Đơn vị";
            dgvDSThuoc.Columns[3].HeaderText = "Đơn giá";
            dgvDSThuoc.Columns[1].Width = 350;
            dgvDSThuoc.Columns[2].Width = 100;
            dgvDSThuoc.Columns[3].Width = 100;
            count = TroGiup.GetPage(TroGiup.pageSize, Thuoc.DemThuoc());
            lblThongBao.Text = "";
        }
        void XoaTextbox()
        {
            txtDonVi.Text = "";
            txtTenThuoc.Text = "";
            numDonGia.Value = numDonGia.Minimum;
            txtTenThuoc.Focus();
            lblThongBao.Text = "";
        }

        private void QLThuoc_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenThuoc.Text.Trim() != "")
                {
                    if (txtDonVi.Text.Trim() != "")
                    {
                        if (numDonGia.Value != numDonGia.Minimum)
                        {
                            string TenThuoc = txtTenThuoc.Text;
                            string DonVi = txtDonVi.Text;
                            int DonGia = (int)numDonGia.Value;
                            if (Thuoc.TimThuoc(TenThuoc, DonGia) == 0)
                            {
                                Thuoc.ThemThuoc(TenThuoc, DonVi, DonGia);
                                LoadData();
                            }
                            else
                            {
                                XoaTextbox();
                            }
                        }
                        else
                        {
                            lblThongBao.Text = "Bạn chưa chọn đơn giá thuốc";
                            numDonGia.Focus();
                        }

                    }
                    else
                    {
                        lblThongBao.Text = "Bạn chưa nhập đơn vị thuốc";
                        txtDonVi.Focus();
                    }
                }
                else
                {
                    lblThongBao.Text = "Bạn chưa nhập tên thuốc";
                    txtTenThuoc.Focus();
                }

            }
            catch
            {
                lblThongBao.Text = "Thêm bị lỗi";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int MaThuoc = (int)dgvDSThuoc["MaThuoc", dgvDSThuoc.CurrentCell.RowIndex].Value;
                if (MessageBox.Show("Bạn có chắc muốn xóa loại thuốc này không. Nếu xóa, tất cả những đơn thuốc có liên quan đến loại thuốc này sẽ bị xóa hết", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    Thuoc.XoaThuoc(MaThuoc);
                    LoadData();
                }
            }
            catch
            {
                lblThongBao.Text = "Xóa bị lỗi";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int MaThuoc = (int)dgvDSThuoc["MaThuoc", dgvDSThuoc.CurrentCell.RowIndex].Value;
                string TenThuoc = txtTenThuoc.Text;
                string DonVi = txtDonVi.Text;
                int DonGia = (int)numDonGia.Value;
                if (TenThuoc.Trim() != "")
                {
                    if (DonVi.Trim() != "")
                    {
                        Thuoc.CapNhatThuoc(MaThuoc, TenThuoc, DonVi, DonGia);
                        LoadData();
                    }
                    else
                    {
                        lblThongBao.Text = "Bạn chưa nhập đơn vị thuốc";
                        txtDonVi.Focus();
                    }
                }
                else
                {
                    lblThongBao.Text = "Bạn chưa nhập tên thuốc";
                    txtTenThuoc.Focus();
                }
            }
            catch
            {
                lblThongBao.Text = "Dữ liệu không hợp lệ";
                txtTenThuoc.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaTextbox();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFirsrt_Click(object sender, EventArgs e)
        {
            pageIndex = 0;
            LoadData();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (pageIndex > 0)
                pageIndex--;
            LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageIndex < count)
                pageIndex++;
            LoadData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pageIndex = count;
            LoadData();
        }
    }
}
