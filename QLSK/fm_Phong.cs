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
    public partial class fm_Phong : Form
    {
        public fm_Phong()
        {
            InitializeComponent();
        }
        private void fm_Phong_Load(object sender, EventArgs e)
        {
            BindGridPhong(PhongDAO.Instance.GetPhongall());
        }
        public void BindGridPhong(List<PHONG> listPhongs)
        {
            dgvPhong.Rows.Clear();
            foreach (var item in listPhongs)
            {
                int index = dgvPhong.Rows.Add();
                dgvPhong.Rows[index].Cells[0].Value = item.MAPHONG;
                dgvPhong.Rows[index].Cells[1].Value = item.TENPHONG;
                dgvPhong.Rows[index].Cells[2].Value = item.KIEUPHONG.TENKIEUPHONG;
                dgvPhong.Rows[index].Cells[3].Value = item.LOAIPHONG.TENLOAIPHONG;
               // dgvPhong.Rows[index].Cells[4].Value = item.DONDEP;
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<PHONG> ListVatTus = PhongDAO.Instance.GetPhongall();
            var listTimKiem = ListVatTus.Where(p => (p is PHONG) && (p as PHONG).TENPHONG.ToLower().Contains(txtTimKiem.Text.ToLower())).ToList();
            BindGridPhong(listTimKiem);
        }

        private void btThemPMoi_Click(object sender, EventArgs e)
        {
            fm_ThemPhongMoi.map = -1;
            fm_ThemPhongMoi.TenForm = "Thêm Phòng Mới";
            fm_ThemPhongMoi fm_ThemPhong = new fm_ThemPhongMoi(this);
            fm_ThemPhong.ShowDialog();
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Xóa một vật tư
                if (dgvPhong.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    if (dgvPhong.Rows[e.RowIndex].Cells["Ten"].Value != null && dgvPhong.Rows[e.RowIndex].Cells["Dondep"].Value != null)
                    {
                        if (dgvPhong.Rows[e.RowIndex].Cells["MaPhong"].Value != null)
                        {
                            int id;
                            id = Convert.ToInt32(dgvPhong.Rows[e.RowIndex].Cells["MaPhong"].Value);
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                PhongDAO.Instance.XoaPhong(id);
                                MessageBox.Show("Xóa thành công!", "Thông báo");
                                BindGridPhong(PhongDAO.Instance.GetPhongall());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa!", "Thông báo");
                            //BindGridPhong(PHONGDAO.GetAll());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thiếu thông tin!", "Thông báo");
                    }
                }
                if (dgvPhong.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
                {
                    fm_ThemPhongMoi.map = int.Parse(dgvPhong.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString());
                    //fm_ThemPhongMoi.idloaiphong = int.Parse(dgvPhong.Rows[e.RowIndex].Cells[2].Value.ToString());
                    //fm_ThemPhongMoi.idkieuphong = int.Parse(dgvPhong.Rows[e.RowIndex].Cells[3].Value.ToString());
                    fm_ThemPhongMoi.TenForm = "Chi Tiết Phòng";
                    fm_ThemPhongMoi fm_ThemPhong = new fm_ThemPhongMoi(this);
                    fm_ThemPhong.ShowDialog();
                }
                
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Thông báo");
            }
        }
    }
}
