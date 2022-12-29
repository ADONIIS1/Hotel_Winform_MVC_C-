using QLSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSK.DAO
{
    public class CTSDDVDAO
    {
        private static CTSDDVDAO instance;

        internal static CTSDDVDAO Instance
        {
            get { if (instance == null) instance = new CTSDDVDAO(); return CTSDDVDAO.instance; }
            private set { CTSDDVDAO.instance = value; }
        }
        private CTSDDVDAO() { }
        public List<CHITIETSDDICHVU> GetListDV(int sophieusddv)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            List<CHITIETSDDICHVU> cs = Context.CHITIETSDDICHVU.Where(p => p.SOPHIEUSDDV == sophieusddv).ToList<CHITIETSDDICHVU>();
            return cs;
        }
        public bool AddCTPhieuSDDV(int iddichvu, int SoLuong, int sophieusd)
        {
            QuanLyKhachSan Context = new QuanLyKhachSan();
            
            

            CHITIETSDDICHVU cHITIETSDDICHVU = Context.CHITIETSDDICHVU.FirstOrDefault(p => p.IDDICHVU == iddichvu && p.SOPHIEUSDDV == sophieusd);
            if(cHITIETSDDICHVU != null)
            {
                int SL = cHITIETSDDICHVU.SOLUONG + SoLuong;
                if (SL > 0)
                {
                    cHITIETSDDICHVU.SOLUONG = SL;

                }
                else
                {
                    Context.CHITIETSDDICHVU.Remove(cHITIETSDDICHVU);
                }
            }
            else

            {
                cHITIETSDDICHVU = new CHITIETSDDICHVU();
                cHITIETSDDICHVU.SOPHIEUSDDV = sophieusd;
                cHITIETSDDICHVU.IDDICHVU = iddichvu;
                cHITIETSDDICHVU.SOLUONG = SoLuong;
                
                Context.CHITIETSDDICHVU.Add(cHITIETSDDICHVU);
            }
                Context.SaveChanges();
                return true;
        }
    }
}
