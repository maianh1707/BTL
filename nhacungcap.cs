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
    public partial class nhacungcap : Form
    {
        public nhacungcap()
        {
            InitializeComponent();
        }

        private void nhacungcap_Load(object sender, EventArgs e)
        {
            txtmancc.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            Load_DataGridView();
        }
        DataTable tblncc;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT mancc, tenncc, diachi, dienthoai FROM tblnhacungcap";
            tblncc = Functions.GetDataToTable(sql);
            dgridnhacungcap.DataSource = tblncc;
            dgridnhacungcap.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgridnhacungcap.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgridnhacungcap.Columns[2].HeaderText = "Địa chỉ";
            dgridnhacungcap.Columns[3].HeaderText = "Điện thoại";
            dgridnhacungcap.Columns[0].Width = 100;
            dgridnhacungcap.Columns[1].Width = 150;
            dgridnhacungcap.Columns[2].Width = 150;
            dgridnhacungcap.Columns[3].Width = 150;
            dgridnhacungcap.AllowUserToAddRows = false;
            dgridnhacungcap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridnhacungcap_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmancc.Focus();
                return;
            }
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmancc.Text = dgridnhacungcap.CurrentRow.Cells["mancc"].Value.ToString();
            txttenncc.Text = dgridnhacungcap.CurrentRow.Cells["tenncc"].Value.ToString();
            txtdiachi.Text = dgridnhacungcap.CurrentRow.Cells["diachi"].Value.ToString();
            mskdienthoai.Text = dgridnhacungcap.CurrentRow.Cells["dienthoai"].Value.ToString();
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
            txtmancc.Enabled = true;
            txtmancc.Focus();
        }
        private void ResetValues()
        {
            txtmancc.Text = "";
            txttenncc.Text = "";
            txtdiachi.Text = "";
            mskdienthoai.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmancc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmancc.Focus();
                return;
            }
            if (txttenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenncc.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mskdienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskdienthoai.Focus();
                return;
            }
            sql = "SELECT mancc FROM tblnhacungcap WHERE mancc=N'" + txtmancc.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmancc.Focus();
                txtmancc.Text = "";
                return;
            }
            sql = "INSERT INTO tblnhacungcap(mancc,tenncc,diachi,dienthoai) VALUES (N'" + txtmancc.Text.Trim() + "',N'" + txttenncc.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" + mskdienthoai.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmancc.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenncc.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mskdienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskdienthoai.Focus();
                return;
            }
            sql = "UPDATE tblnhacungcap SET  tenncc=N'" + txttenncc.Text.Trim().ToString()
                  + "',diachi=N'" + txtdiachi.Text.Trim().ToString() + "',dienthoai='" +
                mskdienthoai.Text.ToString() + "' WHERE mancc=N'" + txtmancc.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnhacungcap WHERE mancc=N'" + txtmancc.Text + "'";
                Functions.RunSqlDel(sql);
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
            txtmancc.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
