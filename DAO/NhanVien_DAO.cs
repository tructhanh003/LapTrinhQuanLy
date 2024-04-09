using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class NhanVien_DAO
    {
        static SqlConnection conn;
        public static int chuyenMaCV(string tenCV)
        {
            int maCV = 0;
            string sTruyVan = "select * from chucvu";
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["tencv"].ToString() == tenCV)
                {
                    maCV = int.Parse(dt.Rows[i]["macv"].ToString());
                    break;
                }
            }
            return maCV;
        }
        public static void InsertNV(NhanVien_DTO nv, string txt)
        {
             nv.SMaCV = chuyenMaCV(txt);
             conn = DataProvider.TaoKetNoi();
             conn.Open();
             string query = string.Format("INSERT nhanvien (manv, tentk, matkhau, hoten, phai, ngaysinh, cccd, sodt, macv, anh) VALUES  ( '{0}', N'{1}', N'{2}', N'{3}', N'{4}', '{5}', '{6}', '{7}', {8}, '{9}')", nv.SMaNV, nv.STenTK, nv.SMatKhau, nv.SHoTen, nv.SPhai, nv.SNgaySinh, nv.SCccd, nv.SSoDT, nv.SMaCV, nv.SAnh);
             SqlCommand cmd = new SqlCommand(query, conn);             
             cmd.ExecuteNonQuery();
             conn.Close();                            
        }
        public static NhanVien_DTO TimNhanVienTheoMa(string ma)
        {
            string queryStr = string.Format(@"select * from nhanvien where manv=N'{0}'", ma);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.SMaNV = dt.Rows[0]["manv"].ToString();
            nv.STenTK = dt.Rows[0]["tentk"].ToString();
            nv.SMatKhau = dt.Rows[0]["matkhau"].ToString();
            nv.SHoTen = dt.Rows[0]["hoten"].ToString();            
            nv.SPhai = dt.Rows[0]["phai"].ToString();
            nv.SNgaySinh = dt.Rows[0]["ngaysinh"].ToString();
            nv.SCccd = dt.Rows[0]["cccd"].ToString();
            nv.SSoDT = dt.Rows[0]["sodt"].ToString();
            nv.SMaCV = int.Parse(dt.Rows[0]["macv"].ToString());
            nv.SAnh = (byte[])dt.Rows[0]["anh"];
            return nv;
        }
        
        public static NhanVien_DTO TimNhanVienTheoUser(string user)
        {
            string queryStr = string.Format(@"select * from nhanvien where tentk=N'{0}'", user);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.SMaNV = dt.Rows[0]["manv"].ToString();
            nv.STenTK = dt.Rows[0]["tentk"].ToString();
            nv.SMatKhau = dt.Rows[0]["matkhau"].ToString();
            nv.SHoTen = dt.Rows[0]["hoten"].ToString();
            nv.SPhai = dt.Rows[0]["phai"].ToString();
            nv.SNgaySinh = dt.Rows[0]["ngaysinh"].ToString();
            nv.SCccd = dt.Rows[0]["cccd"].ToString();
            nv.SSoDT = dt.Rows[0]["sodt"].ToString();
            nv.SMaCV = int.Parse(dt.Rows[0]["macv"].ToString());
            return nv;
        }
        public static NhanVien_DTO TimNhanVienTheoTK(string user, string pass)
        {
            string queryStr = string.Format(@"select * from nhanvien where tentk=N'{0}' and matkhau='{1}'", user, pass);
            conn = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(queryStr, conn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.SMaNV = dt.Rows[0]["manv"].ToString();
            nv.STenTK = dt.Rows[0]["tentk"].ToString();
            nv.SMatKhau = dt.Rows[0]["matkhau"].ToString();
            nv.SHoTen = dt.Rows[0]["hoten"].ToString();
            nv.SPhai = dt.Rows[0]["phai"].ToString();
            nv.SNgaySinh = dt.Rows[0]["ngaysinh"].ToString();
            nv.SCccd = dt.Rows[0]["cccd"].ToString();
            nv.SSoDT = dt.Rows[0]["sodt"].ToString();
            nv.SMaCV = int.Parse(dt.Rows[0]["macv"].ToString());
            return nv;
        }        
    }
}
