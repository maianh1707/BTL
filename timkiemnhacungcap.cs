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
    public partial class timkiemnhacungcap : Form
    {
        public timkiemnhacungcap()
        {
            InitializeComponent();
        }

        private void timkiemnhacungcap_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgridtimkiemncc.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtmancc.Focus();
        }
        DataTable tblncc;
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmancc.Text == "") && (txttenncc.Text == "") && (txtdiachi.Text == "") &&
               (txtdienthoai.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblnhacungcap WHERE 1=1";
            if (txtmancc.Text != "")
                sql = sql + " AND mancc Like N'%" + txtmancc.Text + "%'";
            if (txttenncc.Text != "")
                sql = sql + " AND tenncc Like N'%" + txttenncc.Text + "%'";
            if (txtdiachi.Text != "")
                sql = sql + " AND diachi Like N'%" + txtdiachi.Text + "%'";
            if (txtdienthoai.Text != "")
                sql = sql + " AND dienthoai Like N'%" + txtdienthoai.Text + "%'";
            tblncc = Functions.GetDataToTable(sql);
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblncc.Rows.Count + " bản ghi thỏa mãn điều kiện!!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridtimkiemncc.DataSource = tblncc;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            dgridtimkiemncc.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgridtimkiemncc.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgridtimkiemncc.Columns[2].HeaderText = "Địa chỉ";
            dgridtimkiemncc.Columns[3].HeaderText = "Điện thoại";
            dgridtimkiemncc.Columns[0].Width = 100;
            dgridtimkiemncc.Columns[1].Width = 150;
            dgridtimkiemncc.Columns[2].Width = 100;
            dgridtimkiemncc.Columns[3].Width = 100;
            dgridtimkiemncc.AllowUserToAddRows = false;
            dgridtimkiemncc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgridtimkiemncc.DataSource = null;
        }
        private void dgridtimkiemncc_DoubleClick(object sender, EventArgs e)
        {
            string mancc;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mancc = dgridtimkiemncc.CurrentRow.Cells["mancc"].Value.ToString();
                nhacungcap frm = new nhacungcap();
                frm.txtmancc.Text = mancc;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtdienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
