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
    public partial class GUI_NhapThuoc : Form
    {
        public GUI_NhapThuoc()
        {
            InitializeComponent();
        }

        bool themmoi;

        void KhoaDieuKhien()
        {
            dateTimePicker1.Enabled = false;
            textSoluong.Enabled = false;
            textDongia.Enabled = false;
            cbDonVi.Enabled = false;
            textTenThuoc.Enabled = false;

            buttonLuu.Enabled = false;
            buttonSua.Enabled = true;
            buttonThem.Enabled = true;
        }

        void MoDieuKhien()
        {
            dateTimePicker1.Enabled = true;
            textSoluong.Enabled = true;
            textDongia.Enabled = true;
            cbDonVi.Enabled = true;
            textTenThuoc.Enabled = true;

            buttonLuu.Enabled = true;
            buttonSua.Enabled = false;
            buttonThem.Enabled = false;
        }

        void SetNull()
        {
            textTenThuoc.Text = "";
            textSoluong.Text = "";
            textDongia.Text = "";
            cbDonVi.Text = "";
            labelSoluongton.Text = "0";
            labelMathuoc.Text = "";
        }

        private void GUI_NhapThuoc_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            dataGridView1.DataSource = BUS_Thuoc.LayDuLieu();
            cbDonVi.DataSource = BUS_QuanLyQuyDinh.LayDonVi();
            cbDonVi.ValueMember = "DonVi";
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            int thuocmax = int.Parse(BUS_QuanLyQuyDinh.LayLoaiThuoc());
            int sothuoc = int.Parse(BUS_Thuoc.LaySoThuoc());
            if (sothuoc < thuocmax)
            {
                MoDieuKhien();
                themmoi = true;
                SetNull();
            }
            else
            {
                MessageBox.Show("Vượt quá giới hạn số thuốc");
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                try
                {
                    Thuoc th = new Thuoc();
                    th.TenThuoc = textTenThuoc.Text;
                    th.DonGia = textDongia.Text;
                    th.DonVi = cbDonVi.Text;
                    th.SoLuongTon = textSoluong.Text;
                    BUS_Thuoc.ThemDuLieu(th);

                    PhieuNhapThuoc nt = new PhieuNhapThuoc();
                    nt.NgayNhap = dateTimePicker1.Text;
                    nt.TongTien = labelTongtien.Text;
                    string[] thang = dateTimePicker1.Text.Split('/');
                    nt.Thang = thang[1];
                    BUS_NhapThuoc.ThemPhieu(nt);

                    CTNhapThuoc ct = new CTNhapThuoc();
                    ct.MaPhieu = int.Parse(BUS_NhapThuoc.LayMaPhieu());
                    ct.MaThuoc = int.Parse(BUS_NhapThuoc.LayMaThuoc(textTenThuoc.Text));
                    ct.SoLuong = textSoluong.Text;
                    ct.ThanhTien = labelTongtien.Text;
                    BUS_NhapThuoc.ThemChiTiet(ct);

                    SetNull();
                    KhoaDieuKhien();
                    dataGridView1.DataSource = BUS_Thuoc.LayDuLieu();

                    MessageBox.Show("Added");
                }
                catch
                {
                    MessageBox.Show("Error!");
                    return;
                }
            }
            else
            {
                try
                {
                    Thuoc th = new Thuoc();
                    th.MaThuoc = int.Parse(labelMathuoc.Text);
                    th.TenThuoc = textTenThuoc.Text;
                    th.DonGia = textDongia.Text;
                    th.DonVi = cbDonVi.Text;
                    th.SoLuongTon = (int.Parse(textSoluong.Text) + int.Parse(labelSoluongton.Text)).ToString();
                    BUS_Thuoc.SuaDuLieu(th);

                    PhieuNhapThuoc nt = new PhieuNhapThuoc();
                    nt.NgayNhap = dateTimePicker1.Text;
                    nt.TongTien = labelTongtien.Text;
                    string[] thang = dateTimePicker1.Text.Split('/');
                    nt.Thang = thang[1];
                    BUS_NhapThuoc.ThemPhieu(nt);

                    CTNhapThuoc ct = new CTNhapThuoc();
                    ct.MaPhieu = int.Parse(BUS_NhapThuoc.LayMaPhieu());
                    ct.MaThuoc = int.Parse(BUS_NhapThuoc.LayMaThuoc(textTenThuoc.Text));
                    ct.SoLuong = textSoluong.Text;
                    ct.ThanhTien = labelTongtien.Text;
                    BUS_NhapThuoc.ThemChiTiet(ct);

                    SetNull();
                    KhoaDieuKhien();
                    dataGridView1.DataSource = BUS_Thuoc.LayDuLieu();

                    MessageBox.Show("Updated");
                }
                catch
                {
                    MessageBox.Show("Error!");
                    return;
                }
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            themmoi = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelMathuoc.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textTenThuoc.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textDongia.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbDonVi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            labelSoluongton.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void textSoluong_TextChanged(object sender, EventArgs e)
        {
            if (textDongia.Text != "" && textSoluong.Text != "")
                labelTongtien.Text = (int.Parse(textSoluong.Text) * int.Parse(textDongia.Text)).ToString();
        }

        private void textDongia_TextChanged(object sender, EventArgs e)
        {
            if (textSoluong.Text != "" && textDongia.Text != "")
                labelTongtien.Text = (int.Parse(textSoluong.Text) * int.Parse(textDongia.Text)).ToString();
        }
    }
}
