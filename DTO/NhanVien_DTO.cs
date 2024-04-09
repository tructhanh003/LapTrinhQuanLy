using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        private string sMaNV;
        private string sTenTK;
        private string sMatKhau;
        private string sHoTen;
        private string sPhai;
        private string sNgaySinh;
        private string sCccd;
        private string sSoDT;
        private int sMaCV;
        private byte[] sAnh;

        public NhanVien_DTO(string sMaNV, string sTenTK, string sMatKhau, string sHoTen, string sPhai, string sNgaySinh, string sCccd, string sSoDT, int sMaCV, byte[] sAnh)
        {
            this.SMaNV = sMaNV;
            this.STenTK = sTenTK;
            this.SMatKhau = sMatKhau;
            this.SHoTen = sHoTen;
            this.SPhai = sPhai;
            this.SNgaySinh = sNgaySinh;
            this.SCccd = sCccd;
            this.SSoDT = sSoDT;
            this.SMaCV = sMaCV;
            this.SAnh = sAnh;
        }
        public NhanVien_DTO()
        {
            
        }
        public string SMaNV { get => sMaNV; set => sMaNV = value; }
        public string STenTK { get => sTenTK; set => sTenTK = value; }
        public string SMatKhau { get => sMatKhau; set => sMatKhau = value; }
        public string SHoTen { get => sHoTen; set => sHoTen = value; }
        public string SPhai { get => sPhai; set => sPhai = value; }
        public string SNgaySinh { get => sNgaySinh; set => sNgaySinh = value; }
        public string SCccd { get => sCccd; set => sCccd = value; }
        public string SSoDT { get => sSoDT; set => sSoDT = value; }
        public int SMaCV { get => sMaCV; set => sMaCV = value; }
        public byte[] SAnh { get => sAnh; set => sAnh = value; }
    }
}
