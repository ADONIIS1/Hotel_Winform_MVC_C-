using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class PhieuDatPhongDAO
    {
        private static PhieuDatPhongDAO instance;

        internal static PhieuDatPhongDAO Instance
        {
            get { if (instance == null) instance = new PhieuDatPhongDAO(); return PhieuDatPhongDAO.instance; }
            private set { PhieuDatPhongDAO.instance = value; }
        }
        private PhieuDatPhongDAO() { }

        public static List<PHIEUDATPHONG> GetallListPhieuDatPhong()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.PHIEUDATPHONG.ToList();
        }

        public  bool DeletePhieuDatPhong(int id)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHIEUDATPHONG db = Context.PHIEUDATPHONG.Where(p => p.SOPHIEUDATPHONG == id).FirstOrDefault();
            if (db != null)
            {
                ChiTietPhieuDatPhongDAO.Instance.DeleteCTPhieuThueTheoSoPhieuThue(db.SOPHIEUDATPHONG);
                Context.PHIEUDATPHONG.Remove(db);
                Context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public bool AddPhieuDatPhong(int manv,string CMND)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHIEUDATPHONG db = new PHIEUDATPHONG();
            db.MANV = manv;
            db.NGAYDATPHONG = DateTime.Now;
           
            db.CMND = CMND;
            db.TONGTIENDATPHONG = 0;
            if(db!= null)
            {
                Context.PHIEUDATPHONG.Add(db);
                Context.SaveChanges();
                return true;
            }
            return false;
           
        }
        public PHIEUDATPHONG getPhieuDatPhongTheoSoPhieu(int sophieudatphong)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHIEUDATPHONG db = Context.PHIEUDATPHONG.Where(p => p.SOPHIEUDATPHONG == sophieudatphong).FirstOrDefault();
            return db;
        }
        public int GetSoPhieuMax()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();

            int SoPhieuMax = Context.PHIEUDATPHONG.Max(p => p.SOPHIEUDATPHONG);
            return SoPhieuMax;
        }
        public List<PHIEUDATPHONG> GetPHIEUDATPHONGALL()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.PHIEUDATPHONG.ToList();
        }
        public void updataTongTienPhong( int sophieudatphong, double TongTieDP)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHIEUDATPHONG pHIEUDATPHONG = Context.PHIEUDATPHONG.FirstOrDefault(p => p.SOPHIEUDATPHONG == sophieudatphong);
            if (pHIEUDATPHONG != null)
            {
                pHIEUDATPHONG.TONGTIENDATPHONG = TongTieDP;
                Context.SaveChanges();

            }

        }

    }
}
