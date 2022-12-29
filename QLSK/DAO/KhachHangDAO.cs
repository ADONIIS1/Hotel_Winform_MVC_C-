using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        internal static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return KhachHangDAO.instance; }
            private set { KhachHangDAO.instance = value; }
        }
        private KhachHangDAO() { }
        public bool AddKhachHang(string CMND,string TenKhach,string SDT,string DiaChi,string QuocTich, bool gioitinh)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            KHACHHANG kHACHHANG = Context.KHACHHANG.FirstOrDefault(p => p.CMND.ToString().Equals(CMND));
            if (kHACHHANG == null)
            {
                kHACHHANG = new KHACHHANG();
                kHACHHANG.TENKHACHHANG = TenKhach;
                kHACHHANG.CMND = CMND;
                kHACHHANG.SDT = SDT;
                kHACHHANG.DIACHI = DiaChi;
                kHACHHANG.GIOITINH = gioitinh;
                kHACHHANG.QUOCTICH = QuocTich;
                Context.KHACHHANG.Add(kHACHHANG);
                Context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public KHACHHANG GetKHACHHANGCMND(string CMND)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            KHACHHANG kHACHHANG = Context.KHACHHANG.FirstOrDefault(p => p.CMND.ToString().Equals(CMND));
            return kHACHHANG;
        }

        public  List<KHACHHANG> GetAllKhachHang()
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
          
            return context.KHACHHANG.ToList();
        }
    
        public static void XoaKhachHang(string cmnd)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();

            KHACHHANG data = context.KHACHHANG.Where(p => p.CMND == cmnd).FirstOrDefault();
            if (data != null)
            {
                context.KHACHHANG.Remove(data);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tồn tại trong CSDL");
            }
        }
    }
}
