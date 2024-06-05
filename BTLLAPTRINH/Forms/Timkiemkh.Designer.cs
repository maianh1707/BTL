namespace BTLLAPTRINH.Forms
{
    partial class Timkiemkh
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
            this.mskdienthoai = new System.Windows.Forms.MaskedTextBox();
            this.lblsdt = new System.Windows.Forms.Label();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.lbldiachi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.dgridkh = new System.Windows.Forms.DataGridView();
            this.txttenkh = new System.Windows.Forms.TextBox();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.lbltenkh = new System.Windows.Forms.Label();
            this.lblmakh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgridkh)).BeginInit();
            this.SuspendLayout();
            // 
            // mskdienthoai
            // 
            this.mskdienthoai.Location = new System.Drawing.Point(279, 307);
            this.mskdienthoai.Mask = "(999) 000-0000";
            this.mskdienthoai.Name = "mskdienthoai";
            this.mskdienthoai.Size = new System.Drawing.Size(322, 20);
            this.mskdienthoai.TabIndex = 54;
            // 
            // lblsdt
            // 
            this.lblsdt.AutoSize = true;
            this.lblsdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsdt.Location = new System.Drawing.Point(155, 308);
            this.lblsdt.Name = "lblsdt";
            this.lblsdt.Size = new System.Drawing.Size(102, 20);
            this.lblsdt.TabIndex = 53;
            this.lblsdt.Text = "Số điện thoại";
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(279, 223);
            this.txtdiachi.Multiline = true;
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(322, 44);
            this.txtdiachi.TabIndex = 52;
            // 
            // lbldiachi
            // 
            this.lbldiachi.AutoSize = true;
            this.lbldiachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbldiachi.Location = new System.Drawing.Point(155, 234);
            this.lbldiachi.Name = "lbldiachi";
            this.lbldiachi.Size = new System.Drawing.Size(57, 20);
            this.lbldiachi.TabIndex = 51;
            this.lbldiachi.Text = "Địa chỉ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(218, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 37);
            this.label1.TabIndex = 50;
            this.label1.Text = "TÌM KIẾM KHÁCH HÀNG";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btntimkiem.Location = new System.Drawing.Point(279, 545);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(83, 41);
            this.btntimkiem.TabIndex = 48;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btndong
            // 
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btndong.Location = new System.Drawing.Point(468, 545);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(83, 41);
            this.btndong.TabIndex = 45;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // dgridkh
            // 
            this.dgridkh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridkh.Location = new System.Drawing.Point(225, 373);
            this.dgridkh.Name = "dgridkh";
            this.dgridkh.Size = new System.Drawing.Size(428, 150);
            this.dgridkh.TabIndex = 43;
            // 
            // txttenkh
            // 
            this.txttenkh.Location = new System.Drawing.Point(279, 147);
            this.txttenkh.Multiline = true;
            this.txttenkh.Name = "txttenkh";
            this.txttenkh.Size = new System.Drawing.Size(322, 45);
            this.txttenkh.TabIndex = 42;
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(279, 69);
            this.txtmakh.Multiline = true;
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(322, 45);
            this.txtmakh.TabIndex = 41;
            // 
            // lbltenkh
            // 
            this.lbltenkh.AutoSize = true;
            this.lbltenkh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltenkh.Location = new System.Drawing.Point(155, 160);
            this.lbltenkh.Name = "lbltenkh";
            this.lbltenkh.Size = new System.Drawing.Size(123, 20);
            this.lbltenkh.TabIndex = 40;
            this.lbltenkh.Text = "Tên khách hàng";
            // 
            // lblmakh
            // 
            this.lblmakh.AutoSize = true;
            this.lblmakh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblmakh.Location = new System.Drawing.Point(155, 84);
            this.lblmakh.Name = "lblmakh";
            this.lblmakh.Size = new System.Drawing.Size(118, 20);
            this.lblmakh.TabIndex = 39;
            this.lblmakh.Text = "Mã khách hàng";
            // 
            // Timkiemkh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 598);
            this.Controls.Add(this.mskdienthoai);
            this.Controls.Add(this.lblsdt);
            this.Controls.Add(this.txtdiachi);
            this.Controls.Add(this.lbldiachi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.dgridkh);
            this.Controls.Add(this.txttenkh);
            this.Controls.Add(this.txtmakh);
            this.Controls.Add(this.lbltenkh);
            this.Controls.Add(this.lblmakh);
            this.Name = "Timkiemkh";
            this.Text = "Timkiemkh";
            this.Load += new System.EventHandler(this.Timkiemkh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridkh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskdienthoai;
        private System.Windows.Forms.Label lblsdt;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.Label lbldiachi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.DataGridView dgridkh;
        private System.Windows.Forms.TextBox txttenkh;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.Label lbltenkh;
        private System.Windows.Forms.Label lblmakh;
    }
}