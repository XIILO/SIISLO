namespace Mainproject
{
    partial class phongtro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.trangthaiphong = new System.Windows.Forms.ComboBox();
            this.sophong = new System.Windows.Forms.TextBox();
            this.dientich = new System.Windows.Forms.TextBox();
            this.giathue = new System.Windows.Forms.TextBox();
            this.tiendien = new System.Windows.Forms.TextBox();
            this.tiennuoc = new System.Windows.Forms.TextBox();
            this.tienmang = new System.Windows.Forms.TextBox();
            this.themphong = new System.Windows.Forms.Button();
            this.suaphong = new System.Windows.Forms.Button();
            this.xoaphong = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.trangthaiphong);
            this.groupBox1.Controls.Add(this.sophong);
            this.groupBox1.Controls.Add(this.dientich);
            this.groupBox1.Controls.Add(this.giathue);
            this.groupBox1.Controls.Add(this.tiendien);
            this.groupBox1.Controls.Add(this.tiennuoc);
            this.groupBox1.Controls.Add(this.tienmang);
            this.groupBox1.Controls.Add(this.themphong);
            this.groupBox1.Controls.Add(this.suaphong);
            this.groupBox1.Controls.Add(this.xoaphong);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 402);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý phòng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Trạng thái";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Tiền mạng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Tiền nước";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "Tiền điện";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Giá thuê";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 16);
            this.label14.TabIndex = 3;
            this.label14.Text = "Diện tích";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "Số phòng";
            // 
            // trangthaiphong
            // 
            this.trangthaiphong.FormattingEnabled = true;
            this.trangthaiphong.Items.AddRange(new object[] {
            "Đã cho thuê",
            "Chưa được thuê"});
            this.trangthaiphong.Location = new System.Drawing.Point(100, 328);
            this.trangthaiphong.Name = "trangthaiphong";
            this.trangthaiphong.Size = new System.Drawing.Size(255, 24);
            this.trangthaiphong.TabIndex = 2;
            // 
            // sophong
            // 
            this.sophong.Location = new System.Drawing.Point(100, 72);
            this.sophong.Name = "sophong";
            this.sophong.Size = new System.Drawing.Size(255, 22);
            this.sophong.TabIndex = 1;
            // 
            // dientich
            // 
            this.dientich.Location = new System.Drawing.Point(100, 116);
            this.dientich.Name = "dientich";
            this.dientich.Size = new System.Drawing.Size(255, 22);
            this.dientich.TabIndex = 1;
            // 
            // giathue
            // 
            this.giathue.Location = new System.Drawing.Point(101, 157);
            this.giathue.Name = "giathue";
            this.giathue.Size = new System.Drawing.Size(254, 22);
            this.giathue.TabIndex = 1;
            // 
            // tiendien
            // 
            this.tiendien.Location = new System.Drawing.Point(100, 199);
            this.tiendien.Name = "tiendien";
            this.tiendien.Size = new System.Drawing.Size(255, 22);
            this.tiendien.TabIndex = 1;
            // 
            // tiennuoc
            // 
            this.tiennuoc.Location = new System.Drawing.Point(100, 239);
            this.tiennuoc.Name = "tiennuoc";
            this.tiennuoc.Size = new System.Drawing.Size(255, 22);
            this.tiennuoc.TabIndex = 1;
            // 
            // tienmang
            // 
            this.tienmang.Location = new System.Drawing.Point(100, 285);
            this.tienmang.Name = "tienmang";
            this.tienmang.Size = new System.Drawing.Size(255, 22);
            this.tienmang.TabIndex = 1;
            // 
            // themphong
            // 
            this.themphong.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.themphong.Location = new System.Drawing.Point(387, 123);
            this.themphong.Name = "themphong";
            this.themphong.Size = new System.Drawing.Size(117, 61);
            this.themphong.TabIndex = 0;
            this.themphong.Text = "Thêm";
            this.themphong.UseVisualStyleBackColor = true;
            this.themphong.Click += new System.EventHandler(this.themphong_Click);
            // 
            // suaphong
            // 
            this.suaphong.Location = new System.Drawing.Point(387, 206);
            this.suaphong.Name = "suaphong";
            this.suaphong.Size = new System.Drawing.Size(117, 61);
            this.suaphong.TabIndex = 0;
            this.suaphong.Text = "Sửa";
            this.suaphong.UseVisualStyleBackColor = true;
            this.suaphong.Click += new System.EventHandler(this.suaphong_Click);
            // 
            // xoaphong
            // 
            this.xoaphong.Location = new System.Drawing.Point(387, 292);
            this.xoaphong.Name = "xoaphong";
            this.xoaphong.Size = new System.Drawing.Size(117, 61);
            this.xoaphong.TabIndex = 0;
            this.xoaphong.Text = "Xóa";
            this.xoaphong.UseVisualStyleBackColor = true;
            this.xoaphong.Click += new System.EventHandler(this.xoaphong_Click);
            // 
            // phongtro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 425);
            this.Controls.Add(this.groupBox1);
            this.Name = "phongtro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "phongtro";
            this.Load += new System.EventHandler(this.phongtro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox trangthaiphong;
        private System.Windows.Forms.TextBox sophong;
        private System.Windows.Forms.TextBox dientich;
        private System.Windows.Forms.TextBox giathue;
        private System.Windows.Forms.TextBox tiendien;
        private System.Windows.Forms.TextBox tiennuoc;
        private System.Windows.Forms.TextBox tienmang;
        private System.Windows.Forms.Button themphong;
        private System.Windows.Forms.Button suaphong;
        private System.Windows.Forms.Button xoaphong;
    }
}