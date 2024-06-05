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

namespace BTL
{
    public partial class TimKiemNV : Form
    {
        public TimKiemNV()
        {
            InitializeComponent();
        }
        DataTable tblnv;
        private void TimKiemNV_Load(object sender, EventArgs e)
        {
            
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT manv,tennv,gioitinh,ngaysinh,diachi,dienthoai FROM tblnhanvien";
            tblnv = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblnv;

            //do dl tu bang vao datagridview

            DataGridView.Columns[0].HeaderText = "Mã nhân viên";
            DataGridView.Columns[1].HeaderText = "Tên nhân viên";
            DataGridView.Columns[2].HeaderText = "Giới tính";
            DataGridView.Columns[3].HeaderText = "Ngày sinh";
            DataGridView.Columns[4].HeaderText = "Địa chỉ";
            DataGridView.Columns[5].HeaderText = "Số điện thoại";
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtma.Text = DataGridView.CurrentRow.Cells["maloai"].Value.ToString();
            txtten.Text = DataGridView.CurrentRow.Cells["tenloai"].Value.ToString();
            //btnSua.Enabled = true;
            //btnXoa.Enabled = true;
            //btnBoqua.Enabled = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtma.Text == "") && (txtten.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblnhanvien WHERE 1=1 ";
            if (txtma.Text != "")
                sql = sql + " AND manv Like N'%" + txtma.Text + "%'";
            if (txtten.Text != "")
                sql = sql + " AND tennv Like N'%" + txtten.Text + "%'";
            tblnv = Functions.GetDataToTable(sql);

            if (tblnv.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblnv.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblnv;
            ResetValues();
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT manv,tennv,gioitinh,ngaysinh,diachi,dienthoai FROM tblnhanvien";
            tblnv = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblnv;
        }
        private void ResetValues()
        {
            txtma.Text = "";
            txtten.Text = "";
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
