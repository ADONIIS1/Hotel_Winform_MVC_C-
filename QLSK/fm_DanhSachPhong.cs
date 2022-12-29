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
    public partial class fm_DanhSachPhong : Form
    {

        public fm_DanhSachPhong()
        {
            InitializeComponent();
            LoadDateTimePickerBill();
        }
        void LoadDateTimePickerBill()
        {
            DateTime toDay = DateTime.Now;
            dtkngay.Value = toDay;
            cbbGio.SelectedIndex = 1;
            cbbPhut.SelectedIndex = 0;


        }
       
        public int Sodk = 0;


        private void fm_DanhSachPhong_Load(object sender, EventArgs e)
        {
            LoadPhong();
        }
        QuanLyKhachSan ConText = new QuanLyKhachSan();
 
        
        public void LoadPhong()
        {
            flpShowPhongVip.Controls.Clear();
            flpShowPhongThuong.Controls.Clear();
            //plCheckPhong.Controls.Clear();
            DateTime ngayBD = DateTime.Parse(dtkngay.Text + " " + cbbGio.SelectedItem + ":" + cbbPhut.SelectedItem + ":00");
            List<PHONG> phongs = TimKiem();
            foreach (PHONG item in phongs)
            {

                UCPhong uCPhong = new UCPhong() { Width = 318, Height = 120 };
                uCPhong.ItemSoPhong = item.TENPHONG.ToString();
                uCPhong.ItemLoaiP = item.LOAIPHONG.TENLOAIPHONG;
                uCPhong.Click += new EventHandler(Bt_ChiTietPhong);
                uCPhong.Tag = item;

                int map = item.MAPHONG;
                
                CHITIETPHIEUDATPHONG db = ConText.CHITIETPHIEUDATPHONG.FirstOrDefault(p => p.MAPHONG == map && p.GIOVAO == ngayBD);
               
                if (db != null )
                {
                    Sodk = db.SOPHIEUDATPHONG;
                    HOADON HD = ConText.HOADON.FirstOrDefault(p => p.MAPHONG == map && p.SOPHIEUDATPHONG == Sodk);
                    if(HD == null)
                    {
                        uCPhong.ItemTenKhach = db.PHIEUDATPHONG.KHACHHANG.TENKHACHHANG;
                        uCPhong.ItemTinhTrang = db.TINHTRANGPHONG;
                        uCPhong.SoPhieu = db.SOPHIEUDATPHONG;

                        if (db.TINHTRANGPHONG.Equals("Đã Đặt"))
                        {
                            uCPhong.BackColor = Color.LightPink;
                            int GioThue = ChiTietPhieuDatPhongDAO.Instance.GetSoGioThue(db.MAPHONG, ngayBD);
                            uCPhong.ItemPbKhachHang = Resources.icons8_user_96px;
                            uCPhong.ItemTenKhach = db.PHIEUDATPHONG.KHACHHANG.TENKHACHHANG;
                            int NgayThue = ChiTietPhieuDatPhongDAO.Instance.GetSoNgayThue(db.MAPHONG, ngayBD);

                            if (NgayThue > 0)
                            {
                                if (GioThue == 0)
                                {
                                    uCPhong.ItemThoiGian = "" + NgayThue.ToString() + " Ngày";

                                }
                                else
                                {
                                    uCPhong.ItemThoiGian = "" + NgayThue.ToString() + " Ngày " + GioThue.ToString() + "Giờ";

                                }
                                uCPhong.ItemPbThoigian = Resources.icons8_timesheet_128px;

                            }
                            else
                            {
                                uCPhong.ItemThoiGian = "" + GioThue.ToString() + " Giờ";

                            }

                        }
                        else if (db.TINHTRANGPHONG.Equals("Đang Thuê"))
                        {
                            uCPhong.BackColor = Color.LightGreen;
                            int GioThue = ChiTietPhieuDatPhongDAO.Instance.GetSoGioThue(db.MAPHONG, ngayBD);
                            uCPhong.ItemPbKhachHang = Resources.icons8_user_96px;
                            uCPhong.ItemTenKhach = db.PHIEUDATPHONG.KHACHHANG.TENKHACHHANG;
                            int NgayThue = ChiTietPhieuDatPhongDAO.Instance.GetSoNgayThue(db.MAPHONG, ngayBD);

                            if (NgayThue > 0)
                            {
                                if (GioThue == 0)
                                {
                                    uCPhong.ItemThoiGian = "" + NgayThue.ToString() + " Ngày";

                                }
                                else
                                {
                                    uCPhong.ItemThoiGian = "" + NgayThue.ToString() + " Ngày " + GioThue.ToString() + "Giờ";

                                }
                                uCPhong.ItemPbThoigian = Resources.icons8_timesheet_128px;

                            }
                            else
                            {
                                uCPhong.ItemThoiGian = "" + GioThue.ToString() + " Giờ";

                            }
                        }
                        else
                            uCPhong.BackColor = Color.LightSteelBlue;
                    }
                    else
                    {
                        uCPhong.ItemTinhTrang = "Phòng Trống";
                        uCPhong.ItemTenKhach = "Phòng Trống";
                        uCPhong.ItemThoiGian = " ";
                    }
                   

                }
                else
                {
                    uCPhong.ItemTinhTrang = "Phòng Trống";
                    uCPhong.ItemTenKhach = "Phòng Trống";
                    uCPhong.ItemThoiGian = " ";
                }


                if (item.KIEUPHONG.TENKIEUPHONG.Equals("Vip"))
                {
                    flpShowPhongVip.Controls.Add(uCPhong);
                }else
                    flpShowPhongThuong.Controls.Add(uCPhong);
                if (flpShowPhongVip.Controls.Count == 0)
                {
                    flpShowPhongVip.Visible = false;
                }
                else
                {
                    flpShowPhongVip.Visible = true;
                }
            }

        }

        private void Bt_ChiTietPhong(object sender, EventArgs e)
        {
            DateTime ngayBD = DateTime.Parse(dtkngay.Text + " " + cbbGio.SelectedItem + ":" + cbbPhut.SelectedItem + ":00");
            fm_ChiTietPhong.NgayBĐ = ngayBD;
            fm_ChiTietPhong.MaP = ((sender as UCPhong).Tag as PHONG).MAPHONG.ToString();
            int soPhieu = (sender as UCPhong).SoPhieu;
            int MaP = int.Parse(((sender as UCPhong).Tag as PHONG).MAPHONG.ToString());
            fm_ChiTietPhong fm_ChiTiet = new fm_ChiTietPhong(this);
            fm_ChiTiet.ShowDialog();

        }

        private void f_Update(object seder, EventArgs e)
        {
            LoadPhong();
        }

        private void dtkngay_ValueChanged(object sender, EventArgs e)
        {
            if(cbbGio.SelectedIndex != -1 &&cbbPhut.SelectedIndex != -1)
                LoadPhong();
        }

      
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadPhong();
        }

        private void radiotatcatrangthaiphong_CheckedChanged(object sender, EventArgs e)
        {
            LoadPhong();
        }

        private List<PHONG> TimKiem()
        {
            List<PHONG> ListPhongs = ConText.PHONG.ToList();
            List<PHONG> ListTimKiem = new List<PHONG>();

            string LPhong = "";
            string KPhong = "";
            if (radioPdon.Checked == true)
            {
                LPhong = "Đơn";
            }
            else if (radioPDoi.Checked == true)
            {
                LPhong = "Đôi";
            }
            else if (radioNhieuNguoi.Checked == true)
            {
                LPhong = "Gia Đình";
            }

            if (radioPhongThuong.Checked == true)
            {
                KPhong = "Thường";
            }
            else if (radioPhongVip.Checked == true)
            {
                KPhong = "Vip";
            }

            if (radiotatcaLoaiPhong.Checked == true && radiotatcarkieuphong.Checked == true)
            {
                ListTimKiem = ListPhongs;
            }
            else if (radiotatcaLoaiPhong.Checked == true && radiotatcarkieuphong.Checked == false)
            {
                ListTimKiem = ListPhongs.Where(p => p.KIEUPHONG.TENKIEUPHONG.Contains(KPhong)
                ).ToList();
            }
            else if (radiotatcaLoaiPhong.Checked == false && radiotatcarkieuphong.Checked == true)
            {
                ListTimKiem = ListPhongs.Where(p => p.LOAIPHONG.TENLOAIPHONG.Contains(LPhong)
                ).ToList();
            }
            else if (radiotatcaLoaiPhong.Checked == false && radiotatcarkieuphong.Checked == false)
            {
                ListTimKiem = ListPhongs.Where(p => p.LOAIPHONG.TENLOAIPHONG.Contains(LPhong)
                                        && p.KIEUPHONG.TENKIEUPHONG.Contains(KPhong)
                                        ).ToList();
            }
            if(txtTimKiem.Text != "")
            {
                ListTimKiem = ListTimKiem.Where(p => (p is PHONG) && (p as PHONG).TENPHONG.ToLower().Contains(txtTimKiem.Text.ToLower())
                          || Convert.ToString(p.MAPHONG).Contains(txtTimKiem.Text)).ToList();
            }
            
            return ListTimKiem;
        }

        

        private void cbbGio_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbPhut.SelectedIndex != -1)
                LoadPhong();
        }

        private void cbbPhut_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPhong();
        }
    }
}
