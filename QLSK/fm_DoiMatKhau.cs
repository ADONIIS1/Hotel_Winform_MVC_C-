using QLSK.DAO;
using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSK
{
    public partial class fm_DoiMatKhau : Form
    {
        public fm_DoiMatKhau()
        {
            InitializeComponent();
        }
        public static string TenTK;
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (Kiemtradulieu())
            {
                TAIKHOAN TK = TaiKhoanDAO.Instance.GetTaiKhoanTheotenTK(TenTK);
                if (txtMKcu.Text.ToString().Equals(TK.MATKHAU.ToString()))
                {
                    if (txtMatKhauMoi.Text.Equals(txtLaiMKM.Text))
                    {
                        if (TaiKhoanDAO.Instance.DoiMK(TenTK, txtMatKhauMoi.Text))
                        {
                            MessageBox.Show("Thay Đổi Mật Khẩu Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thay Đổi Mật Khẩu Không  Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Hai Mật Khẩu Không Trùng Nhau!", "Thông Báo", MessageBoxButtons.OK);
                        txtMatKhauMoi.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mật Khẩu Cũ Sai !", "Thông Báo", MessageBoxButtons.OK);
                    txtMKcu.Focus();
                }
            }
        }

        private bool Kiemtradulieu()
        {
            if (string.IsNullOrWhiteSpace(txtMKcu.Text))
            {
                txtMKcu.Focus();
                MessageBox.Show("Nhập đầy đủ Mật Khẩu Cũ !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text) )
            {
                txtMatKhauMoi.Focus();
                MessageBox.Show("Nhập đầy đủ Mật Khẩu Mới !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            //Kiểm tra textbox CCCD rỗng hoặc nhập kí tự chữ không
            if (string.IsNullOrWhiteSpace(txtLaiMKM.Text))
            {
                txtLaiMKM.Focus();
                MessageBox.Show("Nhập đầy đủ Lại Mật Khẩu !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
          
            return true;
        }
    }
}
