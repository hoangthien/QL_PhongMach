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
    public partial class GUI_BaoCaoDoanhThu : Form
    {
        public GUI_BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView1.DataSource = BUS_BCDoanhThu.LayDuLieu(comboBox1.Text);
            int dong = dataGridView1.RowCount;
            for (int i = 0; i < dong - 1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = BUS_PhieuKham.LaySoBN(dataGridView1.Rows[i].Cells[3].Value.ToString());
                dataGridView1.Rows[i].Cells[1].Value = BUS_BCDoanhThu.LayDoanhThu(dataGridView1.Rows[i].Cells[3].Value.ToString());
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "")
                    dataGridView1.Rows[i].Cells[1].Value = float.Parse(BUS_QuanLyQuyDinh.LayTienKham()) + float.Parse(BUS_BCDoanhThu.LayDoanhThu(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                else
                    dataGridView1.Rows[i].Cells[1].Value = BUS_QuanLyQuyDinh.LayTienKham();
                dataGridView1.Rows[i].Cells[2].Value = float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) / float.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 1)
                {
                    BCDoanhThu bc = new BCDoanhThu();
                    bc.Thang = comboBox1.Text;

                    int tong = 0;
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        tong += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }

                    bc.TongDoanhThu = tong.ToString();
                    BUS_BCDoanhThu.ThemDuLieu(bc);

                    CTBCDoanhThu ct = new CTBCDoanhThu();
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        ct.Thang = comboBox1.Text;
                        ct.NgayKham = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        ct.SoBenhNhan = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        ct.DoanhThu = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "0")
                            ct.TyLe = float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());

                        BUS_CTBC.Them(ct);
                    }

                    MessageBox.Show("Added");
                }
            }
            catch
            {
                MessageBox.Show("Error!");
                return;
            }
        }
    }
}
