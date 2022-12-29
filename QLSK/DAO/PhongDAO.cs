using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class PhongDAO
    {
        private static PhongDAO instance;

        internal static PhongDAO Instance
        {
            get { if (instance == null) instance = new PhongDAO(); return PhongDAO.instance; }
            private set { PhongDAO.instance = value; }
        }
        private PhongDAO() { }
        public List<PHONG> GetPHONGTheoGio(DateTime NgayBĐ, DateTime NgayKT)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            List<PHONG> lsTemp = Context.PHONG.SqlQuery("EXEC USP_GetListPHONGByDate '" + NgayBĐ.ToString("MM/dd/yyyy HH:mm:ss") + "','" + NgayKT.ToString("MM/dd/yyyy HH:mm:ss") + "'").ToList<PHONG>();
            return lsTemp;
        }

        public PHONG GetPhong(int Map)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            PHONG pHONG = Context.PHONG.FirstOrDefault(p => p.MAPHONG == Map);
            return pHONG;
        }
        public List<PHONG> GetPhongall()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            List<PHONG> pHONG = Context.PHONG.SqlQuery("select * from PHONG").ToList<PHONG>();
            return pHONG;
        }
        public  bool ThemPhong(string Ten, int idloai, int idkieu)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();

            PHONG dv = new PHONG();
            dv.TENPHONG = Ten;
            dv.IDLOAIPHONG = idloai;
            dv.IDKIEUPHONG = idkieu;
           // dv.DONDEP = dondep;
            if (dv != null)
            {
                context.PHONG.Add(dv);
                context.SaveChanges();
                return true;
            }
            return false;
            
        }
        public  bool SuaPhong(int id, string Ten, int idloai, int idkieu)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();

            PHONG dv = context.PHONG.Where(p => p.MAPHONG == id).FirstOrDefault();
            if (dv != null)
            {
                dv.TENPHONG = Ten;
                dv.IDLOAIPHONG = idloai;
                dv.IDKIEUPHONG = idkieu;
               // dv.DONDEP = dondep;
                context.SaveChanges();
                return true;
            }
            return false;

            
        }
        public  void XoaPhong(int Id)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();

            PHONG data = context.PHONG.Where(p => p.MAPHONG == Id).FirstOrDefault();
            if (data != null)
            {
                context.PHONG.Remove(data);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tồn tại trong CSDL");
            }
        }
    }
}
