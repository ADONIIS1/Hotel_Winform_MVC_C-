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
    public partial class fm_TaiKhoan : Form
    {
        public fm_TaiKhoan()
        {
            InitializeComponent();
            LoadDuLieu();
        }
        List<TAIKHOAN> TimKiem()
        {
            List<TAIKHOAN> TK = TaiKhoanDAO.Instance.GetallListTaiKhoan();
            TK = TK.Where(p => p.TENTAIKHOAN.Contains(txtTimKiem.Text.ToLower()) || p.NHANVIEN.TENNV.ToString().Contains(txtTimKiem.Text.ToLower())).ToList();
            return TK;
        }
        public void LoadDuLieu()
        {
            dgvTaiKhoan.Rows.Clear();
            dgvTaiKhoan.Controls.Clear();

            List<TAIKHOAN> TK = TimKiem();
            foreach (TAIKHOAN item in TK)
            {
                int rowId = dgvTaiKhoan.Rows.Add();
                dgvTaiKhoan.Rows[rowId].Cells[0].Value =item.TENTAIKHOAN;
                if (item.QUYEN == 1)
                {
                    dgvTaiKhoan.Rows[rowId].Cells[1].Value = "Lễ Tân";
                }
                else if(item.QUYEN == 2) 
                { 
                    dgvTaiKhoan.Rows[rowId].Cells[1].Value = "Quản Lý"; 
                }else
                    dgvTaiKhoan.Rows[rowId].Cells[1].Value = "Admin";

                dgvTaiKhoan.Rows[rowId].Cells[2].Value = item.NHANVIEN.TENNV;
            }
          
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void btThemTKMoi_Click(object sender, EventArgs e)
        {
            fm_ThemTaiKhoan.TenForm = "Thêm Tài Khoản";
            fm_ThemTaiKhoan.TenTK = "-1";
            fm_ThemTaiKhoan fm_ThemTaiKhoan1 = new fm_ThemTaiKhoan(this);
            fm_ThemTaiKhoan1.ShowDialog();

        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTaiKhoan.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                if (MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string tentk = dgvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (TaiKhoanDAO.Instance.XoaSuaTaiKhoan(tentk))
                    {

                        MessageBox.Show("Xóa  Tài Khoản " + tentk + " Thành Công");
                        LoadDuLieu();
                    } 
                    else
                    {
                        MessageBox.Show("Xóa  Tài Khoản  " + tentk + " Thất Bại");

                    }
                }
            }
            if (dgvTaiKhoan.Columns[e.ColumnIndex].HeaderText == "Chi Tiết")
            {
                fm_ThemTaiKhoan.TenTK = dgvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
                fm_ThemTaiKhoan.TenForm = "Đặt Lại Mật Khẩu ";
                fm_ThemTaiKhoan fm_ChiTietDat = new fm_ThemTaiKhoan(this);
                fm_ChiTietDat.ShowDialog();
            }
        }
    }
}
