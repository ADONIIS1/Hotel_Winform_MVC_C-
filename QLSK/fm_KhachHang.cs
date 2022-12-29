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
    public partial class fm_KhachHang : Form
    {
        public fm_KhachHang()
        {
            InitializeComponent();
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BindGridKhachHang(KhachHangDAO.Instance.GetAllKhachHang());
        }

        private void BindGridKhachHang(List<KHACHHANG> ListKhachHangs)
        {
            dgvKhachHang.Rows.Clear();
            foreach (var item in ListKhachHangs)
            {
                int index = dgvKhachHang.Rows.Add();
                dgvKhachHang.Rows[index].Cells[0].Value = item.CMND;
                dgvKhachHang.Rows[index].Cells[1].Value = item.TENKHACHHANG;
                dgvKhachHang.Rows[index].Cells[2].Value = item.SDT;
                dgvKhachHang.Rows[index].Cells[3].Value = item.DIACHI;
                dgvKhachHang.Rows[index].Cells[5].Value = item.QUOCTICH;
                if (item.GIOITINH == false)
                {
                    dgvKhachHang.Rows[index].Cells[4].Value = "Nữ";
                }
                else
                {
                    dgvKhachHang.Rows[index].Cells[4].Value = "Nam";
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<KHACHHANG> ListKhachHangs = KhachHangDAO.Instance.GetAllKhachHang();
            var listTimKiem = ListKhachHangs.Where(p => (p is KHACHHANG) && (p as KHACHHANG).TENKHACHHANG.ToLower().Contains(txtTimKiem.Text.ToLower())
                                                || p.DIACHI.ToLower().Contains(txtTimKiem.Text.ToLower())
                                                || p.QUOCTICH.ToLower().Contains(txtTimKiem.Text.ToLower())
                                                || Convert.ToString(p.SDT).Contains(txtTimKiem.Text)
                                                || Convert.ToString(p.CMND).Contains(txtTimKiem.Text)
            ).ToList();
            BindGridKhachHang(listTimKiem);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Xóa một khách hàng
                if (dgvKhachHang.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    if (dgvKhachHang.Rows[e.RowIndex].Cells["CMND"].Value != null)
                    {
                        string id;
                        id = dgvKhachHang.Rows[e.RowIndex].Cells["CMND"].Value.ToString();
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            KhachHangDAO.XoaKhachHang(id);
                            BindGridKhachHang(KhachHangDAO.Instance.GetAllKhachHang());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa!", "Thông báo");
                        BindGridKhachHang(KhachHangDAO.Instance.GetAllKhachHang());
                    }
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Thông báo");
            }
        }
    }
}
