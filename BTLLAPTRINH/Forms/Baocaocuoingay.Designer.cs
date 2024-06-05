namespace BTLLAPTRINH.Forms
{
    partial class Baocaocuoingay
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
            this.txtmabaocao = new System.Windows.Forms.TextBox();
            this.lblmabaocao = new System.Windows.Forms.Label();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnin = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.dgridbccn = new System.Windows.Forms.DataGridView();
            this.txtdoanhthu = new System.Windows.Forms.TextBox();
            this.lbldoanhthu = new System.Windows.Forms.Label();
            this.txtsoluongban = new System.Windows.Forms.TextBox();
            this.txttensp = new System.Windows.Forms.TextBox();
            this.lblmasp = new System.Windows.Forms.Label();
            this.lbltensp = new System.Windows.Forms.Label();
            this.lblsoluongban = new System.Windows.Forms.Label();
            this.mskngay = new System.Windows.Forms.MaskedTextBox();
            this.lblnhanvien = new System.Windows.Forms.Label();
            this.lblthoigian = new System.Windows.Forms.Label();
            this.cbonv = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbosp = new System.Windows.Forms.ComboBox();
            this.txtsoluongnhap = new System.Windows.Forms.TextBox();
            this.lblsln = new System.Windows.Forms.Label();
            this.btndong = new System.Windows.Forms.Button();
            this.lblbaocao = new System.Windows.Forms.Label();
            this.cbotimkiem = new System.Windows.Forms.ComboBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.txttongdoanhthu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtgianhap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtgiaban = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttongtiennhap = new System.Windows.Forms.TextBox();
            this.lbltongtienhang = new System.Windows.Forms.Label();
            this.txttongtienban = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgridbccn)).BeginInit();
            this.SuspendLayout();
            // 
            // txtmabaocao
            // 
            this.txtmabaocao.Location = new System.Drawing.Point(401, 67);
            this.txtmabaocao.Multiline = true;
            this.txtmabaocao.Name = "txtmabaocao";
            this.txtmabaocao.Size = new System.Drawing.Size(187, 26);
            this.txtmabaocao.TabIndex = 98;
            // 
            // lblmabaocao
            // 
            this.lblmabaocao.AutoSize = true;
            this.lblmabaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblmabaocao.Location = new System.Drawing.Point(293, 68);
            this.lblmabaocao.Name = "lblmabaocao";
            this.lblmabaocao.Size = new System.Drawing.Size(92, 20);
            this.lblmabaocao.TabIndex = 99;
            this.lblmabaocao.Text = "Mã báo cáo";
            // 
            // btnhuy
            // 
            this.btnhuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnhuy.Location = new System.Drawing.Point(594, 565);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(83, 31);
            this.btnhuy.TabIndex = 94;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnluu.Location = new System.Drawing.Point(272, 565);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(83, 31);
            this.btnluu.TabIndex = 93;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnin
            // 
            this.btnin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnin.Location = new System.Drawing.Point(435, 565);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(83, 31);
            this.btnin.TabIndex = 92;
            this.btnin.Text = "In";
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btnthem
            // 
            this.btnthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthem.Location = new System.Drawing.Point(96, 565);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(83, 31);
            this.btnthem.TabIndex = 91;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dgridbccn
            // 
            this.dgridbccn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridbccn.Location = new System.Drawing.Point(12, 356);
            this.dgridbccn.Name = "dgridbccn";
            this.dgridbccn.Size = new System.Drawing.Size(919, 150);
            this.dgridbccn.TabIndex = 90;
            this.dgridbccn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridbccn_CellDoubleClick);
            // 
            // txtdoanhthu
            // 
            this.txtdoanhthu.Location = new System.Drawing.Point(484, 324);
            this.txtdoanhthu.Multiline = true;
            this.txtdoanhthu.Name = "txtdoanhthu";
            this.txtdoanhthu.Size = new System.Drawing.Size(250, 26);
            this.txtdoanhthu.TabIndex = 83;
            // 
            // lbldoanhthu
            // 
            this.lbldoanhthu.AutoSize = true;
            this.lbldoanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbldoanhthu.Location = new System.Drawing.Point(386, 334);
            this.lbldoanhthu.Name = "lbldoanhthu";
            this.lbldoanhthu.Size = new System.Drawing.Size(67, 16);
            this.lbldoanhthu.TabIndex = 82;
            this.lbldoanhthu.Text = "Doanh thu";
            // 
            // txtsoluongban
            // 
            this.txtsoluongban.Location = new System.Drawing.Point(733, 186);
            this.txtsoluongban.Multiline = true;
            this.txtsoluongban.Name = "txtsoluongban";
            this.txtsoluongban.Size = new System.Drawing.Size(128, 26);
            this.txtsoluongban.TabIndex = 81;
            this.txtsoluongban.TextChanged += new System.EventHandler(this.txtsoluongban_TextChanged);
            // 
            // txttensp
            // 
            this.txttensp.Location = new System.Drawing.Point(126, 240);
            this.txttensp.Multiline = true;
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(235, 26);
            this.txttensp.TabIndex = 80;
            // 
            // lblmasp
            // 
            this.lblmasp.AutoSize = true;
            this.lblmasp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblmasp.Location = new System.Drawing.Point(18, 199);
            this.lblmasp.Name = "lblmasp";
            this.lblmasp.Size = new System.Drawing.Size(88, 16);
            this.lblmasp.TabIndex = 79;
            this.lblmasp.Text = "Mã sản phẩm";
            // 
            // lbltensp
            // 
            this.lbltensp.AutoSize = true;
            this.lbltensp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltensp.Location = new System.Drawing.Point(18, 240);
            this.lbltensp.Name = "lbltensp";
            this.lbltensp.Size = new System.Drawing.Size(93, 16);
            this.lbltensp.TabIndex = 78;
            this.lbltensp.Text = "Tên sản phẩm";
            // 
            // lblsoluongban
            // 
            this.lblsoluongban.AutoSize = true;
            this.lblsoluongban.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsoluongban.Location = new System.Drawing.Point(635, 196);
            this.lblsoluongban.Name = "lblsoluongban";
            this.lblsoluongban.Size = new System.Drawing.Size(86, 16);
            this.lblsoluongban.TabIndex = 77;
            this.lblsoluongban.Text = "Số lượng bán";
            // 
            // mskngay
            // 
            this.mskngay.Location = new System.Drawing.Point(401, 112);
            this.mskngay.Mask = "00/00/0000";
            this.mskngay.Name = "mskngay";
            this.mskngay.Size = new System.Drawing.Size(187, 20);
            this.mskngay.TabIndex = 74;
            // 
            // lblnhanvien
            // 
            this.lblnhanvien.AutoSize = true;
            this.lblnhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblnhanvien.Location = new System.Drawing.Point(297, 152);
            this.lblnhanvien.Name = "lblnhanvien";
            this.lblnhanvien.Size = new System.Drawing.Size(79, 20);
            this.lblnhanvien.TabIndex = 73;
            this.lblnhanvien.Text = "Nhân viên";
            // 
            // lblthoigian
            // 
            this.lblthoigian.AutoSize = true;
            this.lblthoigian.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblthoigian.Location = new System.Drawing.Point(297, 112);
            this.lblthoigian.Name = "lblthoigian";
            this.lblthoigian.Size = new System.Drawing.Size(45, 20);
            this.lblthoigian.TabIndex = 72;
            this.lblthoigian.Text = "Ngày";
            // 
            // cbonv
            // 
            this.cbonv.FormattingEnabled = true;
            this.cbonv.Location = new System.Drawing.Point(401, 150);
            this.cbonv.Name = "cbonv";
            this.cbonv.Size = new System.Drawing.Size(187, 21);
            this.cbonv.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(265, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 37);
            this.label1.TabIndex = 100;
            this.label1.Text = "BÁO CÁO CUỐI NGÀY";
            // 
            // cbosp
            // 
            this.cbosp.FormattingEnabled = true;
            this.cbosp.Location = new System.Drawing.Point(126, 199);
            this.cbosp.Name = "cbosp";
            this.cbosp.Size = new System.Drawing.Size(235, 21);
            this.cbosp.TabIndex = 101;
            this.cbosp.TextChanged += new System.EventHandler(this.cbosp_TextChanged);
            // 
            // txtsoluongnhap
            // 
            this.txtsoluongnhap.Location = new System.Drawing.Point(484, 186);
            this.txtsoluongnhap.Multiline = true;
            this.txtsoluongnhap.Name = "txtsoluongnhap";
            this.txtsoluongnhap.Size = new System.Drawing.Size(128, 26);
            this.txtsoluongnhap.TabIndex = 103;
            this.txtsoluongnhap.TextChanged += new System.EventHandler(this.txtsoluongnhap_TextChanged);
            // 
            // lblsln
            // 
            this.lblsln.AutoSize = true;
            this.lblsln.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsln.Location = new System.Drawing.Point(386, 196);
            this.lblsln.Name = "lblsln";
            this.lblsln.Size = new System.Drawing.Size(93, 16);
            this.lblsln.TabIndex = 102;
            this.lblsln.Text = "Số lượng nhập";
            // 
            // btndong
            // 
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btndong.Location = new System.Drawing.Point(746, 565);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(83, 31);
            this.btndong.TabIndex = 104;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // lblbaocao
            // 
            this.lblbaocao.AutoSize = true;
            this.lblbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblbaocao.Location = new System.Drawing.Point(60, 611);
            this.lblbaocao.Name = "lblbaocao";
            this.lblbaocao.Size = new System.Drawing.Size(79, 16);
            this.lblbaocao.TabIndex = 107;
            this.lblbaocao.Text = "Mã báo cáo";
            // 
            // cbotimkiem
            // 
            this.cbotimkiem.FormattingEnabled = true;
            this.cbotimkiem.Location = new System.Drawing.Point(144, 608);
            this.cbotimkiem.Name = "cbotimkiem";
            this.cbotimkiem.Size = new System.Drawing.Size(349, 21);
            this.cbotimkiem.TabIndex = 105;
            this.cbotimkiem.DropDown += new System.EventHandler(this.cbotimkiem_DropDown);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btntimkiem.Location = new System.Drawing.Point(512, 602);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(83, 33);
            this.btntimkiem.TabIndex = 106;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // txttongdoanhthu
            // 
            this.txttongdoanhthu.Location = new System.Drawing.Point(177, 524);
            this.txttongdoanhthu.Multiline = true;
            this.txttongdoanhthu.Name = "txttongdoanhthu";
            this.txttongdoanhthu.Size = new System.Drawing.Size(250, 26);
            this.txttongdoanhthu.TabIndex = 109;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(65, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 108;
            this.label2.Text = "Tổng doanh thu";
            // 
            // txtgianhap
            // 
            this.txtgianhap.Location = new System.Drawing.Point(484, 231);
            this.txtgianhap.Multiline = true;
            this.txtgianhap.Name = "txtgianhap";
            this.txtgianhap.Size = new System.Drawing.Size(128, 26);
            this.txtgianhap.TabIndex = 112;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(386, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 111;
            this.label3.Text = "Giá nhập";
            // 
            // txtgiaban
            // 
            this.txtgiaban.Location = new System.Drawing.Point(733, 234);
            this.txtgiaban.Multiline = true;
            this.txtgiaban.Name = "txtgiaban";
            this.txtgiaban.Size = new System.Drawing.Size(128, 26);
            this.txtgiaban.TabIndex = 114;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(635, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 113;
            this.label4.Text = "Giá bán";
            // 
            // txttongtiennhap
            // 
            this.txttongtiennhap.Location = new System.Drawing.Point(484, 277);
            this.txttongtiennhap.Multiline = true;
            this.txttongtiennhap.Name = "txttongtiennhap";
            this.txttongtiennhap.Size = new System.Drawing.Size(128, 26);
            this.txttongtiennhap.TabIndex = 115;
            this.txttongtiennhap.TextChanged += new System.EventHandler(this.txttongtiennhap_TextChanged);
            // 
            // lbltongtienhang
            // 
            this.lbltongtienhang.AutoSize = true;
            this.lbltongtienhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltongtienhang.Location = new System.Drawing.Point(386, 287);
            this.lbltongtienhang.Name = "lbltongtienhang";
            this.lbltongtienhang.Size = new System.Drawing.Size(96, 16);
            this.lbltongtienhang.TabIndex = 116;
            this.lbltongtienhang.Text = "Tổng tiền nhập";
            // 
            // txttongtienban
            // 
            this.txttongtienban.Location = new System.Drawing.Point(733, 277);
            this.txttongtienban.Multiline = true;
            this.txttongtienban.Name = "txttongtienban";
            this.txttongtienban.Size = new System.Drawing.Size(128, 26);
            this.txttongtienban.TabIndex = 117;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(635, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 118;
            this.label5.Text = "Tổng tiền bán";
            // 
            // Baocaocuoingay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 641);
            this.Controls.Add(this.txttongtienban);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txttongtiennhap);
            this.Controls.Add(this.lbltongtienhang);
            this.Controls.Add(this.txtgiaban);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtgianhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttongdoanhthu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblbaocao);
            this.Controls.Add(this.cbotimkiem);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.txtsoluongnhap);
            this.Controls.Add(this.lblsln);
            this.Controls.Add(this.cbosp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtmabaocao);
            this.Controls.Add(this.lblmabaocao);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgridbccn);
            this.Controls.Add(this.txtdoanhthu);
            this.Controls.Add(this.lbldoanhthu);
            this.Controls.Add(this.txtsoluongban);
            this.Controls.Add(this.txttensp);
            this.Controls.Add(this.lblmasp);
            this.Controls.Add(this.lbltensp);
            this.Controls.Add(this.lblsoluongban);
            this.Controls.Add(this.cbonv);
            this.Controls.Add(this.mskngay);
            this.Controls.Add(this.lblnhanvien);
            this.Controls.Add(this.lblthoigian);
            this.Name = "Baocaocuoingay";
            this.Text = "Baocaocuoingay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Baocaocuoingay_FormClosing);
            this.Load += new System.EventHandler(this.Baocaocuoingay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridbccn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtmabaocao;
        private System.Windows.Forms.Label lblmabaocao;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.DataGridView dgridbccn;
        private System.Windows.Forms.TextBox txtdoanhthu;
        private System.Windows.Forms.Label lbldoanhthu;
        private System.Windows.Forms.TextBox txtsoluongban;
        private System.Windows.Forms.TextBox txttensp;
        private System.Windows.Forms.Label lblmasp;
        private System.Windows.Forms.Label lbltensp;
        private System.Windows.Forms.Label lblsoluongban;
        private System.Windows.Forms.MaskedTextBox mskngay;
        private System.Windows.Forms.Label lblnhanvien;
        private System.Windows.Forms.Label lblthoigian;
        private System.Windows.Forms.ComboBox cbonv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbosp;
        private System.Windows.Forms.TextBox txtsoluongnhap;
        private System.Windows.Forms.Label lblsln;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Label lblbaocao;
        private System.Windows.Forms.ComboBox cbotimkiem;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.TextBox txttongdoanhthu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtgianhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtgiaban;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttongtiennhap;
        private System.Windows.Forms.Label lbltongtienhang;
        private System.Windows.Forms.TextBox txttongtienban;
        private System.Windows.Forms.Label label5;
    }
}