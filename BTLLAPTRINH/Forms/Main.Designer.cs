namespace BTLLAPTRINH.Forms
{
    partial class Main
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoCuốiNgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnNhậpNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.kháchHàngToolStripMenuItem,
            this.báoCáoCuốiNgàyToolStripMenuItem,
            this.tìmKiếmKháchHàngToolStripMenuItem,
            this.hóaĐơnNhậpNewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(82, 20);
            this.toolStripMenuItem1.Text = "Khách hàng";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.kháchHàngToolStripMenuItem.Text = "Kích cỡ";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // báoCáoCuốiNgàyToolStripMenuItem
            // 
            this.báoCáoCuốiNgàyToolStripMenuItem.Name = "báoCáoCuốiNgàyToolStripMenuItem";
            this.báoCáoCuốiNgàyToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.báoCáoCuốiNgàyToolStripMenuItem.Text = "Báo cáo cuối ngày";
            this.báoCáoCuốiNgàyToolStripMenuItem.Click += new System.EventHandler(this.báoCáoCuốiNgàyToolStripMenuItem_Click);
            // 
            // tìmKiếmKháchHàngToolStripMenuItem
            // 
            this.tìmKiếmKháchHàngToolStripMenuItem.Name = "tìmKiếmKháchHàngToolStripMenuItem";
            this.tìmKiếmKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.tìmKiếmKháchHàngToolStripMenuItem.Text = "Tìm kiếm khách hàng";
            this.tìmKiếmKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmKháchHàngToolStripMenuItem_Click);
            // 
            // hóaĐơnNhậpNewToolStripMenuItem
            // 
            this.hóaĐơnNhậpNewToolStripMenuItem.Name = "hóaĐơnNhậpNewToolStripMenuItem";
            this.hóaĐơnNhậpNewToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.hóaĐơnNhậpNewToolStripMenuItem.Text = "Hóa đơn nhập new";
            this.hóaĐơnNhậpNewToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnNhậpNewToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem báoCáoCuốiNgàyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnNhậpNewToolStripMenuItem;
    }
}