using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1.Forms
{
    public partial class Baocaothuchi : Form
    {
        public Baocaothuchi()
        {
            InitializeComponent();
        }
        // Xóa tất cả các dòng hiện có trong DataGridView
        private void ClearDataGridView()
        {
            dgridbctc.DataSource = null;
            dgridbctc.Rows.Clear();
        }
        private void Baocaothuchi_Load(object sender, EventArgs e)
        {
            // Các dòng sau để khởi tạo form như ban đầu
            Class.Function.Connect();
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnin.Enabled = false;
            btndong.Enabled = true;

            txttongdoanhthu.ReadOnly = true;
            txtchiphinhaphang.ReadOnly = true;
            txtchiphitraluong.ReadOnly = true;
            //txtchiphigiamgia.ReadOnly = true;
            txttongchiphi.ReadOnly = true;
            txtloinhuan.ReadOnly = true;

            txttongdoanhthu.Text = "0";
            txtchiphinhaphang.Text = "0";
            txtchiphitraluong.Text = "0";
            //txtchiphigiamgia.Text = "0";
            txttongchiphi.Text = "0";
            txtloinhuan.Text = "0";
            msktu.Text = "";
            mskden.Text = "";

            Function.FillCombo("SELECT manv, tennv FROM tblnhanvien", cbomanhanvien, "manv", "manv");
            cbomanhanvien.SelectedIndex = -1;

        }

        private void Load_DataGridView()
        {
            // Xóa dữ liệu hiện có trong DataGridView
            ClearDataGridView();

            // Load dữ liệu mới từ cơ sở dữ liệu
            string sql = "SELECT mabc, ngaytao, manv, tungay, denngay, tongdoanhthu, cpnhaphang, cptraluong, tongcp, loinhuan FROM tblbaocaothuchi";
            tblbctc = Function.GetDataToTable(sql);
            dgridbctc.DataSource = tblbctc;

            // Thiết lập tiêu đề và chiều rộng cho các cột trong DataGridView
            dgridbctc.Columns[0].HeaderText = "Mã báo cáo thu chi";
            dgridbctc.Columns[1].HeaderText = "Ngày tạo";
            dgridbctc.Columns[2].HeaderText = "Mã nhân viên";
            dgridbctc.Columns[3].HeaderText = "Ngày bắt đầu";
            dgridbctc.Columns[4].HeaderText = "Ngày kết thúc";
            dgridbctc.Columns[5].HeaderText = "Tổng doanh thu";
            dgridbctc.Columns[6].HeaderText = "Chi phí nhập hàng";
            dgridbctc.Columns[7].HeaderText = "Chi phí trả lương";
            dgridbctc.Columns[8].HeaderText = "Tổng chi phí";
            dgridbctc.Columns[9].HeaderText = "Lợi nhuận";

            // Thiết lập độ rộng cho các cột trong DataGridView
            dgridbctc.Columns[0].Width = 80;
            dgridbctc.Columns[1].Width = 140;
            dgridbctc.Columns[2].Width = 80;
            dgridbctc.Columns[3].Width = 80;
            dgridbctc.Columns[4].Width = 100;
            dgridbctc.Columns[5].Width = 100;
            dgridbctc.Columns[6].Width = 100;
            dgridbctc.Columns[7].Width = 100;
            dgridbctc.Columns[8].Width = 100;
            dgridbctc.Columns[9].Width = 100;

            dgridbctc.AllowUserToAddRows = false;
            dgridbctc.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        DataTable tblbctc;

        private void btntinh_Click(object sender, EventArgs e)
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ các ô nhập liệu trên giao diện
            DateTime tuNgay = DateTime.Parse(msktu.Text);
            DateTime denNgay = DateTime.Parse(mskden.Text);

            // Kết nối cơ sở dữ liệu và truy vấn để tính toán tổng doanh thu, chi phí nhập hàng và lương
            string connectionString = "Data Source=DESKTOP-4EAN90E\\SQLEXPRESS;Initial Catalog=LTNET;Integrated Security=True;Encrypt=False";
            string query = "SELECT ISNULL(SUM(tongtien), 0) AS tongDoanhThu FROM tblhoadonban WHERE ngayban BETWEEN @TuNgay AND @DenNgay;" +
                           "SELECT ISNULL(SUM(tongthanhtoan), 0) AS tongChiPhiNhapHang FROM tblhoadonnhap WHERE ngaynhap BETWEEN @TuNgay AND @DenNgay;" +
                           "SELECT ISNULL(SUM(luong), 0) AS tongChiPhiLuong FROM tblnhanvien;"; // Sửa truy vấn SQL

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                // Thêm tham số cho ngày bắt đầu và ngày kết thúc
                command.Parameters.AddWithValue("@TuNgay", tuNgay);
                command.Parameters.AddWithValue("@DenNgay", denNgay);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read(); // Đọc kết quả từ truy vấn đầu tiên
                        int tongDoanhThu = Convert.ToInt32(reader["tongDoanhThu"]);

                        // Đọc kết quả từ truy vấn thứ hai (cùng một SqlDataReader)
                        reader.NextResult();
                        reader.Read();
                        int tongChiPhiNhapHang = Convert.ToInt32(reader["tongChiPhiNhapHang"]);

                        // Đọc kết quả từ truy vấn thứ ba
                        reader.NextResult();
                        reader.Read();
                        int tongChiPhiLuong = Convert.ToInt32(reader["tongChiPhiLuong"]);

                        // Tính toán tổng chi phí và lợi nhuận
                        int tongChiPhi = tongChiPhiNhapHang + tongChiPhiLuong;
                        int loiNhuan = tongDoanhThu - tongChiPhi;

                        // Hiển thị các giá trị tính toán trên giao diện người dùng
                        txttongdoanhthu.Text = tongDoanhThu.ToString();
                        txtchiphinhaphang.Text = tongChiPhiNhapHang.ToString();
                        txtchiphitraluong.Text = tongChiPhiLuong.ToString();
                        txttongchiphi.Text = tongChiPhi.ToString();
                        txtloinhuan.Text = loiNhuan.ToString();

                        // Bật các nút "In báo cáo" và "Lưu"
                        btnin.Enabled = true;
                        btnluu.Enabled = true;
                    }
                    else
                    {
                        // Nếu không có dữ liệu, đặt giá trị mặc định là 0 và vô hiệu hóa các nút
                        txttongdoanhthu.Text = "0";
                        txtchiphinhaphang.Text = "0";
                        txtchiphitraluong.Text = "0";
                        txttongchiphi.Text = "0";
                        txtloinhuan.Text = "0";

                        // Vô hiệu hóa các nút "In báo cáo" và "Lưu"
                        btnin.Enabled = false;
                        btnluu.Enabled = false;
                    }
                }
            }

        }
        private void ResetValues()
        {
            txtmabc.Text = "";
            mskden.Text = "";
            mskngaytao.Text = "";
            msktu.Text = "";
            txttongdoanhthu.Text = "0";
            txtchiphinhaphang.Text = "0";
            txtchiphitraluong.Text = "0";
            //txtchiphigiamgia.Text = "0";
            txttongchiphi.Text = "0";
            txtloinhuan.Text = "0";


            cbomanhanvien.SelectedIndex = -1;
            mskngaytao.Text = "";
            msktu.Text = "";
            mskden.Text = "";
        }


        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnin.Enabled = false;
            btnthem.Enabled = false;

            ResetValues();

            txtmabc.Text = Function.CreateKey("HDTHN");
            mskngaytao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //Load_DataGridViewChitiet();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            // Kiểm tra các điều kiện đầu vào
            

            if (cbomanhanvien.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomanhanvien.Focus();
                return;
            }

            if (!DateTime.TryParseExact(mskngaytao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngayTao))
            {
                MessageBox.Show("Vui lòng nhập ngày tạo theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaytao.Focus();
                return;
            }

            // Kiểm tra nếu báo cáo đã tồn tại
            string sql = "SELECT mabc FROM tblbaocaothuchi WHERE mabc = N'" + txtmabc.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã báo cáo này đã tồn tại, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmabc.Focus();
                txtmabc.Text = "";
                return;
            }

            // Lưu dữ liệu vào cơ sở dữ liệu
            sql = "INSERT INTO tblbaocaothuchi(mabc, ngaytao, manv, tungay,denngay, tongdoanhthu, cpnhaphang, cptraluong, tongcp, loinhuan) VALUES(" +
                  "N'" + txtmabc.Text.Trim() + "'," +
                  "'" + Function.ConvertDateTime(mskngaytao.Text) + "'," +
                  "N'" + cbomanhanvien.SelectedValue.ToString() + "'," +
                  "'" + Function.ConvertDateTime(msktu.Text) + "'," +
                  "'" + Function.ConvertDateTime(mskden.Text) + "'," +
                  txttongdoanhthu.Text.Trim() + "," +
                  txtchiphinhaphang.Text.Trim() + "," +
                  txtchiphitraluong.Text.Trim() + "," +
                  txttongchiphi.Text.Trim() + "," +
                  txtloinhuan.Text.Trim() + ")";

            Function.RunSql(sql);

            // Refresh lại DataGridView
            Load_DataGridView();

            // Reset các nút và form
            btnhuy.Enabled = true;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            txtmabc.Enabled = false;
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            try
            {
                // Khai báo thư viện COM Excel
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook;
                COMExcel.Worksheet exSheet;
                COMExcel.Range exRange;
                int hang = 0, cot = 0;

                // Tạo một bảng dữ liệu để lưu trữ dữ liệu từ DataGridView
                DataTable tblThongtinBC = (DataTable)dgridbctc.DataSource;

                exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
                exSheet = exBook.Worksheets[1];

                // Định dạng chung cho báo cáo
                exRange = exSheet.Cells[1, 1];
                exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
                exRange.Range["A1:B3"].Font.Size = 10;
                exRange.Range["A1:B3"].Font.Bold = true;
                exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
                exRange.Range["A1:A1"].ColumnWidth = 7;
                exRange.Range["B1:B1"].ColumnWidth = 15;
                exRange.Range["A1:B1"].MergeCells = true;
                exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A1:B1"].Value = "Siêu thị Mini Mart";
                exRange.Range["A2:B2"].MergeCells = true;
                exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A2:B2"].Value = "Thạch Thất - Hà Nội";
                exRange.Range["A3:B3"].MergeCells = true;
                exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A3:B3"].Value = "Điện thoại: 0977040849";
                exRange.Range["C2:E2"].Font.Size = 16;
                exRange.Range["C2:E2"].Font.Bold = true;
                exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["C2:E2"].MergeCells = true;
                exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C2:E2"].Value = "BÁO CÁO THU CHI";

                // Tạo dòng tiêu đề bảng
                exRange.Range["A12:J12"].Font.Bold = true;
                exRange.Range["A12:J12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A12:J12"].ColumnWidth = 15;

                // Tiêu đề các cột
                exRange.Cells[12, 1] = "Mã báo cáo thu chi";
                exRange.Cells[12, 2] = "Ngày tạo";
                exRange.Cells[12, 3] = "Mã nhân viên";
                exRange.Cells[12, 4] = "Ngày bắt đầu";
                exRange.Cells[12, 5] = "Ngày kết thúc";
                exRange.Cells[12, 6] = "Tổng doanh thu";
                exRange.Cells[12, 7] = "Chi phí nhập hàng";
                exRange.Cells[12, 8] = "Chi phí trả lương";
                exRange.Cells[12, 9] = "Tổng chi phí";
                exRange.Cells[12, 10] = "Lợi nhuận";

                // Điền dữ liệu từ DataTable vào báo cáo Excel
                for (hang = 0; hang < tblThongtinBC.Rows.Count; hang++)
                {
                    exSheet.Cells[hang + 13, 1] = tblThongtinBC.Rows[hang]["mabc"].ToString();
                    exSheet.Cells[hang + 13, 2] = tblThongtinBC.Rows[hang]["ngaytao"].ToString();
                    exSheet.Cells[hang + 13, 3] = tblThongtinBC.Rows[hang]["manv"].ToString();
                    exSheet.Cells[hang + 13, 4] = tblThongtinBC.Rows[hang]["tungay"].ToString();
                    exSheet.Cells[hang + 13, 5] = tblThongtinBC.Rows[hang]["denngay"].ToString();
                    exSheet.Cells[hang + 13, 6] = tblThongtinBC.Rows[hang]["tongdoanhthu"].ToString();
                    exSheet.Cells[hang + 13, 7] = tblThongtinBC.Rows[hang]["cpnhaphang"].ToString();
                    exSheet.Cells[hang + 13, 8] = tblThongtinBC.Rows[hang]["cptraluong"].ToString();
                    exSheet.Cells[hang + 13, 9] = tblThongtinBC.Rows[hang]["tongcp"].ToString();
                    exSheet.Cells[hang + 13, 10] = tblThongtinBC.Rows[hang]["loinhuan"].ToString();
                }

                // Hiển thị ứng dụng Excel
                exApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }



        private void btnhuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnin.Enabled = false;
            btnthem.Enabled = true;
        }

        private void msktu_ValueChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayValues();
        }

        private void mskden_ValueChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayValues();
        }
        private void CalculateAndDisplayValues()
        {


            // Kiểm tra xem người dùng đã chọn ngày hợp lệ chưa
            DateTime tuNgay, denNgay;
            if (!DateTime.TryParseExact(msktu.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tuNgay) ||
                !DateTime.TryParseExact(mskden.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out denNgay))
            {
                MessageBox.Show("Vui lòng nhập ngày tháng theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // câu truy vấn để lấy dữ liệu từ CSDL
            string query = "SELECT " +
               "(SELECT ISNULL(SUM(tongtien), 0) FROM tblhoadonban WHERE ngayban BETWEEN '" + tuNgay.ToString("yyyy-MM-dd") + "' AND '" + denNgay.ToString("yyyy-MM-dd") + "') AS TongDoanhThu, " +
               "(SELECT ISNULL(SUM(tongthanhtoan), 0) FROM tblhoadonnhap WHERE ngaynhap BETWEEN '" + tuNgay.ToString("yyyy-MM-dd") + "' AND '" + denNgay.ToString("yyyy-MM-dd") + "') AS TongChiPhiNhapHang, " +
               "(SELECT ISNULL(SUM(luong), 0) FROM tblnhanvien) AS ChiPhiTraLuong"; 


            //string query = "SELECT " +
            //                      "(SELECT ISNULL(SUM(tongtien), 0) FROM tblhdb WHERE ngayban BETWEEN @From AND @To) AS TongDoanhThu, " +
            //                       "(SELECT ISNULL(SUM(tongtien), 0) FROM tblhdn WHERE ngaynhap BETWEEN @From AND @To) AS TongChiPhiNhapHang, " +
            //                      "(SELECT ISNULL(SUM(luong), 0) FROM tblnhanvien) AS ChiPhiTraLuong";
            // Thực hiện truy vấn và lấy dữ liệu
            DataTable dt = Function.GetDataToTable(query);

            // Kiểm tra xem có dữ liệu trả về không
            if (dt.Rows.Count > 0)
            {
                // Lấy dữ liệu từ DataTable
                int tongDoanhThu = dt.Rows[0]["TongDoanhThu"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["TongDoanhThu"]) : 0;
                int chiPhiNhapHang = dt.Rows[0]["TongChiPhiNhapHang"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["TongChiPhiNhapHang"]) : 0;
                int chiPhiTraLuong = dt.Rows[0]["ChiPhiTraLuong"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["ChiPhiTraLuong"]) : 0;

                // Tính toán tổng chi phí và lợi nhuận
                int tongChiPhi = chiPhiNhapHang + chiPhiTraLuong;
                int loiNhuan = tongDoanhThu - tongChiPhi;

                // Hiển thị các giá trị tính toán trên giao diện người dùng
                txttongdoanhthu.Text = tongDoanhThu.ToString();
                txtchiphinhaphang.Text = chiPhiNhapHang.ToString();
                txtchiphitraluong.Text = chiPhiTraLuong.ToString();
                txttongchiphi.Text = tongChiPhi.ToString();
                txtloinhuan.Text = loiNhuan.ToString();

                // Bật các nút "In báo cáo" và "Lưu"
                btnin.Enabled = true;
                btnluu.Enabled = true;
            }
            else
            {
                // Nếu không có dữ liệu trong DataTable, đặt giá trị mặc định là 0
                txttongdoanhthu.Text = "0";
                txtchiphinhaphang.Text = "0";
                txtchiphitraluong.Text = "0";
                txttongchiphi.Text = "0";
                txtloinhuan.Text = "0";

                // Vô hiệu hóa các nút "In báo cáo" và "Lưu"
                btnin.Enabled = false;
                btnluu.Enabled = false;
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
