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
    public partial class GUI_DSBenhNhan : Form
    {
        public GUI_DSBenhNhan()
        {
            InitializeComponent();
        }

        private void GUI_DSBenhNhan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BUS_BenhNhan.LayDS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BUS_BenhNhan.TimTen(textTen.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BUS_BenhNhan.TimNgay(dateTimePicker1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BUS_BenhNhan.LayDS();
        }




    }
}
