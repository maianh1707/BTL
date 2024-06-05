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
    public partial class GiamGia : Form
    {
        public GiamGia()
        {
            InitializeComponent();
        }
        DataTable tblgiamgia;
        private void GiamGia_Load(object sender, EventArgs e)
        {
            txtma.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT magiamgia, tengiamgia, giatrigiam, ngaybatdau, ngayketthuc, dieukien,soluong,trangthai FROM tblgiamgia";
            tblgiamgia = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblgiamgia;
            DataGridView.Columns[0].HeaderText = "Mã giảm giá";
            DataGridView.Columns[1].HeaderText = "Tên giảm giá";
            DataGridView.Columns[2].HeaderText = "Giá trị giảm";
            DataGridView.Columns[3].HeaderText = "Ngày bắt đầu";
            DataGridView.Columns[4].HeaderText = "Ngày kết thúc";
            DataGridView.Columns[5].HeaderText = "Điều kiện";
            DataGridView.Columns[6].HeaderText = "Số lượng";
            DataGridView.Columns[7].HeaderText = "Trạng thái";
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click_1(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtma.Focus();
                return;
            }
            if (tblgiamgia.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtma.Text = DataGridView.CurrentRow.Cells["magiamgia"].Value.ToString();
            txtten.Text = DataGridView.CurrentRow.Cells["tengiamgia"].Value.ToString();
            txtgt.Text = DataGridView.CurrentRow.Cells["giatrigiam"].Value.ToString();
            txtdk.Text = DataGridView.CurrentRow.Cells["dieukien"].Value.ToString();
            txtsl.Text = DataGridView.CurrentRow.Cells["soluong"].Value.ToString();
            txttt.Text = DataGridView.CurrentRow.Cells["trangthai"].Value.ToString();
            msknbd.Text = DataGridView.CurrentRow.Cells["ngaybatdau"].Value.ToString();
            msknkt.Text = DataGridView.CurrentRow.Cells["ngayketthuc"].Value.ToString();
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
            txtma.Enabled = true;
            txtma.Focus();
        }
        private void ResetValues()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtdk.Text = "";
            txtsl.Text = "";
            txttt.Text = "";
            msknbd.Text = "";
            msknkt.Text = "";
            txtgt.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtma.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Focus();
                return;
            }
            if (txtten.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtten.Focus();
                return;
            }
            if (txtgt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá trị giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgt.Focus();
                return;
            }
            if (msknbd.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày bắt đầu giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msknbd.Focus();
                return;
            }
            if (msknkt.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msknkt.Focus();
                return;
            }
            if (!Functions.IsDate(msknbd.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msknbd.Text = "";
                msknbd.Focus();
                return;
            }
            if (!Functions.IsDate(msknbd.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msknkt.Text = "";
                msknkt.Focus();
                return;
            }

            //if (!Functions.IsDate(mskNgaysinh.Text))
            //{
            //    MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    mskNgaysinh.Text = "";
            //    mskNgaysinh.Focus();
            //    return;
            //}
            if (txtdk.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điều kiện giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdk.Focus();
                return;
            }
            if (txttt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập trạng thái giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttt.Focus();
                return;
            }
            if (txtsl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsl.Focus();
                return;
            }
            sql = "SELECT magiamgia FROM tblgiamgia WHERE magiamgia=N'" + txtma.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã giảm giá này đã tồn tại, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Focus();
                txtma.Text = "";
                return;
            }
            sql = "INSERT INTO tblgiamgia(magiamgia,tengiamgia,giatrigiam,ngaybatdau,ngayketthuc, dieukien,soluong,trangthai) VALUES(N'" + txtma.Text.Trim() + "', N'" + txtten.Text.Trim() + "', '" + txtgt.Text.Trim() + "', '" + Class.Functions.ConvertDateTime(msknbd.Text) + "','" + Class.Functions.ConvertDateTime(msknkt.Text) + "','" + txtdk.Text.Trim() + "','" + txtsl.Text.Trim() + "',N'" + txttt.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtma.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblgiamgia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtma.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtten.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtten.Focus();
                return;
            }
            if (txtgt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá trị giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgt.Focus();
                return;
            }
            if (msknbd.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày bắt đầu giảm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msknbd.Focus();
                return;
            }
            if (msknkt.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msknkt.Focus();
                return;
            }
            if (!Functions.IsDate(msknbd.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msknbd.Text = "";
                msknbd.Focus();
                return;
            }
            if (!Functions.IsDate(msknbd.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msknkt.Text = "";
                msknkt.Focus();
                return;
            }

            if (txtdk.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điều kiện giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdk.Focus();
                return;
            }
            if (txttt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập trạng thái giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttt.Focus();
                return;
            }
            if (txtsl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsl.Focus();
                return;
            }
            // sql = "UPDATE tblgiamgia SET tengiamgia=N'" + txtten.Text.Trim().ToString() + "',giatrigiam='" + txtgt.Text.ToString() + "',ngaybatdau='" + msknbd.Text.ToString() + "',ngayketthuc='" + msknkt.Text.ToString() + "',dieukien='" + txtdk.Text.ToString() + "',soluong='" + txtsl.Text.ToString() + "',trangthai='" + txttt.Text.ToString() + "' WHERE magiamgia=N'" + txtma.Text.Trim().ToString() + "'";
            sql = "UPDATE tblgiamgia SET tengiamgia=N'"+txtten.Text.Trim().ToString()+"',giatrigiam='"+txtgt.Text+"',ngaybatdau='"+msknbd.Text.ToString()+"',ngayketthuc='"+msknkt.Text.ToString()+"',dieukien='"+txtdk.Text.ToString()+"',soluong='"+txtsl.Text.ToString()+"',trangthai='"+txttt.Text.ToString()+"'WHERE magiamgia=N'"+txtma.Text.Trim().ToString()+"'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblgiamgia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtma.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblgiamgia WHERE magiamgia=N'" + txtma.Text + "'";
                Functions.RunSqlDel(sql);
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
            txtma.Enabled = false;
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
