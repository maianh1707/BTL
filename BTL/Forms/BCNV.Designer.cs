namespace BTL
{
    partial class BCNV
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
            this.btnhien = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.btnxuat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.msktime = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnam = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtthang = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnhien
            // 
            this.btnhien.Location = new System.Drawing.Point(570, 396);
            this.btnhien.Name = "btnhien";
            this.btnhien.Size = new System.Drawing.Size(75, 51);
            this.btnhien.TabIndex = 1;
            this.btnhien.Text = "Thoát";
            this.btnhien.UseVisualStyleBackColor = true;
            this.btnhien.Click += new System.EventHandler(this.btnhien_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(396, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "BÁO CÁO NHÂN VIÊN";
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataGridView.Location = new System.Drawing.Point(186, 153);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 62;
            this.DataGridView.RowTemplate.Height = 28;
            this.DataGridView.Size = new System.Drawing.Size(749, 181);
            this.DataGridView.TabIndex = 3;
            // 
            // btnxuat
            // 
            this.btnxuat.Location = new System.Drawing.Point(401, 396);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(137, 51);
            this.btnxuat.TabIndex = 4;
            this.btnxuat.Text = "Xuất báo cáo";
            this.btnxuat.UseVisualStyleBackColor = true;
            this.btnxuat.Click += new System.EventHandler(this.btnxuat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày lập";
            // 
            // msktime
            // 
            this.msktime.Location = new System.Drawing.Point(101, 9);
            this.msktime.Mask = "00/00/0000";
            this.msktime.Name = "msktime";
            this.msktime.Size = new System.Drawing.Size(195, 26);
            this.msktime.TabIndex = 6;
            this.msktime.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tháng";
//            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Năm";
            // 
            // txtnam
            // 
            this.txtnam.Location = new System.Drawing.Point(634, 83);
            this.txtnam.Name = "txtnam";
            this.txtnam.Size = new System.Drawing.Size(100, 26);
            this.txtnam.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(872, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "Hiển thị";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtthang
            // 
            this.txtthang.Location = new System.Drawing.Point(277, 86);
            this.txtthang.Name = "txtthang";
            this.txtthang.Size = new System.Drawing.Size(100, 26);
            this.txtthang.TabIndex = 13;
            // 
            // BCNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 565);
            this.Controls.Add(this.txtthang);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtnam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.msktime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnxuat);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnhien);
            this.Name = "BCNV";
            this.Text = "BCNV";
            this.Load += new System.EventHandler(this.BCNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnhien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button btnxuat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox msktime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtthang;
    }
}