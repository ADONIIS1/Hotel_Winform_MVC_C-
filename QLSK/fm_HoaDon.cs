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
    public partial class fm_HoaDon : Form
    {
        public fm_HoaDon()
        {
            InitializeComponent();
            LoadHoaDon();
        }

        void LoadHoaDon()
        {
            dgvHoaDon.Rows.Clear();
            //dgvDichVuChon.Rows.Clear();
          //  int sophieusddv = PhieuSuDungDichVuDAO.Instance.GetSoPhieuSDDV(MaP, sophieu);
            List<HOADON> HD = HoaDonDAO.Instance.GetHoaDon();
            foreach (var item in HD)
            {
                int rowId = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[rowId].Cells[0].Value = item.IDHOADON;
                dgvHoaDon.Rows[rowId].Cells[1].Value = item.NHANVIEN.TENNV;
                dgvHoaDon.Rows[rowId].Cells[2].Value = item.NGAYLAP;
                dgvHoaDon.Rows[rowId].Cells[3].Value = item.PHONG.TENPHONG;
                dgvHoaDon.Rows[rowId].Cells[4].Value = item.SOPHIEUDATPHONG;
                dgvHoaDon.Rows[rowId].Cells[5].Value = item.SOPHIEUSDDV;
                
            }
        }

        public void BindGridHoaDon(List<HOADON> listDichVu)
        {
            dgvHoaDon.Rows.Clear();

            foreach (var item in listDichVu)
            {
                int rowId = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[rowId].Cells[0].Value = item.IDHOADON;
                dgvHoaDon.Rows[rowId].Cells[1].Value = item.NHANVIEN.TENNV;
                dgvHoaDon.Rows[rowId].Cells[2].Value = item.NGAYLAP;
                dgvHoaDon.Rows[rowId].Cells[3].Value = item.PHONG.TENPHONG;
                dgvHoaDon.Rows[rowId].Cells[4].Value = item.SOPHIEUDATPHONG;
                dgvHoaDon.Rows[rowId].Cells[5].Value = item.SOPHIEUSDDV;
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IDHoaDOn = int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[0].Value.ToString());
            HOADON hOADON = HoaDonDAO.Instance.getHoaDonTheoID(IDHoaDOn);
            int sophieu = int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[4].Value.ToString());
            int MAP = (int)hOADON.MAPHONG;
            CHITIETPHIEUDATPHONG CTPDP = ChiTietPhieuDatPhongDAO.Instance.GetCTPhieuThueTheoSoPhieuThuevaMAp(sophieu, MAP);

            if (dgvHoaDon.Columns[e.ColumnIndex].HeaderText == "Chi Tiết") 
            {
                fm_XuatHoaDon.MaP = MAP;
                fm_XuatHoaDon.NgayBĐ = CTPDP.GIOVAO;
                fm_XuatHoaDon.SoPhieu = sophieu;
                fm_XuatHoaDon fm_XuatHoaDon1 = new fm_XuatHoaDon();
                fm_XuatHoaDon1.ShowDialog();
            }
          
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<HOADON> ListVatTus = HoaDonDAO.Instance.GetHoaDon();
            var listTimKiem = ListVatTus.Where(p => (p is HOADON) && (p as HOADON).NHANVIEN.TENNV.ToLower().Contains(txtTimKiem.Text.ToLower())
                           || Convert.ToString(p.IDHOADON).Contains(txtTimKiem.Text)
                           || Convert.ToString(p.SOPHIEUDATPHONG).Contains(txtTimKiem.Text)
                           || Convert.ToString(p.SOPHIEUSDDV).Contains(txtTimKiem.Text)
                           || p.PHONG.TENPHONG.ToLower().Contains(txtTimKiem.Text.ToLower())
                           ).ToList();
            BindGridHoaDon(listTimKiem);
        }
    }
}
