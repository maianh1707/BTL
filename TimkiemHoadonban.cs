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
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Forms
{
    public partial class frmTimHDBan : Form
    {
        public frmTimHDBan()
        {
            InitializeComponent();
        }
        DataTable tblHDB;
        private void frmTimHDBan_Load(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;
            DataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGridView_CellFormatting);


        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            mskngayban.Text = "";
            txtmahoadonban.Focus();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmahoadonban.Text == "") && (mskngayban.Text == "  /  /") &&
               (txtmanhanvien.Text == "") && (txtmakhachhang.Text == "") &&
               (txttongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT mahdb, manv, ngayban, makh, tongtien FROM tblhoadonban WHERE 1=1";

            if (txtmahoadonban.Text != "")
                sql += " AND mahdb Like N'%" + txtmahoadonban.Text + "%'";

            if (mskngayban.Text != "  /  /")
            {
                DateTime dateValue;
                if (DateTime.TryParseExact(mskngayban.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValue))
                {
                    sql += " AND CONVERT(date, ngayban, 111) = '" + dateValue.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    MessageBox.Show("Ngày bán không hợp lệ!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskngayban.Focus();
                    return;
                }
            }

            if (txtmanhanvien.Text != "")
                sql += " AND manv Like N'%" + txtmanhanvien.Text + "%'";

            if (txtmakhachhang.Text != "")
                sql += " AND makh Like N'%" + txtmakhachhang.Text + "%'";

            if (txttongtien.Text != "")
                sql += " AND tongtien <=" + txttongtien.Text;

            tblHDB = Function.GetDataToTable(sql);

            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            DataGridView.DataSource = tblHDB;
            Load_DataGridView();

        }
        private void Load_DataGridView()
        {
            DataGridView.Columns[0].HeaderText = "Mã HĐB";
            DataGridView.Columns[1].HeaderText = "Mã nhân viên";
            DataGridView.Columns[2].HeaderText = "Ngày bán";
            DataGridView.Columns[3].HeaderText = "Mã khách";
            DataGridView.Columns[4].HeaderText = "Tổng thanh toán";
            DataGridView.Columns[0].Width = 150;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 80;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;

        }

        private void txttongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = DataGridView.CurrentRow.Cells["mahdb"].Value.ToString();
                frmTimHDBan frm = new frmTimHDBan();
                frm.txtmahoadonban.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(DataGridView.Columns[e.ColumnIndex].Name == "ngayban" && e.Value != null)
            {
                DateTime dateValue;
                if (DateTime.TryParse(e.Value.ToString(), out dateValue))
                {
                    e.Value = dateValue.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
