using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainproject
{
    public partial class phongtro : Form
    {
        public phongtro()
        {
            InitializeComponent();
        }

        cosodulieu csdl = new cosodulieu(); 
        private void themphong_Click(object sender, EventArgs e)
        {
            if (int.TryParse(sophong.Text, out int sp) && decimal.TryParse(dientich.Text, out decimal dt) &&
                decimal.TryParse(giathue.Text, out decimal gt) && decimal.TryParse(tiendien.Text, out decimal td) &&
                decimal.TryParse(tiennuoc.Text, out decimal tn) && decimal.TryParse(tienmang.Text, out decimal tm))
            {
                string tenproc = "themphongtro";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@sophong", sp),
                    new SqlParameter("@dientich", dt),
                    new SqlParameter("@giathue", gt),
                    new SqlParameter("@tiendien", td),
                    new SqlParameter("@tiennuoc", tn),
                    new SqlParameter("@tienmang", tm),
                    new SqlParameter("@trangthaiphong", trangthaiphong.Text),
                };
                csdl.proc(tenproc, parameters);

                MessageBox.Show("Thêm thành công", "Thông báo");

            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ các thông tin ", "Thông báo");
            }
        }

        private void suaphong_Click(object sender, EventArgs e)
        {
            if (int.TryParse(sophong.Text, out int sp) && decimal.TryParse(dientich.Text, out decimal dt) &&
                decimal.TryParse(giathue.Text, out decimal gt) && decimal.TryParse(tiendien.Text, out decimal td) &&
                decimal.TryParse(tiennuoc.Text, out decimal tn) && decimal.TryParse(tienmang.Text, out decimal tm))
            {
                string tenproc = "capnhatphongtro";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@sophong", sp),
                    new SqlParameter("@dientich", dt),
                    new SqlParameter("@giathue", gt),
                    new SqlParameter("@tiendien", td),
                    new SqlParameter("@tiennuoc", tn),
                    new SqlParameter("@tienmang", tm),
                    new SqlParameter("@trangthaiphong", trangthaiphong.Text),
                };
                csdl.proc(tenproc, parameters);

                MessageBox.Show("Sửa thành công", "Thông báo");
                
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ các thông tin ", "Thông báo");
            }
        }

        private void xoaphong_Click(object sender, EventArgs e)
        {
            string tenproc = "xoaphongtro";
            if (int.TryParse(sophong.Text, out int sp))
            {
                SqlParameter[] parameter = { new SqlParameter("@sophong", sp), };
                csdl.proc(tenproc, parameter);
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Hãy nhập số phòng để thao tác xóa", "Thông báo");
            }

        }

        public void FillData(int sp, decimal dt, decimal gt, decimal td, decimal tn, decimal tm, string ttp)
        {
            sophong.Text = sp.ToString();
            dientich.Text = dt.ToString();
            giathue.Text = gt.ToString();
            tiendien.Text = td.ToString();
            tiennuoc.Text = tn.ToString();
            tienmang.Text = tm.ToString();
            trangthaiphong.Text = ttp.ToString();
        }

        private void phongtro_Load(object sender, EventArgs e)
        {

        }
    }
}
