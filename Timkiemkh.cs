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
    public partial class Timkiemkh : Form
    {
        public Timkiemkh()
        {
            InitializeComponent();
        }

        private void Timkiemkh_Load(object sender, EventArgs e)
        {
            txtmakh.Enabled = false;
            load_grid();
        }
        DataTable tbltkkh;
        private void load_grid()
        {
            string sql;
            sql = "select * from tblkhachhang";
            tbltkkh = Class.Function.GetDataToTable(sql);
            dgridkh.DataSource = tbltkkh;
            dgridkh.Columns[0].HeaderText = "Mã khách hàng";
            dgridkh.Columns[1].HeaderText = "Tên khách hàng";
            dgridkh.Columns[2].HeaderText = "Địa chỉ";
            dgridkh.Columns[3].HeaderText = "Số điện thoại";
            dgridkh.AllowUserToAddRows = false;
            dgridkh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void resetvalue()
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            mskdienthoai.Text = "(   )    -";
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txttenkh.Text == "") && (txtmakh.Text=="") && (txtdiachi.Text=="") && (mskdienthoai.Text== "(   )    -"))
            {
                MessageBox.Show("Nhập một điều kiện để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "select * from tblkhachhang where 1=1";
            if (txttenkh.Text != "") sql = sql + "and tenkh like N'%" + txttenkh.Text + "%'";
            if (txtmakh.Text != "") sql = sql + "and makh like N'%" + txtmakh.Text+ "%'";
            if (txtdiachi.Text != "") sql = sql + "and diachi like N'%" + txtdiachi.Text + "%'";
            if (mskdienthoai.Text != "(   )    -") sql = sql + "and dienthoai like N'%" + mskdienthoai.Text + "%'";

            tbltkkh = Class.Function.GetDataToTable(sql);
            if (tbltkkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có" + tbltkkh.Rows.Count + " bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgridkh.DataSource = tbltkkh;
            resetvalue();
        }
    }
}
