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
    public partial class fm_ThemVatTu : Form
    {
        public fm_ThemVatTu()
        {
            InitializeComponent();
        }
        public fm_ThemVatTu(fm_VatTu fm_VatTu)
        {
            InitializeComponent();
            fm_VatTu1 = fm_VatTu;
        }
        fm_VatTu fm_VatTu1 = new fm_VatTu();
        public static int MaVT;
        public static string TenForm;



        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                string TenVT = txtTenVT.Text;
               
                string XuatXu = txtXuatXu.Text;
                //int IDLoaiDV = int.Parse(cbbLoaiDV.SelectedValue.ToString());

                VATTU VT = VatTuDAO.Instance.GetVatTutheoMaVT(MaVT);
                if (VT != null)
                {
                    if (VatTuDAO.Instance.SuaVatTu(MaVT,TenVT,XuatXu))
                    {
                        MessageBox.Show("Sửa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    if (VatTuDAO.Instance.ThemVatTu(TenVT, XuatXu))
                    {
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    }

                }
                this.Close();
                fm_VatTu1.BindGridVatTu(VatTuDAO.Instance.GetAllVatTu());
            }
        }
        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtTenVT.Text))
            {
                txtTenVT.Focus();
                MessageBox.Show("Nhập đầy Tên Vật Tư !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            //Kiểm tra textbox dongia rỗng hoặc nhập kí tự chữ không
            if (string.IsNullOrWhiteSpace(txtXuatXu.Text))
            {
                txtXuatXu.Focus();
                MessageBox.Show("Nhập đầy Xuất Xứ !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
            private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fm_ThemVatTu_Load(object sender, EventArgs e)
        {
            

            VATTU VT = VatTuDAO.Instance.GetVatTutheoMaVT(MaVT);
            if (VT != null)
            {
                txtTenVT.Text = VT.TENVATTU;
                txtXuatXu.Text = VT.XUATXU.ToString();
            }
            lbTenForm.Text = TenForm;
        }
    }
}
