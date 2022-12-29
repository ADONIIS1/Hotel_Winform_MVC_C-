using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class VatTuDAO
    {
        private static VatTuDAO instance;

        internal static VatTuDAO Instance
        {
            get { if (instance == null) instance = new VatTuDAO(); return VatTuDAO.instance; }
            private set { VatTuDAO.instance = value; }
        }
        private VatTuDAO() { }
        public  List<VATTU> GetAllVatTu()
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.VATTU.ToList();
        }
        public  VATTU GetVatTutheoMaVT(int MaVT)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.VATTU.Where(p => p.IDVATTU == MaVT).FirstOrDefault();
        }
        public VATTU GetVatTutheoMtenVT(string tenVT)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.VATTU.Where(p => p.TENVATTU == tenVT).FirstOrDefault();
        }
        public  bool ThemVatTu(string TenVT, string XuatXu)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            VATTU vt = new VATTU();
            vt.TENVATTU = TenVT;
            vt.XUATXU = XuatXu;
            if(vt != null)
            {
                context.VATTU.Add(vt);
                context.SaveChanges();
                return true;
            }
            return false;
           
        }
        public  bool SuaVatTu(int id, string TenVT, string XuatXu)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            VATTU vt = context.VATTU.Where(p => p.IDVATTU == id).FirstOrDefault();
            if (vt != null)
            {
                vt.TENVATTU = TenVT;
                vt.XUATXU = XuatXu;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public  void XoaVatTu(int Id)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            VATTU vt = context.VATTU.Where(p => p.IDVATTU == Id).FirstOrDefault();
            if (vt != null)
            {
                context.VATTU.Remove(vt);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tồn tại trong CSDL");
            }
        }
    }
}
