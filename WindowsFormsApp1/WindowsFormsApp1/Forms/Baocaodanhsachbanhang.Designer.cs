namespace WindowsFormsApp1.Forms
{
    partial class Baocaodanhsachbanhang
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
            this.grbkhoang = new System.Windows.Forms.GroupBox();
            this.mskdenngay = new System.Windows.Forms.MaskedTextBox();
            this.msktungay = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rdobtkhoang = new System.Windows.Forms.RadioButton();
            this.rdobtngay = new System.Windows.Forms.RadioButton();
            this.cbbkhachhang = new System.Windows.Forms.ComboBox();
            this.cbbnvban = new System.Windows.Forms.ComboBox();
            this.txtdongiaban = new System.Windows.Forms.TextBox();
            this.bttim = new System.Windows.Forms.Button();
            this.cbbtensp = new System.Windows.Forms.ComboBox();
            this.cbbmahdb = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mskngayban = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgrvidcthdb = new System.Windows.Forms.DataGridView();
            this.dtgrvdsb = new System.Windows.Forms.DataGridView();
            this.btin = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grbkhoang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvidcthdb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvdsb)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grbkhoang);
            this.groupBox1.Controls.Add(this.rdobtkhoang);
            this.groupBox1.Controls.Add(this.rdobtngay);
            this.groupBox1.Controls.Add(this.cbbkhachhang);
            this.groupBox1.Controls.Add(this.cbbnvban);
            this.groupBox1.Controls.Add(this.txtdongiaban);
            this.groupBox1.Controls.Add(this.bttim);
            this.groupBox1.Controls.Add(this.cbbtensp);
            this.groupBox1.Controls.Add(this.cbbmahdb);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mskngayban);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1402, 282);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "tìm kiếm ";
            // 
            // grbkhoang
            // 
            this.grbkhoang.Controls.Add(this.mskdenngay);
            this.grbkhoang.Controls.Add(this.msktungay);
            this.grbkhoang.Controls.Add(this.label2);
            this.grbkhoang.Controls.Add(this.label9);
            this.grbkhoang.Location = new System.Drawing.Point(901, 34);
            this.grbkhoang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbkhoang.Name = "grbkhoang";
            this.grbkhoang.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbkhoang.Size = new System.Drawing.Size(472, 48);
            this.grbkhoang.TabIndex = 29;
            this.grbkhoang.TabStop = false;
            // 
            // mskdenngay
            // 
            this.mskdenngay.Location = new System.Drawing.Point(282, 12);
            this.mskdenngay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mskdenngay.Mask = "00/00/0000";
            this.mskdenngay.Name = "mskdenngay";
            this.mskdenngay.Size = new System.Drawing.Size(170, 26);
            this.mskdenngay.TabIndex = 24;
            this.mskdenngay.ValidatingType = typeof(System.DateTime);
            // 
            // msktungay
            // 
            this.msktungay.Location = new System.Drawing.Point(63, 14);
            this.msktungay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.msktungay.Mask = "00/00/0000";
            this.msktungay.Name = "msktungay";
            this.msktungay.Size = new System.Drawing.Size(170, 26);
            this.msktungay.TabIndex = 21;
            this.msktungay.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Đến";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Từ";
            // 
            // rdobtkhoang
            // 
            this.rdobtkhoang.AutoSize = true;
            this.rdobtkhoang.Location = new System.Drawing.Point(764, 45);
            this.rdobtkhoang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdobtkhoang.Name = "rdobtkhoang";
            this.rdobtkhoang.Size = new System.Drawing.Size(127, 24);
            this.rdobtkhoang.TabIndex = 28;
            this.rdobtkhoang.TabStop = true;
            this.rdobtkhoang.Text = "Theo khoảng";
            this.rdobtkhoang.UseVisualStyleBackColor = true;
            this.rdobtkhoang.CheckedChanged += new System.EventHandler(this.rdobtkhoang_CheckedChanged_1);
            // 
            // rdobtngay
            // 
            this.rdobtngay.AutoSize = true;
            this.rdobtngay.Location = new System.Drawing.Point(764, 101);
            this.rdobtngay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdobtngay.Name = "rdobtngay";
            this.rdobtngay.Size = new System.Drawing.Size(112, 24);
            this.rdobtngay.TabIndex = 27;
            this.rdobtngay.TabStop = true;
            this.rdobtngay.Text = "Theo ngày ";
            this.rdobtngay.UseVisualStyleBackColor = true;
            this.rdobtngay.CheckedChanged += new System.EventHandler(this.rdobtngay_CheckedChanged_1);
            // 
            // cbbkhachhang
            // 
            this.cbbkhachhang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbkhachhang.FormattingEnabled = true;
            this.cbbkhachhang.Location = new System.Drawing.Point(506, 42);
            this.cbbkhachhang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbkhachhang.Name = "cbbkhachhang";
            this.cbbkhachhang.Size = new System.Drawing.Size(170, 28);
            this.cbbkhachhang.TabIndex = 18;
            // 
            // cbbnvban
            // 
            this.cbbnvban.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbnvban.FormattingEnabled = true;
            this.cbbnvban.Location = new System.Drawing.Point(506, 91);
            this.cbbnvban.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbnvban.Name = "cbbnvban";
            this.cbbnvban.Size = new System.Drawing.Size(170, 28);
            this.cbbnvban.TabIndex = 17;
            // 
            // txtdongiaban
            // 
            this.txtdongiaban.Location = new System.Drawing.Point(506, 149);
            this.txtdongiaban.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdongiaban.Name = "txtdongiaban";
            this.txtdongiaban.Size = new System.Drawing.Size(170, 26);
            this.txtdongiaban.TabIndex = 16;
            this.txtdongiaban.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdongiaban_KeyPress_1);
            // 
            // bttim
            // 
            this.bttim.Location = new System.Drawing.Point(1215, 212);
            this.bttim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttim.Name = "bttim";
            this.bttim.Size = new System.Drawing.Size(138, 51);
            this.bttim.TabIndex = 7;
            this.bttim.Text = "Tìm kiếm";
            this.bttim.UseVisualStyleBackColor = true;
            this.bttim.Click += new System.EventHandler(this.bttim_Click_1);
            // 
            // cbbtensp
            // 
            this.cbbtensp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbtensp.FormattingEnabled = true;
            this.cbbtensp.Location = new System.Drawing.Point(150, 88);
            this.cbbtensp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbtensp.Name = "cbbtensp";
            this.cbbtensp.Size = new System.Drawing.Size(170, 28);
            this.cbbtensp.TabIndex = 15;
            // 
            // cbbmahdb
            // 
            this.cbbmahdb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbmahdb.FormattingEnabled = true;
            this.cbbmahdb.Location = new System.Drawing.Point(150, 51);
            this.cbbmahdb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbmahdb.Name = "cbbmahdb";
            this.cbbmahdb.Size = new System.Drawing.Size(170, 28);
            this.cbbmahdb.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tên khách hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Nhân viên bán ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Đơn giá bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tên sản phẩm";
            // 
            // mskngayban
            // 
            this.mskngayban.Location = new System.Drawing.Point(964, 101);
            this.mskngayban.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mskngayban.Mask = "00/00/0000";
            this.mskngayban.Name = "mskngayban";
            this.mskngayban.Size = new System.Drawing.Size(170, 26);
            this.mskngayban.TabIndex = 8;
            this.mskngayban.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hoá đơn";
            // 
            // dtgrvidcthdb
            // 
            this.dtgrvidcthdb.AllowUserToAddRows = false;
            this.dtgrvidcthdb.AllowUserToDeleteRows = false;
            this.dtgrvidcthdb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrvidcthdb.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgrvidcthdb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvidcthdb.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtgrvidcthdb.Location = new System.Drawing.Point(21, 389);
            this.dtgrvidcthdb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgrvidcthdb.Name = "dtgrvidcthdb";
            this.dtgrvidcthdb.RowHeadersWidth = 51;
            this.dtgrvidcthdb.RowTemplate.Height = 24;
            this.dtgrvidcthdb.Size = new System.Drawing.Size(1159, 275);
            this.dtgrvidcthdb.TabIndex = 11;
            // 
            // dtgrvdsb
            // 
            this.dtgrvdsb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrvdsb.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgrvdsb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvdsb.Location = new System.Drawing.Point(1239, 389);
            this.dtgrvdsb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgrvdsb.Name = "dtgrvdsb";
            this.dtgrvdsb.RowHeadersWidth = 51;
            this.dtgrvdsb.RowTemplate.Height = 24;
            this.dtgrvdsb.Size = new System.Drawing.Size(512, 275);
            this.dtgrvdsb.TabIndex = 14;
            // 
            // btin
            // 
            this.btin.Location = new System.Drawing.Point(1226, 693);
            this.btin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btin.Name = "btin";
            this.btin.Size = new System.Drawing.Size(148, 51);
            this.btin.TabIndex = 16;
            this.btin.Text = "In báo cáo ";
            this.btin.UseVisualStyleBackColor = true;
            this.btin.Click += new System.EventHandler(this.btin_Click);
            // 
            // Baocaodanhsachbanhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1763, 772);
            this.Controls.Add(this.btin);
            this.Controls.Add(this.dtgrvdsb);
            this.Controls.Add(this.dtgrvidcthdb);
            this.Controls.Add(this.groupBox1);
            this.Name = "Baocaodanhsachbanhang";
            this.Text = "Baocaodanhsachbanhang";
            this.Load += new System.EventHandler(this.Baocaodanhsachbanhang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbkhoang.ResumeLayout(false);
            this.grbkhoang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvidcthdb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvdsb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbkhoang;
        private System.Windows.Forms.MaskedTextBox mskdenngay;
        private System.Windows.Forms.MaskedTextBox msktungay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdobtkhoang;
        private System.Windows.Forms.RadioButton rdobtngay;
        private System.Windows.Forms.ComboBox cbbkhachhang;
        private System.Windows.Forms.ComboBox cbbnvban;
        private System.Windows.Forms.TextBox txtdongiaban;
        private System.Windows.Forms.Button bttim;
        private System.Windows.Forms.ComboBox cbbtensp;
        private System.Windows.Forms.ComboBox cbbmahdb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mskngayban;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgrvidcthdb;
        private System.Windows.Forms.DataGridView dtgrvdsb;
        private System.Windows.Forms.Button btin;
    }
}