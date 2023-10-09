using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKT
{
    public partial class phongtro : Form
    {
        database dtb = new database();
        public phongtro()
        {
            InitializeComponent();
        }
        // Loadform
        private void phongtro_Load(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinTongQuat";
            load(tablename);
        }

        private void butreload_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinTongQuat";
            load(tablename);
        }

        // Load
        public void load(string tablename)
        {
            datagridviewphongtro.DataSource = dtb.Proc(tablename, null);
        }


        // Thêm
        private void butadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(texsophong.Text) ||
                    string.IsNullOrEmpty(texdientich.Text) ||
                    string.IsNullOrEmpty(texgiathue.Text) ||
                    string.IsNullOrEmpty(textiendien.Text) ||
                    string.IsNullOrEmpty(textiennuoc.Text) ||
                    string.IsNullOrEmpty(textienmang.Text) ||
                    string.IsNullOrEmpty(textrangthai.Text))
                {
                    MessageBox.Show("Dữ liệu trống", "Báo lỗi");
                    return;
                }

                if (int.TryParse(texsophong.Text, out int sp) && decimal.TryParse(texdientich.Text, out decimal dt) &&
                decimal.TryParse(texgiathue.Text, out decimal gt) && decimal.TryParse(textiendien.Text, out decimal td) &&
                decimal.TryParse(textiennuoc.Text, out decimal tn) && decimal.TryParse(textienmang.Text, out decimal tm))
                {   
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@sophong", sp),
                        new SqlParameter("@dientich", dt),
                        new SqlParameter("@giathue", gt),
                        new SqlParameter("@tiendien", td),
                        new SqlParameter("@tiennuoc", tn),
                        new SqlParameter("@tienmang", tm),
                        new SqlParameter("@trangthaiphong", textrangthai.Text),
                    };

                    SqlParameter[] parameter = { new SqlParameter("@sophong", sp) };
                    
                    string procchecker = "CheckPhongTroExists";
                    dtb.CheckDataExists(procchecker, parameter);


                    string procname = "ThemPhongTro";
                    dtb.Proc(procname, parameters);
                    string tablename = "HienThiThongTinTongQuat";
                    load(tablename);
                    MessageBox.Show("Thành công", "Thông báo");
                }             
            }
            catch
            {
                MessageBox.Show("Phòng này đã tồn tại", "Báo lỗi");
            }
        }


        // Sửa
        private void butalter_Click(object sender, EventArgs e)
        {
            int sp;
            decimal dt, gt, td, tn, tm;

            try
            {
                if(string.IsNullOrEmpty(texsophong.Text))
                {
                    MessageBox.Show("Hãy nhập số phòng để chỉnh sửa", "Báo lỗi");
                    return;
                }
                
                if (int.TryParse(texsophong.Text, out sp) && decimal.TryParse(texdientich.Text, out dt) &&
                decimal.TryParse(texgiathue.Text, out gt) && decimal.TryParse(textiendien.Text, out td) &&
                decimal.TryParse(textiennuoc.Text, out tn) && decimal.TryParse(textienmang.Text, out tm))
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@sophong", sp),
                        new SqlParameter("@dientich", dt),
                        new SqlParameter("@giathue", gt),
                        new SqlParameter("@tiendien",td),
                        new SqlParameter("@tiennuoc", tn),
                        new SqlParameter("@tienmang", tm),
                        new SqlParameter("@trangthaiphong", textrangthai.Text),
                    };
  
                    string procname = "SuaPhongTro";
                    dtb.Proc(procname, parameters);
                    string tablename = "HienThiThongTinTongQuat";
                    load(tablename);
                    MessageBox.Show("Thành công", "Thông báo");

                }
            }
            catch
            {
                MessageBox.Show("Không thành công.", "Báo lỗi");
            }
            
            
        }


        //Xóa
        private void butdelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(texsophong.Text))
            {
                MessageBox.Show("Hãy nhập số phòng để xóa");
                return;
            }
            int sp;
            if (int.TryParse(texsophong.Text, out sp) )

            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@sophong", sp),
    
                };
                string procname = "XoaPhongTro";
                dtb.Proc(procname, parameters);
                string tablename = "HienThiThongTinTongQuat";
                load(tablename);
                MessageBox.Show("Thành công", "Thông báo");
            }
        }

        //ClickLoad
        private void datagridviewphongtro_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = datagridviewphongtro.Rows[e.RowIndex];
                texsophong.Text = row.Cells["sophong"].Value.ToString();
                texdientich.Text = row.Cells["dientich"].Value.ToString();
                texgiathue.Text = row.Cells["giathue"].Value.ToString();
                textiendien.Text = row.Cells["tiendien"].Value.ToString();
                textiennuoc.Text = row.Cells["tiennuoc"].Value.ToString();
                textienmang.Text = row.Cells["tienmang"].Value.ToString();
                textrangthai.Text = row.Cells["trangthaiphong"].Value.ToString();
            }
        }
        // Load Hợp Đồng
        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hopdong hd = new hopdong();
            hd.Show();
            this.Hide();
        }

        // Hiển thị đã cho thuê
        private void đãChoThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "PhongDaThue";
            load(tablename);
        }
        // Hiển thị chưa cho thuê
        private void chưaChoThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "PhongChuaThue";
            load(tablename);
        }
        // Hiển thị Phòng

        private void thôngTinPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinPhongThue";
            load(tablename);
        }

        private void HopDongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinHopDong";
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

        private void ngườiĐangThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeNguoiDangThue tk = new ThongKeNguoiDangThue();
            tk.Show();
            this.Hide();
        }
    }
}
