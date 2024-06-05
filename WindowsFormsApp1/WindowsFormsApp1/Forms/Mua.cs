using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class Mua : Form
    {
        public Mua()
        {
            InitializeComponent();
        }

        private void Mua_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            txtmamua.Enabled = false;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            load_grid();
        }
        DataTable tblmua;

        private void load_grid()
        {
            string sql = "SELECT mamua, tenmua FROM tblmua";
            tblmua = Class.Function.GetDataToTable(sql);
            dgridmua.DataSource = tblmua;
            dgridmua.Columns[0].HeaderText = "Mã mùa";
            dgridmua.Columns[1].HeaderText = "Tên mùa";
            dgridmua.AllowUserToAddRows = false;
            dgridmua.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridmua_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblmua.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtmamua.Text = dgridmua.CurrentRow.Cells["mamua"].Value.ToString();
            txttenmua.Text = dgridmua.CurrentRow.Cells["tenmua"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnboqua.Enabled = true;
            txtmamua.Enabled = true;
            txtmamua.Focus();
            resetvalue();
        }
        private void resetvalue()
        {
            txtmamua.Text = "";
            txttenmua.Text = "";
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            resetvalue();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            txtmamua.Enabled = false;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmamua.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã mùa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmamua.Focus();
                return;
            }
            if (txttenmua.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên mùa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenmua.Focus();
                return;
            }
            sql = "select mamua from tblmua where mamua=N'" + txtmamua.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã mùa này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmamua.Focus();
                txtmamua.Text = "";
                return;
            }
            sql = "insert into tblmua(mamua,tenmua)values(N'" + txtmamua.Text.Trim() + "',N'" + txttenmua.Text.Trim() + "')";
            Class.Function.RunSql(sql);
            load_grid();
            resetvalue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmamua.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblmua.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmamua.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txttenmua.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên mùa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenmua.Focus();
                return;
            }
            sql = "UPDATE tblmua SET tenmua = N'" + txttenmua.Text.Trim() + "' WHERE mamua = N'" + txtmamua.Text.Trim() + "'";
            Class.Function.RunSql(sql);
            load_grid();
            resetvalue();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblmua.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmamua.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Check for related rows in tbinhanvien
                sql = "SELECT COUNT(*) FROM tblmua WHERE mamua = N'" + txtmamua.Text.Trim() + "'";
                int count = (int)Class.Function.GetScalarValue(sql);
                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa vì có dữ liệu liên quan trong tblsanpham", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Delete the row in tblchucvu
                    sql = "DELETE FROM tblmua WHERE mamua = N'" + txtmamua.Text.Trim() + "'";
                    Class.Function.RunSql(sql);

                    load_grid();
                    resetvalue();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
