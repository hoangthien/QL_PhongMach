using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLPM_Entity;
using QLPM_BUS;

namespace QuanLyPhongMach
{
    public partial class GUI_BCNhapThuoc : Form
    {
        public GUI_BCNhapThuoc()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView1.DataSource = BUS_NhapThuoc.LayDuLieu(comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BCNhapThuoc bc = new BCNhapThuoc();
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    bc.Thang = comboBox1.Text;
                    bc.NgayNhap = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    bc.TenThuoc = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    bc.SoLuong = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    bc.ThanhTien = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    BUS_BCNhapThuoc.Them(bc);
                }
                MessageBox.Show("Added");
            }
            catch
            {
                MessageBox.Show("Error!");
                return;
            }
        }
    }
}
