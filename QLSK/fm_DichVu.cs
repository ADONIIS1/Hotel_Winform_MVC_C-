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
    public partial class fm_DichVu : Form
    {
        public fm_DichVu()
        {
            InitializeComponent();
            BindGridDichVu(DichVuDAO.Instance.GetallListDichVu());
        }

        private void btThemDichVu_Click(object sender, EventArgs e)
        {
            fm_ThemDichVuMoi fm_ThemDichVu = new fm_ThemDichVuMoi();
            fm_ThemDichVu.ShowDialog();
            
        }
        public void BindGridDichVu(List<DICHVU> listDichVu)
        {
            dgvDichVu.Rows.Clear();

            foreach (var item in listDichVu)
            {
                int index = dgvDichVu.Rows.Add();
                dgvDichVu.Rows[index].Cells[0].Value = item.IDDICHVU;
                dgvDichVu.Rows[index].Cells[1].Value = item.TENDICHVU;
                dgvDichVu.Rows[index].Cells[2].Value = item.DONGIABAN;
                dgvDichVu.Rows[index].Cells[3].Value = item.DVT;
                dgvDichVu.Rows[index].Cells[4].Value = item.LOAIDICHVU.TENLOAIDICHVU;
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<DICHVU> ListVatTus = DichVuDAO.Instance.GetallListDichVu();
            var listTimKiem = ListVatTus.Where(p => (p is DICHVU) && (p as DICHVU).TENDICHVU.ToLower().Contains(txtTimKiem.Text.ToLower())
                           || Convert.ToString(p.DVT).Contains(txtTimKiem.Text)).ToList();
            BindGridDichVu(listTimKiem);
        }
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Xóa một vật tư
                if (dgvDichVu.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    if (dgvDichVu.Rows[e.RowIndex].Cells["Ten"].Value != null && dgvDichVu.Rows[e.RowIndex].Cells["DONGIA"].Value != null && dgvDichVu.Rows[e.RowIndex].Cells["DVT"].Value != null)
                    {
                        if (dgvDichVu.Rows[e.RowIndex].Cells["ID"].Value != null)
                        {
                            int id;
                            id = Convert.ToInt32(dgvDichVu.Rows[e.RowIndex].Cells["ID"].Value);
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                DichVuDAO.Instance.XoaDichVu(id);
                                BindGridDichVu(DichVuDAO.Instance.GetallListDichVu());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa!", "Thông báo");
                            //BindGridDichVu(DICHVUDAO.GetAll());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thiếu thông tin!", "Thông báo");
                    }
                }
                if (dgvDichVu.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
                {
                    fm_ThemDichVuMoi.TenForm = "Chi Tiết Dịch Vụ";
                    fm_ThemDichVuMoi.idDichVu = int.Parse(dgvDichVu.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    fm_ThemDichVuMoi fm_ThemDichVu = new fm_ThemDichVuMoi(this);
                    fm_ThemDichVu.ShowDialog();
                }
           

            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Thông báo");
            }
        }

        private void btThemDVMoi_Click(object sender, EventArgs e)
        {
          
                fm_ThemDichVuMoi.TenForm = "Thêm Dịch Vụ Mới";
                fm_ThemDichVuMoi.idDichVu = -1;
                fm_ThemDichVuMoi fm_ThemDichVu = new fm_ThemDichVuMoi(this);
                fm_ThemDichVu.ShowDialog();
            
        }

    }
}
