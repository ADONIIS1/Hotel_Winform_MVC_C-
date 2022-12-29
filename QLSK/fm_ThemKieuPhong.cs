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
    public partial class fm_ThemKieuPhong : Form
    {
        public fm_ThemKieuPhong()
        {
            InitializeComponent();
        }
        public fm_ThemKieuPhong(fm_KieuPhong fm_KieuPhong)
        {
            InitializeComponent();
            fm_KieuPhong1 = fm_KieuPhong;
        }
        fm_KieuPhong fm_KieuPhong1 = new fm_KieuPhong();
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static int IDkieuPhong;
        public static string TenForm;
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                string TenKP = txtTenKP.Text;
             
                KIEUPHONG dv = KieuPhongDAO.Instance.GetKieuPhong(IDkieuPhong);
                if (dv != null)
                {
                    if (KieuPhongDAO.Instance.Sua(IDkieuPhong,TenKP))
                    {
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    if (KieuPhongDAO.Instance.Them(TenKP))
                    {
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                this.Close();
                fm_KieuPhong1.BindGridKieuPhong(KieuPhongDAO.Instance.GetAllKieuP());
            }
        }

        private void fm_ThemKieuPhong_Load(object sender, EventArgs e)
        {
            KIEUPHONG kp = KieuPhongDAO.Instance.GetKieuPhong(IDkieuPhong);
            if (kp != null)
            {
                txtTenKP.Text = kp.TENKIEUPHONG;
               
                
            }
            lbTenForm.Text = TenForm;
        }
        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtTenKP.Text))
            {
                txtTenKP.Focus();
                MessageBox.Show("Nhập đầy Tên Kiểu Phòng !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            //Kiểm tra textbox dongia rỗng hoặc nhập kí tự chữ không
           
            return true;
        }
    }
}
