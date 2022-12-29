using QLSK.DAO;
using QLSK.DTO;
using QLSK.Properties;
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
    public partial class fm_ChiTietPhong : Form
    {
        public fm_ChiTietPhong()
        {
            InitializeComponent();

        }
        public fm_ChiTietPhong(fm_DanhSachPhong fm_DanhSach)
        {
            InitializeComponent();

            fm_DanhSachP = fm_DanhSach;
        }
        fm_DanhSachPhong fm_DanhSachP = new fm_DanhSachPhong();
        public static string MaP;
        public static string SoPhieu;
        public static DateTime NgayBĐ;
        double TongTienDV = 0;

        public static DialogResult Result { get; internal set; }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void fm_ChiTietPhong_Load(object sender, EventArgs e)
        {
            lbSoPhong.Text = MaP;
            btThemDV.Visible = false;
            btThanhToan.Visible = false;
            LoadDuLieu();
            LoaddgvDichVu();
            
        }
        QuanLyKhachSan ConText = new QuanLyKhachSan();
        public void LoadDuLieu()
        {
            CHITIETPHIEUDATPHONG pHIEUDATPHONG = ChiTietPhieuDatPhongDAO.Instance.GetCTPhieuThueTheoSoPhieuThue(int.Parse(MaP), NgayBĐ);
            if (pHIEUDATPHONG != null)
            {
                int sophieu = pHIEUDATPHONG.SOPHIEUDATPHONG;
                HOADON HD = ConText.HOADON.FirstOrDefault(p => p.MAPHONG.ToString().Equals(MaP) && p.SOPHIEUDATPHONG == sophieu);
                if (HD == null)
                {
                    btThemDV.Visible = true;
                    btThanhToan.Visible = true;
                    int GioThue = ChiTietPhieuDatPhongDAO.Instance.GetSoGioThue(pHIEUDATPHONG.MAPHONG, NgayBĐ);

                    int NgayThue = ChiTietPhieuDatPhongDAO.Instance.GetSoNgayThue(pHIEUDATPHONG.MAPHONG, NgayBĐ);

                    if (NgayThue > 0)
                    {
                        if (GioThue == 0)
                        {
                            lbSoNgayThue.Text = "" + NgayThue.ToString() + " Ngày";
                        }
                        else
                            lbSoNgayThue.Text = "" + NgayThue.ToString() + " Ngày " + GioThue.ToString() + " Giờ";
                    }
                    else
                    {
                        pbThoiGian.Image = Resources.icons8_time_64px;
                        lbSoNgayThue.Text = "" + GioThue.ToString() + " Giờ";

                    }

                    lbNhanVien.Text = pHIEUDATPHONG.PHIEUDATPHONG.NHANVIEN.TENNV;
                    lbNguoiDat.Text = pHIEUDATPHONG.PHIEUDATPHONG.KHACHHANG.TENKHACHHANG;
                    lbNgayDat.Text = pHIEUDATPHONG.PHIEUDATPHONG.NGAYDATPHONG.ToString("dd/MM/yyyy");

                    txtMaDK.Text = pHIEUDATPHONG.SOPHIEUDATPHONG.ToString();
                    txtTinhTrang.Text = pHIEUDATPHONG.TINHTRANGPHONG.ToString();
                    if (pHIEUDATPHONG.TINHTRANGPHONG.ToString().Equals("Đã Đặt"))
                    {
                        btThanhToan.Text = "Nhận Phòng";
                    }
                }
                else
                {
                    txtTinhTrang.Text = "Phòng Trống";
                }
            }
            else
            {
                txtTinhTrang.Text = "Phòng Trống";
            }
       
        }
       
        public void LoaddgvDichVu()
        {
            dgvDichVu.Rows.Clear();
            dgvDichVu.Controls.Clear();
            CHITIETPHIEUDATPHONG pHIEUDATPHONG = ChiTietPhieuDatPhongDAO.Instance.GetCTPhieuThueTheoSoPhieuThue(int.Parse(MaP), NgayBĐ);
            if (pHIEUDATPHONG != null)
            {
                int sophieu = pHIEUDATPHONG.SOPHIEUDATPHONG;
                HOADON HD = ConText.HOADON.FirstOrDefault(p => p.MAPHONG.ToString().Equals(MaP) && p.SOPHIEUDATPHONG == sophieu);
                if (HD == null)
                {
                    int sophieusddv = PhieuSuDungDichVuDAO.Instance.GetSoPhieuSDDV(int.Parse(MaP), int.Parse(txtMaDK.Text));
                    List<CHITIETSDDICHVU> cHITIETSDDICHVUs = CTSDDVDAO.Instance.GetListDV(sophieusddv);
                    foreach (var item in cHITIETSDDICHVUs)
                    {
                        int rowId = dgvDichVu.Rows.Add();
                        dgvDichVu.Rows[rowId].Cells[0].Value = item.DICHVU.TENDICHVU;
                        dgvDichVu.Rows[rowId].Cells[1].Value = item.SOLUONG;
                        dgvDichVu.Rows[rowId].Cells[2].Value = item.SOLUONG * item.DICHVU.DONGIABAN;
                        TongTienDV = TongTienDV + (item.SOLUONG * item.DICHVU.DONGIABAN);
                    }
                    PhieuSuDungDichVuDAO.Instance.updataTongTienDV(int.Parse(MaP), int.Parse(txtMaDK.Text), TongTienDV);
                }
            }
        }

        private void btThemDV_Click(object sender, EventArgs e)
        {

            fm_ThemDichVu.MaP = int.Parse(MaP);
            fm_ThemDichVu.sophieu = int.Parse(txtMaDK.Text);
            fm_ThemDichVu themDichVu = new fm_ThemDichVu(this);
            themDichVu.ShowDialog();

        }


        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if (btThanhToan.Text == "Thanh Toán")
            {
                fm_XuatHoaDon.MaP = int.Parse(MaP);
                fm_XuatHoaDon.NgayBĐ = NgayBĐ;
                fm_XuatHoaDon.SoPhieu = int.Parse(txtMaDK.Text);
                fm_XuatHoaDon fm_XuatHoaDon1 = new fm_XuatHoaDon();
                fm_XuatHoaDon1.ShowDialog();
                this.Close();
                fm_DanhSachP.LoadPhong();
                
            }
            if (btThanhToan.Text == "Nhận Phòng")
            {
                if (ChiTietPhieuDatPhongDAO.Instance.ThayDoiTinhTrangPhong(int.Parse(MaP), int.Parse(txtMaDK.Text)))
                {
                    LoadDuLieu();
                    btThanhToan.Text = "Thanh Toán";
                    fm_DanhSachP.LoadPhong();
                }
               
            }
          
              
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (btThanhToan.Text == "Thanh Toán")
            {
                Result = DialogResult.OK;
                this.Close();

            }
        }
    }
}
