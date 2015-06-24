using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongMach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_BenhNhan option = new GUI_BenhNhan();
            option.ShowDialog();
        }

        private void pkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_PhieuKham option = new GUI_PhieuKham();
            option.ShowDialog();
        }

        private void hdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_HoaDon option = new GUI_HoaDon();
            option.ShowDialog();
        }

        private void ntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhapThuoc option = new GUI_NhapThuoc();
            option.ShowDialog();
        }

        private void dsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_DSBenhNhan option = new GUI_DSBenhNhan();
            option.ShowDialog();
        }

        private void bcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_BaoCaoDoanhThu option = new GUI_BaoCaoDoanhThu();
            option.ShowDialog();
        }

        private void qdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_SuaQuyDinh option = new GUI_SuaQuyDinh();
            option.ShowDialog();
        }

        private void bctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_BCThuoc option = new GUI_BCThuoc();
            option.ShowDialog();
        }

        private void bcntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_BCNhapThuoc option = new GUI_BCNhapThuoc();
            option.ShowDialog();
        }
    }
}
