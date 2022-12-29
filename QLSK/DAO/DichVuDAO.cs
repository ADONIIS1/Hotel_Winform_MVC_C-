using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;

        internal static DichVuDAO Instance
        {
            get { if (instance == null) instance = new DichVuDAO(); return DichVuDAO.instance; }
            private set { DichVuDAO.instance = value; }
        }
        private DichVuDAO() { }

        public List<DICHVU> GetallListDichVu()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.DICHVU.ToList();
        }
     
        public  DICHVU GetDichVu(int MaDV)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.DICHVU.Where(p => p.IDDICHVU == MaDV).FirstOrDefault();
        }
        public bool ThemDichVu(string Ten, double DonGia, string DVT, int loai)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
        
            DICHVU dv = new DICHVU();
            dv.TENDICHVU = Ten;
            dv.DONGIABAN = DonGia;
            dv.DVT = DVT;
            dv.IDLOAIDICHVU = loai;
            if(dv != null)
            {
                context.DICHVU.Add(dv);
                context.SaveChanges();
                return true;
            }
            return false;
           
        }
        public  bool SuaDichVu(int id, string Ten, double DonGia, string DVT, int loai)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            DICHVU dv = context.DICHVU.Where(p => p.IDDICHVU == id).FirstOrDefault();
            if (dv != null)
            {
                dv.TENDICHVU = Ten;
                dv.DONGIABAN = DonGia;
                dv.DVT = DVT;
                dv.IDLOAIDICHVU = loai;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public  void XoaDichVu(int Id)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            DICHVU data = context.DICHVU.Where(p => p.IDDICHVU == Id).FirstOrDefault();
            if (data != null)
            {
                context.DICHVU.Remove(data);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tồn tại trong CSDL");
            }
        }
    }
}
