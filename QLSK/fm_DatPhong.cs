using QLSK.DAO;
using QLSK.DesignUserControl;
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
    public partial class fm_DatPhong : Form
    {
        public fm_DatPhong()
        {
            InitializeComponent();
            LoadPhieudatPhong();
        }
        public static int MaNV;
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm Kiếm")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                txtTimKiem.Text = "Tìm Kiếm";
                txtTimKiem.ForeColor = Color.Silver;
            }
        }

        private void btDatPhongMoi_Click(object sender, EventArgs e)
        {
            fm_DatPhongMoi.MaNV = MaNV;
            fm_DatPhongMoi datPhongMoi = new fm_DatPhongMoi(this);
            datPhongMoi.ShowDialog();
        }
       

        List<PHIEUDATPHONG> TimKiem()
        {
            List<PHIEUDATPHONG> dp = PhieuDatPhongDAO.Instance.GetPHIEUDATPHONGALL();
            if (txtTimKiem.Text != "Tìm Kiếm")
            {
                dp = (from c in dp.Where(c => c.SOPHIEUDATPHONG.ToString().Contains(txtTimKiem.Text) || c.KHACHHANG.TENKHACHHANG.Contains(txtTimKiem.Text) || c.NGAYDATPHONG.ToString().Contains(txtTimKiem.Text)) select c).ToList<PHIEUDATPHONG>();
            }
            return dp;
        }


        public void LoadPhieudatPhong()
        {
            dgvPhieuDatPhong.Rows.Clear();
            dgvPhieuDatPhong.Controls.Clear();

            List<PHIEUDATPHONG> PHIEUDATPHONGs = TimKiem();
            foreach (PHIEUDATPHONG item in PHIEUDATPHONGs)
            {
                int rowId = dgvPhieuDatPhong.Rows.Add();
                dgvPhieuDatPhong.Rows[rowId].Cells["SoPhieuDatPhong"].Value = item.SOPHIEUDATPHONG;
                dgvPhieuDatPhong.Rows[rowId].Cells["TenKhach"].Value = item.KHACHHANG.TENKHACHHANG;
                dgvPhieuDatPhong.Rows[rowId].Cells["NĐat"].Value = item.NGAYDATPHONG.ToString("dd/MM/yyyy");
            }

        }

        private void dgvPhieuDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( dgvPhieuDatPhong.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int sophieudatphongxoa = int.Parse(dgvPhieuDatPhong.Rows[e.RowIndex].Cells["SoPhieuDatPhong"].Value.ToString());
                    bool result = PhieuDatPhongDAO.Instance.DeletePhieuDatPhong(sophieudatphongxoa);
                    if (result)
                    {
                        
                        MessageBox.Show("Xóa Số Phiếu " +sophieudatphongxoa+ " Thành Công");
                        LoadPhieudatPhong();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Số Phiếu " + sophieudatphongxoa + " Thất Bại");

                    }
                }
            }
            if (dgvPhieuDatPhong.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
            {
                fm_ChiTietDatPhong.SophieuDatPhong = int.Parse(dgvPhieuDatPhong.Rows[e.RowIndex].Cells["SoPhieuDatPhong"].Value.ToString());
                fm_ChiTietDatPhong fm_ChiTietDat = new fm_ChiTietDatPhong(this);
                fm_ChiTietDat.ShowDialog();
            }
           
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadPhieudatPhong();
        }
    }
}
