using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLPM_BUS;
using QLPM_Entity;

namespace QuanLyPhongMach
{
    public partial class GUI_BCThuoc : Form
    {
        public GUI_BCThuoc()
        {
            InitializeComponent();
        }

        private void GUI_BCThuoc_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = BUS_BCThuoc.LayDuLieu(comboBox1.Text);
                string t = dataGridView1.Rows[0].Cells[2].Value.ToString();
                int dong = dataGridView1.RowCount;
                for (int i = 0; i < dong - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = BUS_BCThuoc.LaySoLuong(dataGridView1.Rows[i].Cells[2].Value.ToString(), comboBox1.Text);
                    dataGridView1.Rows[i].Cells[1].Value = BUS_BCThuoc.LaySoLan(dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BCThuoc bc = new BCThuoc();
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    bc.TenThuoc = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    bc.Thang = comboBox1.Text;
                    bc.SoLuong = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    bc.DonVi = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    bc.SoLanDung = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    BUS_BCThuoc.Them(bc);
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
