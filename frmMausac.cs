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

namespace BTL.Forms
{
    public partial class frmMausac : Form
    {
        public frmMausac()
        {
            InitializeComponent();
        }
        DataTable tblmau;
        private void frmMausac_Load(object sender, EventArgs e)
        {
            txtMamau.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT mamau, tenmau FROM tblmau";
            tblmau = Class.Functions.GetDataToTable(sql);
            DataGridViewMauSac.DataSource=tblmau;

            DataGridViewMauSac.Columns[0].HeaderText = "Mã màu";
            DataGridViewMauSac.Columns[1].HeaderText = "Tên màu";
            DataGridViewMauSac.AllowUserToAddRows = false;
            DataGridViewMauSac.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void DataGridViewMauSac_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMamau.Focus();
                return;
            }
            if (tblmau.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMamau.Text = DataGridViewMauSac.CurrentRow.Cells["mamau"].Value.ToString();
            txtTenmau.Text = DataGridViewMauSac.CurrentRow.Cells["tenmau"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMamau.Enabled = true;
            txtMamau.Focus();

        }
        private void ResetValues()
        {
            txtMamau.Text = "";
            txtTenmau.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamau.Focus();
                return;
            }
            if (txtTenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmau.Focus();
                return;
            }
            sql = "SELECT mamau FROM tblmau WHERE mamau=N'" + txtMamau.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamau.Focus();
                txtMamau.Text = "";
                return;
            }
            sql = "INSERT INTO tblmau(mamau, tenmau) VALUES(N'" + txtMamau.Text + "',N'" + txtTenmau.Text + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMamau.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblmau.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmau.Focus();
                return;
            }
            sql = "UPDATE tblmau SET tenmau=N'" + txtTenmau.Text.ToString() + "'WHERE mamau=N'" + txtMamau.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblmau.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblmau WHERE mamau=N'" + txtMamau.Text + "'";
                Class.Functions.RunSql(sql);
                Load_DataGridView();
                ResetValues();

            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMamau.Enabled = false;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
