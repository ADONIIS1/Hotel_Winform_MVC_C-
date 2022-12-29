using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        internal static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set { NhanVienDAO.instance = value; }
        }
        private NhanVienDAO() { }

        public List<NHANVIEN> GetallListNhanVien()
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            return Context.NHANVIEN.ToList();
        }
        public NHANVIEN GetnhanVientheoMaNV(int maNV)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            NHANVIEN dv = Context.NHANVIEN.Where(p => p.MANV == maNV).FirstOrDefault();
            return dv;
        }
        public bool AddNhanVien(string TenNV, string DiaChi, string CMND, DateTime NgaySinh, double Luong, Byte[] Anh)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();

            NHANVIEN NV = new NHANVIEN();
            NV.TENNV = TenNV;
            NV.LUONG = Luong;
            NV.ANHDAIDIEN = Anh;
            NV.DIACHI = DiaChi;
            NV.CMND = CMND;
            NV.NGAYSINH = NgaySinh;
            if (NV != null)
            {
                Context.NHANVIEN.Add(NV);
                Context.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public bool SuaNhanVien(int maNV, string TenNV, string DiaChi, string CMND, DateTime NgaySinh, double Luong, Byte[] Anh)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            NHANVIEN dv = context.NHANVIEN.Where(p => p.MANV == maNV).FirstOrDefault();
            if (dv != null)
            {
                dv.TENNV = TenNV;
                dv.LUONG = Luong;
                dv.ANHDAIDIEN = Anh;
                dv.DIACHI = DiaChi;
                dv.CMND = CMND;
                dv.NGAYSINH = NgaySinh;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool SuaAnhNV(int maNV, Byte[] Anh)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();
            NHANVIEN dv = context.NHANVIEN.Where(p => p.MANV == maNV).FirstOrDefault();
            if (dv != null)
            {
              
                dv.ANHDAIDIEN = Anh;
              
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool XoaNhanVien(int MaNV)
        {
            QuanLyKhachSan context = new QuanLyKhachSan();

            NHANVIEN data = context.NHANVIEN.Where(p => p.MANV == MaNV).FirstOrDefault();
            if (data != null)
            {
                context.NHANVIEN.Remove(data);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
