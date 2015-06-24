using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace QLPhongMach
{
    public partial class frmDanhSachKhamBenh : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDanhSachKhamBenh()
        {
            InitializeComponent();
        }

        //Lưu lại số lượng bênh nhân. mặc định số bệnh nhân tối đa là 40

        int soLuongBN = 0;
        //Load dữ liệu khi cần
        private void LoadData()
        {
            dgvDSBenhNhan.DataSource = BenhNhan.LayDSBenhNhan(dtpNgayKham.Text);
            soLuongBN = dgvDSBenhNhan.RowCount;
            if (soLuongBN < TroGiup.soBNToiDa)
            {
                btnThem.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;//Nếu số lượng bệnh nhân vượt qua số lượng bệnh nhân tối đa sẽ ẩn btnThem không cho thêm bệnh nhân
            }
            numSLBN.Value = TroGiup.soBNToiDa;
            lblThongBao.Text = "";
        }
        private void XoaTextbox()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            ckbGioiTinh.Checked = false;
            txtHoTen.Focus();
            lblThongBao.Text = "";
        }
        private void DanhSachKhamBenh_Load(object sender, EventArgs e)
        {
            LoadData();
            lblThongBao.Text = "";
        }
        //Thêm một phiếu khám cho bệnh nhân
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "")
            {
                if (dtpNgaySinh.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                {
                    string HoTen = txtHoTen.Text;
                    DateTime NgaySinh = dtpNgaySinh.Value;
                    string DiaChi = txtDiaChi.Text;
                    int GioiTinh;
                    if (ckbGioiTinh.Checked == true)
                        GioiTinh = 1;
                    else
                        GioiTinh = 0;
                    string ngayKham = dtpNgayKham.Text;
                    int MaBN;
                    //Nếu chua co benh nhan nay trong DS BenhNhan thi se them benh nhan nay vao 
                    if (BenhNhan.KTBenhNhan(HoTen, NgaySinh, out MaBN) == true)
                    {
                        BenhNhan.ThemBenhNhan(HoTen, GioiTinh, NgaySinh, DiaChi);
                    }
                    BenhNhan.KTBenhNhan(HoTen, NgaySinh, out MaBN);
                    if (PhieuKham.TimPhieuKham(dtpNgayKham.Text, MaBN) == 0)//Khong tim thay phieu kham nao
                    {
                        PhieuKham.TaoPhieuKham(ngayKham, MaBN);
                        LoadData();
                    }
                    else
                    {
                        XoaTextbox();
                    }
                }
                else
                {
                    lblThongBao.Text = "Vui lòng chọn ngày sinh";
                    dtpNgaySinh.Focus();
                }
            }
            else
            {
                lblThongBao.Text = "Vui lòng nhập đầy đủ dữ liệu";
                txtHoTen.Focus();
            }
        }
        //Giá trị ngày khám thay đổi sẽ load dữ liệu lai như cũ
        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSBenhNhan.CurrentCell != null)
            {
                //Cảnh báo người dùng nến chọn xóa một người
                if (MessageBox.Show("Bạn có chắc muốn xóa phiếu khám bệnh của bệnh nhân này không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    int a = dgvDSBenhNhan.CurrentCell.RowIndex;
                    int IDBenhNhan = (int)dgvDSBenhNhan["MaBN", a].Value;
                    int IDPhieuKham = PhieuKham.TimPhieuKham(dtpNgayKham.Text, IDBenhNhan);
                    PhieuKham.XoaPhieuKham(IDPhieuKham);
                    //Neu xoa het tat ca cac phieu kham benh lien quan den benh nhan thi xoa luon benh nhan do
                    if (PhieuKham.TimBenhNhan(IDBenhNhan) == false)
                    {
                        BenhNhan.XoaBN(IDBenhNhan);
                    }
                    LoadData();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDSBenhNhan.CurrentCell != null)
            {
                if (txtDiaChi.Text != "" && txtHoTen.Text != "")
                {
                    int gioiTinh;
                    if (ckbGioiTinh.Checked == true)
                        gioiTinh = 1;
                    else
                        gioiTinh = 0;
                    int a = dgvDSBenhNhan.CurrentCell.RowIndex;//Lấy ra chỉ số dòng hiện hành cua dgvDSBenhNhan để chỉnh sửa thông tin cho bệnh nhân đó
                    int MaBN = (int)dgvDSBenhNhan["MaBN", a].Value;
                    BenhNhan.SuaTTBenhNhan(MaBN, txtHoTen.Text, gioiTinh, dtpNgaySinh.Value, txtDiaChi.Text);
                    LoadData();
                }
                else
                {
                    lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin";
                    txtHoTen.Focus();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaTextbox();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Thay đổi số bệnh nhân tối đa trong ngày
        private void numSLBN_ValueChanged(object sender, EventArgs e)
        {
            TroGiup.CapNhapSoBenhNhanToiDa((int)numSLBN.Value);
            if (soLuongBN < TroGiup.soBNToiDa)
            {
                btnThem.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
            }
        }
        //Lấy lại thông tin cho các textbox khi ô hiện hành trong dgvDSBenhNhan bị thay doi
        private void dgvDSBenhNhan_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int a = dgvDSBenhNhan.CurrentCell.RowIndex;
                txtHoTen.Text = dgvDSBenhNhan["HoTen", a].Value.ToString();
                txtDiaChi.Text = dgvDSBenhNhan["DiaChi", a].Value.ToString();
                dtpNgaySinh.Text = dgvDSBenhNhan["NgaySinh", a].Value.ToString();
                ckbGioiTinh.Checked = (bool)dgvDSBenhNhan["GioiTinh", a].Value;
                lblThongBao.Text = "";
            }
            catch
            {
                XoaTextbox();
            }   
        }

 

    }
}
