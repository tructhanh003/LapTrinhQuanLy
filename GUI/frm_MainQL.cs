using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using BUS;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
namespace GUI
{
    public partial class frm_MainQL : KryptonForm
    {   
        public frm_MainQL(string tennv, string cv, string manv)
        {
            InitializeComponent();
            lblTG.Text = DateTime.Now.ToString();
            lblTenNV.Text = tennv;
            lblCV.Text = cv;
            HienThiAvt(manv);
        }
        public void HienThiAvt(string s)
        {
            QLBHDataContext db = new QLBHDataContext();
            nhanvien query = db.nhanviens.Where(nv => nv.manv==s).FirstOrDefault();
            if (query == null)
                return;
            MemoryStream ms = new MemoryStream(query.anh.ToArray());
            Image img = Image.FromStream(ms);
            if(img == null)
            {
                return;
            }
            picAvt.Image = img;
        }        
        public void chuyenMau_Home()
        {
            btnHome.OverrideDefault.Back.Color1 = Color.FromArgb(141, 169, 249);
            btnHome.OverrideDefault.Back.Color2 = Color.FromArgb(141, 169, 249);
            btnHome.OverrideDefault.Border.Color1 = Color.FromArgb(141, 169, 249);
            btnHome.OverrideDefault.Border.Color2 = Color.FromArgb(141, 169, 249);

            btnSP.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnKH.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnDonHang.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnCaiDat.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnDX.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);
        }
        public void chuyenMau_SP()
        {
            btnSP.OverrideDefault.Back.Color1 = Color.FromArgb(141, 169, 249);
            btnSP.OverrideDefault.Back.Color2 = Color.FromArgb(141, 169, 249);
            btnSP.OverrideDefault.Border.Color1 = Color.FromArgb(141, 169, 249);
            btnSP.OverrideDefault.Border.Color2 = Color.FromArgb(141, 169, 249);

            btnHome.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnDonHang.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnKH.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnCaiDat.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnDX.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);
        }
        public void chuyenMau_DonHang()
        {
            btnDonHang.OverrideDefault.Back.Color1 = Color.FromArgb(141, 169, 249);
            btnDonHang.OverrideDefault.Back.Color2 = Color.FromArgb(141, 169, 249);
            btnDonHang.OverrideDefault.Border.Color1 = Color.FromArgb(141, 169, 249);
            btnDonHang.OverrideDefault.Border.Color2 = Color.FromArgb(141, 169, 249);

            btnHome.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnSP.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnKH.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnKH.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnCaiDat.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnDX.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);
        }
        public void chuyenMau_KH()
        {
            btnKH.OverrideDefault.Back.Color1 = Color.FromArgb(141, 169, 249);
            btnKH.OverrideDefault.Back.Color2 = Color.FromArgb(141, 169, 249);
            btnKH.OverrideDefault.Border.Color1 = Color.FromArgb(141, 169, 249);
            btnKH.OverrideDefault.Border.Color2 = Color.FromArgb(141, 169, 249);

            btnDonHang.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnHome.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnSP.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnCaiDat.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnDX.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);
        }
        public void chuyenMau_CaiDat()
        {
            btnCaiDat.OverrideDefault.Back.Color1 = Color.FromArgb(141, 169, 249);
            btnCaiDat.OverrideDefault.Back.Color2 = Color.FromArgb(141, 169, 249);
            btnCaiDat.OverrideDefault.Border.Color1 = Color.FromArgb(141, 169, 249);
            btnCaiDat.OverrideDefault.Border.Color2 = Color.FromArgb(141, 169, 249);

            btnDonHang.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnHome.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnSP.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnDX.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDX.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);
        }
        public void chuyenMau_DX()
        {
            btnDX.OverrideDefault.Back.Color1 = Color.FromArgb(141, 169, 249);
            btnDX.OverrideDefault.Back.Color2 = Color.FromArgb(141, 169, 249);
            btnDX.OverrideDefault.Border.Color1 = Color.FromArgb(141, 169, 249);
            btnDX.OverrideDefault.Border.Color2 = Color.FromArgb(141, 169, 249);

            btnDonHang.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnDonHang.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnHome.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnHome.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnSP.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnSP.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);

            btnCaiDat.OverrideDefault.Back.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Back.Color2 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color1 = Color.FromArgb(33, 33, 33);
            btnCaiDat.OverrideDefault.Border.Color2 = Color.FromArgb(33, 33, 33);
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DangNhap f = new frm_DangNhap();
            f.ShowDialog();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DangNhap f = new frm_DangNhap();
            f.ShowDialog();
            this.Close();
        }
    }
}
