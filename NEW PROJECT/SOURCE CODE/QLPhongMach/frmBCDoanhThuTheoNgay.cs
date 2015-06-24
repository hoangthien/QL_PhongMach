using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CrystalDecisions.Windows.Forms;

namespace QLPhongMach
{
    public partial class frmBCDoanhThuTheoNgay : DevComponents.DotNetBar.Metro.MetroForm
    {
        //Thang, nam mặc định khi load lên form là tháng, năm hiện tại
        int thang = DateTime.Now.Month;
        int nam = DateTime.Now.Year;
        public frmBCDoanhThuTheoNgay()
        {
            InitializeComponent();
        }
        //Hàm LoadData để load lại dữ liệu khi có sự thay đổi
        public void LoadData()
        {
            cbxThang.Text = thang.ToString();
            numNam.Value = nam;
            dgvDoanhThu.DataSource = BaoCaoDoanhThu.LayDuLieu(thang, nam);
            dgvDoanhThu.Columns["NgayKham"].HeaderText = "Ngày";
            dgvDoanhThu.Columns["SoBN"].HeaderText = "Số bệnh nhân";
            dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh thu";
            dgvDoanhThu.Columns["NgayKham"].Width = 200;
            dgvDoanhThu.Columns["SoBN"].Width = 200;
            dgvDoanhThu.Columns["DoanhThu"].Width = 200;
        }
        //Load form
        private void frmBCDoanhThuTheoNgay_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbxThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            thang = int.Parse(cbxThang.Text);
            LoadData();
        }

        private void numNam_ValueChanged(object sender, EventArgs e)
        {
            nam = (int)numNam.Value;
            LoadData();
        }

        private void btnBC_Click(object sender, EventArgs e)
        {
            //Khai bao khoi tao report
            rpBaoCaoDoanhThu bc = new rpBaoCaoDoanhThu();
            //Lay du lieu cho report tu mot doi tuong
            bc.SetDataSource(BaoCaoDoanhThu.LayDuLieu(thang, nam));
            //show roport len form
            frmBaoCao frm = new frmBaoCao();
            CrystalReportViewer crv = (CrystalReportViewer)frm.Controls["rpvw"];
            crv.ReportSource = bc;
            frm.ShowDialog();
        }

        
    }
}
