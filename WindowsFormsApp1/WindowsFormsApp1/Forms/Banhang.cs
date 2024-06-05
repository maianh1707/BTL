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
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Forms
{
    public partial class Banhang : Form
    {
        public Banhang()
        {
            InitializeComponent();
        }
        DataTable tblCTHDB;
        private void Banhang_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();

            // Bật/tắt các nút dựa trên trạng thái ban đầu
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;

            // Đặt thuộc tính chỉ đọc cho các trường thông tin
            txtmahoadonban.ReadOnly = true;
            txttennhanvien.ReadOnly = true;
            txttenkhachhang.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtsodienthoai.ReadOnly = true;
            txttensanpham.ReadOnly = true;
            txtdongiaban.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txttongtien.ReadOnly = true;

            // Khởi tạo các trường văn bản với giá trị mặc định
            txtgiamgia.Text = "0";
            txttongtien.Text = "0";

            // Điền vào các hộp tổ hợp dữ liệu
            Function.FillCombo("SELECT makh, tenkh FROM tblkhachhang", cbomakhach, "makh", "tenkh");
            cbomakhach.SelectedIndex = -1;

            Function.FillCombo("SELECT manv, tennv FROM tblnhanvien", cbomanhanvien, "manv", "tennv");
            cbomanhanvien.SelectedIndex = -1;

            Function.FillCombo("SELECT masanpham, tensanpham FROM tblsanpham", cbomasanpham, "masanpham", "tensanpham");
            cbomasanpham.SelectedIndex = -1;

            Function.FillCombo("SELECT maco, tenco FROM tblco", cbomaco, "maco", "tenco");
            cbomaco.SelectedIndex = -1;

            Function.FillCombo("SELECT mamau, tenmau FROM tblmau", cbomamau, "mamau", "tenmau");
            cbomamau.SelectedIndex = -1;

            // Kiểm tra xem có cần hiển thị một hóa đơn cụ thể không (từ biểu mẫu tìm kiếm)
            if (txtmahoadonban.Text != "")
            {
                Load_ThongtinHD();
                btnxoa.Enabled = true;
                btnin.Enabled = true;
            }

            DataGridView.DataSource = null;
            DataGridView.Rows.Clear();

        }
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT a.masanpham, b.tensanpham, a.maco, a.mamau, a.soluongxuat, a.dongiaban, a.giamgia, a.thanhtien FROM tblchitiethdb AS a " +
                  "JOIN tblsanpham AS b ON a.masanpham = b.masanpham " +
                  "WHERE a.mahdb = N'" + txtmahoadonban.Text.Trim() + "'";
            tblCTHDB = Function.GetDataToTable(sql);
            DataGridView.DataSource = tblCTHDB;

            // Đặt tiêu đề và độ rộng cột
            DataGridView.Columns[0].HeaderText = "Mã hàng";
            DataGridView.Columns[1].HeaderText = "Tên hàng";
            DataGridView.Columns[2].HeaderText = "Mã cỡ";
            DataGridView.Columns[3].HeaderText = "Mã màu";
            DataGridView.Columns[4].HeaderText = "Số lượng";
            DataGridView.Columns[5].HeaderText = "Đơn giá";
            DataGridView.Columns[6].HeaderText = "Giảm giá %";
            DataGridView.Columns[7].HeaderText = "Thành tiền";

            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 80;
            DataGridView.Columns[5].Width = 90;
            DataGridView.Columns[6].Width = 90;
            DataGridView.Columns[7].Width = 90;

            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;


        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT ngayban FROM tblhoadonban WHERE mahdb = N'" + txtmahoadonban.Text + "'";
            txtngayban.Text = Function.ConvertDateTime(Function.GetFieldValues(str));
            str = "SELECT manv FROM tblhoadonban WHERE mahdb = N'" + txtmahoadonban.Text + "'";
            cbomanhanvien.Text = Function.GetFieldValues(str);

            str = "SELECT makh FROM tblhoadonban WHERE mahdb = N'" + txtmahoadonban.Text + "'";
            cbomakhach.Text = Function.GetFieldValues(str);

            str = "SELECT tongtien FROM tblhoadonban WHERE mahdb = N'" + txtmahoadonban.Text + "'";
            txttongtien.Text = Function.GetFieldValues(str);

            lblbangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(txttongtien.Text);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            // Xóa DataGridView bằng cách đặt nguồn dữ liệu của nó thành null
            DataGridView.DataSource = null;

            
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;

            // Kích hoạt các trường đầu vào
            txtngayban.ReadOnly = false;
            cbomanhanvien.Enabled = true;
            cbomakhach.Enabled = true;
            cbomasanpham.Enabled = true;
            cbomaco.Enabled = true;
            cbomamau.Enabled = true;
            txtsoluong.ReadOnly = false;
            txtdongiaban.ReadOnly = false;
            txtgiamgia.ReadOnly = false;
            txtthanhtien.ReadOnly = false;
            ResetValues();
            txtmahoadonban.Text = Function.CreateKey("HDB");
            txtngayban.Text = DateTime.Now.ToString("dd/MM/yyyy");

            Load_DataGridViewChitiet();

        }
        private void ResetValues()
        {
            txtmahoadonban.Text = "";
            txtngayban.Text = DateTime.Now.ToShortDateString();
            

            cbomanhanvien.SelectedIndex = -1;
            cbomakhach.SelectedIndex = -1;
            cbomasanpham.SelectedIndex = -1;
            cbomaco.SelectedIndex = -1;
            cbomamau.SelectedIndex = -1;
            txtsoluong.Text = "";
            txtdongiaban.Text = "";
            txtgiamgia.Text = "0";
            txtthanhtien.Text = "0";
            txttongtien.Text = "0";
            lblbangchu.Text = "Bằng chữ: ";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;

            sql = "SELECT mahdb FROM tblhoadonban WHERE mahdb=N'" + txtmahoadonban.Text + "'";
            if (!Function.CheckKey(sql))
            {
                DateTime ngayban;
                if (!DateTime.TryParse(txtngayban.Text.Trim(), out ngayban))
                {
                    MessageBox.Show("Bạn phải nhập ngày bán hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtngayban.Focus();
                    return;
                }
                if (cbomanhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomanhanvien.Focus();
                    return;
                }
                if (cbomakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomakhach.Focus();
                    return;
                }
                if (cbomaco.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập cỡ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomaco.Focus();
                    return;
                }
                if (cbomamau.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomamau.Focus();
                    return;
                }

                sql = "INSERT INTO tblhoadonban(mahdb, ngayban, manv, makh, tongtien) VALUES(N'" + txtmahoadonban.Text.Trim() + "', '" +
                      ngayban.ToString("yyyy-MM-dd") + "',N'" + cbomanhanvien.SelectedValue + "',N'" +
                      cbomakhach.SelectedValue + "'," + (txttongtien.Text == "" ? "0" : txttongtien.Text) + ")";
                Function.RunSql(sql);
            }

            if (cbomasanpham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomasanpham.Focus();
                return;
            }

            double soluong;
            if (!double.TryParse(txtsoluong.Text.Trim(), out soluong) || soluong <= 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Focus();
                return;
            }

            double giamgia;
            if (!double.TryParse(txtgiamgia.Text.Trim(), out giamgia))
            {
                MessageBox.Show("Bạn phải nhập giảm giá hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiamgia.Focus();
                return;
            }

            sql = "SELECT masanpham FROM tblchitiethdb WHERE masanpham=N'" + cbomasanpham.SelectedValue + "' AND mahdb = N'" + txtmahoadonban.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cbomasanpham.Focus();
                return;
            }

            string slStr = Function.GetFieldValues("SELECT soluong FROM tblchitietsp WHERE masanpham = N'" + cbomasanpham.SelectedValue + "'");
            if (!double.TryParse(slStr, out sl))
            {
                MessageBox.Show("Số lượng không hợp lệ hoặc không có sẵn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soluong > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }

            double dongiaban, thanhtien;
            if (!double.TryParse(txtdongiaban.Text.Trim(), out dongiaban) || !double.TryParse(txtthanhtien.Text.Trim(), out thanhtien))
            {
                MessageBox.Show("Đơn giá bán hoặc thành tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "INSERT INTO tblchitiethdb(mahdb, masanpham, maco, mamau, soluongxuat, dongiaban, giamgia, thanhtien) " +
                  "VALUES(N'" + txtmahoadonban.Text.Trim() + "', N'" + cbomasanpham.SelectedValue + "', N'" + cbomaco.SelectedValue + "',N'" + cbomamau.SelectedValue + "'," + soluong + ", " +
                  dongiaban + ", " + giamgia + ", " + thanhtien + ")";
            Function.RunSql(sql);
            Load_DataGridViewChitiet();

            // Cập nhật số lượng hàng tồn kho
            SLcon = sl - soluong;
            sql = "UPDATE tblchitietsp SET soluong =" + SLcon + " WHERE masanpham= N'" + cbomasanpham.SelectedValue + "'";
            Function.RunSql(sql);

            // Cập nhật tổng số tiền cho hóa đơn
            string tongStr = Function.GetFieldValues("SELECT tongtien FROM tblhoadonban WHERE mahdb = N'" + txtmahoadonban.Text + "'");
            if (!double.TryParse(tongStr, out tong))
            {
                MessageBox.Show("Tổng tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tongmoi = tong + thanhtien;
            sql = "UPDATE tblhoadonban SET tongtien =" + Tongmoi + " WHERE mahdb = N'" + txtmahoadonban.Text + "'";
            Function.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(Tongmoi.ToString());

            btnxoa.Enabled = true;
            btnin.Enabled = true;

        }
        private void ResetValuesHang()
        {
            cbomasanpham.Text = "";
            txtsoluong.Text = "";
            txtgiamgia.Text = "0";
            txtthanhtien.Text = "0";
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masanpham;
            Double Thanhtien;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                masanpham = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
                DelHang(txtmahoadonban.Text, masanpham);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(DataGridView.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtien(txtmahoadonban.Text, Thanhtien);
                Load_DataGridViewChitiet();
            }

        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT soluongxuat FROM tblchitiethdb WHERE mahdb = N'" + Mahoadon + "' AND masanpham = N'" + Mahang + "'";
            s = Convert.ToDouble(Function.GetFieldValues(sql));
            sql = "DELETE tblchitiethdb WHERE mahdb=N'" + Mahoadon + "' AND masanpham = N'" + Mahang + "'";
            Function.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT soluong FROM tblchitietsp WHERE masanpham = N'" + Mahang + "'";
            sl = Convert.ToDouble(Function.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblchitietsp SET soluong =" + SLcon + " WHERE masanpham= N'" + Mahang + "'";
            Function.RunSql(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT tongtien FROM tblhoadonban WHERE mahdb = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Function.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblhoadonban SET tongtien =" + Tongmoi + " WHERE mahdb = N'" + Mahoadon + "'";
            Function.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(Tongmoi.ToString());
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT masanpham FROM tblchitiethdb WHERE mahdb = N'" + txtmahoadonban.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Function.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtmahoadonban.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE tblhoadonban WHERE mahdb=N'" + txtmahoadonban.Text + "'";
                Function.RunSqlDel(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                btnxoa.Enabled = false;
                btnin.Enabled = false;
            }
        }

        private void cbomanhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomanhanvien.Text == "")
                txttennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tennv from tblnhanvien where manv =N'" + cbomanhanvien.SelectedValue + "'";
            txttennhanvien.Text = Function.GetFieldValues(str);
        }

        private void cbomakhach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomakhach.Text == "")
            {
                txttenkhachhang.Text = "";
                txtdiachi.Text = "";
                txtsodienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select tenkh from tblkhachhang where makh = N'" + cbomakhach.SelectedValue + "'";
            txttenkhachhang.Text = Function.GetFieldValues(str);
            str = "Select diachi from tblkhachhang where makh = N'" + cbomakhach.SelectedValue + "'";
            txtdiachi.Text = Function.GetFieldValues(str);
            str = "Select dienthoai from tblkhachhang where makh= N'" + cbomakhach.SelectedValue + "'";
            txtsodienthoai.Text = Function.GetFieldValues(str);
        }

        private void cbomasanpham_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomasanpham.Text == "")
            {
                txttensanpham.Text = "";
                txtdongiaban.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT tensanpham FROM tblsanpham WHERE masanpham =N'" + cbomasanpham.SelectedValue + "'";
            txttensanpham.Text = Function.GetFieldValues(str);
            str = "SELECT dongiaban FROM tblsanpham WHERE masanpham =N'" + cbomasanpham.SelectedValue + "'";
            txtdongiaban.Text = Function.GetFieldValues(str);
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtgiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtgiamgia.Text);
            if (txtdongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtgiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtgiamgia.Text);
            if (txtdongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void btnin_Click(object sender, EventArgs e)
        {

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop TAG";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)37562222";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.mahdb, a.ngayban, a.tongtien, b.tenkh, b.diachi, b.dienthoai, c.tennv FROM tblhoadonban AS a, tblkhachhang AS b, tblnhanvien AS c WHERE a.mahdb = N'" + txtmahoadonban.Text + "' AND a.makh = b.makh AND a.manv =c.manv";
            tblThongtinHD = Function.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT a.masanpham, b.tensanpham, a.maco, a.mamau, a.soluongxuat, a.dongiaban, a.giamgia, a.thanhtien " +
                  "FROM tblchitiethdb AS a, tblsanpham AS b WHERE a.mahdb = N'" +
                  txtmahoadonban.Text + "' AND a.masanpham = b.masanpham";
            tblThongtinHang = Function.GetDataToTable(sql);

            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:I11"].Font.Bold = true;
            exRange.Range["A11:H11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:H11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã hàng";
            exRange.Range["C11:C11"].Value = "Tên hàng";
            exRange.Range["D11:D11"].Value = "Mã cỡ";
            exRange.Range["E11:E11"].Value = "Mã màu";
            exRange.Range["F11:F11"].Value = "Số lượng";
            exRange.Range["G11:G11"].Value = "Đơn giá";
            exRange.Range["H11:H11"].Value = "Giảm giá %";
            exRange.Range["I11:I11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }



            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:H1"].MergeCells = true;
            exRange.Range["A1:H1"].Font.Bold = true;
            exRange.Range["A1:H1"].Font.Italic = true;
            exRange.Range["A1:H1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:H1"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbomahoadonban.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomahoadonban.Focus();
                return;
            }
            txtmahoadonban.Text = cbomahoadonban.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
            cbomahoadonban.SelectedIndex = -1;
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void txtgiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void cbomahoadonban_DropDown(object sender, EventArgs e)
        {
            Function.FillCombo("SELECT mahdb FROM tblhoadonban", cbomahoadonban, "mahdb", "mahdb");
            cbomahoadonban.SelectedIndex = -1;
        }

        private void Banhang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
