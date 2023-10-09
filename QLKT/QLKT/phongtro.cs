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
            int sp = default(int);
            decimal dt = default(decimal);
            decimal gt = default(decimal);
            decimal td = default(decimal);
            decimal tn = default(decimal);
            decimal tm = default(decimal);

            if (int.TryParse(texsophong.Text, out sp) && decimal.TryParse(texdientich.Text, out  dt) &&
            decimal.TryParse(texgiathue.Text, out gt) && decimal.TryParse(textiendien.Text, out td) &&
            decimal.TryParse(textiennuoc.Text, out tn) && decimal.TryParse(textienmang.Text, out tm))
            {
                SqlParameter[] parameter = { new SqlParameter("@sophong", sp) };
                string procchecker = "PTKhongThemKhiTrung";
                if (dtb.checker(procchecker, parameter))
                {

                    MessageBox.Show("Phòng này đã tồn tại", "Báo lỗi");
                    return;
                }
                else
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

                    string procname = "PTThem";
                    dtb.Proc(procname, parameters);
                    string tablename = "HienThiThongTinTongQuat";
                    load(tablename);
                    MessageBox.Show("Thành công", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập vào không phù hợp", "Báo Lỗi");
            }
           
            

        }


        // Sửa
        private void butalter_Click(object sender, EventArgs e)
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
                SqlParameter[] parameter = { new SqlParameter("@sophong", sp) };
                string checker = "PTKhongSuaKhiKhongtontai";
                if (dtb.checker(checker, parameter) == false)
                {
                    MessageBox.Show("Phòng không tồn tại ", "Báo lỗi");
                    return;
                }
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

                string procname = "PTSua";
                dtb.Proc(procname, parameters);
                string tablename = "HienThiThongTinTongQuat";
                load(tablename);
                MessageBox.Show("Thành công", "Thông báo");
                
            }
            else
            {
                MessageBox.Show("Không thành công", "Báo lỗi ");
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
                SqlParameter[] parameter ={ new SqlParameter("@sophong", sp),};
                string checker = "PTKhongXoaKhiKhongTonTai";
                if (dtb.checker(checker, parameter) == false)
                {
                    MessageBox.Show("Không thể xóa khi không tồn tại phòng   "+texsophong.Text+"", "Báo lỗi");
                    return;
                }
                string checker2 = "PTKhongXoaKhiDangCoNguoiThue";
                SqlParameter[] parameter2 = { new SqlParameter("@sophong", sp),};
                if(dtb.checker(checker2, parameter2))
                {
                    MessageBox.Show("Phòng "+texsophong.Text+" Đang có người thuê ", "Báo lỗi");
                    return;
                }
                else
                {
                    SqlParameter[] parameters = { new SqlParameter("@sophong", sp), };
                    string procname = "PTXoa";
                    dtb.Proc(procname, parameters);
                    string tablename = "HienThiThongTinTongQuat";
                    load(tablename);
                    MessageBox.Show("Thành công", "Thông báo");
                    
                }
                
            }
        }

        //ClickLoad
        private void datagridviewphongtro_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch { }
        }






        // Load Hợp Đồng
        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hopdong hd = new hopdong();
            hd.Show();
            this.Close();
        }
        // Load Hóa đơn
        private void HóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hoadon hd = new hoadon();
            hd.Show();
            this.Close();
        }











        // Hiển thị đã cho thuê
        private void đãChoThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "PTHienThiThongTinPhongDaChoThue";
            load(tablename);
        }
        // Hiển thị chưa cho thuê
        private void chưaChoThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "PTHienThiThongTinPhongChuaChoThue";
            load(tablename);
        } 

        // Hiển thị tổng quát
        private void tổngQuátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinTongQuat";
            load(tablename);
        }
        // Hiển thị thông tin phòng
        private void thôngTinPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "PTHienThiThongTinPhong";
            load(tablename);
        }

        private void buttimkiem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(timkiem.Text))
            {
                MessageBox.Show("Nhập thông tin cần tìm", "Thông báo");
                return;
            }
            
        }
    }
}
