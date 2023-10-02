using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
    }
}