using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        internal static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set { HoaDonDAO.instance = value; }
        }

        private HoaDonDAO() { }

        public static List<HOADON> GetListHoaDon()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.HOADON.ToList();
        }

        public List<HOADON> GetHoaDon()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.HOADON.ToList();
        }

        public HOADON getHoaDonTheoID(int ID)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            return context.HOADON.Where(p => p.IDHOADON == ID).FirstOrDefault();
        }


        public bool AddHoaDon( double TongTien, int soPhieudatP,int SoPhieuDV,int MAP,int MANV )
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            HOADON hOADON = Context.HOADON.FirstOrDefault(p => p.SOPHIEUDATPHONG.ToString().Equals(soPhieudatP.ToString()) && p.MAPHONG.ToString().Equals(MAP.ToString()));
            if (hOADON == null)
            {
                hOADON = new HOADON();
                hOADON.MANV = MANV;
                hOADON.SOPHIEUDATPHONG = soPhieudatP;
                hOADON.TONGTIEN = TongTien;
                hOADON.MAPHONG = MAP;
                hOADON.SOPHIEUSDDV = SoPhieuDV;
                hOADON.TINHTRANG = 1;
                hOADON.NGAYLAP = DateTime.Now;
                Context.HOADON.Add(hOADON);
                Context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public HOADON GetIDHoaDon(int MaP,int soPhieuDat,int sophieudv)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
           
            HOADON HD = Context.HOADON.FirstOrDefault(p => p.MAPHONG.ToString().Equals(MaP.ToString())&& p.SOPHIEUDATPHONG.ToString().Equals(soPhieuDat.ToString()) && p.SOPHIEUSDDV.ToString().Equals(sophieudv.ToString()));
            return HD;
        }
        public bool updateTongTien(double TongTien, int soPhieudatP, int SoPhieuDV, int MAP)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            HOADON hOADON = Context.HOADON.FirstOrDefault(p => p.SOPHIEUDATPHONG.ToString().Equals(soPhieudatP.ToString()) && p.MAPHONG.ToString().Equals(MAP.ToString() ) && p.SOPHIEUSDDV.ToString().Equals(SoPhieuDV.ToString()));
            if (hOADON != null)
            {
               
                hOADON.TONGTIEN = TongTien;
                
                
                Context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
