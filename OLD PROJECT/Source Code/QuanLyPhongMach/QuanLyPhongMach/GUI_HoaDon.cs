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
    public partial class GUI_HoaDon : Form
    {
        public GUI_HoaDon()
        {
            InitializeComponent();
        }

        int dong;

        private void GUI_HoaDon_Load(object sender, EventArgs e)
        {
            cbTenbn.DataSource = BUS_PhieuKham.LayThongTinBN();
            dataGridView2.DataSource = BUS_HoaDon.LayDuLieu();
            cbTenbn.ValueMember = "MaBN";
            cbTenbn.DisplayMember = "TenBN";
            dataGridView1.Refresh();
        }

        private void cbTenbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tienthuoc = 0;
            cbNgaykham.DataSource = BUS_PhieuKham.LayNgay(cbTenbn.Text);
            cbNgaykham.ValueMember = "NgayKham";

            dataGridView1.Refresh();
            dataGridView1.DataSource = BUS_HoaDon.LayToa(cbTenbn.Text, cbNgaykham.Text);

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    string sl = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string dg = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    dataGridView1.Rows[i].Cells[0].Value = (int.Parse(sl) * int.Parse(dg)).ToString();
                    tienthuoc += (int.Parse(sl) * int.Parse(dg));
                }
            }

            labelTienthuoc.Text = tienthuoc.ToString();
        }

        private void cbNgaykham_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tienthuoc = 0;

            dataGridView1.Refresh();
            dataGridView1.DataSource = BUS_HoaDon.LayToa(cbTenbn.Text, cbNgaykham.Text);

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
			    {
                    string sl = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string dg = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    dataGridView1.Rows[i].Cells[0].Value = (int.Parse(sl) * int.Parse(dg)).ToString();
                    tienthuoc += (int.Parse(sl) * int.Parse(dg));
			    }
                labelTienthuoc.Text = tienthuoc.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    string sl = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string slt = BUS_CTToaThuoc.LaySLTon(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    if (int.Parse(sl) > int.Parse(slt))
                    {
                        MessageBox.Show("Số lượng thuốc mua vượt quá số lượng tồn");
                        return;
                    }
                }
                HoaDon hd = new HoaDon();
                hd.Thang = cbNgaykham.Text;
                hd.TienThuoc = int.Parse(labelTienthuoc.Text);
                hd.MaToa = int.Parse(BUS_HoaDon.LayMaToa(cbTenbn.Text, cbNgaykham.Text));
                BUS_HoaDon.ThemDuLieu(hd);

                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    string sl = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string slt = BUS_CTToaThuoc.LaySLTon(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    int soluongton = int.Parse(slt) - int.Parse(sl);
                    BUS_Thuoc.UpdateSLTon(dataGridView1.Rows[i].Cells[1].Value.ToString(), soluongton);
                }

                dataGridView2.DataSource = BUS_HoaDon.LayDuLieu();
                MessageBox.Show("Added");
            }
            catch
            {
                MessageBox.Show("Error!");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string t = dataGridView2.Rows[dong].Cells[0].Value.ToString();
                BUS_HoaDon.XoaDuLieu(t);
                dataGridView2.DataSource = BUS_HoaDon.LayDuLieu();
                MessageBox.Show("Deleted");
            }
            catch
            {
                MessageBox.Show("Error!");
                return;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }


    }
}
