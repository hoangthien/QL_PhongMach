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
    public partial class frmQLNguoiDung : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmQLNguoiDung()
        {
            InitializeComponent();
        }
        //Hàm bật tắt các textbox không cho người dùng chỉnh sửa. chỉ mở khi xóa trắng dữ liệu để thêm người dùng mới
        void OnOff(bool en)
        {
            txtDiaChi.ReadOnly = !en;
            txtMatKhau.ReadOnly = !en;
            txtNgaySinh.ReadOnly = !en;
            txtSoDienThoai.ReadOnly = !en;
            txtTenDangNhap.ReadOnly = !en;
            txtTenNguoiDung.ReadOnly = !en;
            cbxChucVu.Enabled = en;
            rdoNu.Enabled = en;
            rdoNam.Enabled = en;
        }
        //Load lại dữ liệu khi có sự thay đổi về người dùng
        void LoadData()
        {
            OnOff(true);
            dgvDSNguoiDung.DataSource = NguoiDung.LayDSNguoiDung();
            dgvDSNguoiDung.Columns["STT"].HeaderText = "STT";
            dgvDSNguoiDung.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dgvDSNguoiDung.Columns["ChucVu"].HeaderText = "Chức vụ";
            dgvDSNguoiDung.Columns["TenND"].HeaderText = "Tên người dùng";
            dgvDSNguoiDung.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDSNguoiDung.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDSNguoiDung.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDSNguoiDung.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvDSNguoiDung.Columns[0].Width = 50;
            dgvDSNguoiDung.Columns[1].Width = 100;
            dgvDSNguoiDung.Columns[2].Width = 100;
            dgvDSNguoiDung.Columns[3].Width = 200;
            dgvDSNguoiDung.Columns[4].Width = 100;
            dgvDSNguoiDung.Columns[5].Width = 100;
            dgvDSNguoiDung.Columns[6].Width = 100;
            if (dgvDSNguoiDung.RowCount <= 2)
                btnXoa.Enabled = false;
            else
                btnXoa.Enabled = true;
            lblThongBao.Text = "";
        }
        void XoaTrang()
        {
            OnOff(true);
            txtTenNguoiDung.Focus();
            txtTenNguoiDung.Text = "";
            txtMatKhau.Text = "";
            txtNgaySinh.Text = "";
            rdoNam.Checked = true;
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTenDangNhap.Text = "";
            btnThem.Enabled = true;
            lblThongBao.Text = "";
        }
        
        private void QLNguoiDung_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";
            LoadData();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Lầy các giá trị của các textbox 
            string TenND = txtTenNguoiDung.Text;
            string NgaySinh = txtNgaySinh.Text;
            string DiaChi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;
            string TenDangNhap = txtTenDangNhap.Text;
            string MK = txtMatKhau.Text;
            string ChucVu = cbxChucVu.Text;
            int GioiTinh;
            if (rdoNam.Checked == true)
                GioiTinh = 1;
            else
                GioiTinh = 0;
            
                try
                {
                    if (TenND.Trim() != "")
                    {
                        if (TenDangNhap.Trim() != "")
                        {
                            if (MK.Trim() != "")
                            {
                                try
                                {
                                    MK = TroGiup.Md5(MK);
                                    NguoiDung.ThemNguoiDung(TenND, NgaySinh, GioiTinh, DiaChi, SDT, TenDangNhap, MK, ChucVu);
                                    LoadData();
                                }
                                catch
                                {
                                    lblThongBao.Text = "Tên đăng nhập đã có người sử dụng";
                                    txtTenDangNhap.Clear();
                                    txtTenDangNhap.Focus();
                                }
                            }
                            else
                            {
                                lblThongBao.Text = "Bạn chưa nhập mật khẩu";
                                txtMatKhau.Focus();
                            }
                        }
                        else
                        {
                            lblThongBao.Text = "Bạn chưa nhập tên đăng nhập";
                            txtTenDangNhap.Focus();
                        }
                    }
                    else
                    {
                        lblThongBao.Text = "Bạn chưa nhập tên";
                        txtTenNguoiDung.Focus();
                    }
                }
                catch
                {
                    lblThongBao.Text = "Thêm bị lỗi";
                }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int a = dgvDSNguoiDung.CurrentCell.RowIndex;
            string TenDangNhap = dgvDSNguoiDung[1, a].Value.ToString();
            string ChucVu = dgvDSNguoiDung[2, a].Value.ToString();
            //Không được xóa admin
            if (ChucVu != "Admin" && TenDangNhap != PhanQuyen.TenDangNhap)
            {

                NguoiDung.XoaNguoiDung(TenDangNhap);
                LoadData();
            }
            else //Không cho xóa 2 người dùng đầu tiên (admin và chính mình)
            {
                lblThongBao.Text = "Bạn không thể xóa người dùng này";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string TenDangNhap = (string)dgvDSNguoiDung["TenDangNhap", dgvDSNguoiDung.CurrentCell.RowIndex].Value;
                string TenND = txtTenNguoiDung.Text;
                string NgaySinh = txtNgaySinh.Text;
                string DiaChi = txtDiaChi.Text;
                string SDT = txtSoDienThoai.Text;
                string MK = txtMatKhau.Text;
                string ChucVu = cbxChucVu.Text;
                int GioiTinh;
                if (rdoNam.Checked == true)
                    GioiTinh = 1;
                else
                    GioiTinh = 0;

                if (TenND.Trim() != "")
                {
                    if (TenDangNhap.Trim() != "")
                    {
                        if (MK.Trim() != "")
                        {
                            NguoiDung.CapNhatThongTin(TenDangNhap, TenND, NgaySinh, GioiTinh, DiaChi, SDT);
                            LoadData();
                        }
                        else
                        {
                            lblThongBao.Text = "Bạn chưa nhập mật khẩu";
                            txtMatKhau.Focus();
                        }
                    }
                    else
                    {
                        lblThongBao.Text = "Bạn chưa nhập tên đăng nhập";
                        txtTenDangNhap.Focus();
                    }
                }
                else
                {
                    lblThongBao.Text = "Bạn chưa nhập tên";
                    txtTenNguoiDung.Focus();
                }
            }
            catch
            {
                lblThongBao.Text = "Dữ liệu không hợp lệ";
                txtTenNguoiDung.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaTrang();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
    }
}
