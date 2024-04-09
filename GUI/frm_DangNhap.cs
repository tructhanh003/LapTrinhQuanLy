using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DTO;
using BUS;
using System.Security.Cryptography;
namespace GUI
{
    public partial class frm_DangNhap : KryptonForm
    {
        QLBHDataContext db = new QLBHDataContext();
        string user;
        string pass;       
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void txtHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool chk_DL()
        {
            if(String.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Tên tài khoản không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return false;
            }
            return true;
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
        public void layDL()
        {
            if(chk_DL())
            {
                MD5 md5Hash = MD5.Create();
                user = txtUser.Text;
                pass = GetMd5Hash(md5Hash, txtPass.Text);
            }
        }
        private void btnDN_Click(object sender, EventArgs e)
        {
            layDL();            
            var query = (from nv in db.nhanviens
                         where nv.tentk == user
                         select nv
                         ).First();              
            if (query.matkhau==pass)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (query.macv==0)
                {
                    this.Hide();
                    frm_MainQL f = new frm_MainQL(query.hoten, "Quản lý", query.manv);
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.Hide();
                    frm_Main f = new frm_Main(query.hoten, "Nhân viên", query.manv);
                    f.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDK_Click(object sender, EventArgs e)
        {           
            frm_DangKy f = new frm_DangKy();
            f.ShowDialog();            
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            
        }
    }
}
