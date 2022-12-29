using Microsoft.Reporting.WinForms;
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
    public partial class fm_BaoCao : Form
    {
        int Nam = 2022;
        public fm_BaoCao()
        {
            InitializeComponent();
        }

        private void fm_BaoCao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyKhachSan1DataSet.HOADON' table. You can move, or remove it, as needed.
            this.HOADONTableAdapter.Fill(this.QuanLyKhachSan1DataSet.HOADON);
            LoadComboboxThang();
            LoadComboboxNam();
            cbbNam.Text = "2022";
        }

        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime ngayDauThang = new DateTime();
            DateTime ngayCuoiThang = new DateTime();
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
            else if (cbbThang.Text == "12")
            {
                ngayDauThang = new DateTime(Nam, 12, 1);
                ngayCuoiThang = new DateTime(Nam, 12, 31);
            }

            List<HOADON> listHoaDon = HoaDonDAO.GetListHoaDon();
            var listdata = listHoaDon.Where(p => (p as HOADON).NGAYLAP >= ngayDauThang && p.NGAYLAP <= ngayCuoiThang).ToList();
            this.reportViewer1.LocalReport.ReportPath = "ReportHoaDon.rdlc";
            var reportDataSource = new ReportDataSource("HoaDonData", listdata);
            this.reportViewer1.LocalReport.DataSources.Clear(); //clear
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNam.Text == "2018")
            {
                Nam = 2018;
                cbbThang.Text = "1";
                cbbThang.Text = "Cả năm";
            }
            else if (cbbNam.Text == "2019")
            {
                Nam = 2019;
                cbbThang.Text = "1";
                cbbThang.Text = "Cả năm";
            }
            else if (cbbNam.Text == "2020")
            {
                Nam = 2020;
                cbbThang.Text = "1";
                cbbThang.Text = "Cả năm";

            }
            else if (cbbNam.Text == "2021")
            {
                Nam = 2021;
                cbbThang.Text = "1";
                cbbThang.Text = "Cả năm";
            }
            else if (cbbNam.Text == "2022")
            {
                Nam = 2022;
                cbbThang.Text = "1";
                cbbThang.Text = "Cả năm";

            }
            else if (cbbNam.Text == "2023")
            {
                Nam = 2023;
                cbbThang.Text = "1";
                cbbThang.Text = "Cả năm";
            }
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

        void LoadComboboxNam()
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

    }
}
