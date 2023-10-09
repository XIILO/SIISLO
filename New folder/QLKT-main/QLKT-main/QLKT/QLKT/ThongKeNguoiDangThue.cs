﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKT
{
    public partial class ThongKeNguoiDangThue : Form
    {
        database dtb = new database();
        public ThongKeNguoiDangThue()
        {
            InitializeComponent();
        }
        
        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongtro pt = new phongtro();
            pt.Show();
            this.Hide();
        }

        private void hợpĐồngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hopdong hd = new hopdong();
            hd.Show();
            this.Hide();
        }

        private void ngườiĐangThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongke tk = new Thongke();
            tk.Show();
            this.Hide();
        }

        private void đãChoThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongtro pt = new phongtro();
            pt.Show();
            string sql = "PhongDaThue";
            pt.load(sql);
            this.Hide();
        }

        private void chưaChoThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongtro pt = new phongtro();
            pt.Show();
            string sql = "PhongChuaThue";
            pt.load(sql);
            this.Hide();
        }

        private void thôngTinPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongtro pt = new phongtro();
            pt.Show();
            string sql = "HienThiThongTinPhongThue";
            pt.load(sql);
            this.Hide();
        }

        private void HopDongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hopdong hd = new hopdong();
            hd.Show();
            string sql = "HienThiThongTinHopDong";
            hd.load(sql);
            this.Hide();
        }

        private void tổngQuátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongtro pt = new phongtro();
            pt.Show();
            string sql = "HienThiThongTinTongQuat";
            pt.load(sql);
            this.Hide();
        }

        private void ThongKeNguoiDangThue_Load(object sender, EventArgs e)
        {
            string sql = "ThongKeNguoiDangThue";
            dgvtk.DataSource = dtb.Proc(sql, null);
        }
    }
}
