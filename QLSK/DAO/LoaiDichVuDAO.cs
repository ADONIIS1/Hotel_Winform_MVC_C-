using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class LoaiDichVuDAO

    {
        private static LoaiDichVuDAO instance;

        internal static LoaiDichVuDAO Instance
        {
            get { if (instance == null) instance = new LoaiDichVuDAO(); return LoaiDichVuDAO.instance; }
            private set { LoaiDichVuDAO.instance = value; }
        }
        private LoaiDichVuDAO() { }

        public List<LOAIDICHVU> GetLoaiDichVu()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.LOAIDICHVU.ToList();
        }
        public  LOAIDICHVU GetloaiTheoID(int ID)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.LOAIDICHVU.Where(p => p.IDLOAIDICHVU == ID).FirstOrDefault();
        }
        public  bool Them(string Ten)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            LOAIDICHVU dv = new LOAIDICHVU();
            dv.TENLOAIDICHVU = Ten;
            if(dv != null)
            {
                context.LOAIDICHVU.Add(dv);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public  bool Sua(int id, string Ten)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            LOAIDICHVU dv = context.LOAIDICHVU.Where(p => p.IDLOAIDICHVU == id).FirstOrDefault();
            if (dv != null)
            {
                dv.TENLOAIDICHVU = Ten;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public  void Xoa(int Id)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            LOAIDICHVU data = context.LOAIDICHVU.Where(p => p.IDLOAIDICHVU == Id).FirstOrDefault();
            if (data != null)
            {
                context.LOAIDICHVU.Remove(data);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tồn tại trong CSDL");
            }
        }
    }
}
