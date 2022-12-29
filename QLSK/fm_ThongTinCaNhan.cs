using QLSK.DAO;
using QLSK.DTO;
using QLSK.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSK
{
    public partial class fm_ThongTinCaNhan : Form
    {
        public fm_ThongTinCaNhan()
        {
            InitializeComponent();
        }
        public static string TenDN;
        

        int dem = 0;
        int d = 1;
        private void btTaiAnh_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png; *.jfif)| *.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png; *.jfif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ptbAnhNhanVien.Image = Image.FromFile(openFileDialog.FileName);
                dem = 1 ;
            }
        }
        int MANV;
        private byte[] ImageToByteArray(PictureBox picturebox)
        {
            MemoryStream memoryStream = new MemoryStream();
            ptbAnhNhanVien.Image.Save(memoryStream, ptbAnhNhanVien.Image.RawFormat);
            return memoryStream.ToArray();
        }
        private void fm_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            try
            {
                TAIKHOAN TK = TaiKhoanDAO.Instance.GetTaiKhoanTheotenTK(TenDN);
                txtTenNV.Text = TK.NHANVIEN.TENNV;
                MANV = (int)TK.MANV;
                if (TK.QUYEN == 1)
                {
                    txtChucVu.Text = "Lễ Tân";
                }
                else if (TK.QUYEN == 2)
                {
                    txtChucVu.Text = "Quản Lý";

                }
                else
                {
                    txtChucVu.Text = "Admin";

                }
                txtLuong.Text = TK.NHANVIEN.LUONG.ToString();
                txtDC.Text = TK.NHANVIEN.DIACHI;
                txtCMND.Text = TK.NHANVIEN.CMND;
                MemoryStream memoryStream = new MemoryStream((TK.NHANVIEN.ANHDAIDIEN));
                ptbAnhNhanVien.Image = Image.FromStream(memoryStream);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
       
        

        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if(dem == d)
            {
                if (NhanVienDAO.Instance.SuaAnhNV(MANV, ImageToByteArray(ptbAnhNhanVien)))
                {
                    MessageBox.Show("đổi ảnh thành công!");

                }
                else
                {
                    MessageBox.Show("Đổi  ảnh Không thành công!");
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy Chọn ảnh Mới!");

            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fm_DoiMatKhau.TenTK = TenDN;
            fm_DoiMatKhau DMK = new fm_DoiMatKhau();
            DMK.ShowDialog();
        }
    }
}
