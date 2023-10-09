using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKT
{
    public partial class hoadon : Form
    {
        
        database dtb = new database();
        // Thêm
        private void butadd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mahoadon.Text) &&
                string.IsNullOrEmpty(thang.Text) && 
                string.IsNullOrEmpty(nam.Text) &&
                string.IsNullOrEmpty(mahopdong.Text) &&
                string.IsNullOrEmpty(sodiencu.Text) &&
                string.IsNullOrEmpty(sodienmoi.Text) &&
                string.IsNullOrEmpty(sonuoccu.Text)&&
                string.IsNullOrEmpty(sonuocmoi.Text))
            {
                MessageBox.Show("Không được để trống thông tin", "Báo lỗi");
                return;
            }
            int t = default(int); 
            int mhd = default(int);
            int n = default(int);
            int mhoad = default(int);
            int sdc = default(int);
            int sdm = default(int);
            int snc = default(int);
            int snm = default(int);

            if (!(int.TryParse(thang.Text, out t) && int.TryParse(nam.Text, out n) &&
                int.TryParse(mahopdong.Text, out  mhd) && int.TryParse(sodiencu.Text, out  sdc) &&
                int.TryParse(sodienmoi.Text, out  sdm) && int.TryParse(sonuoccu.Text, out  snc) &&
                int.TryParse(sonuocmoi.Text, out  snm) && int.TryParse(mahoadon.Text, out  mhoad)))
            {

                MessageBox.Show("Dữ liệu nhập vào không phù hợp", "Báo lỗi");
                return;
            }
            if(t >= 12)
            {
                MessageBox.Show("Làm gì có tháng "+thang.Text+"", "Báo lỗi");
                return;
            }
              
                
            SqlParameter[] parameter = { new SqlParameter("@mahopdong", mhd),};
            SqlParameter[] parameter2 = { new SqlParameter("@mahoadon", mhoad), };

            string checker = "HoaDonKhongthethemkhihopdongkhongtontaimhd";
            string checker2 = "HoaDonKhongthethemkhitrungmaHD";

            if (!dtb.checker(checker, parameter))
            {
                MessageBox.Show("Không tồn tại mã hợp đồng " + mahopdong.Text + "", " Báo lỗi");
                return;
            }
            if (dtb.checker(checker2, parameter2))
            {
                MessageBox.Show("Mã hóa đơn " + mahoadon.Text + " đã tồn tại", " Báo lỗi");
                return;
            }

            else
            {
                   
                SqlParameter[] parameters =
                {
                    new SqlParameter("@mahopdong", mhd),
                    new SqlParameter("@thang", t),
                    new SqlParameter("@nam", n),
                    new SqlParameter("@mahoadon", mhoad),
                    new SqlParameter("@sodiencu", sdc),
                    new SqlParameter("@sodienmoi", sdm),
                    new SqlParameter("@sonuoccu", snc),
                    new SqlParameter("@sonuocmoi", snm),

                };
                string procname = "HoaDonT";
                dtb.Proc(procname, parameters);
                load("HienThiThongTinTongQuat");
                MessageBox.Show("Thêm thành công", "Thông báo");

            }

            

        }


        private void butdelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mahoadon.Text))
            {
                MessageBox.Show("Nhập mã hợp đồng để xóa", "Báo lỗi");
                return;
            }
            if(int.TryParse(mahoadon.Text, out int mhd))
            {
                // Nếu mã hóa đơn không tồn tại thì không xóa
                SqlParameter[] parameter = { new SqlParameter("@mahoadon", mhd) };
                string checker = "HoaDonKhongtontaithikhongxoa";
                if (!dtb.checker(checker, parameter))
                {
                    MessageBox.Show("Mã hóa đơn không tồn tại", "Báo Lỗi");
                    return;
                }
                else
                {
                    SqlParameter[] parameters = { new SqlParameter("@mahoadon", mhd) };
                    string procname = "HoaDonX";
                    dtb.Proc(procname, parameters);
                    load("HienThiThongTinTongQuat");
                    MessageBox.Show("Xóa Thành công", "Thông Báo");

                }
            }

            

        }

        private void datagridviewhoadon_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = datagridviewhoadon.Rows[e.RowIndex];
                    mahoadon.Text = row.Cells["mahoadon"].Value.ToString();
                    thang.Text = row.Cells["thang"].Value.ToString();
                    nam.Text = row.Cells["nam"].Value.ToString();
                    mahopdong.Text = row.Cells["mahopdong"].Value.ToString();
                    sodiencu.Text = row.Cells["sodiencu"].Value.ToString();
                    sodienmoi.Text = row.Cells["sodienmoi"].Value.ToString();
                    sonuoccu.Text = row.Cells["sonuoccu"].Value.ToString();
                    sonuocmoi.Text = row.Cells["sonuocmoi"].Value.ToString();
                }
            }
            catch (Exception ex) { }
            
        }


        public void load(string tablename)
        {
            datagridviewhoadon.DataSource = dtb.Proc(tablename, null);
        }
        public hoadon()
        {
            InitializeComponent();
        }
        // Gọi hợp đồng 
        private void hợpĐồngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hopdong hd = new hopdong();
            hd.Show();
            this.Close();
        }
        // Gọi phòng trọ
        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongtro pt = new phongtro();
            pt.Show();
            this.Close();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hoadon hd = new hoadon();
            hd.Show();
            this.Close();
        }


        // Load hóa đơn form
        private void hoadon_Load(object sender, EventArgs e)
        {
            string tablename = "HienThiThongTinTongQuat";
            load(tablename);

        }
        //reload
        private void butreload_Click(object sender, EventArgs e)
        {
            string procname = "HienThiThongTinTongQuat";
            load(procname); 
        }

        // hiển thị hóa đơn
        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HoaDonHT";
            load(tablename);
        }
        // Hiển thị tổng quát
        private void tổngQuátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string tablename = "HienThiThongTinTongQuat"; 
            load(tablename);
        }
        // Hiển thị bảng tiền
        private void hiểnThịBảngTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tablename = "HoaDonCallViewPhongTroThongTinThue"; 
            load(tablename);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}
