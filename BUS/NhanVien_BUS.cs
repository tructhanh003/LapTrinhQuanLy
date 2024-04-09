using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class NhanVien_BUS
    {
        public static void InsertNV_BUS(NhanVien_DTO nv, string txt)
        {
            MD5 md5Hash = MD5.Create();
            string matkhauMH = NhanVien_BUS.GetMd5Hash(md5Hash, nv.SMatKhau);
            nv.SMatKhau = matkhauMH;
            NhanVien_DAO.InsertNV(nv, txt);
        }
        public static NhanVien_DTO TimNhanVienTheoMa_BUS(string ma)
        {
            return NhanVien_DAO.TimNhanVienTheoMa(ma);
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static NhanVien_DTO TimNhanVienTheoTK_BUS(string user, string pass)
        {
            MD5 md5Hash = MD5.Create();
            string matkhauMH = NhanVien_BUS.GetMd5Hash(md5Hash, pass);
            return NhanVien_DAO.TimNhanVienTheoTK(user, matkhauMH);
        }
    }
}
