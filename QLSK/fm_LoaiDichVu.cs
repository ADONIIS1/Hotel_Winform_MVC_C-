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
    public partial class fm_LoaiDichVu : Form
    {
        public fm_LoaiDichVu()
        {
            InitializeComponent();
            BindGridLoaiDichVu(LoaiDichVuDAO.Instance.GetLoaiDichVu());
        }
        public void BindGridLoaiDichVu(List<LOAIDICHVU> list)
        {
            dgvLoaiDichVu.Rows.Clear();

            foreach (var item in list)
            {
                int index = dgvLoaiDichVu.Rows.Add();
                dgvLoaiDichVu.Rows[index].Cells[0].Value = item.IDLOAIDICHVU;
                dgvLoaiDichVu.Rows[index].Cells[1].Value = item.TENLOAIDICHVU;
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<LOAIDICHVU> List = LoaiDichVuDAO.Instance.GetLoaiDichVu();
            var listTimKiem = List.Where(p => p.TENLOAIDICHVU.ToLower().Contains(txtTimKiem.Text.ToLower())
                                                || Convert.ToString(p.IDLOAIDICHVU).Contains(txtTimKiem.Text.ToLower())
            ).ToList();
            BindGridLoaiDichVu(listTimKiem);
        }
        private void dgvLoaiDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Xóa một vật tư
                if (dgvLoaiDichVu.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    if (dgvLoaiDichVu.Rows[e.RowIndex].Cells["Ten"].Value != null)
                    {
                        if (dgvLoaiDichVu.Rows[e.RowIndex].Cells["ID"].Value != null)
                        {
                            int id;
                            id = Convert.ToInt32(dgvLoaiDichVu.Rows[e.RowIndex].Cells["ID"].Value);
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                LoaiDichVuDAO.Instance.Xoa(id);
                                BindGridLoaiDichVu(LoaiDichVuDAO.Instance.GetLoaiDichVu());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa!", "Thông báo");
                            //BindGridKieuPhong(KIEUPHONGDAO.GetAll());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thiếu thông tin!", "Thông báo");
                    }
                }

                if (dgvLoaiDichVu.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
                {
                    fm_ThemLoaiDichVu.IDloaiDV = int.Parse(dgvLoaiDichVu.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    fm_ThemLoaiDichVu.TenForm = "Chi Tiết Loại Phòng";
                    fm_ThemLoaiDichVu fm_ThemLoai = new fm_ThemLoaiDichVu(this);
                    fm_ThemLoai.ShowDialog();
                }
               

            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Thông báo");
            }

        }

        private void btThemDVMoi_Click(object sender, EventArgs e)
        {
          
                fm_ThemLoaiDichVu.TenForm = "Thêm  Loại Phòng";
                fm_ThemLoaiDichVu.IDloaiDV = -1;
                fm_ThemLoaiDichVu fm_ThemLoai = new fm_ThemLoaiDichVu(this);
                fm_ThemLoai.ShowDialog();
            
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            List<LOAIDICHVU> ListDichVus = LoaiDichVuDAO.Instance.GetLoaiDichVu();
            var listTimKiem = ListDichVus.Where(p => (p is LOAIDICHVU) && (p as LOAIDICHVU).TENLOAIDICHVU.ToLower().Contains(txtTimKiem.Text.ToLower())
                                                                           || Convert.ToString(p.IDLOAIDICHVU).Contains(txtTimKiem.Text)).ToList();

            BindGridLoaiDichVu(listTimKiem);
        }
    }   
}
