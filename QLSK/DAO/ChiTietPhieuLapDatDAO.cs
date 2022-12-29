using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class ChiTietPhieuLapDatDAO
    {
        private static ChiTietPhieuLapDatDAO instance;

        internal static ChiTietPhieuLapDatDAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuLapDatDAO(); return ChiTietPhieuLapDatDAO.instance; }
            private set { ChiTietPhieuLapDatDAO.instance = value; }
        }
        private ChiTietPhieuLapDatDAO() { }
     
        public List<CHITIETLAPDAT> GetCHITIETLAPDATforSOPhiue(int soPhieu)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            List<CHITIETLAPDAT> db = context.CHITIETLAPDAT.Where(p => p.SOPHIEULAPDAT == soPhieu).ToList();
            return db;
        }
        public  bool ThemCTLAPDAT ( int vatTu)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            CHITIETLAPDAT dv = new CHITIETLAPDAT();
            dv.SOPHIEULAPDAT = GetSoPhieuMax();
            dv.IDVATTU = vatTu;
            dv.TINHTRANG = "Mới";
           if(dv!= null)
            {
                context.CHITIETLAPDAT.Add(dv);
                context.SaveChanges();
                return true;
            }
            return false;

         
        }
        public int GetSoPhieuMax()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();

            int SoPhieuMax = Context.PHIEULAPDAT.Max(p => p.SOPHIEULAPDAT);
            return SoPhieuMax;
        }
        int dem = 0;
        public bool DeleteCTPhieuThueTheoSoPhieuLapDat(int sophieu)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            List<CHITIETLAPDAT> db = Context.CHITIETLAPDAT.Where(p => p.SOPHIEULAPDAT == sophieu).ToList();
            foreach (CHITIETLAPDAT item in db)
            {
                Context.CHITIETLAPDAT.Remove(item);
                Context.SaveChanges();
                dem++;
            }
            if (db.Count == dem)
            {
                return true;
            }
            return false;
        }
        public  bool XoaCTphieu(int tenvt)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();

            CHITIETLAPDAT data = context.CHITIETLAPDAT.Where(p => p.IDVATTU == tenvt).FirstOrDefault();
            if (data != null)
            {
                context.CHITIETLAPDAT.Remove(data);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
