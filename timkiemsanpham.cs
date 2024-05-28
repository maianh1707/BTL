using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using baitaplon.Class;

namespace baitaplon.Forms
{
    public partial class timkiemsanpham : Form
    {
        public timkiemsanpham()
        {
            InitializeComponent();
        }

        private void timkiemsanpham_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgridtimkiemsanpham.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtmasanpham.Focus();
        }
        DataTable tblsp;

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmasanpham.Text == "") && (txttensanpham.Text == "") && (txtmaloai.Text == "") &&
               (txtmaco.Text == "") && (txtmachatlieu.Text == "") &&
               (txtmamau.Text == "") && (txtmamua.Text == "") &&
               (txtmancc.Text == "") && (txtdongianhap.Text == "")&&
               (txtsoluong.Text == "") &&(txtdongiaban.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblsanpham WHERE 1=1";
            if (txtmasanpham.Text != "")
                sql = sql + " AND masanpham Like N'%" + txtmasanpham.Text + "%'";
            if (txttensanpham.Text != "")
                sql = sql + " AND tensanpham Like N'%" + txttensanpham.Text + "%'";
            if (txtmaloai.Text != "")
                sql = sql + " AND maloai Like N'%" + txtmaloai.Text + "%'";
            if (txtmaco.Text != "")
                sql = sql + " AND maco Like N'%" + txtmaco.Text + "%'";
            if (txtmachatlieu.Text != "")
                sql = sql + " AND machatlieu Like N'%" + txtmachatlieu.Text + "%'";
            if (txtmamau.Text != "")
                sql = sql + " AND mamau Like N'%" + txtmamau.Text + "%'";
            if (txtmamua.Text != "")
                sql = sql + " AND mamua Like N'%" + txtmamua.Text + "%'";
            if (txtmancc.Text != "")
                sql = sql + " AND mancc Like N'%" + txtmancc.Text + "%'";
            if (txtsoluong.Text != "")
                sql = sql + " AND soluong <=" + txtsoluong.Text;
            if (txtdongianhap.Text != "")
                sql = sql + " AND dongianhap <=" + txtdongianhap.Text;
            if (txtdongiaban.Text != "")
                sql = sql + " AND dongiaban <=" + txtdongiaban.Text;
            tblsp = Functions.GetDataToTable(sql);
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblsp.Rows.Count + " bản ghi thỏa mãn điều kiện!!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridtimkiemsanpham.DataSource = tblsp;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            dgridtimkiemsanpham.Columns[0].HeaderText = "Mã sản phẩm";
            dgridtimkiemsanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dgridtimkiemsanpham.Columns[2].HeaderText = "Số lượng";
            dgridtimkiemsanpham.Columns[3].HeaderText = "Ảnh";
            dgridtimkiemsanpham.Columns[4].HeaderText = "Đơn giá nhập";
            dgridtimkiemsanpham.Columns[5].HeaderText = "Đơn giá bán";
            dgridtimkiemsanpham.Columns[6].HeaderText = "Mã loại";
            dgridtimkiemsanpham.Columns[7].HeaderText = "Mã cỡ";
            dgridtimkiemsanpham.Columns[8].HeaderText = "Mã chất liệu";
            dgridtimkiemsanpham.Columns[9].HeaderText = "Mã màu";
            dgridtimkiemsanpham.Columns[10].HeaderText = "Mã mùa";
            dgridtimkiemsanpham.Columns[11].HeaderText = "Mã nhà cung cấp";
            dgridtimkiemsanpham.Columns[0].Width = 80;
            dgridtimkiemsanpham.Columns[1].Width = 100;
            dgridtimkiemsanpham.Columns[2].Width = 80;
            dgridtimkiemsanpham.Columns[3].Width = 80;
            dgridtimkiemsanpham.Columns[4].Width = 80;
            dgridtimkiemsanpham.Columns[5].Width = 80;
            dgridtimkiemsanpham.Columns[6].Width = 80;
            dgridtimkiemsanpham.Columns[7].Width = 80;
            dgridtimkiemsanpham.Columns[8].Width = 80;
            dgridtimkiemsanpham.Columns[9].Width = 80;
            dgridtimkiemsanpham.Columns[10].Width = 80;
            dgridtimkiemsanpham.Columns[11].Width = 80;
            dgridtimkiemsanpham.AllowUserToAddRows = false;
            dgridtimkiemsanpham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridtimkiemsanpham.DataSource = null;
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtdongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtdongiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}



