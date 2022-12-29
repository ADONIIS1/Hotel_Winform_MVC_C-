using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class PhieuSuDungDichVuDAO
    {
        private static PhieuSuDungDichVuDAO instance;

        internal static PhieuSuDungDichVuDAO Instance
        {
            get { if (instance == null) instance = new PhieuSuDungDichVuDAO(); return PhieuSuDungDichVuDAO.instance; }
            private set { PhieuSuDungDichVuDAO.instance = value; }
        }
        private PhieuSuDungDichVuDAO() { }

        public static List<PHIEUSDDV> GetallListSDDV()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.PHIEUSDDV.ToList();
        }

        public bool AddPhieuSDDV(int map, int sophieudatphong)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHIEUSDDV db = Context.PHIEUSDDV.FirstOrDefault(p => p.MAPHONG == map && p.SOPHIEUDATPHONG == sophieudatphong);
            if (db != null)
            {
                return false;
            }
            else
            {
                db = new PHIEUSDDV();
                db.MAPHONG = map;
                db.NGAYSDDV = DateTime.Now;
                db.SOPHIEUDATPHONG = sophieudatphong;
                db.TONGTIENDV = 0;
                if (db != null)
                {
                    Context.PHIEUSDDV.Add(db);
                    Context.SaveChanges();
                    return true;
                }
            }
            return false;

        }
 
        public int GetSoPhieuSDDV(int map,int sophieudatphong)

        {  
             int sophieu = 0;
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHIEUSDDV pHIEUSDDV = Context.PHIEUSDDV.FirstOrDefault(p => p.MAPHONG == map&& p.SOPHIEUDATPHONG == sophieudatphong);
            if(pHIEUSDDV!=null)
            { 
               sophieu = pHIEUSDDV.SOPHIEUSDDV; 
            }
           
            return sophieu;
        }
        public void updataTongTienDV(int map,int sophieudatphong, double tongtendv )
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHIEUSDDV pHIEUSDDV = Context.PHIEUSDDV.FirstOrDefault(p => p.MAPHONG == map && p.SOPHIEUDATPHONG == sophieudatphong);
            if (pHIEUSDDV != null)
            {
                pHIEUSDDV.TONGTIENDV = tongtendv;
                Context.SaveChanges();
             
            }
          
        }
      

    }
}
