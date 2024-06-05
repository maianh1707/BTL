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
    public partial class Khachhang : Form
    {
        public Khachhang()
        {
            InitializeComponent();
        }
        private void Khachhang_Load(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmakh.Enabled = false;
            load_dgrid();
        }
        DataTable tblkh;
        private void load_dgrid()
        {
            string sql;
            sql = "select * from tblkhachhang";
            tblkh = Class.Function.GetDataToTable(sql);
            dgridkh.DataSource = tblkh;
            dgridkh.Columns[0].HeaderText = "Mã khách hàng";
            dgridkh.Columns[1].HeaderText = "Tên khách hàng";
            dgridkh.Columns[2].HeaderText = "Địa chỉ";
            dgridkh.Columns[3].HeaderText = "Điện thoại";
            dgridkh.AllowUserToAddRows = false;
            dgridkh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridkh_Click(object sender, EventArgs e)
        {
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtmakh.Text = dgridkh.CurrentRow.Cells["makh"].Value.ToString();
            txttenkh.Text = dgridkh.CurrentRow.Cells["tenkh"].Value.ToString();
            txtdiachi.Text = dgridkh.CurrentRow.Cells["diachi"].Value.ToString();
            mskdienthoai.Text = dgridkh.CurrentRow.Cells["dienthoai"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            btnluu.Enabled = true;
            btnboqua.Enabled = true;
            txtmakh.Enabled = true;
            reset();
        }
        private void reset()
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            mskdienthoai.Text = "(   )    -";
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            txtmakh.Enabled = false;
            reset();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmakh.Focus();
                return;
            }
            if (txttenkh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenkh.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (mskdienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "select makh from tblkhachhang where makh='" + txtmakh.Text + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmakh.Focus();
                txtmakh.Text = "";
                return;
            }
            sql = "insert into tblkhachhang(makh,tenkh,diachi,dienthoai)values(N'" + txtmakh.Text.Trim() + "',N'" + txttenkh.Text.Trim() + "',N'" + txtdiachi.Text + "','" + mskdienthoai.Text + "')";
            Class.Function.RunSql(sql);
            load_dgrid();
            reset();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmakh.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "update tblkhachhang set tenkh=N'" + txttenkh.Text.Trim() + "', diachi=N'" + txtdiachi.Text.Trim() + "',dienthoai='" + mskdienthoai.Text + "' where makh=N'" + txtmakh.Text + "'";
            Class.Function.RunSql(sql);
            load_dgrid();
            reset();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            string sql;
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) 
            {
                sql = "delete tblkhachhang where makh=N'" + txtmakh.Text + "'";
                Class.Function.RunSql(sql);
                load_dgrid();
                reset();
            }   
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
