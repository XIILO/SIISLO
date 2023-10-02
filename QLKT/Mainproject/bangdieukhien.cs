using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainproject
{
    public partial class bangdieukhien : Form
    {
        // khai báo các lớp
        
        cosodulieu csdl = new cosodulieu();
        public bangdieukhien()
        {
            InitializeComponent();
        }

        // Load
        private void bangdieukhien_Load(object sender, EventArgs e)
        {
            string tenproc = "tongquat";
            viewtongquat.DataSource = csdl.proc(tenproc, null);

        }

            
        // Forms actions
        private void bangdieukhien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        public void reload()
        {
            string tenproc = "tongquat";
            viewtongquat.DataSource = csdl.proc(tenproc, null);
        }

        private void bảngThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hopdong hd = new hopdong();
            hd.Show();
        }

        private void phòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongtro pt = new phongtro();
            pt.Show();
        }

        private void reloadgrview_Click(object sender, EventArgs e)
        {
            reload();
        }


        private hopdong hd;
        private phongtro pt;    
        private void viewtongquat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int sophong = Convert.ToInt32(viewtongquat.Rows[e.RowIndex].Cells["sophong"].Value);
                decimal dientich = Convert.ToDecimal(viewtongquat.Rows[e.RowIndex].Cells["dientich"].Value);
                decimal giathue = Convert.ToDecimal(viewtongquat.Rows[e.RowIndex].Cells["giathue"].Value);
                decimal tiendien = Convert.ToDecimal(viewtongquat.Rows[e.RowIndex].Cells["tiendien"].Value);
                decimal tiennuoc = Convert.ToDecimal(viewtongquat.Rows[e.RowIndex].Cells["tiennuoc"].Value);
                decimal tienmang = Convert.ToDecimal(viewtongquat.Rows[e.RowIndex].Cells["tienmang"].Value);
                string trangthaiphong = viewtongquat.Rows[e.RowIndex].Cells["trangthaiphong"].Value.ToString();
                int mamhopdong = Convert.ToInt32(viewtongquat.Rows[e.RowIndex].Cells["mahopdong"].Value);
                float cancuoccongdannguoithue = Convert.ToSingle(viewtongquat.Rows[e.RowIndex].Cells["cancuoccongdannguoithue"].Value);
                string hovatennguoithue = viewtongquat.Rows[e.RowIndex].Cells["hovatennguoithue"].Value.ToString();
                float sodienthoainguoithue = Convert.ToSingle(viewtongquat.Rows[e.RowIndex].Cells["sodienthoainguoithue"].Value);
                decimal sotiencoc = Convert.ToDecimal(viewtongquat.Rows[e.RowIndex].Cells["sotiencoc"].Value);
                DateTime ngaybatdau = Convert.ToDateTime(viewtongquat.Rows[e.RowIndex].Cells["ngaybatdau"].Value);
                DateTime ngayketthuc = Convert.ToDateTime(viewtongquat.Rows[e.RowIndex].Cells["ngayketthuc"].Value);

                if (hd == null || hd.IsDisposed)
                {
                    hd = new hopdong();
                    hd.Show();
                }

                if (pt == null || pt.IsDisposed)
                {
                    pt = new phongtro();
                    pt.Show();
                }
                pt.FillData(sophong, dientich, giathue, tiendien, tiennuoc, tienmang, trangthaiphong);
                hd.FillData(mamhopdong, cancuoccongdannguoithue, hovatennguoithue, sodienthoainguoithue, sophong, sotiencoc, ngaybatdau, ngayketthuc);

            }
            catch
            {
                MessageBox.Show("Không thể load dữ liệu lên form", "Thông báo");
            }


        }



    }
}