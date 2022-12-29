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
    public partial class fm_ChiTietDatPhong : Form
    {
        public static int SophieuDatPhong;
        public fm_ChiTietDatPhong()
        {
            InitializeComponent();
            LoadDuLieu();
        }
        public fm_ChiTietDatPhong(fm_DatPhong datPhong)
        {
            InitializeComponent();
            LoadDuLieu();
            datPhong1 = datPhong;
        }
        double TongTienP = 0;
        fm_DatPhong datPhong1 = new fm_DatPhong();
        void LoadDuLieu()
        {
            dgvChiTiet.Rows.Clear();
            dgvChiTiet.Controls.Clear();
            PHIEUDATPHONG db = PhieuDatPhongDAO.Instance.getPhieuDatPhongTheoSoPhieu(SophieuDatPhong);
            if(db!= null)
            {
                lbSoPhieu.Text = db.SOPHIEUDATPHONG.ToString();
                lbTenKhach.Text = db.KHACHHANG.TENKHACHHANG;
                lbThoiGian.Text = db.NGAYDATPHONG.ToString("dd/MM/yyyy");
                lbNguoiLap.Text = db.NHANVIEN.TENNV;
            }
           

            List<CHITIETPHIEUDATPHONG> cHITIETPHIEUDATPHONGs = ChiTietPhieuDatPhongDAO.Instance.GetListCTPhieuThueTheoSoPhieuThue(SophieuDatPhong);
            
            foreach (var item in cHITIETPHIEUDATPHONGs)
            {
                int rowId = dgvChiTiet.Rows.Add();
                dgvChiTiet.Rows[rowId].Cells[0].Value = item.MAPHONG;
                dgvChiTiet.Rows[rowId].Cells[1].Value = item.SONGUOI;
                dgvChiTiet.Rows[rowId].Cells[2].Value = item.GIOVAO.ToString();
                dgvChiTiet.Rows[rowId].Cells[3].Value = item.GIORA.ToString();
                int GioThue = ChiTietPhieuDatPhongDAO.Instance.GetSoGioThue(item.MAPHONG,item.GIOVAO);
                
                int NgayThue = ChiTietPhieuDatPhongDAO.Instance.GetSoNgayThue(item.MAPHONG, item.GIOVAO);
               
            }
           
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (dgvChiTiet.Columns[e.ColumnIndex].HeaderText.Equals("Xóa"))
           {
                int tenPhong;
                DateTime ngayvao;
                
                tenPhong = int.Parse((dgvChiTiet.Rows[e.RowIndex].Cells[0].Value).ToString());
                ngayvao = DateTime.Parse((string)dgvChiTiet.Rows[e.RowIndex].Cells[2].Value);
                if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (ChiTietPhieuDatPhongDAO.Instance.DeleteCTPhieuThueTheoMaPhong(tenPhong,ngayvao))
                    {
                        MessageBox.Show("Xóa Phòng " + tenPhong + " của Phiếu" + lbSoPhieu.Text + " Thành Công !", "Thông Báo", MessageBoxButtons.OK);
                        LoadDuLieu();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Xóa Phòng " + tenPhong + " của Phiếu " + lbSoPhieu.Text + " Không  Thành Công !", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                if(dgvChiTiet.Rows.Count == 0)
                {
                    PhieuDatPhongDAO.Instance.DeletePhieuDatPhong(int.Parse(lbSoPhieu.Text));
                    this.Close();
                    datPhong1.LoadPhieudatPhong();
                }
                
                
            }
            
        }

        private void fm_ChiTietDatPhong_Load(object sender, EventArgs e)
        {

        }
    }
}
