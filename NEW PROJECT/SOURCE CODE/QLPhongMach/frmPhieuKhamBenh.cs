using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLPhongMach
{
    public partial class frmPhieuKhamBenh : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmPhieuKhamBenh()
        {
            InitializeComponent();
        }
        void OnOff(bool en)
        {
            btnSua.Enabled = en;
            btnXoa.Enabled = en;
            dgvToaThuoc.Columns["colThuoc"].ReadOnly = en;

            btnThem.Enabled = !en;
        }
        public static int MaPK;
        int MaBN;
        //Lấy dữ liệu lên các điều khiển
        private void LoadData()
        {
            MaBN = 0;
            DateTime NgayKham = dtpNgayKham.Value; 
            try
            {
                cbxHoTen.DisplayMember = "TenBN";
                cbxHoTen.ValueMember = "MaBN";
                cbxHoTen.DataSource = BenhNhan.LayDSBenhNhan(dtpNgayKham.Text);//Lầy dữ liệu cho cbxHoTen theo ngày khám                
                cbxHoTen.SelectedIndex = 0;
                MaBN = (int)cbxHoTen.SelectedValue;
            }
            catch//Không có bệnh nhân nào
            {
                cbxHoTen.Text = "";
            }
            (dgvToaThuoc.Columns["colThuoc"] as DataGridViewComboBoxColumn).DisplayMember = "TenThuoc";
            (dgvToaThuoc.Columns["colThuoc"] as DataGridViewComboBoxColumn).ValueMember = "MaThuoc";
            (dgvToaThuoc.Columns["colThuoc"] as DataGridViewComboBoxColumn).DataSource = Thuoc.LayThuoc(0, Thuoc.DemThuoc());
            dgvToaThuoc.AutoGenerateColumns = false;
        }
        void LayDuLieuChoTextBox()
        {
            MaPK = PhieuKham.TimPhieuKham(dtpNgayKham.Text, MaBN);//Lầy ra MaPk dựa vào Ngày khám và MABN
            List<ChiTietToaThuoc> toaThuoc = ToaThuoc.LayChiTietDonThuoc(MaPK);
            dgvToaThuoc.AutoGenerateColumns = false;
            if (toaThuoc.Count > 0)
            {
                dgvToaThuoc.DataSource = toaThuoc;//Lầy chi tiết toa thuốc của phiếu khám
                OnOff(true);
            }
            else
            {
                //dgvToaThuoc.Rows.Clear();
                dgvToaThuoc.DataSource = null;
                OnOff(false);
            }
            dgvToaThuoc.AutoGenerateColumns = false;
            string TrieuChung;
            string LoaiBenh;
            PhieuKham.LayDuLieu(MaPK, out LoaiBenh, out TrieuChung);//Lấy ra triệu chứng và loại bệnh của bệnh nhân. nếu có
            txtTrieuChung.Text = TrieuChung;
            txtLoaiBenh.Text = LoaiBenh;

        }

        private void PhieuKhamBenh_Load(object sender, EventArgs e)
        {
            LoadData();
            LayDuLieuChoTextBox();
        }

        private void cbxHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MaBN = (int)cbxHoTen.SelectedValue;
                LayDuLieuChoTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
            LayDuLieuChoTextBox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtLoaiBenh.Text != "" && txtTrieuChung.Text != "")
            {
                try
                {
                    PhieuKham.CapNhapPhieuKham(MaPK, txtTrieuChung.Text, txtLoaiBenh.Text);
                    for (int i = 0; i < dgvToaThuoc.Rows.Count - 1; i++)
                    {
                        int MaThuoc = (int)dgvToaThuoc.Rows[i].Cells["colThuoc"].Value;
                        int SoLuong = int.Parse(dgvToaThuoc.Rows[i].Cells["colSoLuong"].Value.ToString());
                        string CachDung = dgvToaThuoc.Rows[i].Cells["colCachDung"].Value.ToString();
                        ToaThuoc.ThemDuLieu(MaPK, MaThuoc, SoLuong, CachDung);
                    }
                }
                catch
                {
                    MessageBox.Show("Thêm dữ liệu bị lỗi");
                }
                LayDuLieuChoTextBox();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu trong khung phiếu khám");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dgvToaThuoc.CurrentCell.RowIndex;
                int MaThuoc = (int)dgvToaThuoc["colThuoc", rowindex].Value;
                ToaThuoc.XoaDuLieu(MaPK, MaThuoc);
                LayDuLieuChoTextBox();
            }
            catch
            {
                MessageBox.Show("Xóa bị lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dgvToaThuoc.CurrentCell.RowIndex;
                int MaThuoc = (int)dgvToaThuoc["colThuoc", rowindex].Value;
                int SoLuong = (int)dgvToaThuoc["colSoLuong", rowindex].Value;
                string CachDung = dgvToaThuoc["colCachDung", rowindex].Value.ToString();
                ToaThuoc.CapNhatDL(MaPK, MaThuoc, SoLuong, CachDung);//Cập nhật cho ChiTietToaThuoc
                string TrieuChung = txtTrieuChung.Text;
                string LoaiBenh = txtLoaiBenh.Text;
                PhieuKham.CapNhapPhieuKham(MaPK, TrieuChung, LoaiBenh);//Cập nhật thong tin cho phieukham
                LayDuLieuChoTextBox();
            }
            catch
            {
                MessageBox.Show("Cập nhật bị lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            OnOff(false);
            //Xoa dữ liệu trong dgvToaThuoc de chuan bi them moi
            dgvToaThuoc.DataSource = null;
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            frmHoaDonThanhToan dh = new frmHoaDonThanhToan();
            dh.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        
    }
}
