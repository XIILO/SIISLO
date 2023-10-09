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

namespace QLKT
{
    public partial class hopdong : Form
    {
        database dtb = new database();
        public hopdong()
        {
            InitializeComponent();
        }

        private void hopdong_Load(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinTongQuat";
            load(tablename);
        }

        public void load(string tablename)
        {
            datagridviewhopdong.DataSource = dtb.Proc(tablename, null);
        }

        private void butthem_Click(object sender, EventArgs e)
        {


            try
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

                if (int.TryParse(mahopdong.Text, out int mhd) && int.TryParse(sophong.Text, out int sp) &&
                decimal.TryParse(sotiencoc.Text, out decimal stc) && DateTime.TryParse(ngaybatdau.Text, out DateTime nbd) &&
                DateTime.TryParse(ngayketthuc.Text, out DateTime nkt))
                {

                    SqlParameter[] checker =
                    {
                        new SqlParameter("@mahopdong", mhd),
                        new SqlParameter("@sophong", sp)

                    };

                    string procchecker = "CheckHopDongMaPhong";
                    dtb.CheckDataExists(procchecker, checker);
                    
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

                    string procname = "ThemHopDongThue";
                    dtb.Proc(procname, parameters);

                    string tablename = "HienThiThongTinTongQuat";
                    load(tablename);

                    MessageBox.Show("Thành công", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Mã hợp đồng hoặc số phòng bị trùng", "Báo lỗi");
            }
            

            
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

        private void ngườiThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinHopDong";
            load(tablename);
        }

        private void butsua_Click(object sender, EventArgs e)
        {
            try
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

                if (int.TryParse(mahopdong.Text, out int mhd) && int.TryParse(sophong.Text, out int sp) &&
                decimal.TryParse(sotiencoc.Text, out decimal stc) && DateTime.TryParse(ngaybatdau.Text, out DateTime nbd) &&
                DateTime.TryParse(ngayketthuc.Text, out DateTime nkt))
                {

                    SqlParameter[] checker =
                    {
                        new SqlParameter("@mahopdong", mhd),
                        new SqlParameter("@sophong", sp)

                    };

                    string procchecker = "CheckHopDongMaPhong";
                    dtb.CheckDataExists(procchecker, checker);

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

                    string procname = "SuaHopDongThue";
                    dtb.Proc(procname, parameters);

                    string tablename = "HienThiThongTinTongQuat";
                    load(tablename);

                    MessageBox.Show("Thành công", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Mã hợp đồng hoặc số phòng bị trùng", "Báo lỗi");
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
                SqlParameter[] parameters =
                {
                    new SqlParameter("@mahopdong", mhd),

                };
                string procname = "XoaHopDongThue";
                dtb.Proc(procname, parameters);

                string tablename = "HienThiThongTinTongQuat";
                load(tablename);
                MessageBox.Show("Thành công", "Thông báo");
            }
        }

        private void datagridviewhopdong_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void thôngTinPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinPhongThue";
            load(tablename);
        }

        private void tổngQuátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinTongQuat";
            load(tablename);
        }

        private void tổngTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongke tk = new Thongke();
            tk.Show();
            this.Hide();
        }

        private void đãChoThuêToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string tablename = "PhongDaThue";
            load(tablename);
        }

        private void chưaChoThuêToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string tablename = "PhongChuaThue";
            load(tablename);
        }

        private void ngườiĐangThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeNguoiDangThue tk = new ThongKeNguoiDangThue();
            tk.Show();
            this.Hide();
        }
    }
}
