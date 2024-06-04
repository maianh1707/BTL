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
    public partial class frmNhanvien : Form
    {
        DataTable tblnhanvien;
        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            txtManhanvien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            Functions.FillCombo("SELECT macv, tencv FROM tblchucvu", cboChucvu, "macv", "tencv");
            cboChucvu.SelectedIndex = -1;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT manv, tennv, gioitinh, diachi, dienthoai, ngaysinh, macv FROM tblnhanvien";
            tblnhanvien = Functions.GetDataToTable(sql);
            DataGridViewNhanVien.DataSource = tblnhanvien;
            DataGridViewNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            DataGridViewNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            DataGridViewNhanVien.Columns[2].HeaderText = "Giới tính";
            DataGridViewNhanVien.Columns[3].HeaderText = "Địa chỉ";
            DataGridViewNhanVien.Columns[4].HeaderText = "Số điện thoại";
            DataGridViewNhanVien.Columns[4].HeaderText = "Chức vụ";
            DataGridViewNhanVien.Columns[5].HeaderText = "Ngày sinh";
            DataGridViewNhanVien.AllowUserToAddRows = false;
            DataGridViewNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridViewNhanVien_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManhanvien.Focus();
                return;
            }
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtManhanvien.Text = DataGridViewNhanVien.CurrentRow.Cells["manv"].Value.ToString();
            txtTennhanvien.Text = DataGridViewNhanVien.CurrentRow.Cells["tennv"].Value.ToString();
            if (DataGridViewNhanVien.CurrentRow.Cells["gioitinh"].Value.ToString() == "Nam")
                chkNam.Checked = true;
            else
                chkNam.Checked = false;
            if (DataGridViewNhanVien.CurrentRow.Cells["gioitinh"].Value.ToString() == "Nữ")
                chkNu.Checked = true;
            else
                chkNu.Checked = false;
            txtDiachi.Text = DataGridViewNhanVien.CurrentRow.Cells["diachi"].Value.ToString();
            mskSdt.Text = DataGridViewNhanVien.CurrentRow.Cells["dienthoai"].Value.ToString();
            mskNgaysinh.Text = DataGridViewNhanVien.CurrentRow.Cells["ngaysinh"].Value.ToString();
            ma = DataGridViewNhanVien.CurrentRow.Cells["macv"].Value.ToString();
            cboChucvu.Text = Functions.GetFieldValues("SELECT tencv FROM tblchucvu WHERE macv =N'" + ma + "'");
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
            txtManhanvien.Enabled = true;
            txtManhanvien.Focus();
        }
        private void ResetValues()
        {
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            chkNam.Checked = false;
            chkNu.Checked = false;
            txtDiachi.Text = "";
            mskNgaysinh.Text = "";
            mskSdt.Text = "";
            cboChucvu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtManhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskSdt.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSdt.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if (cboChucvu.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucvu.Focus();
                return;
            }    
            if (chkNam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "SELECT manv FROM tblnhanvien WHERE manv=N'" + txtManhanvien.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                txtManhanvien.Text = "";
                return;
            }
            sql = "INSERT INTO tblnhanvien(manv,tennv,gioitinh, diachi, dienthoai, ngaysinh, macv) VALUES(N'" + txtManhanvien.Text.Trim() + "', N'" + txtTennhanvien.Text.Trim() + "', N'" + gt + "', N'" + txtDiachi.Text.Trim() + "', '" + mskSdt.Text + "', '" + Functions.ConvertDateTime(mskNgaysinh.Text) + "','" + cboChucvu.SelectedValue.ToString() + "')"; ;
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtManhanvien.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskSdt.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSdt.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if (cboChucvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucvu.Focus();
                return;
            }

            if (chkNam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE tblnhanvien SET  tennv=N'" +txtTennhanvien.Text.Trim().ToString() +
                    "',diachi=N'" + txtDiachi.Text.Trim().ToString() +
                    "',dienthoai='" + mskSdt.Text.ToString() + "',gioitinh=N'" + gt +
                    "',ngaysinh='" + Functions.ConvertDateTime(mskNgaysinh.Text)+
                    cboChucvu.SelectedValue.ToString() +
                    "' WHERE manv=N'" + txtManhanvien.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnhanvien WHERE manv=N'" + txtManhanvien.Text + "'";
                Functions.RunSql(sql);
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
            txtManhanvien.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
