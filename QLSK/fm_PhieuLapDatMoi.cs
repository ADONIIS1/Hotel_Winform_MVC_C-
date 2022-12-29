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
    public partial class fm_PhieuLapDatMoi : Form
    {
        public fm_PhieuLapDatMoi()
        {
            InitializeComponent();
             LoadCombobox();
            LoadDanhSachVatTu();
        }
        public fm_PhieuLapDatMoi(fm_LapDat fm_Lap)
        {
            InitializeComponent();
            LoadCombobox();
            LoadDanhSachVatTu();
            fm_Lap1 = fm_Lap;
        }
        fm_LapDat fm_Lap1 = new fm_LapDat();
        List<VATTU> VTChon = new List<VATTU>();
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<VATTU> TimKiem()
        {
            List<VATTU> vs = VatTuDAO.Instance.GetAllVatTu();
           
             vs = vs.Where(p => p.TENVATTU.Contains(txtTimkiem.Text.ToString().ToLower()) || p.XUATXU.Contains(txtTimkiem.Text.ToString().ToLower())).ToList();
          
                vs = (from l in vs
                      where !(from pdc in VTChon select pdc.TENVATTU).Contains(l.TENVATTU)
                      select l).ToList();
        
            return vs;
        }
        void LoadDanhSachVatTu()
        {
            dgvVatTu.Rows.Clear();
            List<VATTU> vs = TimKiem();
            foreach(var item in vs)
            {
                int rowId = dgvVatTu.Rows.Add();
                dgvVatTu.Rows[rowId].Cells[0].Value = item.TENVATTU;
                dgvVatTu.Rows[rowId].Cells[1].Value = item.XUATXU;
            }
        }

        void  LoadCombobox()
        {
            List<PHONG> P = PhongDAO.Instance.GetPhongall();
            P.Insert(0, new PHONG { TENPHONG = "Chọn Phòng" });
            cbbTenPhong.DataSource = P;
            cbbTenPhong.DisplayMember = "TENPHONG";
            cbbTenPhong.ValueMember = "MAPHONG";
        }

        private void dgvVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVatTu.Columns[e.ColumnIndex].HeaderText == "Thêm")
            {
               string tenPhong = (dgvVatTu.Rows[e.RowIndex].Cells[0].Value).ToString();
                VATTU VT = VatTuDAO.Instance.GetVatTutheoMtenVT(tenPhong);


                int rowId = dgvVatTuChon.Rows.Add();
                dgvVatTuChon.Rows[rowId].Cells[0].Value = VT.TENVATTU;


                VATTU vATTU = new VATTU();
                vATTU.IDVATTU = VT.IDVATTU;
                vATTU.TENVATTU = dgvVatTu.Rows[e.RowIndex].Cells[0].Value.ToString();
                vATTU.XUATXU = dgvVatTu.Rows[e.RowIndex].Cells[1].Value.ToString();
                VTChon.Add(vATTU);
                dgvVatTu.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachVatTu();
        }
        private bool kiemTraDayDuThongTin()
        {
            if (cbbTenPhong.SelectedIndex == 0)
            {
                cbbTenPhong.Focus();
                MessageBox.Show("Bạn Hãy Chọn Phòng Để Lăp Đặt !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (VTChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Vật tự trước khi lưu !", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        int dem = 0;
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraDayDuThongTin())
            {
                if (PhieuLapDatDAO.Instance.ThemPhieuLD(1,int.Parse(cbbTenPhong.SelectedValue.ToString())))
                {
                    foreach (var item in VTChon)
                    {

                        if (ChiTietPhieuLapDatDAO.Instance.ThemCTLAPDAT(item.IDVATTU))
                        {
                            dem++;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi: Thêm Chi Tiết Phiếu Lăp Đặt!", "Thông báo", MessageBoxButtons.OK);
                            break;
                        }

                    }
                }
                if(dem == VTChon.Count && dem != 0)
                {
                    MessageBox.Show("Thêm Phiếu Lăp Đặt Thành Công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Lỗi: Thêm Phiếu Lăp Đặt!", "Thông báo", MessageBoxButtons.OK);
                }
                this.Close();
                fm_Lap1.BindGridPhieu(PhieuLapDatDAO.Instance.GetAllPhieuLapDat());
            }
        }

        private void dgvVatTuChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVatTuChon.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string tenPhong = (dgvVatTuChon.Rows[e.RowIndex].Cells[0].Value).ToString();
                VATTU VT = VatTuDAO.Instance.GetVatTutheoMtenVT(tenPhong);

                int rowId = dgvVatTu.Rows.Add();
                dgvVatTu.Rows[rowId].Cells[0].Value = VT.TENVATTU;
                dgvVatTu.Rows[rowId].Cells[1].Value = VT.XUATXU;

                VATTU VT1 = VTChon.FirstOrDefault(p => p.TENVATTU.Equals(tenPhong));
                VTChon.Remove(VT1);
                dgvVatTuChon.Rows.RemoveAt(e.RowIndex);
            }
        }

    }
}
