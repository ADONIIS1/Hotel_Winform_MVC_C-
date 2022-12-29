using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class PhieuLapDatDAO
    {
        private static PhieuLapDatDAO instance;

        internal static PhieuLapDatDAO Instance
        {
            get { if (instance == null) instance = new PhieuLapDatDAO(); return PhieuLapDatDAO.instance; }
            private set { PhieuLapDatDAO.instance = value; }
        }
        private PhieuLapDatDAO() { }
        public  List<PHIEULAPDAT> GetAllPhieuLapDat()
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.PHIEULAPDAT.ToList();
        }
        public  PHIEULAPDAT GetphieulapDattheosophieu(int SoPhieu)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.PHIEULAPDAT.Where(p => p.SOPHIEULAPDAT == SoPhieu).FirstOrDefault();
        }
        public  bool ThemPhieuLD(int maNV,int MaP)
        {
            DateTime date = DateTime.Now;
            QuanLyKhachSan context = new QuanLyKhachSan();
            PHIEULAPDAT dv = new PHIEULAPDAT();
            if(dv!= null)
            {
                dv.MANV = maNV;
                dv.NGAYLAPDAT = date;
                dv.MAPHONG = MaP;
                context.PHIEULAPDAT.Add(dv);
                context.SaveChanges();
                return true;
            }
            return false;
           
        }
        public  void SuaPhieuLD(int soPhieu, int maNV, DateTime ngay)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            PHIEULAPDAT dv = context.PHIEULAPDAT.Where(p => p.SOPHIEULAPDAT == soPhieu).FirstOrDefault();
            if (dv != null)
            {
                dv.MANV = maNV;
                dv.NGAYLAPDAT = ngay;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tồn tại trong CSDL");
            }

            context.SaveChanges();
        }
        public bool DeletePhieuLapDat(int id)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHIEULAPDAT db = Context.PHIEULAPDAT.Where(p => p.SOPHIEULAPDAT == id).FirstOrDefault();
            if (db != null)
            {
                if (ChiTietPhieuLapDatDAO.Instance.DeleteCTPhieuThueTheoSoPhieuLapDat(db.SOPHIEULAPDAT))
                {
                    Context.PHIEULAPDAT.Remove(db);
                    Context.SaveChanges();
                    return true;
                }
                
            }        
           return false;
        }
    }
}
