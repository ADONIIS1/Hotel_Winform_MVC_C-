using QLSK.BUS;
using QLSK.DAO;
using QLSK.DesignUserControl;
using QLSK.DTO;
using QLSK.Properties;
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
    public partial class fm_DatPhongMoi : Form
    {
        List<PHONG> pHONGsTrong;
        List<CT_PhieuDatPhong_Custom> pHONGsChon = new List<CT_PhieuDatPhong_Custom>();
        public fm_DatPhongMoi()
        {
            
            InitializeComponent();
            LoadDateTimePickerBill();


        }
        public static int MaNV;
        public fm_DatPhongMoi(fm_DatPhong fm_DatPhonG)
        {
           
            InitializeComponent();
            LoadDateTimePickerBill();
            fm_DatPhong = fm_DatPhonG;
        }
        fm_DatPhong fm_DatPhong = new fm_DatPhong();


        void LoadDateTimePickerBill()
        {
            cbbGioBD.SelectedIndex = 1;
            cbbPhutBD.SelectedIndex = 0;
            cbbGioKT.SelectedIndex = 2;
            cbbPhutKT.SelectedIndex = 0;
            DateTime toDay = DateTime.Now;
            dtkNgayKT.Value = toDay;
            dtkNgayBD.Value = toDay;

        }
        private void bthuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region DesignText

        private void txtTenKhachHang_Leave(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text == "")
            {
                txtTenKhachHang.Text = "Nhập Tên Khách Hàng";
                txtTenKhachHang.ForeColor = Color.Silver;
            }
        }

        private void txtTenKhachHang_Enter(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text == "Nhập Tên Khách Hàng")
            {
                txtTenKhachHang.Text = "";
                txtTenKhachHang.ForeColor = Color.Black;
            }
        }
        private void txtCMND_Leave(object sender, EventArgs e)
        {
            if (txtCMND.Text == "")
            {
                txtCMND.Text = "Nhập CMND/CCCD";
                txtCMND.ForeColor = Color.Silver;
            }
        }

        private void txtCMND_Enter(object sender, EventArgs e)
        {
            if (txtCMND.Text == "Nhập CMND/CCCD")
            {
                txtCMND.Text = "";
                txtCMND.ForeColor = Color.Black;
            }
        }
       
        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (txtSDT.Text == "")
            {
                txtSDT.Text = "Nhập SĐT";
                txtSDT.ForeColor = Color.Silver;
            }
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {

            if (txtSDT.Text == "Nhập SĐT")
            {
                txtSDT.Text = "";
                txtSDT.ForeColor = Color.Black;
            }
        }

        private void txtDiaChi_Leave(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                txtDiaChi.Text = "Nhập Địa Chỉ";
                txtDiaChi.ForeColor = Color.Silver;
            }
        }

        private void txtDiaChi_Enter(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "Nhập Địa Chỉ")
            {
                txtDiaChi.Text = "";
                txtDiaChi.ForeColor = Color.Black;
            }
        }

        private void txtQuocTich_Leave(object sender, EventArgs e)
        {
            if (txtQuocTich.Text == "")
            {
                txtQuocTich.Text = "Nhập Quốc Tịch";
                txtQuocTich.ForeColor = Color.Silver;
            }
        }

        private void txtQuocTich_Enter(object sender, EventArgs e)
        {
            if (txtQuocTich.Text == "Nhập Quốc Tịch")
            {
                txtQuocTich.Text = "";
                txtQuocTich.ForeColor = Color.Black;
            }

        }

        #endregion

        QuanLyKhachSan ConText = new QuanLyKhachSan();


        private void LoadPhongTrongTheoNgay()
        {
            DateTime ngayBD = DateTime.Parse(dtkNgayBD.Text + " " + cbbGioBD.SelectedItem + ":" + cbbPhutBD.SelectedItem + ":00");
            DateTime ngayKT = DateTime.Parse(dtkNgayKT.Text + " " + cbbGioKT.SelectedItem + ":" + cbbPhutKT.SelectedItem + ":00");

            List<PHONG> lsTemp = PhongDAO.Instance.GetPHONGTheoGio(ngayBD, ngayKT);
            var ls = lsTemp;
            if (pHONGsChon.Count > 0)
            {
                ls = (from l in lsTemp
                      where !(from pdc in pHONGsChon select pdc.MAPHONG).Contains(l.MAPHONG)
                      select l).ToList();
            }

            pHONGsTrong = ls.ToList<PHONG>();
            dgvPhongTrong.Rows.Clear();
            foreach (var item in pHONGsTrong)
            {
                int rowId = dgvPhongTrong.Rows.Add();
                dgvPhongTrong.Rows[rowId].Cells["MaPTrong"].Value = item.MAPHONG;
                dgvPhongTrong.Rows[rowId].Cells["TenPhongTrong"].Value = item.TENPHONG;
                dgvPhongTrong.Rows[rowId].Cells["KieuPTrong"].Value = item.KIEUPHONG.TENKIEUPHONG;
                dgvPhongTrong.Rows[rowId].Cells["LoaiPhong"].Value = item.LOAIPHONG.TENLOAIPHONG;
            }

        }


        private void tpGioBD_ValueChanged(object sender, EventArgs e)
        {
            if (cbbGioKT.SelectedIndex != -1 && cbbPhutBD.SelectedIndex != -1 && cbbPhutKT.SelectedIndex != -1 && cbbGioBD.SelectedIndex != -1)
            {
                DateTime dtNBD;
                DateTime dtNKT;
                DateTime timeNBD;
                DateTime timeNKT;
                if (!DateTime.TryParse(dtkNgayBD.Text, out dtNBD))
                {
                    MessageBox.Show("Nhập đúng định dạng ngày bắt đầu !", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (!DateTime.TryParse(dtkNgayKT.Text, out dtNKT))
                {
                    MessageBox.Show("Nhập đúng định dạng ngày kết thúc !", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                //Nếu 2 ngày bằng nhau thì kiểm tra giờ xem giờ bắt đầu có lơn hơn giờ kết thúc không
                if (dtNBD == dtNKT)
                {
                    if (!DateTime.TryParse(dtkNgayBD.Text + " " + cbbGioBD.SelectedItem + ":" + cbbPhutBD.SelectedItem + ":30", out timeNBD))
                    {

                        MessageBox.Show("Nhập đúng định dạng giờ bắt đầu !", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    if (!DateTime.TryParse(dtkNgayKT.Text + " " + cbbGioKT.SelectedItem + ":" + cbbPhutKT.SelectedItem + ":30", out timeNKT))
                    {
                        MessageBox.Show("Nhập đúng định dạng giờ kết thúc !", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    if (timeNBD > timeNKT)
                    {
                        MessageBox.Show("Giờ bắt đầu không thế lớn hơn giờ kết thúc !", "Thông báo", MessageBoxButtons.OK);
                        cbbGioBD.Text = (int.Parse(cbbGioKT.Text) - 1).ToString();
                        cbbPhutBD.Text = cbbPhutKT.Text;
                        return;
                    }

                }
                LoadPhongTrongTheoNgay();
            }
           
        }



        private void dtkNgayBD_ValueChanged(object sender, EventArgs e)
        {
            string ngayBD = dtkNgayBD.Text;
            string ngayKT = dtkNgayKT.Text;
            DateTime dtNBD;
            DateTime dtNKT;
            if (!DateTime.TryParse(ngayBD, out dtNBD))
            {
                MessageBox.Show("Nhập đúng định dạng ngày bắt đầu !", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (!DateTime.TryParse(ngayKT, out dtNKT))
            {
                MessageBox.Show("Nhập đúng định dạng ngày kết thúc !", "Thông báo", MessageBoxButtons.OK);

                return;
            }
            //nếu ngày bắt đầu lớn hơn ngày kết thúc thì phải báo lỗi ngay
            if (dtNBD > dtNKT)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc !", "Thông báo", MessageBoxButtons.OK);
                dtkNgayBD.Text = ngayKT;
                dtkNgayKT.Text = ngayKT;
                return;
            }
            LoadPhongTrongTheoNgay();
        }


        private void dgvPhongTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvPhongTrong.Columns[e.ColumnIndex].HeaderText == "Thêm")
            {
                DateTime ngayBD = DateTime.Parse(dtkNgayBD.Text + " " + cbbGioBD.SelectedItem + ":" + cbbPhutBD.SelectedItem + ":00");
                DateTime ngayKT = DateTime.Parse(dtkNgayKT.Text + " " + cbbGioKT.SelectedItem + ":" + cbbPhutKT.SelectedItem + ":00");
                string tenPhong;

                tenPhong = (dgvPhongTrong.Rows[e.RowIndex].Cells["MaPTrong"].Value).ToString();
                PHONG pHONG = ConText.PHONG.FirstOrDefault(p => p.MAPHONG.ToString().Equals(tenPhong));
                int rowId = dgvPhongChon.Rows.Add();
                dgvPhongChon.Rows[rowId].Cells[0].Value = pHONG.MAPHONG;
                dgvPhongChon.Rows[rowId].Cells[1].Value = pHONG.TENPHONG;
                dgvPhongChon.Rows[rowId].Cells[2].Value = ngayBD;
                dgvPhongChon.Rows[rowId].Cells[3].Value = ngayKT;
                dgvPhongChon.Rows[rowId].Cells[4].Value = 1;
               
                // MessageBox.Show(tenPhong.ToString());
                pHONGsTrong.Remove(pHONG);
                CT_PhieuDatPhong_Custom cT_PhieuDat = new CT_PhieuDatPhong_Custom();
                cT_PhieuDat.MAPHONG = pHONG.MAPHONG;
                cT_PhieuDat.GIOVAO = ngayBD;
                cT_PhieuDat.GIORA = ngayKT;
                cT_PhieuDat.SONGUOI = int.Parse(dgvPhongChon.Rows[rowId].Cells[4].Value.ToString()) ;
                pHONGsChon.Add(cT_PhieuDat);
                dgvPhongTrong.Rows.RemoveAt(e.RowIndex);

            }


        }

        private void dgvPhongChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvPhongChon.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string tenPhong = (dgvPhongChon.Rows[e.RowIndex].Cells["MaPChon"].Value).ToString();
                PHONG pHONG = ConText.PHONG.FirstOrDefault(p => p.MAPHONG.ToString().Equals(tenPhong));
                int rowId = dgvPhongTrong.Rows.Add();
                dgvPhongTrong.Rows[rowId].Cells["MaPTrong"].Value = pHONG.MAPHONG;
                dgvPhongTrong.Rows[rowId].Cells["TenPhongTrong"].Value = pHONG.TENPHONG;
                dgvPhongTrong.Rows[rowId].Cells["kieuPTrong"].Value = pHONG.KIEUPHONG.TENKIEUPHONG;
                dgvPhongTrong.Rows[rowId].Cells["LoaiPhong"].Value = pHONG.LOAIPHONG.TENLOAIPHONG;
                pHONGsTrong.Add(pHONG);
                CT_PhieuDatPhong_Custom cT_Phieu = pHONGsChon.FirstOrDefault(p => p.MAPHONG.ToString().Equals(tenPhong)); 
                pHONGsChon.Remove(cT_Phieu);
                dgvPhongChon.Rows.RemoveAt(e.RowIndex);

            }

        }

        private void btLuu_Click(object sender, EventArgs e)
        {
                 
            if (kiemTraDayDuThongTin())
            {
                string TenKhach = txtTenKhachHang.Text;
                string CMND = txtCMND.Text;
                string SDT = txtSDT.Text;
                string QuocTich = txtQuocTich.Text;
                string DiaChi = txtDiaChi.Text;
               
            
                
                bool Gioitinh;
                int dem = 0;

                if (rdoNam.Checked == true)
                {
                    Gioitinh = true;
                }
                else
                    Gioitinh = false;
                
                if (KhachHangDAO.Instance.AddKhachHang(CMND,TenKhach, SDT, DiaChi, QuocTich, Gioitinh))
                {
                    MessageBox.Show("Thêm Khách Hàng mới thành công!!");
                    
                }
                if(PhieuDatPhongDAO.Instance.AddPhieuDatPhong(MaNV, CMND))
                {

                    foreach(CT_PhieuDatPhong_Custom item  in pHONGsChon)
                    {
                      
                        if (ChiTietPhieuDatPhongDAO.Instance.AddCTPhieuThue(item.MAPHONG, item.GIOVAO, item.GIORA,item.SONGUOI))
                        {
                            dem++;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi: Thêm Chi Tiết Phiếu Thuê!", "Thông báo", MessageBoxButtons.OK);
                            break;
                        }

                    }
                }else
                {
                    MessageBox.Show("Lỗi: Thêm Phiếu Đặt Phòng!", "Thông báo", MessageBoxButtons.OK);
                }
                if (dem == pHONGsChon.Count && dem != 0)
                {

                    MessageBox.Show("Đặt phòng Thành Công !", "Thông báo", MessageBoxButtons.OK);
                    this.Close();
                    fm_DatPhong.LoadPhieudatPhong();
                }
                else
                {
                    MessageBox.Show("Đặt phòng thất bại  !", "Thông báo", MessageBoxButtons.OK);
                    
                }
            }
        }


        private bool kiemTraDayDuThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text)|| txtTenKhachHang.Text.Equals("Nhập Tên Khách Hàng"))
            {
                txtTenKhachHang.Focus();
                MessageBox.Show("Nhập đầy đủ họ tên !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            //Kiểm tra textbox CCCD rỗng hoặc nhập kí tự chữ không
            if (string.IsNullOrWhiteSpace(txtCMND.Text) || txtCMND.Text.Equals("Nhập CMND/CCCD"))
            {
                txtCMND.Focus();
                MessageBox.Show("Nhập đầy đủ căn cước công dân !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                if (!long.TryParse(txtCMND.Text, out long temp1))
                {
                    txtCMND.Focus();
                    MessageBox.Show("Nhập căn cước công dân đúng định dạng số !", "Thông báo", MessageBoxButtons.OK);
                  
                    return false;
                }
                if (txtCMND.Text.Length > 12)
                {
                    txtCMND.Focus();
                    MessageBox.Show("Nhập căn cước công dân không quá 12 ký tự !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
            }
            //Kiểm tra textbox SDT rỗng hoặc có nhập chữ không
            if (string.IsNullOrWhiteSpace(txtSDT.Text) || txtSDT.Text.Equals("Nhập SĐT"))
            {
                txtSDT.Focus();
                MessageBox.Show("Nhập đầy đủ số điện thoại !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                if (!long.TryParse(txtSDT.Text, out long temp2))
                {
                    txtSDT.Focus();
                    MessageBox.Show("Nhập số điện thoại đúng định dạng số !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                if (txtSDT.Text.Length > 10)
                {
                    txtSDT.Focus();
                    MessageBox.Show("Nhập số điện thoại không quá 10 ký tự !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
            }
            //Kiểm tra ô nhập địa chỉ
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text) || txtDiaChi.Text.Equals("Nhập Địa Chỉ"))
            {
                txtDiaChi.Focus();
                MessageBox.Show("Nhập đầy đủ địa chỉ !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            //kiểm tra ô quốc tịch
            if (string.IsNullOrWhiteSpace(txtQuocTich.Text) || txtQuocTich.Text.Equals("Nhập Quốc Tịch"))
            {
                txtQuocTich.Focus();
                MessageBox.Show("Nhập đầy đủ quốc tịch !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
          
            if (pHONGsChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng trước khi lưu !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void searchCMND_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCMND.Text) || txtCMND.Text.Equals("Nhập CMND/CCCD"))
            {
                txtCMND.Focus();
                MessageBox.Show("Nhập đầy đủ căn cước công dân !", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                KHACHHANG kHACHHANG = KhachHangDAO.Instance.GetKHACHHANGCMND(txtCMND.Text);
                if (kHACHHANG != null)
                {
                    txtTenKhachHang.Text = kHACHHANG.TENKHACHHANG;
                    txtSDT.Text = kHACHHANG.SDT;
                    txtQuocTich.Text = kHACHHANG.QUOCTICH;
                    txtDiaChi.Text = kHACHHANG.DIACHI;
                    if (kHACHHANG.GIOITINH == true)
                    {
                        rdoNam.Checked = true;
                    }
                    else
                        rdoNu.Checked = true;
                }
                else
                    MessageBox.Show("CMND/CCCD chưa có trong danh sách"); 
               
            }


        }

        private void dgvPhongChon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int soNguoi = 1;
            if (dgvPhongChon.Rows[e.RowIndex].Cells[4].Value != null)
            {
                if (!int.TryParse(dgvPhongChon.Rows[e.RowIndex].Cells[4].Value.ToString(), out soNguoi) || soNguoi <= 0)
                {
                    dgvPhongChon.Rows[e.RowIndex].Cells[4].Value = 1;
                    MessageBox.Show("Lỗi: Nhập số người kiểu số nguyên!", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    string tenPhong = (dgvPhongChon.Rows[e.RowIndex].Cells[0].Value).ToString();
                    PHONG pHONG = ConText.PHONG.FirstOrDefault(p => p.MAPHONG.ToString().Equals(tenPhong));
                    CT_PhieuDatPhong_Custom cT_Phieu = pHONGsChon.FirstOrDefault(p => p.MAPHONG.ToString().Equals(tenPhong));
                    cT_Phieu.SONGUOI = int.Parse(dgvPhongChon.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            else
            {
                dgvPhongChon.Rows[e.RowIndex].Cells[4].Value = 1;
                MessageBox.Show("Lỗi: Nhập số người kiểu số nguyên!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
