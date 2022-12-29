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
    public partial class fm_LapDat : Form
    {
        public fm_LapDat()
        {
            InitializeComponent();
        }
        private void frmLapDat_Load(object sender, EventArgs e)
        {
            BindGridPhieu(PhieuLapDatDAO.Instance.GetAllPhieuLapDat());
            
        }
        public void BindGridPhieu(List<PHIEULAPDAT> list)
        {
            dgvPhieuLapDat.Rows.Clear();

            foreach (var item in list)
            {
                int index = dgvPhieuLapDat.Rows.Add();
                dgvPhieuLapDat.Rows[index].Cells[0].Value = item.SOPHIEULAPDAT;
                dgvPhieuLapDat.Rows[index].Cells[1].Value = item.NHANVIEN.TENNV;
                dgvPhieuLapDat.Rows[index].Cells[2].Value = item.NGAYLAPDAT;
            }
        }

        private void btThemLDMoi_Click(object sender, EventArgs e)
        {
            fm_PhieuLapDatMoi fm_PhieuLapDatMoi = new fm_PhieuLapDatMoi(this);
            fm_PhieuLapDatMoi.ShowDialog();
        }

        private void dgvPhieuLapDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuLapDat.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int sophieudatphongxoa = int.Parse(dgvPhieuLapDat.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (PhieuLapDatDAO.Instance.DeletePhieuLapDat(sophieudatphongxoa))
                    {

                        MessageBox.Show("Xóa Số Phiếu " + sophieudatphongxoa + " Thành Công");
                        BindGridPhieu(PhieuLapDatDAO.Instance.GetAllPhieuLapDat());
                    }
                    else
                    {
                        MessageBox.Show("Xóa Số Phiếu " + sophieudatphongxoa + " Thất Bại");

                    }
                }
            }
            if (dgvPhieuLapDat.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
            {
                fm_ChiTietLapDat.sophieu = int.Parse(dgvPhieuLapDat.Rows[e.RowIndex].Cells[0].Value.ToString());
                fm_ChiTietLapDat.TenForm = "Chi Tiết Phiếu Lắp Đặt ";
                fm_ChiTietLapDat fm_ChiTietDat = new fm_ChiTietLapDat(this);
                fm_ChiTietDat.ShowDialog();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<PHIEULAPDAT> ListVatTus = PhieuLapDatDAO.Instance.GetAllPhieuLapDat();
            var listTimKiem = ListVatTus.Where(p => (p is PHIEULAPDAT) && (p as PHIEULAPDAT).NHANVIEN.TENNV.ToLower().Contains(txtTimKiem.Text.ToLower())
                           || Convert.ToString(p.SOPHIEULAPDAT).Contains(txtTimKiem.Text)).ToList();
            BindGridPhieu(listTimKiem);
        }
    }
}
