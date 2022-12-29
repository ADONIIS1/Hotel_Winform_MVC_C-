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
    public partial class fm_ThemTaiKhoan : Form
    {
        public fm_ThemTaiKhoan()
        {
            InitializeComponent();
            LoadCombobox();
        }
        public fm_ThemTaiKhoan(fm_TaiKhoan fm_Dich)
        {
            InitializeComponent();
            LoadCombobox();
            taikhoan = fm_Dich;
        }
        fm_TaiKhoan taikhoan = new fm_TaiKhoan();
        public static string TenTK;
        public static string TenForm;
        void LoadCombobox()
        {
            List<NHANVIEN> DV = NhanVienDAO.Instance.GetallListNhanVien();
           
            DV.Insert(0, new NHANVIEN { TENNV = "Chọn Nhân Viên" });
            cbbNhanVien.DataSource = DV;
            cbbNhanVien.ValueMember = "MANV";
            cbbNhanVien.DisplayMember = "TENNV";
            List<string> quyen = new List<string>();
            quyen.Add("Chọn Quyền");
            quyen.Add("Lễ Tân");
            quyen.Add("Quản Lý");
            quyen.Add("Admin");
            cbbQuyen.DataSource = quyen;

        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                string TenTK = txtTenTK.Text;
                
                string MatKhau = txtMatKhau.Text;
                int MaNV = int.Parse(cbbNhanVien.SelectedValue.ToString());
                int Quyen = int.Parse(cbbQuyen.SelectedIndex.ToString());

                TAIKHOAN TK = TaiKhoanDAO.Instance.GetTaiKhoanTheotenTK(TenTK);
                if (TK != null)
                {
                    if (TaiKhoanDAO.Instance.SuaTaiKhoan(TenTK, MatKhau, MaNV, Quyen))
                    {
                        MessageBox.Show("Đặt Lại Mật Khẩu Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    if (TaiKhoanDAO.Instance.ThemTaiKhoan(TenTK, MatKhau, MaNV, Quyen))
                    {
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                this.Close();
                taikhoan.LoadDuLieu();
            }
        }
        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtTenTK.Text))
            {
                txtTenTK.Focus();
                MessageBox.Show("Nhập đầy Tên Tài Khoản !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            //Kiểm tra textbox dongia rỗng hoặc nhập kí tự chữ không
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Focus();
                MessageBox.Show("Nhập đầy Mật Khẩu !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
           
            if (cbbNhanVien.SelectedIndex == 0)
            {
                cbbNhanVien.Focus();
                MessageBox.Show("Bạn Phải Chọn Nhân Viên", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            if (cbbQuyen.SelectedIndex == 0)
            {
                cbbQuyen.Focus();
                MessageBox.Show("Bạn Phải Chọn Quyền", "Thông báo", MessageBoxButtons.OK);

                return false;
            }




            return true;
        }

        private void fm_ThemTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadCombobox();

            TAIKHOAN dv = TaiKhoanDAO.Instance.GetTaiKhoanTheotenTK(TenTK);
            if (dv != null)
            {
                txtTenTK.Text = dv.TENTAIKHOAN;

                cbbQuyen.SelectedIndex = (int)dv.QUYEN;
                cbbNhanVien.SelectedIndex = (int)dv.MANV;
                txtTenTK.Visible = false;
                cbbNhanVien.Visible = false;
                cbbQuyen.Visible = false;
                PictureBox1.Visible = false;
                PictureBox3.Visible = false;
                PictureBox4.Visible = false;
            }
            else
            {
                cbbNhanVien.SelectedIndex = 0;
                cbbQuyen.SelectedIndex = 0;
            }

            lbTenForm.Text = TenForm;
        }
    }
}
