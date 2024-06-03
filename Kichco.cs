using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLLAPTRINH.Forms
{
    public partial class Kichco : Form
    {
        public Kichco()
        {
            InitializeComponent();
        }

        private void Kichco_Load(object sender, EventArgs e)
        {
            txtmaco.Enabled = false;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            load_datagrid();
        }
        DataTable tblkc;
        private void load_datagrid()
        {
            string sql;
            sql = "select maco, tenco from tblco";
            tblkc = Class.Function.GetDataToTable(sql);
            dgridco.DataSource = tblkc;
            dgridco.Columns[0].HeaderText = "Mã cỡ";
            dgridco.Columns[1].HeaderText = "Tên cỡ";
            dgridco.AllowUserToAddRows = false;
            dgridco.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridco_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblkc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtmaco.Text = dgridco.CurrentRow.Cells["maco"].Value.ToString();
            txttenco.Text = dgridco.CurrentRow.Cells["tenco"].Value.ToString();
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
            txtmaco.Enabled = true;
            txtmaco.Focus();
            resetvalue();
        }
        private void resetvalue()
        {
            txtmaco.Text = "";
            txttenco.Text = "";
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            resetvalue();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            txtmaco.Enabled = false;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {

            string sql;
            if (txtmaco.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã cỡ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmaco.Focus();
                return;
            }
            if (txttenco.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên cỡ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenco.Focus();
                return;
            }
            sql = "select maco from tblco where maco=N'" + txtmaco.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã kích cỡ này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmaco.Focus();
                txtmaco.Text = "";
                return;
            }
            sql = "insert into tblco(maco,tenco)values(N'" + txtmaco.Text.Trim() + "',N'" + txttenco.Text.Trim() + "')";
            Class.Function.RunSql(sql);
            load_datagrid();
            resetvalue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmaco.Enabled = false;

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmaco.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txttenco.Text == "")
            {

                MessageBox.Show("Bạn phải nhập tên kích cỡ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenco.Focus();
                return;
            }
            sql = "update tblco set tenco=N'" + txttenco.Text.Trim() + "'where maco=N'" + txtmaco.Text + "'";
            Class.Function.RunSql(sql);
            load_datagrid();
            resetvalue();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmaco.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sql = "delete tblco where maco=N'" + txtmaco.Text + "' ";
                Class.Function.RunSql(sql);
                load_datagrid();
                resetvalue();
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
