using QLSK.Custom;
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
    public partial class fm_ThongKe : Form
    {

        // dữ liệu biểu đồ tròn
        double TongTienPhong = 0;
        double TongTienDV = 0;
        double TongSoLanDatPhong = 0;

        // dữ liệu biểu đồ đường
        string thangd;
        double TienPhongd = 0;
        double TienDichVud = 0;
        double TongTiend = 0;

        // danh sách biểu đồ tròn
        List<DataBDTron_Custom> ThongKe = new List<DataBDTron_Custom>();

        //danh sách biểu đồ đường
        List<DataBDCot_Custom> Data = new List<DataBDCot_Custom>();

        int Nam = 2022; // gán năm cho cbbThang

        public fm_ThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadComboboxThang();
            LoadConboboxNam();
            cbbNam.Text = "2022";
        }


        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime ngayDauThang = new DateTime();
            DateTime ngayCuoiThang = new DateTime();

            ThongKe.Clear();
            //ChonThang(ngayDau, ngayCuoi); chua return dc ngày đầu ngày cuối
            if (cbbThang.Text == "Cả năm")
            {
                ngayDauThang = new DateTime(Nam, 1, 1);
                ngayCuoiThang = new DateTime(Nam, 12, 31);
            }
            else if (cbbThang.Text == "1")
            {
                ngayDauThang = new DateTime(Nam, 1, 1);
                ngayCuoiThang = new DateTime(Nam, 1, 31);
            }
            else if (cbbThang.Text == "2")
            {
                ngayDauThang = new DateTime(Nam, 2, 1);
                ngayCuoiThang = new DateTime(Nam, 2, 28);
            }
            else if (cbbThang.Text == "3")
            {
                ngayDauThang = new DateTime(Nam, 3, 1);
                ngayCuoiThang = new DateTime(Nam, 3, 31);
            }
            else if (cbbThang.Text == "4")
            {
                ngayDauThang = new DateTime(Nam, 4, 1);
                ngayCuoiThang = new DateTime(Nam, 4, 30);
            }
            else if (cbbThang.Text == "5")
            {
                ngayDauThang = new DateTime(Nam, 5, 1);
                ngayCuoiThang = new DateTime(Nam, 5, 31);
            }
            else if (cbbThang.Text == "6")
            {
                ngayDauThang = new DateTime(Nam, 6, 1);
                ngayCuoiThang = new DateTime(Nam, 6, 30);
            }
            else if (cbbThang.Text == "7")
            {
                ngayDauThang = new DateTime(Nam, 7, 1);
                ngayCuoiThang = new DateTime(Nam, 7, 31);
            }
            else if (cbbThang.Text == "8")
            {
                ngayDauThang = new DateTime(Nam, 8, 1);
                ngayCuoiThang = new DateTime(Nam, 8, 31);
            }
            else if (cbbThang.Text == "9")
            {
                ngayDauThang = new DateTime(Nam, 9, 1);
                ngayCuoiThang = new DateTime(Nam, 9, 30);
            }
            else if (cbbThang.Text == "10")
            {
                ngayDauThang = new DateTime(Nam, 10, 1);
                ngayCuoiThang = new DateTime(Nam, 10, 31);
            }
            else if (cbbThang.Text == "11")
            {
                ngayDauThang = new DateTime(Nam, 11, 1);
                ngayCuoiThang = new DateTime(Nam, 11, 30);
            }
            else
            {
                ngayDauThang = new DateTime(Nam, 12, 1);
                ngayCuoiThang = new DateTime(Nam, 12, 31);
            }

            // tien dich vu
            List<PHIEUSDDV> conbo = PhieuSuDungDichVuDAO.GetallListSDDV();
            var bo = conbo.Where(p => (p as PHIEUSDDV).NGAYSDDV >= ngayDauThang && p.NGAYSDDV <= ngayCuoiThang).ToList();
            TongTienDV = TienDV(bo);


            //tien phong
            List<PHIEUDATPHONG> contrau = PhieuDatPhongDAO.GetallListPhieuDatPhong();
            var trau = contrau.Where(p => (p as PHIEUDATPHONG).NGAYDATPHONG >= ngayDauThang && p.NGAYDATPHONG <= ngayCuoiThang).ToList();
            TongTienPhong = TienPhong(trau);

            // so lan dat phong
            TongSoLanDatPhong = SoLanDatPhong(trau);

            AddListBDTron();
            LoadBieuDoTron();
            LoadLableThang();
        }

        void AddListBDTron()
        {
            DataBDTron_Custom phong = new DataBDTron_Custom();
            phong.Ten = "Phòng : " + (TongTienPhong / (TongTienPhong + TongTienDV) * 100).ToString("#.##") + "%";
            phong.Tien = TongTienPhong;
            ThongKe.Add(phong);

            DataBDTron_Custom dv = new DataBDTron_Custom();
            dv.Ten = "Dịch vụ : " + (TongTienDV / (TongTienPhong + TongTienDV) * 100).ToString("#.##") + "%";
            dv.Tien = TongTienDV;
            ThongKe.Add(dv);
        }

        void LoadBieuDoTron()
        {
            cBieuDoTron.Titles.Clear();
            cBieuDoTron.Titles.Add("Doanh thu tháng");
            cBieuDoTron.Series["HinhTron"].Points.Clear();
            foreach (var item in ThongKe)
            {
                cBieuDoTron.Series["HinhTron"].Points.AddXY(item.Ten, item.Tien);
            }
        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime ngayDauThang = new DateTime();
            DateTime ngayCuoiThang = new DateTime();
            Nam = int.Parse(cbbNam.Text);
            // làm m0i Danh sách giá trị truyền vào biểu đồ đường
            Data.Clear();

            for (int i = 1; i <= 12; i++)
            {
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
                {
                    ngayDauThang = new DateTime(Nam, i, 1);
                    ngayCuoiThang = new DateTime(Nam, i, 31);
                    AddListBDDuong(ngayDauThang, ngayCuoiThang, i);
                    cbbThang.Text = "1";
                    cbbThang.Text = "Cả năm";
                }
                else if (i == 2)
                {
                    ngayDauThang = new DateTime(Nam, 2, 1);
                    ngayCuoiThang = new DateTime(Nam, 2, 28);
                    AddListBDDuong(ngayDauThang, ngayCuoiThang, 2);
                    cbbThang.Text = "1";
                    cbbThang.Text = "Cả năm";
                }
                else
                {
                    ngayDauThang = new DateTime(Nam, i, 1);
                    ngayCuoiThang = new DateTime(Nam, i, 30);
                    AddListBDDuong(ngayDauThang, ngayCuoiThang, i);
                    cbbThang.Text = "1";
                    cbbThang.Text = "Cả năm";
                }
            }
            LoadBieuDoCot();
        }

        void AddListBDDuong(DateTime ngayDauThang, DateTime ngayCuoiThang, int thang)
        {
            // tien dich vu
            List<PHIEUSDDV> conbo = PhieuSuDungDichVuDAO.GetallListSDDV();
            var bo = conbo.Where(p => (p as PHIEUSDDV).NGAYSDDV >= ngayDauThang && p.NGAYSDDV <= ngayCuoiThang).ToList();
            TienDichVud = TienDV(bo);

            //tien phong
            List<PHIEUDATPHONG> contrau = PhieuDatPhongDAO.GetallListPhieuDatPhong();
            var trau = contrau.Where(p => (p as PHIEUDATPHONG).NGAYDATPHONG >= ngayDauThang && p.NGAYDATPHONG <= ngayCuoiThang).ToList();
            TienPhongd = TienPhong(trau);

            TongSoLanDatPhong = SoLanDatPhong(trau);

            TongTiend = TienDichVud + TienPhongd;
            thangd = "Tháng " + thang;

            DataBDCot_Custom data = new DataBDCot_Custom();
            data.Thang = thangd;
            data.TienDichVu = TienDichVud;
            data.TienPhong = TienPhongd;
            data.TongTien = TongTiend;
            Data.Add(data);
        }

        void LoadBieuDoCot()
        {
            chartDuong.Titles.Clear();
            chartDuong.Titles.Add("Doanh Thu năm");
            chartDuong.Series["TongTien"].Points.Clear();
            chartDuong.Series["TienDV"].Points.Clear();
            chartDuong.Series["TienPhong"].Points.Clear();
            foreach (var item in Data)
            {
                chartDuong.Series["TongTien"].Points.AddXY(item.Thang, item.TongTien);
                chartDuong.Series["TienDV"].Points.AddY(item.TienDichVu);
                chartDuong.Series["TienPhong"].Points.AddY(item.TienPhong);
            }
        }

        void LoadLableThang()
        {
            lblTienPhong.Text = TongTienPhong.ToString();
            lblTienDV.Text = TongTienDV.ToString();
            lblSoPhong.Text = TongSoLanDatPhong.ToString();
        }

        void LoadLableNam()
        {
            lblTienPhong.Text = TongTienPhong.ToString();
            lblTienDV.Text = TongTienDV.ToString();
            lblSoPhong.Text = TongSoLanDatPhong.ToString();
        }

        void LoadConboboxNam()
        {
            List<string> nam = new List<string>();
            nam.Add("2018");
            nam.Add("2019");
            nam.Add("2020");
            nam.Add("2021");
            nam.Add("2022");
            nam.Add("2023");
            cbbNam.DataSource = nam;
        }

        void LoadComboboxThang()
        {
            List<string> thang = new List<string>();
            thang.Add("Cả năm");
            thang.Add("1");
            thang.Add("2");
            thang.Add("3");
            thang.Add("4");
            thang.Add("5");
            thang.Add("6");
            thang.Add("7");
            thang.Add("8");
            thang.Add("9");
            thang.Add("10");
            thang.Add("11");
            thang.Add("12");
            cbbThang.DataSource = thang;
        }

        private double TienDV(List<PHIEUSDDV> List)
        {
            TongTienDV = 0;
            foreach (var item in List)
            {
                TongTienDV = TongTienDV + double.Parse(item.TONGTIENDV.ToString());
            }
            return TongTienDV;
        }

        private double TienPhong(List<PHIEUDATPHONG> List)
        {
            TongTienPhong = 0;
            foreach (var item in List)
            {
                TongTienPhong = TongTienPhong + double.Parse(item.TONGTIENDATPHONG.ToString());
            }
            return TongTienPhong;
        }

        private double SoLanDatPhong(List<PHIEUDATPHONG> List)
        {
            TongSoLanDatPhong = 0;
            foreach (var item in List)
            {
                TongSoLanDatPhong++;
            }
            return TongSoLanDatPhong;
        }

        private void bttabMenu_Click(object sender, EventArgs e)
        {
            fm_BaoCao BaoCao = new fm_BaoCao();
            BaoCao.ShowDialog();
        }
    }
}
