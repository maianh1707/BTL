using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;


namespace WindowsFormsApp1.Forms
{
    public partial class Baocaodanhsachbanhang : Form
    {
        public Baocaodanhsachbanhang()
        {
            InitializeComponent();
        }
        DataTable tbhdb, tbsp;
        private void Baocaodanhsachbanhang_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            Function.FillCombo("select mahdb from tblhoadonban", cbbmahdb, "mahdb", "mahdb");
            Function.FillCombo("select tensanpham from tblsanpham", cbbtensp, "tensanpham", "tensanpham");
            Function.FillCombo("select tenkh from tblkhachhang", cbbkhachhang, "tenkh", "tenkh");
            Function.FillCombo("select tennv from tblnhanvien ", cbbnvban, "tennv", "tennv");
            cbbmahdb.SelectedIndex = -1;
            cbbtensp.SelectedIndex = -1;
            cbbkhachhang.SelectedIndex = -1;
            cbbnvban.SelectedIndex = -1;
            grbkhoang.Enabled = false;
            mskngayban.Enabled = false;
        }
        

            private void load_datagrvidsb(string sql)
            {

            tbsp = Function.GetDataToTable(sql);
            dtgrvdsb.DataSource = tbsp;
            // Thiết lập các cột cho DataGridView
            dtgrvdsb.Columns[0].HeaderText = "Sản phẩm";
            dtgrvdsb.Columns[1].HeaderText = "Mã màu";
            dtgrvdsb.Columns[2].HeaderText = "Mã cỡ";
            dtgrvdsb.Columns[3].HeaderText = "Số lượng bán";
            dtgrvdsb.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        

        private void load_datagrvid(string sql)
        {
            tbhdb = Function.GetDataToTable(sql);
            dtgrvidcthdb.DataSource = tbhdb;
            // Thiết lập các cột cho DataGridView
            dtgrvidcthdb.Columns[0].HeaderText = "Mã hoá đơn";
            dtgrvidcthdb.Columns[1].HeaderText = "Tên sản phẩm";
            dtgrvidcthdb.Columns[2].HeaderText = "Mã sản phẩm";
            dtgrvidcthdb.Columns[3].HeaderText = "Số lượng bán ";
            dtgrvidcthdb.Columns[4].HeaderText = "Đơn giá bán";
            dtgrvidcthdb.Columns[5].HeaderText = "Giảm giá";
            dtgrvidcthdb.Columns[6].HeaderText = "Thành tiền";
            dtgrvidcthdb.Columns[7].HeaderText = "Ngày bán";
            dtgrvidcthdb.Columns[8].HeaderText = "Tên Khách hàng";
            dtgrvidcthdb.Columns[9].HeaderText = "Tên nhân viên bán ";
            dtgrvidcthdb.Columns[10].HeaderText = "Mã cỡ";
            dtgrvidcthdb.Columns[11].HeaderText = "Mã màu";
            dtgrvidcthdb.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


       
        private void reset()
        {
            cbbmahdb.SelectedIndex = -1;
            cbbtensp.SelectedIndex = -1;
            cbbkhachhang.SelectedIndex = -1;
            cbbnvban.SelectedIndex = -1;
            txtdongiaban.Text = "";
            mskngayban.Text = "  /  /";
            msktungay.Text = "  /  /";
            mskdenngay.Text = "  /  /";
        }

        //private void bthienthi_Click(object sender, EventArgs e)
        //{
        //    load_datagrvid("select * from dsban");
        //    load_datagrvidsb("select tensanpham, sum(soluong), maco, mamau from dsban group by tensanpham, mamau, maco order by sum(soluong) desc");
        //    reset();

        //}

        private void btin_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem DataGridViews có dữ liệu hay không
            if (dtgrvidcthdb.Rows.Count == 0 || dtgrvdsb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            int hang = 0, cot = 0;

            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];

            // Định dạng tiêu đề
            exRange.Range["E10:G10"].Font.Size = 14;
            exRange.Range["E10:G10"].Font.Name = "Times New Roman";
            exRange.Range["E10:G10"].Font.Bold = true;
            exRange.Range["E10:G10"].Font.ColorIndex = 3; // Màu đỏ
            exRange.Range["E10:G10"].MergeCells = true;
            exRange.Range["E10:G10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E10:G10"].Value = "Danh sách Bán hàng";

            // Định dạng cột tiêu đề cho bảng dtgrvidcthdb
            exRange.Range["A12:K12"].Font.Bold = true;
            exRange.Range["A12:K12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].Value = "Mã hoá đơn";
            exRange.Range["B12:B12"].ColumnWidth = 20;
            exRange.Range["C12:C12"].Value = "Tên sản phẩm";
            exRange.Range["C12:C12"].ColumnWidth = 20;
            exRange.Range["D12:D12"].Value = "Mã sản phẩm";
            exRange.Range["D12:D12"].ColumnWidth = 15;
            exRange.Range["E12:E12"].Value = "Số lượng Bán";
            exRange.Range["E12:E12"].ColumnWidth = 14;
            exRange.Range["F12:F12"].Value = "Đơn giá bán";
            exRange.Range["F12:F12"].ColumnWidth = 20;
            exRange.Range["G12:G12"].Value = "Khuyến mãi";
            exRange.Range["G12:G12"].ColumnWidth = 9.5;
            exRange.Range["H12:H12"].Value = "Thành tiền";
            exRange.Range["H12:H12"].ColumnWidth = 20;
            exRange.Range["I12:I12"].Value = "Ngày bán";
            exRange.Range["I12:I12"].ColumnWidth = 9.5;
            exRange.Range["J12:J12"].Value = "Tên khách hàng";
            exRange.Range["J12:J12"].ColumnWidth = 20;
            exRange.Range["K12:K12"].Value = "Tên nhân viên bán";
            exRange.Range["K12:K12"].ColumnWidth = 20;

            // In dữ liệu từ DataGridView dtgrvidcthdb
            for (int row = 0; row < dtgrvidcthdb.Rows.Count; row++)
            {
                exSheet.Cells[row + 13, 1] = row + 1; // Số thứ tự
                for (int col = 0; col < dtgrvidcthdb.Columns.Count; col++)
                {
                    DataGridViewCell cell = dtgrvidcthdb.Rows[row].Cells[col];
                    if (cell.Value != null)
                    {
                        exSheet.Cells[row + 13, col + 2] = cell.Value.ToString();
                    }
                }
            }

            // Định dạng cột tiêu đề cho bảng dtgrvdsb
            exRange.Range["L12:Q12"].Font.Bold = true;
            exRange.Range["L12:Q12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["L12:L12"].Value = "STT";
            exRange.Range["M12:M12"].Value = "Tên sản Phẩm";
            exRange.Range["M12:M12"].ColumnWidth = 20;
            exRange.Range["N12:N12"].Value = "Số lượng bán";
            exRange.Range["N12:N12"].ColumnWidth = 20;
            exRange.Range["O12:O12"].Value = "Mã màu";
            exRange.Range["O12:O12"].ColumnWidth = 20;
            exRange.Range["P12:P12"].Value = "Mã cỡ";
            exRange.Range["P12:P12"].ColumnWidth = 20;

            // In dữ liệu từ DataGridView dtgrvdsb
            for (int row = 0; row < dtgrvdsb.Rows.Count; row++)
            {
                exSheet.Cells[row + 13, 1] = row + 1; // Số thứ tự
                for (int col = 0; col < dtgrvdsb.Columns.Count; col++)
                {
                    DataGridViewCell cell = dtgrvdsb.Rows[row].Cells[col];
                    if (cell.Value != null)
                    {
                        exSheet.Cells[row + 13, col + 12] = cell.Value.ToString();
                    }
                }
            }

            exApp.Visible = true;

        }

        private void rdobtkhoang_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdobtkhoang.Checked == true)
                grbkhoang.Enabled = true;
            else
            {
                grbkhoang.Enabled = false;
                msktungay.Text = "";
                mskdenngay.Text = "";
            }
        }

        private void txtdongiaban_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void bttim_Click_1(object sender, EventArgs e)
        {
            string sql, sql1;
            // Kiểm tra xem có ít nhất một dữ liệu được nhập không
            if (cbbmahdb.SelectedValue == null && cbbtensp.SelectedValue == null && txtdongiaban.Text == "" && mskngayban.Text == "  /  /" && cbbkhachhang.SelectedValue == null && cbbnvban.SelectedValue == null && msktungay.Text == "  /  /" && mskdenngay.Text == "  /  /")
            {
                MessageBox.Show("Hãy nhập ít nhất 1 dữ liệu để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thiết lập câu truy vấn ban đầu
            sql = "select * from dsban where 1=1";
            // Thêm điều kiện vào câu truy vấn nếu có dữ liệu đã được chọn hoặc nhập
            if (cbbmahdb.SelectedValue != null)
            {
                sql += " and mahdb = N'" + cbbmahdb.SelectedValue.ToString() + "'";
            }
            if (cbbtensp.SelectedValue != null)
            {
                sql += " and tensanpham = N'" + cbbtensp.SelectedValue.ToString() + "'";
            }
            if (txtdongiaban.Text != "")
            {
                sql += " and giaban = " + txtdongiaban.Text;
            }
            if (mskngayban.Text != "  /  /")
            {
                if (!Function.IsDate(mskngayban.Text))
                {
                    MessageBox.Show("Hãy nhập lại ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskngayban.Focus();
                    mskngayban.Text = "";
                    return;
                }
                sql += " and ngayban = '" + Function.ConvertDateTime(mskngayban.Text) + "'";
            }
            if (msktungay.Text != "  /  /" && mskdenngay.Text != "  /  /")
            {
                if (!Function.IsDate(msktungay.Text))
                {
                    MessageBox.Show("Hãy nhập lại từ ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msktungay.Focus();
                    msktungay.Text = "";
                    return;
                }
                if (!Function.IsDate(mskdenngay.Text))
                {
                    MessageBox.Show("Hãy nhập lại đến ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskdenngay.Focus();
                    mskdenngay.Text = "";
                    return;
                }
                if (DateTime.ParseExact(msktungay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(mskdenngay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msktungay.Focus();
                    return;
                }
                sql += " and ngayban between '" + Function.ConvertDateTime(msktungay.Text) + "' and '" + Function.ConvertDateTime(mskdenngay.Text) + "'";
            }
            if (cbbkhachhang.SelectedValue != null)
            {
                sql += " and tenkh = N'" + cbbkhachhang.SelectedValue.ToString() + "'";
            }
            if (cbbnvban.SelectedValue != null)
            {
                sql += " and tennv = N'" + cbbnvban.SelectedValue.ToString() + "'";
            }

            // Lấy dữ liệu từ cơ sở dữ liệu dựa trên điều kiện đã chọn
            DataTable tbbchdb = Function.GetDataToTable(sql);
            // Kiểm tra xem có bản ghi nào phù hợp không
            if (tbbchdb.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Load dữ liệu lên DataGridView
                dtgrvidcthdb.DataSource = tbbchdb;
                // Thiết lập câu truy vấn cho DataGridView phụ
                sql1 = "select tensanpham, mamau, maco, sum(soluong) from dsban where 1=1";
                if (cbbmahdb.SelectedValue != null)
                {
                    sql1 += " and mahdb = N'" + cbbmahdb.SelectedValue.ToString() + "'";
                }
                if (cbbtensp.SelectedValue != null)
                {
                    sql1 += " and tensanpham = N'" + cbbtensp.SelectedValue.ToString() + "'";
                }
                if (txtdongiaban.Text != "")
                {
                    sql1 += " and dongia = " + txtdongiaban.Text;
                }
                if (mskngayban.Text != "  /  /")
                {
                    sql1 += " and ngayban = '" + Function.ConvertDateTime(mskngayban.Text) + "'";
                }
                if (msktungay.Text != "  /  /" && mskdenngay.Text != "  /  /")
                {
                    sql1 += " and ngayban between '" + Function.ConvertDateTime(msktungay.Text) + "' and '" + Function.ConvertDateTime(mskdenngay.Text) + "'";
                }
                if (cbbkhachhang.SelectedValue != null)
                {
                    sql1 += " and tenkh = N'" + cbbkhachhang.SelectedValue.ToString() + "'";
                }
                if (cbbnvban.SelectedValue != null)
                {
                    sql1 += " and tennv = N'" + cbbnvban.SelectedValue.ToString() + "'";
                }
                sql1 += " group by tensanpham, mamau, maco order by sum(soluong) desc";

                DataTable tbsp = Function.GetDataToTable(sql1);
                dtgrvdsb.DataSource = tbsp;
            }
        }

        private void rdobtngay_CheckedChanged_1(object sender, EventArgs e)
        {

            if (rdobtngay.Checked == true)
                mskngayban.Enabled = true;
            else
            {
                mskngayban.Enabled = false;
                mskngayban.Text = "";
            }
        }

        
    }
}
