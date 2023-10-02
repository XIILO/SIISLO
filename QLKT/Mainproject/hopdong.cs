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
                if (int.TryParse(mahopdong.Text, out int mhd) && float.TryParse(cccd.Text, out float cccdnt) &&
                float.TryParse(sodienthoai.Text, out float sdt) && int.TryParse(sophonghd.Text, out int sp) &&
                decimal.TryParse(tiencoc.Text, out decimal tc) && DateTime.TryParse(ngaybatdau.Text, out DateTime nbd)
                && DateTime.TryParse(ngayketthuc.Text, out DateTime nkt))
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
                    string tenproc = "themhopdongthue";
                    csdl.proc(tenproc, parameters);
                    MessageBox.Show(" Thêm thành công ", "Thông báo");
                }
                else
                {
                    MessageBox.Show(" Thêm không thành công do thiếu thông tin, thông tin không đúng với kiểu dữ liệu,  hoặc trùng mã hợp đồng ", "Thông báo");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(mahopdong.Text, out int mhd) && float.TryParse(cccd.Text, out float cccdnt) &&
                float.TryParse(sodienthoai.Text, out float sdt) && int.TryParse(sophonghd.Text, out int sp) &&
                decimal.TryParse(tiencoc.Text, out decimal tc) && DateTime.TryParse(ngaybatdau.Text, out DateTime nbd)
                && DateTime.TryParse(ngayketthuc.Text, out DateTime nkt))
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
                    string tenproc = "themhopdongthue";
                    csdl.proc(tenproc, parameters);
                    MessageBox.Show(" cập thành công ", "Thông báo");
                }
                else
                {
                    MessageBox.Show(" Cập nhật không thành công do thiếu thông tin, thông tin không đúng với kiểu dữ liệu ", "Thông báo");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi hệ thống");
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
    }
}
