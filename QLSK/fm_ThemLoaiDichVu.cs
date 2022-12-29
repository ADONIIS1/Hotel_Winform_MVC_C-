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
    public partial class fm_ThemLoaiDichVu : Form
    {
        public fm_ThemLoaiDichVu()
        {
            InitializeComponent();
        }

        public fm_ThemLoaiDichVu(fm_LoaiDichVu fm_Dich)
        {
            InitializeComponent();
            //LoadCombobox();
            dichVu = fm_Dich;
        }
        fm_LoaiDichVu dichVu = new fm_LoaiDichVu();
        public static int IDloaiDV;
        public static string TenForm;
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fm_ThemLoaiPhong_Load(object sender, EventArgs e)
        {
            // LoadCombobox();

            LOAIDICHVU dv = LoaiDichVuDAO.Instance.GetloaiTheoID(IDloaiDV);
            if (dv != null)
            {
                txtTenLoaiDV.Text = dv.TENLOAIDICHVU;

            }
            else

                lbTenForm.Text = TenForm;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                string TenLoaiDV = txtTenLoaiDV.Text;
               
                LOAIDICHVU dv = LoaiDichVuDAO.Instance.GetloaiTheoID(IDloaiDV);
                if (dv != null)
                {
                    if (LoaiDichVuDAO.Instance.Sua(IDloaiDV,TenLoaiDV))
                    {
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    if (LoaiDichVuDAO.Instance.Them(TenLoaiDV))
                    {
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                this.Close();
                dichVu.BindGridLoaiDichVu(LoaiDichVuDAO.Instance.GetLoaiDichVu());
            }
        }
        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtTenLoaiDV.Text))
            {
                txtTenLoaiDV.Focus();
                MessageBox.Show("Nhập đầy Tên Loại Dịch Vụ !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
    }
}
