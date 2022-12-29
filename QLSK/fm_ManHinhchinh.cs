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
    public partial class fm_ManHinhchinh : Form
    {
        public static string TenDK;
        TAIKHOAN TK = TaiKhoanDAO.Instance.GetTaiKhoanTheotenTK(TenDK);
        public static int quyen;
        public fm_ManHinhchinh()
        {
            InitializeComponent();
            CustomizeDesing();
            PhanQuyen();
           // CustomizeDesingCon();
        }

        


        void PhanQuyen()
        {
            if(quyen == 1)
            {
                btQuanLy.Visible = false;
                btTaiKhoan.Visible = false;
                btThongKe.Visible = false;
            }
            else if(quyen == 2)
            {
                btTaiKhoan.Visible = false;
            }
        }

        private void bttabMenu_Click(object sender, EventArgs e)
        {
            if (plChucNang.Width == 0)
            {
                ShowChucnang();
            }
            else
            {
                HideChucnang();
            }
        }
        private void ShowChucnang()
        {

                plChucNang.Width = 280;
                guna2Transition1.ShowSync(plChucNang);

     
        }
        private void HideChucnang()
        {
                plChucNang.Width = 0;
                guna2Transition1.ShowSync(plChucNang);
                
        }

        private void CustomizeDesing()
        {
            plChucNangPhong.Visible = false;
            plChucNangQuanLy.Visible = false;
        }

        private void hideSubMenu()
        {
            if (plChucNangPhong.Visible == true)
                plChucNangPhong.Visible = false;
            if (plChucNangQuanLy.Visible == true)
                plChucNangQuanLy.Visible = false;
        
        }
      

        private void showSubMenu(Panel Sub)
        {
            if (Sub.Visible == false)
            {
                hideSubMenu();
                
                Sub.Visible = true;
            }
            else
                Sub.Visible = false;
        }

      
        private Form activiveForm = null;
        private void OpenChildForm(Form ChildForm)
        {
            if (activiveForm != null)
                activiveForm.Close();
            activiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            plchucNangForm.Controls.Add(ChildForm);
            plchucNangForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void btPhong_Click_1(object sender, EventArgs e)
        {
            showSubMenu(plChucNangPhong);
        }

        private void btQuanLy_Click(object sender, EventArgs e)
        {
            showSubMenu(plChucNangQuanLy);
        }
       


        private void btDanhSachPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_DanhSachPhong());
            hideSubMenu();
            HideChucnang();
        }

        private void btDatPhong_Click(object sender, EventArgs e)
        {
            fm_DatPhong.MaNV = (int)TK.MANV;

            OpenChildForm(new fm_DatPhong());
            hideSubMenu();
            HideChucnang();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_DichVu());
            hideSubMenu();
            HideChucnang();
        }

        private void btLoaiDV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_LoaiDichVu());
            hideSubMenu();
            HideChucnang();
           
        }

        private void btVatTu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_VatTu());
            hideSubMenu();
            HideChucnang();
          
        }

        private void btKieuPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_KieuPhong());
            hideSubMenu();
            HideChucnang();
           
        }

        private void btLoaiPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_LoaiPhong());
            hideSubMenu();
            HideChucnang();
          
        }

        private void btQLP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_Phong());
            hideSubMenu();
            HideChucnang();
           
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_KhachHang());
            hideSubMenu();
            HideChucnang();
            

        }

        private void btPhieuLapDat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_LapDat());
            hideSubMenu();
            HideChucnang();
            
        }

        private void btTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_TaiKhoan());
            hideSubMenu();
            HideChucnang();
        }

        private void btHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_HoaDon());
            hideSubMenu();
            HideChucnang();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_NhanVien());
            hideSubMenu();
            HideChucnang();
        }

        private void btThongTinCaNhan_Click(object sender, EventArgs e)
        {
            fm_ThongTinCaNhan.TenDN = TenDK;
            OpenChildForm(new fm_ThongTinCaNhan());
            hideSubMenu();
            HideChucnang();
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_ThongKe());
            hideSubMenu();
            HideChucnang();
        }

        private void btQuanLyGiaP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fm_GiaPhong());
            hideSubMenu();
            HideChucnang();
        }
    }
}
