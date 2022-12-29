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
    public partial class fm_KieuPhong : Form
    {
        public fm_KieuPhong()
        {
            InitializeComponent();
        }
        private void frmKieuPhong_Load(object sender, EventArgs e)
        {
            BindGridKieuPhong(KieuPhongDAO.Instance.GetAllKieuP());
        }

        public void BindGridKieuPhong(List<KIEUPHONG> list)
        {
            dgvKieuPhong.Rows.Clear();

            foreach (var item in list)
            {
                int index = dgvKieuPhong.Rows.Add();
                dgvKieuPhong.Rows[index].Cells[0].Value = item.IDKIEUPHONG;
                dgvKieuPhong.Rows[index].Cells[1].Value = item.TENKIEUPHONG;
                
            }
        }

        private void btThemKPMoi_Click(object sender, EventArgs e)
        {
            fm_ThemKieuPhong.TenForm = "Thêm Kiểu Phòng";
            fm_ThemKieuPhong.IDkieuPhong = -1;
            fm_ThemKieuPhong themVatTu = new fm_ThemKieuPhong(this);
            themVatTu.ShowDialog();
        }
        private void dgvVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Xóa 
                if (dgvKieuPhong.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    if (dgvKieuPhong.Rows[e.RowIndex].Cells["Ten"].Value != null && dgvKieuPhong.Rows[e.RowIndex].Cells["GiaNgay"].Value != null && dgvKieuPhong.Rows[e.RowIndex].Cells["GiaGio"].Value != null)
                    {
                        if (dgvKieuPhong.Rows[e.RowIndex].Cells["ID"].Value != null)
                        {
                            int id;
                            id = Convert.ToInt32(dgvKieuPhong.Rows[e.RowIndex].Cells["ID"].Value);
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                KieuPhongDAO.Instance.Xoa(id);
                                BindGridKieuPhong(KieuPhongDAO.Instance.GetAllKieuP());
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
                if (dgvKieuPhong.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
                {
                    fm_ThemKieuPhong.TenForm = "Chi Tiết Kiểu Phòng";
                    fm_ThemKieuPhong.IDkieuPhong = int.Parse(dgvKieuPhong.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    fm_ThemKieuPhong themVatTu = new fm_ThemKieuPhong(this);
                    themVatTu.ShowDialog();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Thông báo");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<KIEUPHONG> ListVatTus = KieuPhongDAO.Instance.GetAllKieuP();
            var listTimKiem = ListVatTus.Where(p => (p is KIEUPHONG) && (p as KIEUPHONG).TENKIEUPHONG.ToLower().Contains(txtTimKiem.Text.ToLower())
                           || Convert.ToString(p.IDKIEUPHONG).Contains(txtTimKiem.Text)
                           ).ToList();
            BindGridKieuPhong(listTimKiem);
        }
    }
}
