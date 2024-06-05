namespace BTLLAPTRINH.Forms
{
    partial class Khachhang
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnboqua = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.dgridkh = new System.Windows.Forms.DataGridView();
            this.txttenkh = new System.Windows.Forms.TextBox();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.lbltenkh = new System.Windows.Forms.Label();
            this.lblmakh = new System.Windows.Forms.Label();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.lbldiachi = new System.Windows.Forms.Label();
            this.lblsdt = new System.Windows.Forms.Label();
            this.mskdienthoai = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridkh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(333, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 37);
            this.label1.TabIndex = 34;
            this.label1.Text = "KHÁCH HÀNG";
            // 
            // btnsua
            // 
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnsua.Location = new System.Drawing.Point(232, 538);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(83, 41);
            this.btnsua.TabIndex = 33;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxoa.Location = new System.Drawing.Point(369, 538);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(83, 41);
            this.btnxoa.TabIndex = 32;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnluu
            // 
            this.btnluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnluu.Location = new System.Drawing.Point(502, 538);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(83, 41);
            this.btnluu.TabIndex = 31;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnboqua
            // 
            this.btnboqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnboqua.Location = new System.Drawing.Point(635, 538);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Size = new System.Drawing.Size(83, 41);
            this.btnboqua.TabIndex = 30;
            this.btnboqua.Text = "Bỏ qua";
            this.btnboqua.UseVisualStyleBackColor = true;
            this.btnboqua.Click += new System.EventHandler(this.btnboqua_Click);
            // 
            // btndong
            // 
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btndong.Location = new System.Drawing.Point(761, 538);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(83, 41);
            this.btndong.TabIndex = 29;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnthem
            // 
            this.btnthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthem.Location = new System.Drawing.Point(93, 538);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(83, 41);
            this.btnthem.TabIndex = 28;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dgridkh
            // 
            this.dgridkh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridkh.Location = new System.Drawing.Point(258, 368);
            this.dgridkh.Name = "dgridkh";
            this.dgridkh.Size = new System.Drawing.Size(428, 150);
            this.dgridkh.TabIndex = 27;
            this.dgridkh.Click += new System.EventHandler(this.dgridkh_Click);
            // 
            // txttenkh
            // 
            this.txttenkh.Location = new System.Drawing.Point(312, 142);
            this.txttenkh.Multiline = true;
            this.txttenkh.Name = "txttenkh";
            this.txttenkh.Size = new System.Drawing.Size(322, 45);
            this.txttenkh.TabIndex = 26;
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(312, 64);
            this.txtmakh.Multiline = true;
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(322, 45);
            this.txtmakh.TabIndex = 25;
            // 
            // lbltenkh
            // 
            this.lbltenkh.AutoSize = true;
            this.lbltenkh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltenkh.Location = new System.Drawing.Point(188, 155);
            this.lbltenkh.Name = "lbltenkh";
            this.lbltenkh.Size = new System.Drawing.Size(123, 20);
            this.lbltenkh.TabIndex = 24;
            this.lbltenkh.Text = "Tên khách hàng";
            // 
            // lblmakh
            // 
            this.lblmakh.AutoSize = true;
            this.lblmakh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblmakh.Location = new System.Drawing.Point(188, 79);
            this.lblmakh.Name = "lblmakh";
            this.lblmakh.Size = new System.Drawing.Size(118, 20);
            this.lblmakh.TabIndex = 23;
            this.lblmakh.Text = "Mã khách hàng";
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(312, 220);
            this.txtdiachi.Multiline = true;
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(322, 44);
            this.txtdiachi.TabIndex = 36;
            // 
            // lbldiachi
            // 
            this.lbldiachi.AutoSize = true;
            this.lbldiachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbldiachi.Location = new System.Drawing.Point(216, 231);
            this.lbldiachi.Name = "lbldiachi";
            this.lbldiachi.Size = new System.Drawing.Size(57, 20);
            this.lbldiachi.TabIndex = 35;
            this.lbldiachi.Text = "Địa chỉ";
            // 
            // lblsdt
            // 
            this.lblsdt.AutoSize = true;
            this.lblsdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsdt.Location = new System.Drawing.Point(188, 302);
            this.lblsdt.Name = "lblsdt";
            this.lblsdt.Size = new System.Drawing.Size(102, 20);
            this.lblsdt.TabIndex = 37;
            this.lblsdt.Text = "Số điện thoại";
            // 
            // mskdienthoai
            // 
            this.mskdienthoai.Location = new System.Drawing.Point(312, 301);
            this.mskdienthoai.Mask = "(999) 000-0000";
            this.mskdienthoai.Name = "mskdienthoai";
            this.mskdienthoai.Size = new System.Drawing.Size(322, 20);
            this.mskdienthoai.TabIndex = 38;
            // 
            // Khachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 603);
            this.Controls.Add(this.mskdienthoai);
            this.Controls.Add(this.lblsdt);
            this.Controls.Add(this.txtdiachi);
            this.Controls.Add(this.lbldiachi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnboqua);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgridkh);
            this.Controls.Add(this.txttenkh);
            this.Controls.Add(this.txtmakh);
            this.Controls.Add(this.lbltenkh);
            this.Controls.Add(this.lblmakh);
            this.Name = "Khachhang";
            this.Text = "Khachhang";
            this.Load += new System.EventHandler(this.Khachhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridkh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnboqua;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.DataGridView dgridkh;
        private System.Windows.Forms.TextBox txttenkh;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.Label lbltenkh;
        private System.Windows.Forms.Label lblmakh;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.Label lbldiachi;
        private System.Windows.Forms.Label lblsdt;
        private System.Windows.Forms.MaskedTextBox mskdienthoai;
    }
}