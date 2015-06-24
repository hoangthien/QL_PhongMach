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
    public partial class frmCapNhatThongTinND : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmCapNhatThongTinND()
        {
            InitializeComponent();
        }
        //Load form. Các giá trị trên các textbox lúc load form là các thông tin trong csdl của người đang sử dụng
        private void frmCapNhatThongTinND_Load(object sender, EventArgs e)
        {
            ChiTietNguoiDung nd = NguoiDung.LayThongTin(PhanQuyen.TenDangNhap);
            txtDiaChi.Text = nd.DiaChi;
            txtNgaySinh.Text = nd.NgaySinh.ToString();
            txtSoDienThoai.Text = nd.SDT;
            txtTenNguoiDung.Text = nd.TenND;
            ckbGioiTinh.Checked = nd.GioiTinh;
            lblThongBao.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Lấy các giá trị từ các textbox
            string TenND = txtTenNguoiDung.Text;
            string DiaChi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;
            string NgaySinh = txtNgaySinh.Text;
            int GioiTinh;
            if (ckbGioiTinh.Checked == true)
                GioiTinh = 1;
            else
                GioiTinh = 0;
            if (TenND.Trim() != "")//Cắt khoảng trắng để kiêm tra sự đúng đắn của dữ liệu nhập vào. tránh trường hợp người dùng nhập toàn khoảng trắng
            {
                if (NgaySinh.Trim() != "")
                {
                    if (DiaChi.Trim() != "")
                    {
                        try
                        {
                            DateTime ns = DateTime.Parse(NgaySinh);//Chuyền kiểu qua DateTime để bắt lỗi cho ngaysinh người dùng nhập
                            NguoiDung.CapNhatThongTin(PhanQuyen.TenDangNhap, TenND, NgaySinh, GioiTinh, DiaChi, SDT);
                            this.Close();
                        }
                        catch
                        {
                            lblThongBao.Text = "Ngày sinh không hợp lệ";
                            txtNgaySinh.Focus();
                        }
                    }
                    else
                    {
                        lblThongBao.Text = "Vui lòng nhập địa chỉ";
                        txtDiaChi.Focus();
                    }

                }
                else
                {
                    lblThongBao.Text = "Vui lòng nhập ngày sinh";
                    txtNgaySinh.Focus();
                }
            }
            else
            {
                lblThongBao.Text = "Vui lòng nhập tên bạn";
                txtTenNguoiDung.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
