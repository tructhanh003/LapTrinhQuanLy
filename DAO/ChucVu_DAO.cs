using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class ChucVu_DAO
    {
        static SqlConnection conn;
        public static List<ChucVu_DTO> LayChucVu()
        {
            string sTruyVan = "select * from chucvu";
            conn = DataProvider.TaoKetNoi();
            List<ChucVu_DTO> lstChucVu = new List<ChucVu_DTO>();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, conn);
            if (dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChucVu_DTO cv = new ChucVu_DTO();
                cv.SMaCV = int.Parse(dt.Rows[i]["macv"].ToString());
                cv.STenCV = dt.Rows[i]["tencv"].ToString();                
                lstChucVu.Add(cv);
            }
            return lstChucVu;
        }
    }
}
