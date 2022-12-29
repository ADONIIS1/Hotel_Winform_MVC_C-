using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class ChiTietPhieuDatPhongDAO
    {
        private static ChiTietPhieuDatPhongDAO instance;

        internal static ChiTietPhieuDatPhongDAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuDatPhongDAO(); return ChiTietPhieuDatPhongDAO.instance; }
            private set { ChiTietPhieuDatPhongDAO.instance = value; }
        }
        private ChiTietPhieuDatPhongDAO() { }

        public bool AddCTPhieuThue(int MAPHONG, DateTime ngayBD, DateTime ngayKT,int songuoi)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            CHITIETPHIEUDATPHONG cHITIETPHIEUDATPHONG = new CHITIETPHIEUDATPHONG();
            cHITIETPHIEUDATPHONG.MAPHONG = MAPHONG;
            cHITIETPHIEUDATPHONG.GIOVAO = ngayBD;
            cHITIETPHIEUDATPHONG.GIORA = ngayKT;
            cHITIETPHIEUDATPHONG.SONGUOI = songuoi;
            cHITIETPHIEUDATPHONG.SOPHIEUDATPHONG = PhieuDatPhongDAO.Instance.GetSoPhieuMax();
            cHITIETPHIEUDATPHONG.TINHTRANGPHONG = "Đã Đặt";
            if (cHITIETPHIEUDATPHONG != null)
            {
                Context.CHITIETPHIEUDATPHONG.Add(cHITIETPHIEUDATPHONG);
                Context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteCTPhieuThueTheoSoPhieuThue(int sophieu)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            List<CHITIETPHIEUDATPHONG> db = Context.CHITIETPHIEUDATPHONG.Where(p => p.SOPHIEUDATPHONG == sophieu).ToList();
            foreach(CHITIETPHIEUDATPHONG item in db)
            {
                Context.CHITIETPHIEUDATPHONG.Remove(item);
                Context.SaveChanges();
               
            }
            if (db.Count == 0)
            {
                return true;

            }
            return false;
        }
        public bool DeleteCTPhieuThueTheoMaPhong(int maP,DateTime NgayVao)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            CHITIETPHIEUDATPHONG db = Context.CHITIETPHIEUDATPHONG.FirstOrDefault(p => p.MAPHONG == maP && p.GIOVAO == NgayVao);
            if(db != null)
            {
                Context.CHITIETPHIEUDATPHONG.Remove(db);
                Context.SaveChanges();
                return true;
            }

            return false;
        }
        public List<CHITIETPHIEUDATPHONG> GetListCTPhieuThueTheoSoPhieuThue(int sophieu)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            List<CHITIETPHIEUDATPHONG> db = Context.CHITIETPHIEUDATPHONG.Where(p => p.SOPHIEUDATPHONG == sophieu).ToList();
            return db;
        }
        public CHITIETPHIEUDATPHONG GetCTPhieuThueTheoSoPhieuThue(int sophieu,DateTime NgayBĐ)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            CHITIETPHIEUDATPHONG db = Context.CHITIETPHIEUDATPHONG.FirstOrDefault(p => p.MAPHONG == sophieu && p.GIOVAO == NgayBĐ);
            return db;
        }
        public CHITIETPHIEUDATPHONG GetCTPhieuThueTheoSoPhieuThuevaMAp(int sophieu, int Map)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            CHITIETPHIEUDATPHONG db = Context.CHITIETPHIEUDATPHONG.FirstOrDefault(p => p.MAPHONG == Map && p.SOPHIEUDATPHONG == sophieu);
            return db;
        }
        public int GetSoNgayThue(int MaP, DateTime giovao)
        {

            int SoNgay;
            CHITIETPHIEUDATPHONG db = GetCTPhieuThueTheoSoPhieuThue(MaP, giovao);
            SoNgay = db.GIORA.Day - db.GIOVAO.Day;
            return SoNgay;
        }
        public int GetSoGioThue(int MaP,DateTime giovao)
        {
            int SoGio;
            CHITIETPHIEUDATPHONG db = GetCTPhieuThueTheoSoPhieuThue(MaP, giovao);
            SoGio = db.GIORA.Hour - db.GIOVAO.Hour;
            return SoGio;
        }
        public bool ThayDoiTinhTrangPhong(int MaP, int SoPhieuDP)
        {
           QuanLyKhachSan Context = new QuanLyKhachSan();
           CHITIETPHIEUDATPHONG db = Context.CHITIETPHIEUDATPHONG.FirstOrDefault(p => p.MAPHONG == MaP && p.SOPHIEUDATPHONG == SoPhieuDP);
           if (db != null)
           {
                db.TINHTRANGPHONG = "Đang Thuê";
                Context.SaveChanges();
                return true;
                 
           }
            return false;
        }
    }
}
