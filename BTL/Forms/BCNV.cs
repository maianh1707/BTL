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
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace BTL
{
    public partial class BCNV : Form
    {
        public BCNV()
        {
            InitializeComponent();
        }
        System.Data.DataTable bcnv;


        private void BCNV_Load(object sender, EventArgs e)
        {
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            msktime.Text = DateTime.Now.ToString("");
            msktime.Enabled = false;      

          //  sql = "SELECT a.manv, tennv, SUM(tongthanhtoan) FROM tblnhanvien a INNER JOIN tblhoadonban b ON a.manv = b.manv WHERE YEAR(b.ngayban) = '" + txtnam.Text + "' AND MONTH(b.ngayban) = '" + cbothang.Text + "' GROUP BY a.manv, tennv;";

           sql = "SELECT tblnhanvien.manv,tennv,sum(tongtien) FROM tblhoadonban join tblnhanvien on tblhoadonban.manv=tblnhanvien.manv group by tblnhanvien.manv,tennv";
            bcnv = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = bcnv;

            //do dl tu bang vao datagridview
            DataGridView.Columns[0].HeaderText = "Mã nhân viên";
            DataGridView.Columns[1].HeaderText = "Tên nhân viên";
            DataGridView.Columns[2].HeaderText = "Tổng tiền hàng";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 140;
            DataGridView.Columns[2].Width = 100;
            

            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            if (txtthang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tháng cần xuất dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtthang.Focus();
                return; // Dừng việc thực hiện tiếp theo
            }

            if (txtnam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm cần xuất dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnam.Focus();
                return; // Dừng việc thực hiện tiếp theo
            }

            if (bcnv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Khai báo thư viện COM Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;

           
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; // Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; // Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng quần áo";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0388207555";
            
            exRange = exSheet.Range["C2:E2"];
            exRange.Font.Size = 16;
            exRange.Font.Bold = true;
            exRange.Font.ColorIndex = 3; // Màu đỏ
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "BÁO CÁO NHÂN VIÊN";

            // Thiết lập thông tin "Báo cáo tháng/năm"
            exRange = exSheet.Range["C3:E3"];
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "Báo cáo tháng " + txtthang.Text + "/ " + txtnam.Text;


            // Lấy thông tin CHO bảng
            //// Tạo truy vấn SQL để lấy dữ liệu
            //string sql = "SELECT a.manv, a.tennv, SUM(b.tongtien) AS Tongtien FROM tblnhanvien a INNER JOIN tblhoadonban b ON a.manv = b.manv WHERE YEAR(b.ngayban) = " + nam + " AND MONTH(b.ngayban) = " + thang + " GROUP BY a.manv, a.tennv";

            //// Lấy dữ liệu vào DataTable
            // bcnv = Functions.GetDataToTable(sql);

            //// Hiển thị dữ liệu trong DataGridView
            //DataGridView.DataSource = bcnv;

            //// Cập nhật dữ liệu trong bảng
            //Class.Functions.RunSql(sql);


            exRange = exSheet.Range["c8:f8"];

            // Thiết lập các thuộc tính cho ô Range
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Columns.AutoFit();

            // Thiết lập kích thước cột cho ô Range
            exSheet.Columns["C"].ColumnWidth = 5; // Cột A
            exSheet.Columns["D"].ColumnWidth = 15; // Cột B
            exSheet.Columns["E"].ColumnWidth = 20; // Cột C
            exSheet.Columns["F"].ColumnWidth = 15; // Cột D

            // Đặt nội dung cho các ô tiêu đề
            exSheet.Cells[8, 3].Value = "STT";
            exSheet.Cells[8, 4].Value = "Mã nhân viên";
            exSheet.Cells[8, 5].Value = "Tên nhân viên";
            exSheet.Cells[8, 6].Value = "Tổng tiền";


            int nv = 0; int cot = 0;
            // Bắt đầu việc đặt dữ liệu từ ô C9
            int startRow = 9;

            // Điền thông tin hàng hóa và thêm đường viền
            for (nv = 0; nv < bcnv.Rows.Count; nv++)
            {
                // Điền số thứ tự vào cột 3 từ dòng startRow
                exSheet.Cells[startRow + nv, 3].Value = nv + 1;
                for (cot = 0; cot < bcnv.Columns.Count; cot++)
                {
                    // Gán dữ liệu vào ô tương ứng (cột bắt đầu từ cột 4)
                    exSheet.Cells[startRow + nv, cot + 4].Value = bcnv.Rows[nv][cot].ToString();
                }
            }

            // Thêm đường viền cho dữ liệu bảng
            exRange = exSheet.Range["C8:F" + (nv + 8).ToString()];
            exRange.Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;

            // Thêm thông tin ngày tháng 
            exRange = exSheet.Cells[5][nv + 11]; // Ô A1
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime now = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + now.Day + " tháng " + now.Month + " năm " + now.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên tạo báo cáo";
            //exRange.Range["A6:C6"].MergeCells = true;
            //exRange.Range["A6:C6"].Font.Italic = true;
            //exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            //exRange.Range["A6:C6"].Value = bcnv.Rows[0][2].ToString();

            exSheet.Name = "Báo cáo nhân viên";
            exApp.Visible = true;

        }

        private void btnhien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtthang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtthang.Focus();
                return;
            }

            if (txtnam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnam.Focus();
                return;
            }

            // Lấy tháng và năm từ TextBox
            int thang = int.Parse(txtthang.Text);
            int nam = int.Parse(txtnam.Text);

            // Kiểm tra tháng hợp lệ
            if (thang < 1 || thang > 12)
            {
                MessageBox.Show("Tháng không hợp lệ. Vui lòng nhập tháng từ 1 đến 12", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtthang.Focus();
                return;
            }

            // Lấy ngày hiện tại
            DateTime now = DateTime.Now;

            // Tạo ngày tháng được nhập
            DateTime ngayNhap = new DateTime(nam, thang, 1);

            // Kiểm tra ngày tháng nhập có quá thời gian hiện tại
            if (ngayNhap > now)
            {
                MessageBox.Show("Tháng và năm nhập không thể sau tháng và năm hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtthang.Focus();
                return;
            }

            // Tạo truy vấn SQL để lấy dữ liệu
            string sql = "SELECT a.manv, a.tennv, SUM(b.tongtien) AS Tongtien FROM tblnhanvien a INNER JOIN tblhoadonban b ON a.manv = b.manv WHERE YEAR(b.ngayban) = " + nam + " AND MONTH(b.ngayban) = " + thang + " GROUP BY a.manv, a.tennv";

            // Lấy dữ liệu vào DataTable
             bcnv = Functions.GetDataToTable(sql);

            // Hiển thị dữ liệu trong DataGridView
            DataGridView.DataSource = bcnv;

            // Cập nhật dữ liệu trong bảng
            Class.Functions.RunSql(sql);
        }
    }
}
