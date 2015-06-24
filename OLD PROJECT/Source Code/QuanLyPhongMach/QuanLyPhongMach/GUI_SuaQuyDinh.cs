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
    public partial class GUI_SuaQuyDinh : Form
    {
        public GUI_SuaQuyDinh()
        {
            InitializeComponent();
        }

        void Khoa()
        {
            textBNMax.Enabled = false;
            textThuocmax.Enabled = false;
            textLoaibenh.Enabled = false;
            textDonvi.Enabled = false;
            textCachdung.Enabled = false;
            textTienkham.Enabled = false;

            btnLuubenh.Enabled = false;
            btnLuubn.Enabled = false;
            btnLuudonvi.Enabled = false;
            btnLuudung.Enabled = false;
            btnLuuthuoc.Enabled = false;
            btnLuutien.Enabled = false;

            cbCachdung.Enabled = true;
            cbDonvi.Enabled = true;
            cbLoaibenh.Enabled = true;
        }

        private void GUI_SuaQuyDinh_Load(object sender, EventArgs e)
        {
            Khoa();
            textBNMax.Text = BUS_QuanLyQuyDinh.LayBNMax();
            textThuocmax.Text = BUS_QuanLyQuyDinh.LayLoaiThuoc();

            cbLoaibenh.DataSource = BUS_QuanLyQuyDinh.LayLoaiBenh();
            cbLoaibenh.ValueMember = "LoaiBenh";

            cbDonvi.DataSource = BUS_QuanLyQuyDinh.LayDonVi();
            cbDonvi.ValueMember = "DonVi";

            cbCachdung.DataSource = BUS_QuanLyQuyDinh.LayCachDung();
            cbCachdung.ValueMember = "CachDung";

            textTienkham.Text = BUS_QuanLyQuyDinh.LayTienKham();
        }

        private void btnSuabn_Click(object sender, EventArgs e)
        {
            textBNMax.Enabled = true;
            btnLuubn.Enabled = true;          
        }

        private void btnLuubn_Click(object sender, EventArgs e)
        {
            try
            {
                BUS_QuanLyQuyDinh.SuaBenhNhanToiDa(textBNMax.Text);
                textBNMax.Text = BUS_QuanLyQuyDinh.LayBNMax();
            }
            catch
            {
                return;
            }
            Khoa();
        }

        private void btnSuathuoc_Click(object sender, EventArgs e)
        {
            textThuocmax.Enabled = true;
            btnLuuthuoc.Enabled = true;
        }

        private void btnLuuthuoc_Click(object sender, EventArgs e)
        {
            try
            {
                BUS_QuanLyQuyDinh.SuaThuocToiDa(textThuocmax.Text);
                textThuocmax.Text = BUS_QuanLyQuyDinh.LayLoaiThuoc();
            }
            catch
            {
                return;
            }
            Khoa();
        }

        private void btnThembenh_Click(object sender, EventArgs e)
        {
            cbLoaibenh.Enabled = false;
            textLoaibenh.Enabled = true;
            btnLuubenh.Enabled = true;
        }

        private void btnLuubenh_Click(object sender, EventArgs e)
        {
            if (textLoaibenh.Text != "")
            {
                BUS_QuanLyQuyDinh.SuaLoaiBenh(textLoaibenh.Text);
                cbLoaibenh.DataSource = BUS_QuanLyQuyDinh.LayLoaiThuoc();
                cbLoaibenh.ValueMember = "LoaiBenh";
            }
            else
                MessageBox.Show("Chưa nhập thông tin");

            textLoaibenh.Text = "";
            Khoa();
        }

        private void btnThemdonvi_Click(object sender, EventArgs e)
        {
            cbDonvi.Enabled = false;
            textDonvi.Enabled = true;
            btnLuudonvi.Enabled = true;
        }

        private void btnLuudonvi_Click(object sender, EventArgs e)
        {
            if (textDonvi.Text != "")
            {
                BUS_QuanLyQuyDinh.SuaDonVi(textDonvi.Text);
                cbDonvi.DataSource = BUS_QuanLyQuyDinh.LayDonVi();
                cbDonvi.ValueMember = "DonVi";
            }
            else
                MessageBox.Show("Chưa nhập thông tin");

            textDonvi.Text = "";
            Khoa();
        }

        private void btnThemdung_Click(object sender, EventArgs e)
        {
            cbCachdung.Enabled = false;
            textCachdung.Enabled = true;
            btnLuudung.Enabled = true;
        }

        private void btnLuudung_Click(object sender, EventArgs e)
        {
            if (textCachdung.Text != "")
            {
                BUS_QuanLyQuyDinh.SuaCachDung(textCachdung.Text);
                cbCachdung.DataSource = BUS_QuanLyQuyDinh.LayCachDung();
                cbCachdung.ValueMember = "CachDung";
            }
            else
                MessageBox.Show("Chưa nhập thông tin");

            textCachdung.Text = "";
            Khoa();
        }

        private void btnSuatien_Click(object sender, EventArgs e)
        {
            textTienkham.Enabled = true;
            btnLuutien.Enabled = true;
        }

        private void btnLuutien_Click(object sender, EventArgs e)
        {
            BUS_QuanLyQuyDinh.SuaTienKham(textTienkham.Text);
            textTienkham.Text = BUS_QuanLyQuyDinh.LayTienKham();

            Khoa();
        }


    }
}
