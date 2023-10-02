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
    public partial class hopdong : Form
    {
        public hopdong()
        {
            InitializeComponent();
        }

        cosodulieu csdl = new cosodulieu();
        private void themhopdong_Click(object sender, EventArgs e)
        {
            try
            {
                int mhd = default;
                float cccdnt = default;
                string hvt = default;
                float sdt = default;
                int sp = default;
                decimal tc = default;
                DateTime nbd = default;
                DateTime nkt = default;

                if (int.TryParse(mahopdong.Text, out mhd) && float.TryParse(cccd.Text, out cccdnt)
                    && float.TryParse(sodienthoai.Text, out sdt) && int.TryParse(sophonghd.Text, out sp)
                    && decimal.TryParse(tiencoc.Text, out tc) && DateTime.TryParse(ngaybatdau.Text, out nbd)
                    && DateTime.TryParse(ngayketthuc.Text, out nkt))
                {
                    SqlParameter[] parameters =
                    {
                    new SqlParameter("@mahopdong", mhd),
                    new SqlParameter("@cancuoccongdannguoithue", cccdnt),
                    new SqlParameter("@hovatennguoithue", hovaten.Text),
                    new SqlParameter("@sodienthoainguoithue", sdt),
                    new SqlParameter("@sophong", sp),
                    new SqlParameter("@sotiencoc", tc),
                    new SqlParameter("@ngaybatdau", nbd),
                    new SqlParameter("@ngayketthuc", nkt),
                };
                    string tenproc = "themhopdong"; // Tên stored procedure bạn đã tạo
                    csdl.proc(tenproc, parameters);
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Thêm không thành công", "Thông báo");
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
       
            int mhd = default;
            float cccdnt = default;
            string hvt = default;
            float sdt = default;
            int sp = default;
            decimal tc = default;
            DateTime nbd = default;
            DateTime nkt = default;

            if(int.TryParse(mahopdong.Text, out mhd) && float.TryParse(cccd.Text, out cccdnt) 
                && float.TryParse(sodienthoai.Text, out sdt) && int.TryParse(sophonghd.Text, out sp)
                && decimal.TryParse(tiencoc.Text, out tc) && DateTime.TryParse(ngaybatdau.Text, out nbd)
                && DateTime.TryParse(ngayketthuc.Text, out nkt))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@mahopdong", mhd),
                    new SqlParameter("@cancuoccongdannguoithue", cccdnt),
                    new SqlParameter("@hovatennguoithue", hovaten.Text),
                    new SqlParameter("@sodienthoainguoithue", sdt),
                    new SqlParameter("@sophong", sp),
                    new SqlParameter("@sotiencoc", tc),
                    new SqlParameter("@ngaybatdau", nbd),
                    new SqlParameter("@ngayketthuc", nkt),
                };
                string tenproc = "capnhat_hopdong"; // Tên stored procedure bạn đã tạo
                csdl.proc(tenproc, parameters);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }

        }



        private void xoahopdong_Click(object sender, EventArgs e)
        {
            string procname = "xoahopdong";
            if (int.TryParse(mahopdong.Text, out int mhd))
            {
                SqlParameter[] parameter ={ new SqlParameter("@mahopdong", mhd),};
                csdl.proc(procname, parameter);
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa không thành công, hãy nhập mã hợp đồng muốn xóa");
            }
        }



        private void hopdong_Load(object sender, EventArgs e)
        {

        }

        public void FillData(int mhd, float cccdnt, string hvt, float sdt, int sp, decimal tc, DateTime nbd, DateTime nkt)
        {
            mahopdong.Text = mhd.ToString();
            cccd.Text = cccd.ToString();
            hovaten.Text = hvt.ToString();  
            sodienthoai.Text = sdt.ToString();
            tiencoc.Text = tc.ToString();
            sophonghd.Text = sdt.ToString();    
            ngaybatdau.Text = nbd.ToString();
            ngayketthuc.Text = nkt.ToString();
        }

    }
}
