using QLSK.BUS;

using QLSK.DAO;
using QLSK.DTO;
using QLSK.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSK
{
    public partial class fm_XuatHoaDon : Form
    {
        public fm_XuatHoaDon()
        {
            InitializeComponent();
           
        }
        List<CT_SDDICHVU> _SDDICHVUs = new List<CT_SDDICHVU>();
        private void fm_XuatHoaDon_Load(object sender, EventArgs e)
        {
            int sophieusddv = PhieuSuDungDichVuDAO.Instance.GetSoPhieuSDDV(MaP, SoPhieu);
            HoaDonDAO.Instance.AddHoaDon(TongTien, SoPhieu, sophieusddv, MaP, 1);
            LoaddgvDichVu();
            LoadThongTinHoaDon();
        }
        public static int MaP;
        public static int SoPhieu;
        public static DateTime NgayBĐ;
        double TongTienDV;
        double TongTienPhong;
        double TongTien;
        public void LoaddgvDichVu()
        {

            dgvDichVu.Rows.Clear();
            dgvDichVu.Controls.Clear();
            CHITIETPHIEUDATPHONG pHIEUDATPHONG = ChiTietPhieuDatPhongDAO.Instance.GetCTPhieuThueTheoSoPhieuThue(MaP, NgayBĐ);
            if (pHIEUDATPHONG != null)
            {
                int sophieusddv = PhieuSuDungDichVuDAO.Instance.GetSoPhieuSDDV(MaP, SoPhieu);
                List<CHITIETSDDICHVU> cHITIETSDDICHVUs = CTSDDVDAO.Instance.GetListDV(sophieusddv);
                foreach (var item in cHITIETSDDICHVUs)
                {
                    int rowId = dgvDichVu.Rows.Add();
                    dgvDichVu.Rows[rowId].Cells[0].Value = item.DICHVU.TENDICHVU;
                    dgvDichVu.Rows[rowId].Cells[1].Value = item.SOLUONG;
                    dgvDichVu.Rows[rowId].Cells[2].Value =item.DICHVU.DONGIABAN;
                    dgvDichVu.Rows[rowId].Cells[3].Value =item.DICHVU.DVT;
                    dgvDichVu.Rows[rowId].Cells[4].Value = item.SOLUONG * item.DICHVU.DONGIABAN;
                    CT_SDDICHVU DV = new CT_SDDICHVU();
                    DV.IDDICHVU = item.IDDICHVU;
                    DV.TenDV = item.DICHVU.TENDICHVU;
                    DV.SOLUONG = item.SOLUONG;
                    DV.DVT = item.DICHVU.DVT;
                    DV.DonGia = item.DICHVU.DONGIABAN;
                    _SDDICHVUs.Add(DV);
                    TongTienDV = TongTienDV + (item.SOLUONG * item.DICHVU.DONGIABAN);
                }
                
            }
            lbTienDV.Text = TongTienDV.ToString();
        }
        void LoadThongTinHoaDon()
        {
            CHITIETPHIEUDATPHONG pHIEUDATPHONG = ChiTietPhieuDatPhongDAO.Instance.GetCTPhieuThueTheoSoPhieuThue(MaP, NgayBĐ);
            if (pHIEUDATPHONG != null)
            {

                int GioThue = ChiTietPhieuDatPhongDAO.Instance.GetSoGioThue(pHIEUDATPHONG.MAPHONG, NgayBĐ);

                int NgayThue = ChiTietPhieuDatPhongDAO.Instance.GetSoNgayThue(pHIEUDATPHONG.MAPHONG, NgayBĐ);

                if (NgayThue > 0)
                {
                    if (GioThue == 0)
                    {
                        lbThoiGian.Text = "" + NgayThue.ToString() + " Ngày";
                    }
                    else
                        lbThoiGian.Text = "" + NgayThue.ToString() + " Ngày " + GioThue.ToString() + " Giờ";
                }
                else
                {

                    lbThoiGian.Text = "" + GioThue.ToString() + " Giờ";

                }
                int sophieusddv = PhieuSuDungDichVuDAO.Instance.GetSoPhieuSDDV(MaP, SoPhieu);
                HOADON HD = HoaDonDAO.Instance.GetIDHoaDon(MaP, SoPhieu, sophieusddv);
                lbSoHoaDon.Text = HD.IDHOADON.ToString();
                lbNhanVien.Text = pHIEUDATPHONG.PHIEUDATPHONG.NHANVIEN.TENNV;
                lbNgayLap.Text = HD.NGAYLAP.ToString();
                string IDkieP = pHIEUDATPHONG.PHONG.KIEUPHONG.TENKIEUPHONG;
                string IDLP = pHIEUDATPHONG.PHONG.LOAIPHONG.TENLOAIPHONG;

                GIAPHONG GP = GiaPhongDAO.Instance.GetGIAPHONGTheoKPANDLP(IDkieP, IDLP);

                double TienTheoGio = (double)(GP.GIAGIO * GioThue);
                double TienTheoNgay = (double)(GP.GIANGAY * NgayThue);
                TongTienPhong = (TienTheoGio + TienTheoNgay);
                lbTienPhong.Text = (TienTheoGio + TienTheoNgay).ToString();
                TongTien = int.Parse(lbTienPhong.Text) + int.Parse(lbTienDV.Text);
                lbTongTien.Text = (int.Parse(lbTienPhong.Text) + int.Parse(lbTienDV.Text)).ToString();
                PHONG hONG =  PhongDAO.Instance.GetPhong(MaP);
                lbSoPhong.Text = hONG.TENPHONG;
                HoaDonDAO.Instance.updateTongTien(TongTien, SoPhieu, sophieusddv, MaP);
            }

        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image image = Resources.hoadon;
            Image image1 = Resources.icons8_heart_suit_96px_1;

            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("Ngày Lập: " + lbNgayLap.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, 190));
            e.Graphics.DrawString("Số Phòng: "+ lbSoPhong.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(500, 190));
            e.Graphics.DrawString("Số Hóa đơn: "+lbSoHoaDon.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, 245));
            e.Graphics.DrawString("Thời Gian Thuê: "+lbThoiGian.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(500, 245));
            e.Graphics.DrawString("Nhân Viên: "+lbNhanVien.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, 300));
            e.Graphics.DrawString("Tổng Tiền Phòng: "+lbTienPhong.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(500, 300));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, 350));
            e.Graphics.DrawString("Tên Dịch Vụ", new Font("Arial", 18, FontStyle.Regular), Brushes.Red, new Point(30, 380));
            e.Graphics.DrawString("Số Lượng", new Font("Arial", 18, FontStyle.Regular), Brushes.Red, new Point(200, 380));
            e.Graphics.DrawString("Đơn Giá", new Font("Arial", 18, FontStyle.Regular), Brushes.Red, new Point(380, 380));
            e.Graphics.DrawString("ĐVT", new Font("Arial", 18, FontStyle.Regular), Brushes.Red, new Point(520, 380));
            e.Graphics.DrawString("Thành Tiền", new Font("Arial", 18, FontStyle.Regular), Brushes.Red, new Point(650, 380));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, 400));
            int yPos = 430;
            foreach (var item in _SDDICHVUs)
            {
                e.Graphics.DrawString(item.TenDV, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(37, yPos));
                e.Graphics.DrawString(item.SOLUONG.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(250, yPos));
                e.Graphics.DrawString(item.DonGia.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(387, yPos));
                e.Graphics.DrawString(item.DVT, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(527, yPos));
                e.Graphics.DrawString((item.SOLUONG*item.DonGia).ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(680, yPos));
                yPos += 30;
            }
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
            yPos += 30;
            e.Graphics.DrawString("Tổng Tiền Dich Vụ: "+ lbTienDV.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Red, new Point(520, yPos));
            yPos += 30;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
            yPos += 30;
            e.Graphics.DrawString("Tổng Tiền: " + lbTongTien.Text, new Font("Arial", 22, FontStyle.Bold), Brushes.Black, new Point(520, yPos));
            
            e.Graphics.DrawImage(image1, 10, yPos-10, 50, 50);
            e.Graphics.DrawString("Cám Ơn Quý Khách ", new Font("Arial", 20, FontStyle.Bold), Brushes.Red, new Point(60, yPos));
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

     
    }
}
