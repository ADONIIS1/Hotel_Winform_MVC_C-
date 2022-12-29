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
    public partial class fm_ThemPhongMoi : Form
    {
        public fm_ThemPhongMoi()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public fm_ThemPhongMoi(fm_Phong fm_Phong)
        {
            InitializeComponent();
            LoadCombobox();
            Phong = fm_Phong;
        }
        fm_Phong Phong = new fm_Phong();

        public static int map;
        public static int idloaiphong;
        public static int idkieuphong;
        public static string TenForm;

        void LoadCombobox()
        {
            //load cbb LoaiPhong
            List<LOAIPHONG> list = LoaiPhongDAO.Instance.GetAllLoaiPhong();
            list.Insert(0, new LOAIPHONG { TENLOAIPHONG = "Chọn Loại Phòng" });
            this.cbbLoaiP.DataSource = list;
            this.cbbLoaiP.DisplayMember = "TENLOAIPHONG";
            this.cbbLoaiP.ValueMember = "IDLOAIPHONG";
            //load cbb kieuphong
            List<KIEUPHONG> list1 = KieuPhongDAO.Instance.GetAllKieuP();
            list1.Insert(0, new KIEUPHONG { TENKIEUPHONG = "Chọn Kiểu Phòng" });
            this.cbbKieuP.DataSource = list1;
            this.cbbKieuP.DisplayMember = "TENKIEUPHONG";
            this.cbbKieuP.ValueMember = "IDKIEUPHONG";
        }


        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                string TenLoaiDV = txtTenPhong.Text;
                int idloaip = int.Parse(cbbLoaiP.SelectedValue.ToString());
                int idkieuphong = int.Parse(cbbKieuP.SelectedValue.ToString());

                PHONG dv = PhongDAO.Instance.GetPhong(map);
                if (dv != null)
                {
                    if (PhongDAO.Instance.SuaPhong(map, TenLoaiDV,idloaip,idkieuphong))
                    {
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    if (PhongDAO.Instance.ThemPhong(TenLoaiDV, idloaip, idkieuphong))
                    {
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                this.Close();
                Phong.BindGridPhong(PhongDAO.Instance.GetPhongall());
            }
        }
        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtTenPhong.Text))
            {
                txtTenPhong.Focus();
                MessageBox.Show("Nhập đầy Tên Phòng !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if(cbbKieuP.SelectedIndex == 0)
            {
                cbbKieuP.Focus();
                MessageBox.Show("Chọn Kiểu Phòng Phòng !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (cbbLoaiP.SelectedIndex == 0)
            {
                cbbLoaiP.Focus();
                MessageBox.Show("Chọn Loại Phòng Phòng !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void fm_ThemPhongMoi_Load(object sender, EventArgs e)
        {
            PHONG dv = PhongDAO.Instance.GetPhong(map);
            if (dv != null)
            {
                txtTenPhong.Text = dv.TENPHONG;
                cbbKieuP.SelectedIndex = dv.IDKIEUPHONG;
                cbbLoaiP.SelectedValue = dv.IDLOAIPHONG;

            }
            else
            {
                cbbLoaiP.SelectedIndex = 0;
                cbbKieuP.SelectedIndex = 0;
            }
          
            lbTenForm.Text = TenForm;
        }
    }
}
