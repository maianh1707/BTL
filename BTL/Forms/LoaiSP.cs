using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class LoaiSP : Form
    {
        public LoaiSP()
        {
            InitializeComponent();
        }
        DataTable tbllsp;
        private void LoaiSP_Load(object sender, EventArgs e)
        {
            txtmaloai.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT maloai, tenloai FROM tblloai";
            tbllsp = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tbllsp;

            //do dl tu bang vao datagridview

            DataGridView.Columns[0].HeaderText = "Mã loại sản phẩm";
            DataGridView.Columns[1].HeaderText = "Tên loại sản phẩm";
            
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaloai.Focus();
                return;
            }
            if (tbllsp.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaloai.Text = DataGridView.CurrentRow.Cells["maloai"].Value.ToString();
            txttenloai.Text = DataGridView.CurrentRow.Cells["tenloai"].Value.ToString();
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
            txtmaloai.Enabled = true;
            txttenloai.Focus();

        }
        private void ResetValues()
        {
            txtmaloai.Text = "";
            txttenloai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmaloai.Text =="")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloai.Focus();
                return;
            }
            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }
            sql = "SELECT maloai FROM tblloai WHERE maloai=N'" +txtmaloai.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloai.Focus();
                txttenloai.Text = "";
                return;
            }
            sql = "INSERT INTO tblloai(maloai,tenloai) VALUES(N'" +txtmaloai.Text + "',N'" + txttenloai.Text + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaloai.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbllsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtmaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }
            sql = "UPDATE tblloai SET tenloai=N'" + txttenloai.Text.ToString() +"' WHERE maloai=N'" + txtmaloai.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbllsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtmaloai.Text))
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    // Xóa các bản ghi liên quan trong bảng sản phẩm
                    sql = "DELETE FROM tblsanpham WHERE maloai = N'" + txtmaloai.Text + "'";
                    Class.Functions.RunSqlDel(sql);

                    // Sau đó xóa bản ghi trong bảng loại sản phẩm
                    sql = "DELETE FROM tblloai WHERE maloai = N'" + txtmaloai.Text + "'";
                    Class.Functions.RunSqlDel(sql);

                    // Tải lại dữ liệu và đặt lại các giá trị
                    Load_DataGridView();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            txtmaloai.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
