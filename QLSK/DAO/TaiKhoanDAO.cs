using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        internal static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return TaiKhoanDAO.instance; }
            private set { TaiKhoanDAO.instance = value; }
        }
        private TaiKhoanDAO() { }
        public List<TAIKHOAN> GetallListTaiKhoan()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.TAIKHOAN.ToList();
        }
        public TAIKHOAN GetTaiKhoanTheotenTK(string tentk)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            TAIKHOAN cs = Context.TAIKHOAN.FirstOrDefault(p => p.TENTAIKHOAN.Equals(tentk));
            return cs;
        }

        public bool ThemTaiKhoan(string Ten,string MK,int MaNV,int quyen)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            TAIKHOAN dv = context.TAIKHOAN.FirstOrDefault(p => p.TENTAIKHOAN.Equals(Ten));
            if (dv==null)
            {
                 dv = new TAIKHOAN();
                dv.TENTAIKHOAN = Ten;
                dv.MATKHAU = MK;
                dv.MANV = MaNV;
                dv.QUYEN = quyen;
                if (dv != null)
                {
                    context.TAIKHOAN.Add(dv);
                    context.SaveChanges();
                    return true;
                }
            }
          
            return false;
        }

        public bool DoiMK(string TenTK,string MK)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            TAIKHOAN cs = Context.TAIKHOAN.FirstOrDefault(p => p.TENTAIKHOAN.Equals(TenTK));
            if(cs != null)
            {
                cs.MATKHAU = MK;
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SuaTaiKhoan(string Ten, string MK, int MaNV, int quyen)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            TAIKHOAN dv =  context.TAIKHOAN.Where(p => p.TENTAIKHOAN.Equals(Ten)).FirstOrDefault();
            if (dv != null)
            {
                dv.TENTAIKHOAN = Ten;
                dv.MATKHAU = MK;
                dv.MANV = MaNV;
                dv.QUYEN = quyen;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool XoaSuaTaiKhoan(string Ten)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            TAIKHOAN data = context.TAIKHOAN.Where(p => p.TENTAIKHOAN == Ten).FirstOrDefault();
            if (data != null)
            {
                context.TAIKHOAN.Remove(data);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
