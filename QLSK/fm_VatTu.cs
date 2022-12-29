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
    public partial class fm_VatTu : Form
    {
        public fm_VatTu()
        {
            InitializeComponent();
        }

        private void fm_VatTu_Load(object sender, EventArgs e)
        {
            BindGridVatTu(VatTuDAO.Instance.GetAllVatTu());
        }



        public void BindGridVatTu(List<VATTU> listVatTus)
        {
            dgvVatTu.Rows.Clear();

            foreach (var item in listVatTus)
            {
                int index = dgvVatTu.Rows.Add();
                dgvVatTu.Rows[index].Cells[0].Value = item.IDVATTU;
                dgvVatTu.Rows[index].Cells[1].Value = item.TENVATTU;
                dgvVatTu.Rows[index].Cells[2].Value = item.XUATXU;
            }
        }

        private void btThemVTMoi_Click(object sender, EventArgs e)
        {
            fm_ThemVatTu.TenForm = "Thêm Vật Tư";
            fm_ThemVatTu.MaVT =-1;
            fm_ThemVatTu themVatTu = new fm_ThemVatTu(this);
            themVatTu.ShowDialog();
        }

        private void dgvVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Xóa một vật tư
                if (dgvVatTu.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    if (dgvVatTu.Rows[e.RowIndex].Cells["Ten"].Value != null && dgvVatTu.Rows[e.RowIndex].Cells["XX"].Value != null)
                    {
                        if (dgvVatTu.Rows[e.RowIndex].Cells["ID"].Value != null)
                        {
                            int id;
                            id = Convert.ToInt32(dgvVatTu.Rows[e.RowIndex].Cells["ID"].Value);
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                VatTuDAO.Instance.XoaVatTu(id);
                                BindGridVatTu(VatTuDAO.Instance.GetAllVatTu());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa!", "Thông báo");
                            BindGridVatTu(VatTuDAO.Instance.GetAllVatTu());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thiếu thông tin!", "Thông báo");
                    }
                }
                if(dgvVatTu.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
                {
                    fm_ThemVatTu.TenForm = "Chi Tiết Vật Tư";
                    fm_ThemVatTu.MaVT = int.Parse(dgvVatTu.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    fm_ThemVatTu themVatTu = new fm_ThemVatTu(this);
                    themVatTu.ShowDialog();
                }

            }   
            catch(Exception b)
            {
                MessageBox.Show(b.Message, "Thông báo");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<VATTU> ListVatTus = VatTuDAO.Instance.GetAllVatTu();
            var listTimKiem = ListVatTus.Where(p => (p is VATTU) && (p as VATTU).TENVATTU.ToLower().Contains(txtTimKiem.Text.ToLower())
                           || p.XUATXU.ToLower().Contains(txtTimKiem.Text.ToLower())
                           || Convert.ToString(p.IDVATTU).Contains(txtTimKiem.Text)).ToList();
            BindGridVatTu(listTimKiem);
        }
    }
}
