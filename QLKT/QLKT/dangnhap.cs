using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKT
{
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }
        string tk = "1";
        string mk = "1";
        private void butdangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (taikhoan.Text == tk && matkhau.Text == mk)
                {
                    phongtro pt = new phongtro();  
                    pt.Show();
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công", "Báo Lỗi");
                    this.Focus();
                }
            }
            catch
            {

            }
        }

        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
