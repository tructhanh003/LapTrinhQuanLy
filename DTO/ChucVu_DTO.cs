using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucVu_DTO
    {
        private int sMaCV;
        private string sTenCV;

        public ChucVu_DTO(int sMaCV, string sTenCV)
        {
            this.SMaCV = sMaCV;
            this.STenCV = sTenCV;
        }
        public ChucVu_DTO()
        {
            
        }
        public int SMaCV { get => sMaCV; set => sMaCV = value; }
        public string STenCV { get => sTenCV; set => sTenCV = value; }
    }
}
