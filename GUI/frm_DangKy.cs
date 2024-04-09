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
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Drawing.Imaging;
namespace GUI
{
    public partial class frm_DangKy : KryptonForm
    {
        nhanvien nv;
        QLBHDataContext db = new QLBHDataContext();
        public frm_DangKy()
        {
            InitializeComponent();
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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)|*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string f = openFileDialog.FileName;
                Image img = Image.FromFile(f);
                picAnh.Image = img;
            }    
        }     
        private byte[] ImageToByteArray(PictureBox p)
        {
            MemoryStream memoryStream = new MemoryStream();
            p.Image.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }
        private void LayDL()
        {
            MD5 md5Hash = MD5.Create();
            nv = new nhanvien();
            nv.manv = txtMaNV.Text;
            nv.tentk = txtUser.Text;
            nv.matkhau = GetMd5Hash(md5Hash, txtPass.Text);
            nv.hoten = txtHoTen.Text;
            nv.phai = radNam.Checked ? "Nam" : "Nữ";
            nv.ngaysinh = dtpNgaySinh.Value;
            nv.cccd = txtCCCD.Text;
            nv.sodt = txtDT.Text;
            nv.macv = cboCV.Text.Equals("Quản lý")?0:1;
            nv.anh = ImageToByteArray(picAnh);
        }
        private void btnDK_Click(object sender, EventArgs e)
        {
            try
            {                             
                LayDL();
                db.nhanviens.InsertOnSubmit(nv);
                db.SubmitChanges();
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void frm_DangKy_Load(object sender, EventArgs e)
        {
            var query1 = from chucvu in db.chucvus
                         select chucvu.tencv;
            cboCV.DataSource = query1;
        }

        private void txtReset_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtUser.Focus();
            txtPass.Text = "";
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtCCCD.Text = "";
            txtDT.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
        }
    }
}
