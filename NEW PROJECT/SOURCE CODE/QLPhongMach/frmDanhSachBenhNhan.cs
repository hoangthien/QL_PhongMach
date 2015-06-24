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
    public partial class frmDanhSachBenhNhan : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDanhSachBenhNhan()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dgvDSBenhNhan.DataSource = PhieuKham.DSKhamBenh(dtpNgayKham.Text);
        }

        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDanhSachBenhNhan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
