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
    public partial class fm_ChiTietLapDat : Form
    {
        public fm_ChiTietLapDat()
        {
            InitializeComponent();
        }
        public fm_ChiTietLapDat(fm_LapDat fm_LapDat)
        {
            InitializeComponent();
            fm_LapDat1 = fm_LapDat;
        }
        fm_LapDat fm_LapDat1 = new fm_LapDat();
        public static string TenForm;
        public static int sophieu;

        private void fm_ChiTietLapDat_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            dgvChiTiet.Rows.Clear();
            dgvChiTiet.Controls.Clear();
            PHIEULAPDAT db = PhieuLapDatDAO.Instance.GetphieulapDattheosophieu(sophieu);
            if(db != null)
            {
                lbPhòng.Text = db.PHONG.TENPHONG.ToString();
                lbTenFrom.Text = TenForm;
                // lbTenKhach.Text = db.KHACHHANG.TENKHACHHANG;
                lbThoiGian.Text = db.NGAYLAPDAT.ToString();
                lbNguoiLap.Text = db.NHANVIEN.TENNV;
            }
           
          //  lbTenFrom = 

            List<CHITIETLAPDAT> cHITIETPHIEUDATPHONGs = ChiTietPhieuLapDatDAO.Instance.GetCHITIETLAPDATforSOPhiue(sophieu);

            foreach (var item in cHITIETPHIEUDATPHONGs)
            {
                int rowId = dgvChiTiet.Rows.Add();
                dgvChiTiet.Rows[rowId].Cells[0].Value = item.IDVATTU;
                dgvChiTiet.Rows[rowId].Cells[1].Value = item.VATTU.TENVATTU;
                dgvChiTiet.Rows[rowId].Cells[2].Value = item.TINHTRANG;
            }
           

        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChiTiet.Columns[e.ColumnIndex].HeaderText.Equals("Xóa"))
            {
                int tenPhong;
               

                tenPhong = int.Parse((dgvChiTiet.Rows[e.RowIndex].Cells[0].Value).ToString());
                
               
                if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (ChiTietPhieuLapDatDAO.Instance.XoaCTphieu(tenPhong))
                    {
                        MessageBox.Show("Xóa  Thành Công !", "Thông Báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Xóa  Không  Thành Công !", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                if (dgvChiTiet.Rows.Count == 0)
                {
                    PhieuLapDatDAO.Instance.DeletePhieuLapDat(sophieu);
                    this.Close();
                    fm_LapDat1.BindGridPhieu(PhieuLapDatDAO.Instance.GetAllPhieuLapDat());
                }


            }
        }
    }
}
