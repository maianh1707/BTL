namespace BTL.Forms
{
    partial class Menu
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
            this.mnusp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnubcnv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnulsp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutknv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnugiamgia = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnusp,
            this.mnubcnv,
            this.mnulsp,
            this.mnutknv,
            this.mnugiamgia});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnusp
            // 
            this.mnusp.Name = "mnusp";
            this.mnusp.Size = new System.Drawing.Size(48, 29);
            this.mnusp.Text = "SP";
            this.mnusp.Click += new System.EventHandler(this.mnusp_Click);
            // 
            // mnubcnv
            // 
            this.mnubcnv.Name = "mnubcnv";
            this.mnubcnv.Size = new System.Drawing.Size(73, 29);
            this.mnubcnv.Text = "BCNV";
            this.mnubcnv.Click += new System.EventHandler(this.mnubcnv_Click);
            // 
            // mnulsp
            // 
            this.mnulsp.Name = "mnulsp";
            this.mnulsp.Size = new System.Drawing.Size(56, 29);
            this.mnulsp.Text = "LSP";
            this.mnulsp.Click += new System.EventHandler(this.mnulsp_Click);
            // 
            // mnutknv
            // 
            this.mnutknv.Name = "mnutknv";
            this.mnutknv.Size = new System.Drawing.Size(71, 29);
            this.mnutknv.Text = "TKNV";
            this.mnutknv.Click += new System.EventHandler(this.mnutknv_Click);
            // 
            // mnugiamgia
            // 
            this.mnugiamgia.Name = "mnugiamgia";
            this.mnugiamgia.Size = new System.Drawing.Size(93, 29);
            this.mnugiamgia.Text = "Giamgia";
            this.mnugiamgia.Click += new System.EventHandler(this.mnugiamgia_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnusp;
        private System.Windows.Forms.ToolStripMenuItem mnubcnv;
        private System.Windows.Forms.ToolStripMenuItem mnulsp;
        private System.Windows.Forms.ToolStripMenuItem mnutknv;
        private System.Windows.Forms.ToolStripMenuItem mnugiamgia;
    }
}