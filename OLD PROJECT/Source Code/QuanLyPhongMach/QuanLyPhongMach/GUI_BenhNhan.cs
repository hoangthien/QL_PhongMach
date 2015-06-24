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
    public partial class GUI_BenhNhan : Form
    {
        public GUI_BenhNhan()
        {
            InitializeComponent();
        }

        BenhNhan ec = new BenhNhan();
        bool themmoi;

        void KhoaDieuKhien()
        {
            textMabn.Enabled = false;
            textTenbn.Enabled = false;
            dateTimeNgaysinh.Enabled = false;
            comboBoxGioitinh.Enabled = false;
            textDiachi.Enabled = false;
            textDienthoai.Enabled = false;

            buttonThem.Enabled = true;
            buttonXoa.Enabled = true;
            buttonSua.Enabled = true;
            buttonLuu.Enabled = false;
        }

        void MoDieuKhien()
        {
            textMabn.Enabled = false;
            textTenbn.Enabled = true;
            dateTimeNgaysinh.Enabled = true;
            comboBoxGioitinh.Enabled = true;
            textDiachi.Enabled = true;
            textDienthoai.Enabled = true;

            buttonThem.Enabled = false;
            buttonXoa.Enabled = false;
            buttonSua.Enabled = false;
            buttonLuu.Enabled = true;
        }

        void SetNull()
        {
            textMabn.Text = "";
            textTenbn.Text = "";
            dateTimeNgaysinh.ResetText();
            textDiachi.Text = "";
            textDienthoai.Text = "";
        }

        private void GUI_BenhNhan_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            dataGridView1.DataSource = BUS_BenhNhan.LayDuLieu();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            SetNull();
            themmoi = true;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            textMabn.Enabled = false;
            themmoi = false;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textMabn.Text;
                BUS_BenhNhan.XoaDuLieu(ma);
                MessageBox.Show("Deleted!");
                KhoaDieuKhien();
                SetNull();
                dataGridView1.DataSource = BUS_BenhNhan.LayDuLieu();
            }
            catch
            {           
                MessageBox.Show("Error!");
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (themmoi == true)
                {
                    ec.TenBN = textTenbn.Text;
                    ec.NgaySinh = dateTimeNgaysinh.Text;
                    ec.GioiTinh = comboBoxGioitinh.Text;
                    ec.DiaChi = textDiachi.Text;
                    ec.SDT = textDienthoai.Text;

                    BUS_BenhNhan.ThemDuLieu(ec);
                    MessageBox.Show("Added");
                    SetNull();
                    KhoaDieuKhien();
                    dataGridView1.DataSource = BUS_BenhNhan.LayDuLieu();
                }
                else
                {
                    ec.MaBN = int.Parse(textMabn.Text);
                    ec.TenBN = textTenbn.Text;
                    ec.NgaySinh = dateTimeNgaysinh.Text;
                    ec.GioiTinh = comboBoxGioitinh.Text;
                    ec.DiaChi = textDiachi.Text;
                    ec.SDT = textDienthoai.Text;

                    BUS_BenhNhan.SuaDuLieu(ec);
                    MessageBox.Show("Updated");
                    SetNull();
                    KhoaDieuKhien();
                    dataGridView1.DataSource = BUS_BenhNhan.LayDuLieu();
                }
            }
            catch
            {
                MessageBox.Show("Error!");
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textMabn.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textTenbn.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimeNgaysinh.Value = DateTime.ParseExact(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);
            comboBoxGioitinh.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textDiachi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textDienthoai.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
