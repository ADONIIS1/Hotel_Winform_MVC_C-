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
    public partial class fm_ThemLoaiPhong : Form
    {
        public fm_ThemLoaiPhong()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        public fm_ThemLoaiPhong(fm_LoaiPhong fm_Dich)
        {
            InitializeComponent();
            //LoadCombobox();
            loaiPhong = fm_Dich;
        }
        fm_LoaiPhong loaiPhong = new fm_LoaiPhong();

        public static int IDloaiPhong;
        public static string TenForm;
    

        private void fm_ThemLoaiPhong_Load(object sender, EventArgs e)
        {
            // LoadCombobox();

            LOAIPHONG dv = LoaiPhongDAO.Instance.GetLOAIPHONGTheoMALoaiP(IDloaiPhong);
            if (dv != null)
            {
                txtTenLoaiP.Text = dv.TENLOAIPHONG;

            }
                lbTenForm.Text = TenForm;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                string TenLoaiDV = txtTenLoaiP.Text;

                LOAIPHONG dv = LoaiPhongDAO.Instance.GetLOAIPHONGTheoMALoaiP(IDloaiPhong);
                if (dv != null)
                {
                    if (LoaiPhongDAO.Instance.Sua(IDloaiPhong, TenLoaiDV))
                    {
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    if (LoaiPhongDAO.Instance.Them(TenLoaiDV))
                    {
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                this.Close();
                loaiPhong.BindGridLoaiPhong(LoaiPhongDAO.Instance.GetAllLoaiPhong());
            }
        }
        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtTenLoaiP.Text))
            {
                txtTenLoaiP.Focus();
                MessageBox.Show("Nhập đầy Tên Loại Phòng !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
    }
}
