using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKT
{
    public partial class hopdong : Form
    {
        database dtb = new database();
        public hopdong()
        {
            InitializeComponent();
        }

        private void butthem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(mahopdong.Text) ||
            string.IsNullOrEmpty(cancuocongdan.Text) ||
            string.IsNullOrEmpty(hovaten.Text) ||
            string.IsNullOrEmpty(sodienthoai.Text) ||
            string.IsNullOrEmpty(sophong.Text) ||
            string.IsNullOrEmpty(sotiencoc.Text) ||
            string.IsNullOrEmpty(ngaybatdau.Text) ||
            string.IsNullOrEmpty(ngayketthuc.Text))
            {
                MessageBox.Show("Dữ liệu trống", "Báo lỗi");
                return;
            }

            if (!(int.TryParse(mahopdong.Text, out int mhd) && int.TryParse(sophong.Text, out int sp) &&
            decimal.TryParse(sotiencoc.Text, out decimal stc) && DateTime.TryParse(ngaybatdau.Text, out DateTime nbd) &&
            DateTime.TryParse(ngayketthuc.Text, out DateTime nkt)))
            {
                MessageBox.Show("Dữ liệu nhập vào không phù hợp", "Báo Lỗi");
                return;
            }

            SqlParameter[] checker = { new SqlParameter("@mahopdong", mhd),};
            SqlParameter[] checker2 = { new SqlParameter("@sophong", sp), };
            SqlParameter[] checker3 = { new SqlParameter("@sophong", sp), };

            string procchecker = "HDTKhongthemkhitrungMHD";
            string procchecker2 = "HDTKhongthemkhikhongtontaisp";
            string procchecker3 = "HDTKhongthethemkhiphongdadung";


            if (dtb.checker(procchecker, checker) == true)
            {
                MessageBox.Show("Đã tồn tại mã hợp đồng thuê", "Báo lỗi");
                return;
            }
            if(dtb.checker(procchecker2, checker2) == true )
            {
                MessageBox.Show("Phòng "+sophong.Text+" Không tồn tại", "Báo Lỗi");
                return;
            }
            if (dtb.checker(procchecker3, checker3) == true)
            {
                MessageBox.Show("Phòng " + sophong.Text + " đang được sử dụng ", "Báo Lỗi");
                return;
            }
            else
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@mahopdong", mhd),
                    new SqlParameter("@cancuoccongdannguoithue", cancuocongdan.Text),
                    new SqlParameter("@hovatennguoithue", hovaten.Text),
                    new SqlParameter("@sodienthoainguoithue",sodienthoai.Text),
                    new SqlParameter("@sophong", sp),
                    new SqlParameter("@sotiencoc", stc),
                    new SqlParameter("@ngaybatdau", nbd),
                    new SqlParameter("@ngayketthuc", nkt),
                };

                string procname = "HDTThem";
                dtb.Proc(procname, parameters);

                string tablename = "HienThiThongTinTongQuat";
                load(tablename);

                MessageBox.Show("Thành công", "Thông báo");   
            }

        }


        private void butsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mahopdong.Text) ||
            string.IsNullOrEmpty(cancuocongdan.Text) ||
            string.IsNullOrEmpty(hovaten.Text) ||
            string.IsNullOrEmpty(sodienthoai.Text) ||
            string.IsNullOrEmpty(sophong.Text) ||
            string.IsNullOrEmpty(sotiencoc.Text) ||
            string.IsNullOrEmpty(ngaybatdau.Text) ||
            string.IsNullOrEmpty(ngayketthuc.Text))
            {
                MessageBox.Show("Dữ liệu trống", "Báo lỗi");
                return;
            }

            if (!(int.TryParse(mahopdong.Text, out int mhd) && int.TryParse(sophong.Text, out int sp) &&
            decimal.TryParse(sotiencoc.Text, out decimal stc) && DateTime.TryParse(ngaybatdau.Text, out DateTime nbd) &&
            DateTime.TryParse(ngayketthuc.Text, out DateTime nkt)))
            {
                MessageBox.Show("Dữ liệu nhập vào không phù hợp", "Báo Lỗi");
                return;
            }

            SqlParameter[] checker = { new SqlParameter("@sophong", sp), };
            SqlParameter[] checker2 = { new SqlParameter("@sophong", sp), };
            string procchecker = "HDTKhongsuakhikhongtontaiSP";
            string procchecker2 = "HDTKhongchinhsuakhiphongdangduocthue";
            if (!dtb.checker(procchecker, checker))
            {
                MessageBox.Show("Không tồn tại số phòng "+sophong.Text+"  ", "Báo lỗi");
                return;
            }
            if(!dtb.checker(procchecker2, checker2))
            {

                MessageBox.Show("Phòng " + sophong.Text + " Đang được thuê  ", "Báo lỗi");
                return;
            }
            else
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@mahopdong", mhd),
                    new SqlParameter("@cancuoccongdannguoithue", cancuocongdan.Text),
                    new SqlParameter("@hovatennguoithue", hovaten.Text),
                    new SqlParameter("@sodienthoainguoithue",sodienthoai.Text),
                    new SqlParameter("@sophong", sp),
                    new SqlParameter("@sotiencoc", stc),
                    new SqlParameter("@ngaybatdau", nbd),
                    new SqlParameter("@ngayketthuc", nkt),
                };

                string procname = "HDTSua";
                dtb.Proc(procname, parameters);

                string tablename = "HienThiThongTinTongQuat";
                load(tablename);

                MessageBox.Show("Thành công", "Thông báo");
            }

            
        }

        private void butxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mahopdong.Text))
            {
                MessageBox.Show("Hãy nhập mã hợp đồng để xóa");
                return;
            }

            int mhd;
            if (int.TryParse(mahopdong.Text, out mhd))
            {
                SqlParameter[] parameters ={  new SqlParameter("@mahopdong", mhd),};
                SqlParameter[] parameters2 = { new SqlParameter("@mahopdong", mhd), };
                string checker2 = "HDTKhongxoakhikhongtontaimhd";
                if(!dtb.checker(checker2, parameters2))
                {
                    MessageBox.Show(" Mã hợp đồng không tồn tại", "Báo lỗi");
                    return;
                }
                else
                {
                    string procname = "HDTXoa";
                    dtb.Proc(procname, parameters);

                    string tablename = "HienThiThongTinTongQuat";
                    load(tablename);
                    MessageBox.Show("Thành công", "Thông báo");
                }
                
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập vào không phù hợp", "Báo Lỗi");
                return;
            }
        }

        private void datagridviewhopdong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = datagridviewhopdong.Rows[e.RowIndex];
                    mahopdong.Text = row.Cells["mahopdong"].Value.ToString();
                    cancuocongdan.Text = row.Cells["cancuoccongdannguoithue"].Value.ToString();
                    hovaten.Text = row.Cells["hovatennguoithue"].Value.ToString();
                    sodienthoai.Text = row.Cells["sodienthoainguoithue"].Value.ToString();
                    sophong.Text = row.Cells["sophong"].Value.ToString();
                    sotiencoc.Text = row.Cells["sotiencoc"].Value.ToString();
                    ngaybatdau.Text = row.Cells["ngaybatdau"].Value.ToString();
                    ngayketthuc.Text = row.Cells["ngayketthuc"].Value.ToString();
                }
            }
            catch { }
           

        }




        private void tổngQuátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinTongQuat";
            load(tablename);
        }






        private void butload_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinTongQuat";
            load(tablename);
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongtro pt = new phongtro();
            pt.Show();
            this.Close();
        }

        private void hopdong_Load(object sender, EventArgs e)
        {
            String tablename = "HienThiThongTinTongQuat";
            load(tablename);
        }

        public void load(string tablename)
        {
            datagridviewhopdong.DataSource = dtb.Proc(tablename, null);
        }


        private void thôngTinHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HDTHienThi";
            load(tablename);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string tablename = "HoaDonHT";
            load(tablename);
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hoadon hd = new hoadon();
            hd.Show();
            this.Close();
        }
    }
}
