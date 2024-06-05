using BTL.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms
{
    public partial class frmTimkiemHDNhap : Form
    {
        DataTable tblhoadonnhap;
        public frmTimkiemHDNhap()
        {
            InitializeComponent();
        }

        private void frmTimkiemHDNhap_Load(object sender, EventArgs e)
        {
            ResetValues();
            DataGridViewTimKiemHDNhap.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDNhap.Focus();
        }

        

        private void Load_DataGridView()
        {
            DataGridViewTimKiemHDNhap.Columns[0].HeaderText = "Mã hoá đơn nhập";
            DataGridViewTimKiemHDNhap.Columns[1].HeaderText = "Mã nhân viên nhập";
            DataGridViewTimKiemHDNhap.Columns[2].HeaderText = "Ngày nhập";
            DataGridViewTimKiemHDNhap.Columns[3].HeaderText = "Mã nhà cung cấp";
            DataGridViewTimKiemHDNhap.Columns[4].HeaderText = "Tổng tiền";
            DataGridViewTimKiemHDNhap.Columns[4].HeaderText = "Chiết khấu";
            DataGridViewTimKiemHDNhap.AllowUserToAddRows = false;
            DataGridViewTimKiemHDNhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimkiemlai_Click(object sender, EventArgs e)
        {
          
            ResetValues();
            DataGridViewTimKiemHDNhap.DataSource = null;
            
        }
        private void txtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtChietkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDNhap.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtMaNVNhap.Text == "") && (txtMaNCC.Text == "") &&
               (txtTongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHDBan WHERE 1=1";
            if (txtMaHDNhap.Text != "")
                sql = sql + " AND mahdn Like N'%" + txtMaHDNhap.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(ngaynhap) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(ngaynhap) =" + txtNam.Text;
            if (txtMaNVNhap.Text != "")
                sql = sql + " AND manv Like N'%" + txtMaNVNhap.Text + "%'";
            if (txtMaNCC.Text != "")
                sql = sql + " AND mancc Like N'%" + txtMaNCC.Text + "%'";
            if (txtTongtien.Text != "")
                sql = sql + " AND tongthanhtoan <=" + txtTongtien.Text;
            if (txtChietkhau.Text != "")
                sql = sql + " AND chietkhau <=" + txtChietkhau.Text;
            tblhoadonnhap = Functions.GetDataToTable(sql);
            if (tblhoadonnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblhoadonnhap.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridViewTimKiemHDNhap.DataSource = tblhoadonnhap;
            Load_DataGridView();
        }
    }
}
