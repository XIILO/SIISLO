namespace Mainproject
{
    partial class bangdieukhien
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảngThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phòngTrọToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewtongquat = new System.Windows.Forms.DataGridView();
            this.reloadgrview = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewtongquat)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1462, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bảngThốngKêToolStripMenuItem,
            this.phòngTrọToolStripMenuItem});
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.thốngKêToolStripMenuItem.Text = "Quản lý";
            // 
            // bảngThốngKêToolStripMenuItem
            // 
            this.bảngThốngKêToolStripMenuItem.Name = "bảngThốngKêToolStripMenuItem";
            this.bảngThốngKêToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.bảngThốngKêToolStripMenuItem.Text = "Hợp đồng";
            this.bảngThốngKêToolStripMenuItem.Click += new System.EventHandler(this.bảngThốngKêToolStripMenuItem_Click);
            // 
            // phòngTrọToolStripMenuItem
            // 
            this.phòngTrọToolStripMenuItem.Name = "phòngTrọToolStripMenuItem";
            this.phòngTrọToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.phòngTrọToolStripMenuItem.Text = "Phòng trọ";
            this.phòngTrọToolStripMenuItem.Click += new System.EventHandler(this.phòngTrọToolStripMenuItem_Click);
            // 
            // viewtongquat
            // 
            this.viewtongquat.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.viewtongquat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewtongquat.Location = new System.Drawing.Point(12, 127);
            this.viewtongquat.Name = "viewtongquat";
            this.viewtongquat.Size = new System.Drawing.Size(1438, 772);
            this.viewtongquat.TabIndex = 4;
            this.viewtongquat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewtongquat_CellContentClick);
            // 
            // reloadgrview
            // 
            this.reloadgrview.Location = new System.Drawing.Point(1313, 59);
            this.reloadgrview.Name = "reloadgrview";
            this.reloadgrview.Size = new System.Drawing.Size(137, 62);
            this.reloadgrview.TabIndex = 6;
            this.reloadgrview.Text = "Reload";
            this.reloadgrview.UseVisualStyleBackColor = true;
            this.reloadgrview.Click += new System.EventHandler(this.reloadgrview_Click);
            // 
            // bangdieukhien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1462, 911);
            this.Controls.Add(this.reloadgrview);
            this.Controls.Add(this.viewtongquat);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "bangdieukhien";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng điều khiển";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bangdieukhien_FormClosing);
            this.Load += new System.EventHandler(this.bangdieukhien_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewtongquat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView viewtongquat;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bảngThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phòngTrọToolStripMenuItem;
        private System.Windows.Forms.Button reloadgrview;
    }
}