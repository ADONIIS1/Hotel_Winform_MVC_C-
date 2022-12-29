using QLSK.BUS;
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
    public partial class fm_ThemDichVu : Form
    {
        List<CT_SDDICHVU> cT_SDDICHVUs = new List<CT_SDDICHVU>();
        public fm_ThemDichVu()
        {
            InitializeComponent();
            LoadCombobox();
        }
        public fm_ThemDichVu(fm_ChiTietPhong fm_Chi)
        {
            InitializeComponent();
            LoadCombobox();
            LoadDicVu();
            fm_ChiTiet = fm_Chi;
        }
        fm_ChiTietPhong fm_ChiTiet = new fm_ChiTietPhong();
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static int MaP;
        public static int sophieu;
        private void fm_ThemDichVu_Load(object sender, EventArgs e)
        {
            PhieuSuDungDichVuDAO.Instance.AddPhieuSDDV(MaP, sophieu);
        }
        void LoadCombobox()
        {
            List<LOAIDICHVU> DV = LoaiDichVuDAO.Instance.GetLoaiDichVu();
            DV.Insert(0, new LOAIDICHVU {TENLOAIDICHVU =  "Tất Cả" });
            cbbLoaiDV.DataSource = DV;
            cbbLoaiDV.ValueMember = "IDLOAIDICHVU";
            cbbLoaiDV.DisplayMember = "TENLOAIDICHVU";

        }
        List<DICHVU> TimKiem()
        {
            //int sophieusddv = PhieuSuDungDichVuDAO.Instance.GetSoPhieuSDDV(MaP, sophieu);
            List<DICHVU> DV = DichVuDAO.Instance.GetallListDichVu();
            List<DICHVU> ls = new List<DICHVU>();
            ls = DV;
            if (cT_SDDICHVUs.Count > 0)
            {
                ls = (from l in DV
                      where !(from pdc in cT_SDDICHVUs select pdc.IDDICHVU).Contains(l.IDDICHVU)
                      select l).ToList();
            }
            if (cbbLoaiDV.SelectedIndex != 0)
            {
                ls = ls.Where(p => p.IDLOAIDICHVU.ToString().Equals(cbbLoaiDV.SelectedValue.ToString())).ToList();
            }
            if(txtTimKiem.Text != "")
            {
                ls = ls.Where(p =>  p.TENDICHVU.Contains(txtTimKiem.Text) || p.LOAIDICHVU.TENLOAIDICHVU.ToString().Contains(txtTimKiem.Text)|| p.DONGIABAN.ToString().Contains(txtTimKiem.Text)).ToList();
            }
            return ls;
        }
        void LoadDicVu()
        {
            dgvDichVu.Rows.Clear();
            //dgvDichVuChon.Rows.Clear();
            int sophieusddv = PhieuSuDungDichVuDAO.Instance.GetSoPhieuSDDV(MaP, sophieu);
            List<DICHVU> cHITIETSDDICHVUs = TimKiem();
            foreach (var item in cHITIETSDDICHVUs)
            {
                int rowId = dgvDichVu.Rows.Add();
                dgvDichVu.Rows[rowId].Cells[0].Value = item.LOAIDICHVU.TENLOAIDICHVU;
                dgvDichVu.Rows[rowId].Cells[1].Value = item.TENDICHVU;
                dgvDichVu.Rows[rowId].Cells[2].Value = item.DONGIABAN;
            }
        }

        private void cbbLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDicVu();
        }

        QuanLyKhachSan ConText = new QuanLyKhachSan();
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDichVu.Columns[e.ColumnIndex].HeaderText == "Thêm")
            {
                string TenDV = dgvDichVu.Rows[e.RowIndex].Cells[1].Value.ToString();
                DICHVU DV = ConText.DICHVU.FirstOrDefault(p => p.TENDICHVU.Equals(TenDV));
                int rowId = dgvDichVuChon.Rows.Add();
                dgvDichVuChon.Rows[rowId].Cells[0].Value = DV.TENDICHVU;
                dgvDichVuChon.Rows[rowId].Cells[1].Value = 1;
                dgvDichVuChon.Rows[rowId].Cells[2].Value = DV.DONGIABAN*1;
                CT_SDDICHVU cT = new CT_SDDICHVU();
                cT.IDDICHVU = DV.IDDICHVU;
                cT.TenDV = DV.TENDICHVU;
                cT.SOLUONG = int.Parse(dgvDichVuChon.Rows[rowId].Cells[1].Value.ToString());
                cT.DonGia = DV.DONGIABAN;
                cT_SDDICHVUs.Add(cT);
                dgvDichVu.Rows.RemoveAt(e.RowIndex);
            }

        }

        private void dgvDichVuChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDichVuChon.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                string TenDV = dgvDichVuChon.Rows[e.RowIndex].Cells[0].Value.ToString();
                DICHVU DV = ConText.DICHVU.FirstOrDefault(p => p.TENDICHVU.Equals(TenDV));
                int rowId = dgvDichVu.Rows.Add();
                dgvDichVu.Rows[rowId].Cells[0].Value = DV.LOAIDICHVU.TENLOAIDICHVU;
                dgvDichVu.Rows[rowId].Cells[1].Value = DV.TENDICHVU;
                dgvDichVu.Rows[rowId].Cells[2].Value = DV.DONGIABAN;
                CT_SDDICHVU cT = cT_SDDICHVUs.FirstOrDefault(p => p.TenDV.Equals(TenDV));
                cT_SDDICHVUs.Remove(cT);
                dgvDichVuChon.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgvDichVuChon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                int soNguoi = 1;
         
                if(dgvDichVuChon.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    if (!int.TryParse(dgvDichVuChon.Rows[e.RowIndex].Cells[1].Value.ToString(), out soNguoi) || soNguoi == 0)
                    {
                        dgvDichVuChon.Rows[e.RowIndex].Cells[1].Value = 1;
                        MessageBox.Show("Lỗi: Nhập số Lượng Dịch Vụ số nguyên!", "Thông báo", MessageBoxButtons.OK);

                    }
                    else
                    {
                        string TenDV = (dgvDichVuChon.Rows[e.RowIndex].Cells[0].Value).ToString();

                        DICHVU DV = ConText.DICHVU.FirstOrDefault(p => p.TENDICHVU.ToString().Equals(TenDV));

                        dgvDichVuChon.Rows[e.RowIndex].Cells[2].Value = DV.DONGIABAN * int.Parse(dgvDichVuChon.Rows[e.RowIndex].Cells[1].Value.ToString());
                        CT_SDDICHVU cT_Phieu = cT_SDDICHVUs.FirstOrDefault(p => p.TenDV.ToString().Equals(TenDV));
                        cT_Phieu.SOLUONG = int.Parse(dgvDichVuChon.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                }
                else
                {
                    dgvDichVuChon.Rows[e.RowIndex].Cells[1].Value = 1;
                    MessageBox.Show("Lỗi: Nhập số Lượng Dịch Vụ số nguyên!", "Thông báo", MessageBoxButtons.OK);
                }
               
        
           
          
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDicVu();
        }
        int dem = 0;
        private void btLuu_Click(object sender, EventArgs e)
        {
           int sophieudv =  PhieuSuDungDichVuDAO.Instance.GetSoPhieuSDDV(MaP, sophieu);
           foreach(var item in cT_SDDICHVUs)
            {
                if(CTSDDVDAO.Instance.AddCTPhieuSDDV(item.IDDICHVU,item.SOLUONG, sophieudv))
                {
                    dem++;
                }
            }
           if(dem== cT_SDDICHVUs.Count)
            {
                MessageBox.Show("Thêm Dịch Vụ Thành Công ", "Thông Báo", MessageBoxButtons.OK);
                this.Close();
                fm_ChiTiet.LoaddgvDichVu();
            }
        }
    }
}
