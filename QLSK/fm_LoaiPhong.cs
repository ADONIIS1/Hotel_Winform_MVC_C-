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
    public partial class fm_LoaiPhong : Form
    {
        public fm_LoaiPhong()
        {
            InitializeComponent();
        }
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            BindGridLoaiPhong(LoaiPhongDAO.Instance.GetAllLoaiPhong());
        }

        public void BindGridLoaiPhong(List<LOAIPHONG> list)
        {
            dgvLoaiPhong.Rows.Clear();

            foreach (var item in list)
            {
                int index = dgvLoaiPhong.Rows.Add();
                dgvLoaiPhong.Rows[index].Cells[0].Value = item.IDLOAIPHONG;
                dgvLoaiPhong.Rows[index].Cells[1].Value = item.TENLOAIPHONG;
            }
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLoaiPhong.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    if (dgvLoaiPhong.Rows[e.RowIndex].Cells["Ten"].Value != null)
                    {
                        if (dgvLoaiPhong.Rows[e.RowIndex].Cells["ID"].Value != null)
                        {
                            int id;
                            id = Convert.ToInt32(dgvLoaiPhong.Rows[e.RowIndex].Cells["ID"].Value);
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                LoaiPhongDAO.Instance.Xoa(id);
                                BindGridLoaiPhong(LoaiPhongDAO.Instance.GetAllLoaiPhong());
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
                if (dgvLoaiPhong.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
                {
                    fm_ThemLoaiPhong.TenForm = "Chi Tiết Loại Phòng";
                    fm_ThemLoaiPhong.IDloaiPhong = int.Parse(dgvLoaiPhong.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    fm_ThemLoaiPhong themVatTu = new fm_ThemLoaiPhong(this);
                    themVatTu.ShowDialog();
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Thông báo");
            }

        }

        private void btThemLPMoi_Click(object sender, EventArgs e)
        {
            fm_ThemLoaiPhong.TenForm = "Thêm Loại Phòng";
            fm_ThemLoaiPhong.IDloaiPhong =-1;
            fm_ThemLoaiPhong themVatTu = new fm_ThemLoaiPhong(this);
            themVatTu.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<LOAIPHONG> ListLoaiPhong = LoaiPhongDAO.Instance.GetAllLoaiPhong();
            var listTimKiem = ListLoaiPhong.Where(p => (p is LOAIPHONG) && (p as LOAIPHONG).TENLOAIPHONG.ToLower().Contains(txtTimKiem.Text.ToLower())
                           || Convert.ToString(p.IDLOAIPHONG).Contains(txtTimKiem.Text)).ToList();
            BindGridLoaiPhong(listTimKiem);
        }
    }
}
