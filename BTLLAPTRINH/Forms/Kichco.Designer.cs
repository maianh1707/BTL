namespace BTLLAPTRINH.Forms
{
    partial class Kichco
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
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnboqua = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.dgridco = new System.Windows.Forms.DataGridView();
            this.txttenco = new System.Windows.Forms.TextBox();
            this.txtmaco = new System.Windows.Forms.TextBox();
            this.lbltenco = new System.Windows.Forms.Label();
            this.lblmaco = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgridco)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsua
            // 
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnsua.Location = new System.Drawing.Point(236, 485);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(83, 41);
            this.btnsua.TabIndex = 21;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxoa.Location = new System.Drawing.Point(373, 485);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(83, 41);
            this.btnxoa.TabIndex = 20;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnluu
            // 
            this.btnluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnluu.Location = new System.Drawing.Point(506, 485);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(83, 41);
            this.btnluu.TabIndex = 19;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnboqua
            // 
            this.btnboqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnboqua.Location = new System.Drawing.Point(639, 485);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Size = new System.Drawing.Size(83, 41);
            this.btnboqua.TabIndex = 18;
            this.btnboqua.Text = "Bỏ qua";
            this.btnboqua.UseVisualStyleBackColor = true;
            this.btnboqua.Click += new System.EventHandler(this.btnboqua_Click);
            // 
            // btndong
            // 
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btndong.Location = new System.Drawing.Point(765, 485);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(83, 41);
            this.btndong.TabIndex = 17;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnthem
            // 
            this.btnthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthem.Location = new System.Drawing.Point(97, 485);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(83, 41);
            this.btnthem.TabIndex = 16;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dgridco
            // 
            this.dgridco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridco.Location = new System.Drawing.Point(352, 293);
            this.dgridco.Name = "dgridco";
            this.dgridco.Size = new System.Drawing.Size(256, 138);
            this.dgridco.TabIndex = 15;
            this.dgridco.Click += new System.EventHandler(this.dgridco_Click);
            // 
            // txttenco
            // 
            this.txttenco.Location = new System.Drawing.Point(331, 202);
            this.txttenco.Multiline = true;
            this.txttenco.Name = "txttenco";
            this.txttenco.Size = new System.Drawing.Size(322, 51);
            this.txttenco.TabIndex = 14;
            // 
            // txtmaco
            // 
            this.txtmaco.Location = new System.Drawing.Point(331, 110);
            this.txtmaco.Multiline = true;
            this.txtmaco.Name = "txtmaco";
            this.txtmaco.Size = new System.Drawing.Size(322, 51);
            this.txtmaco.TabIndex = 13;
            // 
            // lbltenco
            // 
            this.lbltenco.AutoSize = true;
            this.lbltenco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltenco.Location = new System.Drawing.Point(220, 218);
            this.lbltenco.Name = "lbltenco";
            this.lbltenco.Size = new System.Drawing.Size(57, 20);
            this.lbltenco.TabIndex = 12;
            this.lbltenco.Text = "Tên cỡ";
            // 
            // lblmaco
            // 
            this.lblmaco.AutoSize = true;
            this.lblmaco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblmaco.Location = new System.Drawing.Point(220, 124);
            this.lblmaco.Name = "lblmaco";
            this.lblmaco.Size = new System.Drawing.Size(52, 20);
            this.lblmaco.TabIndex = 11;
            this.lblmaco.Text = "Mã cỡ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(379, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 37);
            this.label1.TabIndex = 22;
            this.label1.Text = "KÍCH CỠ";
            // 
            // Kichco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 610);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnboqua);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgridco);
            this.Controls.Add(this.txttenco);
            this.Controls.Add(this.txtmaco);
            this.Controls.Add(this.lbltenco);
            this.Controls.Add(this.lblmaco);
            this.Name = "Kichco";
            this.Text = "Kichco";
            this.Load += new System.EventHandler(this.Kichco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnboqua;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.DataGridView dgridco;
        private System.Windows.Forms.TextBox txttenco;
        private System.Windows.Forms.TextBox txtmaco;
        private System.Windows.Forms.Label lbltenco;
        private System.Windows.Forms.Label lblmaco;
        private System.Windows.Forms.Label label1;
    }
}