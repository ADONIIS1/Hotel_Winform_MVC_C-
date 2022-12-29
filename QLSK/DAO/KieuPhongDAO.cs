using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class KieuPhongDAO
    {
        private static KieuPhongDAO instance;

        internal static KieuPhongDAO Instance
        {
            get { if (instance == null) instance = new KieuPhongDAO(); return KieuPhongDAO.instance; }
            private set { KieuPhongDAO.instance = value; }
        }
        private KieuPhongDAO() { }

        public  List<KIEUPHONG> GetAllKieuP()
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.KIEUPHONG.ToList();
        }
        public  KIEUPHONG GetKieuPhong(int MaKPhong)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.KIEUPHONG.Where(p => p.IDKIEUPHONG == MaKPhong).FirstOrDefault();
        }

        public  bool Them(string Ten)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            KIEUPHONG dv = new KIEUPHONG();
            dv.TENKIEUPHONG = Ten;
            
            if(dv != null)
            {
                context.KIEUPHONG.Add(dv);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public  bool Sua(int id, string Ten)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            KIEUPHONG dv = context.KIEUPHONG.Where(p => p.IDKIEUPHONG == id).FirstOrDefault();
            if (dv != null)
            {
                dv.TENKIEUPHONG = Ten;
               
                context.SaveChanges();
                return true;
            }
            return false;
           
        }
        public  void Xoa(int Id)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            KIEUPHONG data = context.KIEUPHONG.Where(p => p.IDKIEUPHONG == Id).FirstOrDefault();
            if (data != null)
            {
                context.KIEUPHONG.Remove(data);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tồn tại trong CSDL");
            }
        } 
    }
}
