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


namespace baitaplon.Forms
{
    public partial class chatlieu : Form
    {
        public chatlieu()
        {
            InitializeComponent();
        }

        private void chatlieu_Load(object sender, EventArgs e)
        {
            txtmachatlieu.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            Load_DataGridView();
        }
        DataTable tblcl;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT machatlieu,tenchatlieu FROM tblchatlieu";
            tblcl = Class.Functions.GetDataToTable(sql);
            dgridchatlieu.DataSource = tblcl;
            dgridchatlieu.Columns[0].HeaderText = "Mã chất liệu";
            dgridchatlieu.Columns[1].HeaderText = "Tên chất liệu";
            dgridchatlieu.Columns[0].Width = 150;
            dgridchatlieu.Columns[1].Width = 400;
            dgridchatlieu.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgridchatlieu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridchatlieu_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmachatlieu.Focus();
                return;
            }
            if (tblcl.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmachatlieu.Text = dgridchatlieu.CurrentRow.Cells["machatlieu"].Value.ToString();
            txttenchatlieu.Text = dgridchatlieu.CurrentRow.Cells["tenchatlieu"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmachatlieu.Enabled = true;
            txtmachatlieu.Focus();
        }
        private void ResetValues()
        {
            txtmachatlieu.Text = "";
            txttenchatlieu.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmachatlieu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmachatlieu.Focus();
                return;
            }
            if (txttenchatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenchatlieu.Focus();
                return;
            }
            sql = "SELECT machatlieu FROM tblchatlieu WHERE machatlieu=N'" + txtmachatlieu.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmachatlieu.Focus();
                txtmachatlieu.Text = "";
                return;
            }
            sql = "INSERT INTO tblchatlieu(machatlieu,tenchatlieu) VALUES(N'" + txtmachatlieu.Text + "',N'" + txttenchatlieu.Text + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmachatlieu.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblcl.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmachatlieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenchatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenchatlieu.Focus();
                return;
            }
            sql = "UPDATE tblchatlieu SET tenchatlieu=N'" + txttenchatlieu.Text.ToString() + "' WHERE machatlieu=N'" + txtmachatlieu.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblcl.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmachatlieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblchatlieu WHERE machatlieu=N'" + txtmachatlieu.Text + "'";
                Class.Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmachatlieu.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
