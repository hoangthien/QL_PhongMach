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
    public partial class GUI_PhieuKham : Form
    {
        public GUI_PhieuKham()
        {
            InitializeComponent();
        }

        PhieuKham pk = new PhieuKham();
        int dong;
        bool themmoi;

        void HienThi()
        {
            dataGridView2.DataSource = BUS_PhieuKham.LayDuLieu();          
        }

        void KhoaDieuKhien()
        {
            textMaphieu.Enabled = false;
            textTienkham.Enabled = false;
            textTrieuchung.Enabled = false;
            cbChuandoan.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;

            dataGridView1.Enabled = false;

            buttonThem.Enabled = true;
            buttonXoa.Enabled = true;
            buttonSua.Enabled = true;
            buttonLuu.Enabled = false;
        }

        void MoDieuKhien()
        {
            textMaphieu.Enabled = false;
            textTienkham.Enabled = true;
            textTrieuchung.Enabled = true;
            cbChuandoan.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;

            dataGridView1.Enabled = true;

            buttonThem.Enabled = false;
            buttonXoa.Enabled = false;
            buttonSua.Enabled = false;
            buttonLuu.Enabled = true;
        }

        void SetNull()
        {
            textMaphieu.Text = "";
            textTienkham.Text = "";
            cbChuandoan.Text = "";
            textTrieuchung.Text = "";
            dateTimePicker1.ResetText();          
        }

        private void GUI_PhieuKham_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
            comboBox1.DataSource = BUS_PhieuKham.LayThongTinBN();
            comboBox1.ValueMember = "MaBN";

            Column1.DataSource = BUS_Thuoc.LayTenThuoc();
            Column1.ValueMember = "MaThuoc";

            Column10.DataSource = BUS_QuanLyQuyDinh.LayCachDung();
            Column10.ValueMember = "CachDung";

            cbChuandoan.DataSource = BUS_QuanLyQuyDinh.LayLoaiBenh();
            cbChuandoan.ValueMember = "LoaiBenh";

            textTienkham.Text = BUS_QuanLyQuyDinh.LayTienKham();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            int benhnhanmax = int.Parse(BUS_QuanLyQuyDinh.LayBNMax());
            int bntrongngay = int.Parse(BUS_PhieuKham.LaySoBN(dateTimePicker1.Text));
            if (bntrongngay < benhnhanmax)
            {
                MoDieuKhien();
                SetNull();
                themmoi = true;
            }
            else
            {
                MessageBox.Show("Vượt quá số bệnh nhân trong ngày");
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string pk = textMaphieu.Text;
                string toa = BUS_ToaThuoc.MaToa(pk);
                if (toa != null)
                    BUS_CTToaThuoc.XoaDuLieu(toa);
                BUS_ToaThuoc.XoaDuLieu(pk);
                BUS_PhieuKham.XoaDuLieu(pk);
                MessageBox.Show("Deleted!");
                KhoaDieuKhien();
                SetNull();
                HienThi();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            textMaphieu.Enabled = false;
            themmoi = false;
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (themmoi == true)
            {
                try
                {
                    pk.NgayKham = dateTimePicker1.Text;
                    pk.TrieuChung = textTrieuchung.Text;
                    pk.ChuanDoan = cbChuandoan.Text;
                    pk.TienKham = BUS_QuanLyQuyDinh.LayTienKham();
                    pk.MaBN = int.Parse(comboBox1.Text);
                    string[] th = dateTimePicker1.Text.Split('/');
                    pk.Thang = th[1];
                    BUS_PhieuKham.ThemDuLieu(pk);

                    ToaThuoc tt = new ToaThuoc();
                    tt.Thang = dateTimePicker1.Text;
                    tt.MaBN = int.Parse(comboBox1.Text);
                    tt.MaPK = int.Parse(BUS_PhieuKham.LayMaPK());
                    string[] tht = dateTimePicker1.Text.Split('/');
                    tt.ThangToa = tht[1];
                    BUS_ToaThuoc.ThemDuLieu(tt);

                    ChiTietToaThuoc cttt = new ChiTietToaThuoc();
                    int c = dataGridView1.RowCount - 1;
                    for (int i = 0; i < c; i++)
                    {
                        cttt.MaThuoc = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        cttt.MaToa = int.Parse(BUS_ToaThuoc.LayMaToa());
                        cttt.SoLuong = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        cttt.CachDung = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        BUS_CTToaThuoc.ThemDuLieu(cttt);
                    }


                    MessageBox.Show("Added");
                    SetNull();
                    KhoaDieuKhien();
                    HienThi();
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
                    pk.MaPK = int.Parse(textMaphieu.Text);
                    pk.NgayKham = dateTimePicker1.Text;
                    pk.TrieuChung = textTrieuchung.Text;
                    pk.ChuanDoan = cbChuandoan.Text;
                    pk.TienKham = BUS_QuanLyQuyDinh.LayTienKham();
                    pk.MaBN = int.Parse(comboBox1.Text);
                    string[] th = dateTimePicker1.Text.Split('/');
                    pk.Thang = th[1];
                    BUS_PhieuKham.SuaDuLieu(pk);

                    ToaThuoc tt = new ToaThuoc();
                    tt.MaToa = int.Parse(BUS_ToaThuoc.MaToa(textMaphieu.Text));
                    tt.Thang = dateTimePicker1.Text;
                    tt.MaBN = int.Parse(comboBox1.Text);
                    tt.MaPK = int.Parse(textMaphieu.Text);
                    string[] tht = dateTimePicker1.Text.Split('/');
                    tt.ThangToa = tht[1];
                    BUS_ToaThuoc.SuaDuLieu(tt);

                    ChiTietToaThuoc cttt = new ChiTietToaThuoc();
                    int c = int.Parse(BUS_PhieuKham.LayTenThuoc(textMaphieu.Text));
                    for (int i = 0; i < c; i++)
                    {
                        cttt.MaThuoc = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        cttt.MaToa = int.Parse(BUS_ToaThuoc.MaToa(textMaphieu.Text));
                        cttt.SoLuong = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        cttt.CachDung = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        BUS_CTToaThuoc.SuaDuLieu(cttt);
                    }

                    MessageBox.Show("Updated!");
                    SetNull();
                    KhoaDieuKhien();
                    HienThi();
                }
                catch
                {
                    MessageBox.Show("Error!");
                    return;
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Refresh();
                textMaphieu.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTimePicker1.Value = DateTime.ParseExact(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);
                textTrieuchung.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbChuandoan.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                textTienkham.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();

                int d = int.Parse(BUS_PhieuKham.LayTenThuoc(textMaphieu.Text));
                DataTable dt = new DataTable();
                for (int i = 0; i < d; i++)
                {
                    dt = BUS_PhieuKham.LayToa(int.Parse(textMaphieu.Text));
                    dataGridView1.DataSource = BUS_PhieuKham.LayToa(int.Parse(textMaphieu.Text));

                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i]["MaThuoc"].ToString();
                }
            }
            catch
            {
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BUS_Thuoc.LayDonVi(dataGridView1.Rows[dong].Cells[0].Value.ToString());
                dataGridView1.Rows[dong].Cells[1].Value = dt.Rows[0]["DonVi"].ToString();
                dataGridView1.Rows[dong].Cells[4].Value = dt.Rows[0]["TenThuoc"].ToString();
            }
            catch
            {
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }
    }
}
