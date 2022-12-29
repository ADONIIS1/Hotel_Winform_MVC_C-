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
    public partial class fm_GiaPhong : Form
    {
        public fm_GiaPhong()
        {
            InitializeComponent();
            LoadGiaPhong();
        }


        void LoadGiaPhong()
        {

            dgvGiaPhong.Rows.Clear();
            dgvGiaPhong.Controls.Clear();

            List<GIAPHONG> GP = GiaPhongDAO.Instance.GetGIAPHONG();

            foreach (GIAPHONG item in GP)
            {
                int rowId = dgvGiaPhong.Rows.Add();
                dgvGiaPhong.Rows[rowId].Cells[0].Value = item.KIEUPHONG.TENKIEUPHONG;
                dgvGiaPhong.Rows[rowId].Cells[1].Value = item.LOAIPHONG.TENLOAIPHONG;
                dgvGiaPhong.Rows[rowId].Cells[2].Value = item.GIANGAY.ToString();
                dgvGiaPhong.Rows[rowId].Cells[3].Value = item.GIAGIO.ToString();
            }
        }


        private void dgvGiaPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGiaPhong.Columns[e.ColumnIndex].HeaderText == "Lưu")
            {
                string TenKieu = dgvGiaPhong.Rows[e.RowIndex].Cells[0].Value.ToString();
                string TenLoai = dgvGiaPhong.Rows[e.RowIndex].Cells[1].Value.ToString();
                double GiaNgay = double.Parse(dgvGiaPhong.Rows[e.RowIndex].Cells[2].Value.ToString());
                double GiaGio = double.Parse(dgvGiaPhong.Rows[e.RowIndex].Cells[3].Value.ToString());
                GIAPHONG GP = GiaPhongDAO.Instance.GetGIAPHONGTheoKPANDLP(TenKieu, TenLoai);
                if (GP != null)
                {
                    if (GiaPhongDAO.Instance.SuaGiaPhong(TenKieu, TenLoai, GiaNgay, GiaGio))
                    {
                        MessageBox.Show("Bạn Sửa Giá Phòng Thành Công!!!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void dgvGiaPhong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int soNguoi = 1; 
            string TenKieu = dgvGiaPhong.Rows[e.RowIndex].Cells[0].Value.ToString();
            string TenLoai = dgvGiaPhong.Rows[e.RowIndex].Cells[1].Value.ToString();

            GIAPHONG GP = GiaPhongDAO.Instance.GetGIAPHONGTheoKPANDLP(TenKieu, TenLoai);
            double giangay = (double)GP.GIANGAY;
            double giagio = (double)GP.GIAGIO;
            if (dgvGiaPhong.Rows[e.RowIndex].Cells[2].Value != null && dgvGiaPhong.Rows[e.RowIndex].Cells[3].Value != null)
            {
                if (!int.TryParse(dgvGiaPhong.Rows[e.RowIndex].Cells[2].Value.ToString(), out soNguoi) || soNguoi == 0)
                {
                    dgvGiaPhong.Rows[e.RowIndex].Cells[2].Value = giangay;
                    MessageBox.Show("Lỗi: Nhập Giá Ngày số nguyên!", "Thông báo", MessageBoxButtons.OK);
                }
                if (!int.TryParse(dgvGiaPhong.Rows[e.RowIndex].Cells[3].Value.ToString(), out soNguoi) || soNguoi == 0)
                {
                    dgvGiaPhong.Rows[e.RowIndex].Cells[3].Value = giagio;
                    MessageBox.Show("Lỗi: Nhập Giá Giờ số nguyên!", "Thông báo", MessageBoxButtons.OK);
                }

            }
            else
            {
                dgvGiaPhong.Rows[e.RowIndex].Cells[2].Value = giangay;
                dgvGiaPhong.Rows[e.RowIndex].Cells[3].Value = giagio;
                MessageBox.Show("Lỗi: Nhập số Lượng Dịch Vụ số nguyên!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
