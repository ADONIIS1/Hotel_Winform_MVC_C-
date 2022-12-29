using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class LoaiPhongDAO
    {
        private static LoaiPhongDAO instance;

        internal static LoaiPhongDAO Instance
        {
            get { if (instance == null) instance = new LoaiPhongDAO(); return LoaiPhongDAO.instance; }
            private set { LoaiPhongDAO.instance = value; }
        }
        private LoaiPhongDAO() { }
        public  List<LOAIPHONG> GetAllLoaiPhong()
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.LOAIPHONG.ToList();
        }
        public  LOAIPHONG GetLOAIPHONGTheoMALoaiP(int MaLPhong)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.LOAIPHONG.Where(p => p.IDLOAIPHONG == MaLPhong).FirstOrDefault();
        }

        public bool Them(string Ten)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            LOAIPHONG dv = new LOAIPHONG();
            dv.TENLOAIPHONG = Ten;
            if(dv != null)
            {
                context.LOAIPHONG.Add(dv);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool  Sua(int id, string Ten)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            LOAIPHONG dv = context.LOAIPHONG.Where(p => p.IDLOAIPHONG == id).FirstOrDefault();
            if (dv != null)
            {
                dv.TENLOAIPHONG = Ten;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public  void Xoa(int Id)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            LOAIPHONG data = context.LOAIPHONG.Where(p => p.IDLOAIPHONG == Id).FirstOrDefault();
            if (data != null)
            {
                context.LOAIPHONG.Remove(data);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tồn tại trong CSDL");
            }
        }
    }
}
