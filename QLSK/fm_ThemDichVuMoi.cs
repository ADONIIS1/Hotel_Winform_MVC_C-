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
    public partial class fm_ThemDichVuMoi : Form
    {
        public fm_ThemDichVuMoi()
        {
            InitializeComponent();
            
        }
        public fm_ThemDichVuMoi(fm_DichVu fm_Dich)
        {
            InitializeComponent();
            LoadCombobox();
            dichVu = fm_Dich;
        }
        fm_DichVu dichVu = new fm_DichVu();
        public static int idDichVu;
        public static string TenForm;
        void LoadCombobox()
        {
            List<LOAIDICHVU> DV = LoaiDichVuDAO.Instance.GetLoaiDichVu();
          
            DV.Insert(0, new LOAIDICHVU { TENLOAIDICHVU = "Chọn Loại Dịch Vụ" });
            cbbLoaiDV.DataSource = DV;
            cbbLoaiDV.ValueMember = "IDLOAIDICHVU";
            cbbLoaiDV.DisplayMember = "TENLOAIDICHVU";
           
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fm_ThemDichVuMoi_Load(object sender, EventArgs e)
        {
            LoadCombobox();
           
            DICHVU dv = DichVuDAO.Instance.GetDichVu(idDichVu);
            if(dv != null)
            {
                txtTenDV.Text = dv.TENDICHVU;
                txtDonGia.Text = dv.DONGIABAN.ToString();
                txtDVT.Text = dv.DVT;
                cbbLoaiDV.SelectedIndex = dv.LOAIDICHVU.IDLOAIDICHVU;
            }
            else
                cbbLoaiDV.SelectedIndex = 0;
            lbTenForm.Text = TenForm;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                string TenDV = txtTenDV.Text;
                int dongia = int.Parse(txtDonGia.Text);
                string DVT = txtDVT.Text;
                int IDLoaiDV = int.Parse(cbbLoaiDV.SelectedValue.ToString());

                DICHVU dv = DichVuDAO.Instance.GetDichVu(idDichVu);
                if (dv != null)
                {
                    if (DichVuDAO.Instance.SuaDichVu(idDichVu, TenDV, dongia, DVT, IDLoaiDV))
                    {
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    if (DichVuDAO.Instance.ThemDichVu(TenDV, dongia, DVT, IDLoaiDV))
                    {
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                this.Close();
                dichVu.BindGridDichVu(DichVuDAO.Instance.GetallListDichVu());
            }
        }
        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtTenDV.Text))
            {
                txtTenDV.Focus();
                MessageBox.Show("Nhập đầy Tên Dịch Vụ !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            //Kiểm tra textbox dongia rỗng hoặc nhập kí tự chữ không
            if (string.IsNullOrWhiteSpace(txtDonGia.Text) )
            {
                txtDonGia.Focus();
                MessageBox.Show("Nhập đầy Đơn Giá !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                if (!long.TryParse(txtDonGia.Text, out long temp1))
                {
                    txtDonGia.Focus();
                    MessageBox.Show("Nhập Đơn Giá đúng định dạng số !", "Thông báo", MessageBoxButtons.OK);

                    return false;
                }
                
            }
            if(cbbLoaiDV.SelectedIndex == 0)
            {
                cbbLoaiDV.Focus();
                MessageBox.Show("Bạn Phải Chọn Loại Dịch Vụ", "Thông báo", MessageBoxButtons.OK);

                return false;
            }
            //Kiểm tra textbox SDT rỗng hoặc có nhập chữ không
           
            //Kiểm tra ô Đơn Vị Tính
            if (string.IsNullOrWhiteSpace(txtDVT.Text))
            {
                txtDVT.Focus();
                MessageBox.Show("Nhập đầy Đơn Vị Tính !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
           
            return true;
        }
    }
}
