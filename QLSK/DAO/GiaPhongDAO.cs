using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class GiaPhongDAO
    {
        private static GiaPhongDAO instance;

        internal static GiaPhongDAO Instance
        {
            get { if (instance == null) instance = new GiaPhongDAO(); return GiaPhongDAO.instance; }
            private set { GiaPhongDAO.instance = value; }
        }
        private GiaPhongDAO() { }

        public GIAPHONG GetGIAPHONGTheoKPANDLP(string IDKieuPhong, string IDLoaiPhong)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            GIAPHONG GP = Context.GIAPHONG.FirstOrDefault(p => p.KIEUPHONG.TENKIEUPHONG == IDKieuPhong && p.LOAIPHONG.TENLOAIPHONG == IDLoaiPhong);

            return GP;
        }
        public List<GIAPHONG> GetGIAPHONG()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.GIAPHONG.ToList();
        }
        public bool SuaGiaPhong(string IDKieuPhong, string IDLoaiPhong, double GiaNgay, double GiaGio)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            GIAPHONG GP = Context.GIAPHONG.FirstOrDefault(p => p.KIEUPHONG.TENKIEUPHONG == IDKieuPhong && p.LOAIPHONG.TENLOAIPHONG == IDLoaiPhong);

            if (GP != null)
            {
                GP.GIANGAY = GiaNgay;
                GP.GIAGIO = GiaGio;
                Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
