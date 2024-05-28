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
    public partial class Chucvu : Form
    {
        public Chucvu()
        {
            InitializeComponent();
        }

        private void Chucvu_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            txtmacv.Enabled = false;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            load_grid();
        }
        DataTable tblcv;
     
        private void load_grid()
        {
            string sql = "SELECT macv, tencv FROM tblchucvu";
            tblcv = Class.Function.GetDataToTable(sql);
            dgridchucvu.DataSource = tblcv;
            dgridchucvu.Columns[0].HeaderText = "Mã chức vụ";
            dgridchucvu.Columns[1].HeaderText = "Tên chức vụ";
            dgridchucvu.AllowUserToAddRows = false;
            dgridchucvu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridchucvu_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblcv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtmacv.Text = dgridchucvu.CurrentRow.Cells["macv"].Value.ToString();
            txttencv.Text = dgridchucvu.CurrentRow.Cells["tencv"].Value.ToString();
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
            txtmacv.Enabled = true;
            txtmacv.Focus();
            resetvalue();
        }
        private void resetvalue()
        {
            txtmacv.Text = "";
            txttencv.Text = "";
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            resetvalue();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            txtmacv.Enabled = false;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmacv.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmacv.Focus();
                return;
            }
            if (txttencv.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttencv.Focus();
                return;
            }
            sql = "select macv from tblchucvu where macv=N'" + txtmacv.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã chức vụ này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmacv.Focus();
                txtmacv.Text = "";
                return;
            }
            sql = "insert into tblchucvu(macv,tencv)values(N'" + txtmacv.Text.Trim() + "',N'" + txttencv.Text.Trim() + "')";
            Class.Function.RunSql(sql);
            load_grid();
            resetvalue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmacv.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblcv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmacv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txttencv.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttencv.Focus();
                return;
            }
            sql = "UPDATE tblchucvu SET tencv = N'" + txttencv.Text.Trim() + "' WHERE macv = N'" + txtmacv.Text.Trim() + "'";
            Class.Function.RunSql(sql);
            load_grid();
            resetvalue();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblcv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmacv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Check for related rows in tbinhanvien
                sql = "SELECT COUNT(*) FROM tblnhanvien WHERE macv = N'" + txtmacv.Text.Trim() + "'";
                int count = (int)Class.Function.GetScalarValue(sql);
                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa vì có dữ liệu liên quan trong tblnhanvien", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Delete the row in tblchucvu
                    sql = "DELETE FROM tblchucvu WHERE macv = N'" + txtmacv.Text.Trim() + "'";
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
