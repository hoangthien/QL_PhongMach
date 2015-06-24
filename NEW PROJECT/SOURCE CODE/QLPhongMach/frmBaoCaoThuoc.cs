using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;

namespace QLPhongMach
{
    public partial class frmBaoCaoThuoc : DevComponents.DotNetBar.Metro.MetroForm
    {
        //Thang, nam mặc định khi load lên form là tháng, năm hiện tại
        int thang = DateTime.Now.Month;
        int nam = DateTime.Now.Year;
        public frmBaoCaoThuoc()
        {
            InitializeComponent();
        }
        //Hàm LoadData để load lại dữ liệu khi có sự thay đổi
        public void LoatData()
        {
            cbxThang.Text = thang.ToString();
            numNam.Value = nam;
            dgvDSThuoc.DataSource = BaoCaoThuoc.LayDuLieu(thang, nam);
            dgvDSThuoc.Columns["TenThuoc"].HeaderText = "Thuốc";
            dgvDSThuoc.Columns["DonVi"].HeaderText = "Đơn vị tính";
            dgvDSThuoc.Columns["TongSoLuong"].HeaderText = "Số lượng";
            dgvDSThuoc.Columns["SoLanDung"].HeaderText = "Số lần dùng";
            dgvDSThuoc.Columns["TenThuoc"].Width = 200;
            dgvDSThuoc.Columns["TongSoLuong"].Width = 200;
            dgvDSThuoc.Columns["SoLanDung"].Width = 200;
        }

        private void frmBaoCaoThuoc_Load(object sender, EventArgs e)
        {
            LoatData();
        }

        private void cbxThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            thang = int.Parse(cbxThang.Text);
            LoatData();
        }

        private void numNam_ValueChanged(object sender, EventArgs e)
        {
            nam = (int)numNam.Value;
            LoatData();
        }

        private void btnBC_Click(object sender, EventArgs e)
        {
            rpBaoCaoSuDungThuoc bc = new rpBaoCaoSuDungThuoc();
            bc.SetDataSource(BaoCaoThuoc.LayDuLieu(thang, nam));
            frmBaoCao frm = new frmBaoCao();
            CrystalReportViewer crv = (CrystalReportViewer)frm.Controls["rpvw"];
            crv.ReportSource = bc;
            frm.ShowDialog();
        }
    }
}
