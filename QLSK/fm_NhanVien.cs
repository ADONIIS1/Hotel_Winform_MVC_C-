using QLSK.DAO;
using QLSK.DTO;
using QLSK.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSK
{
    public partial class fm_NhanVien : Form
    {
        public fm_NhanVien()
        {
            InitializeComponent();
        }

        private void BindGridNhanVien(List<NHANVIEN> listNhanViens)
        {
            dgvNhanVien.Rows.Clear();
            foreach (var item in listNhanViens)
            {
                int index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[0].Value = item.MANV;
                dgvNhanVien.Rows[index].Cells[1].Value = item.TENNV;
                dgvNhanVien.Rows[index].Cells[2].Value = item.LUONG;
                DateTime NS = (DateTime)item.NGAYSINH;
                dgvNhanVien.Rows[index].Cells[3].Value = NS.ToString("dd/MM/yyyy");
                dgvNhanVien.Rows[index].Cells[4].Value = item.DIACHI;
                dgvNhanVien.Rows[index].Cells[5].Value = item.CMND;
                if (item.ANHDAIDIEN != null)
                {
                    dgvNhanVien.Rows[index].Cells[6].Value = item.ANHDAIDIEN;
                }
                else
                {
                   
                }

            }
            ptbAnhNhanVien.Image = Resources.tải_xuống;
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].HeaderText == "Lưu")
            {
                if (kiemTraDayDuThongTin(e.RowIndex))
                {
                    string ten = dgvNhanVien.Rows[e.RowIndex].Cells["Ten"].Value.ToString();
                    int manv;
                    if (dgvNhanVien.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        manv = int.Parse(dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                    else
                        manv = -1;
                    string DiaChi = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string CMND = dgvNhanVien.Rows[e.RowIndex].Cells[5].Value.ToString();
                    double luong = double.Parse(dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString());
                    DateTime NS = DateTime.Parse(dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString());
                    NHANVIEN nv = NhanVienDAO.Instance.GetnhanVientheoMaNV(manv);
                    if (nv == null)
                    {
                        if (NhanVienDAO.Instance.AddNhanVien(ten, DiaChi, CMND, NS, luong, ImageToByteArray(ptbAnhNhanVien)))
                        {
                            MessageBox.Show("Thêm thành công");

                        }
                    }
                    else
                    {
                        if (NhanVienDAO.Instance.SuaNhanVien(manv, ten, DiaChi, CMND, NS, luong, ImageToByteArray(ptbAnhNhanVien)))
                        {
                            MessageBox.Show("sửa thành công");

                        }
                    }

                    BindGridNhanVien(NhanVienDAO.Instance.GetallListNhanVien());

                }
                else
                {
                    MessageBox.Show("Nhập đầy đủ thông tin!", "Thông báo");
                }
            }
            if (dgvNhanVien.Rows[e.RowIndex].Cells[3].Value != null)
            {
                MemoryStream memoryStream = new MemoryStream((byte[])dgvNhanVien.Rows[e.RowIndex].Cells[6].Value);
                ptbAnhNhanVien.Image = Image.FromStream(memoryStream);

            }
            else
            {
                ptbAnhNhanVien.Image = Resources.tải_xuống;
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string maNV;
                maNV = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (NhanVienDAO.Instance.XoaNhanVien(int.Parse(maNV)))
                {
                    if (MessageBox.Show("Bạn Có Muốn Xóa Nhân Viên Mã: " + maNV, "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show("Xóa thành công");
                        BindGridNhanVien(NhanVienDAO.Instance.GetallListNhanVien());
                    }

                }
                else
                {
                    MessageBox.Show("Xóa Không thành công");
                }
            }
        }
        private byte[] ImageToByteArray(PictureBox picturebox)
        {
            MemoryStream memoryStream = new MemoryStream();
            ptbAnhNhanVien.Image.Save(memoryStream, ptbAnhNhanVien.Image.RawFormat);
            return memoryStream.ToArray();
        }
       
        private void fm_NhanVien_Load(object sender, EventArgs e)
        {
            BindGridNhanVien(NhanVienDAO.Instance.GetallListNhanVien());
        }

        private void btThemNhanVien_Click(object sender, EventArgs e)
        {
            int index = dgvNhanVien.Rows.Add();
            
        }
        private bool kiemTraDayDuThongTin(int rowindex)
        {
            if (string.IsNullOrWhiteSpace(dgvNhanVien.Rows[rowindex].Cells["Ten"].Value.ToString()))
            {
              
                MessageBox.Show("Nhập đầy Tên Nhân Viên  !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (string.IsNullOrWhiteSpace(dgvNhanVien.Rows[rowindex].Cells[2].Value.ToString()))
            {

                MessageBox.Show("Nhập đầy Lương Nhân Viên  !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void btDoiAnh_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png; *.jfif)| *.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png; *.jfif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ptbAnhNhanVien.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<NHANVIEN> ListVatTus = NhanVienDAO.Instance.GetallListNhanVien();
            var listTimKiem = ListVatTus.Where(p => (p is NHANVIEN) && (p as NHANVIEN).TENNV.ToLower().Contains(txtTimKiem.Text.ToLower())
                           || Convert.ToString(p.MANV).Contains(txtTimKiem.Text)
                           || Convert.ToString(p.LUONG).Contains(txtTimKiem.Text)
                           ).ToList();
            BindGridNhanVien(listTimKiem);
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
   
        }
    }
}
