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
    public partial class fm_DangNhap : Form
    {
        public fm_DangNhap()
        {
            InitializeComponent();
        }

     

     
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            TAIKHOAN taiKhoan = new TAIKHOAN();
            List<TAIKHOAN> list = TaiKhoanDAO.Instance.GetallListTaiKhoan();

            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatkhau.Text;
            var check = list.Where(item => item.TENTAIKHOAN.Equals(tenDangNhap)).ToList();
            if (check.Count > 0)
            {
                if (check[0].MATKHAU.Equals(matKhau))
                {
                    MessageBox.Show("Đăng Nhập Thành Công");
                    fm_ManHinhchinh.quyen = check[0].QUYEN;
                    fm_ManHinhchinh.TenDK = check[0].TENTAIKHOAN.ToString();
                    fm_ManHinhchinh Menu = new fm_ManHinhchinh();
                    Menu.FormClosed += Form_Closed;
                    Menu.Show();
                    this.Hide();
                    ClearTextBox();
                }
                else
                {
                    MessageBox.Show("Mật Khẩu không Đúng!");
                }
            }
            else
            {
                MessageBox.Show("Tài Khoản không tồn tại!");
            }
        }
        void ClearTextBox()
        {
            txtTenDangNhap.Text = "";
            txtMatkhau.Text = "";
        }
        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

     

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
      
        private void fm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                txtMatkhau.UseSystemPasswordChar = false;

            }
            else
                txtMatkhau.UseSystemPasswordChar = true;
        }
    }
}
