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
using baitaplon.Class;
using System.Globalization;

namespace baitaplon.Forms
{
    public partial class baocaotonkho : Form
    {

        public baocaotonkho()
        {
            InitializeComponent();
        }

        private void baocaotonkho_Load(object sender, EventArgs e)
        {
            btnthemkiemke.Enabled = true;
            btnluu.Enabled = false;
            btnhuykiemke.Enabled = false;
            btninkiemke.Enabled = false;
            btndong.Enabled = true;

            txtmakiemke.ReadOnly = true;
            txtthoigiantao.ReadOnly = true;
            txttennv.ReadOnly = true;
            txtsoluongchenhlech.ReadOnly = true;
            txtsoluongchenhlech.Text = "";

            // Điền danh sách nhân viên vào combobox cbomanv
            Functions.FillCombo("SELECT manv, tennv FROM tblnhanvien", cbomanv, "manv", "manv");
            cbomanv.SelectedIndex = -1;

            // Điền danh sách mã hàng vào combobox cbomahang
            Functions.FillCombo("SELECT masanpham, tensanpham FROM tblsanpham", cbomasp, "masanpham", "masanpham");
            cbomasp.SelectedIndex = -1;

            // Điền danh sách mã hàng vào combobox cbomaco
            Functions.FillCombo("SELECT maco, tenco FROM tblco", cbomaco, "maco", "tenco");
            cbomaco.SelectedIndex = -1;

            // Điền danh sách mã hàng vào combobox cbomamau
            Functions.FillCombo("SELECT mamau, tenmau FROM tblmau", cbomamau, "mamau", "tenmau");
            cbomamau.SelectedIndex = -1;

            Functions.FillCombo("SELECT makiemke FROM tblchitietbckiemkho", cbomakiemke, "makiemke", "makiemke");
            cbomakiemke.SelectedIndex = -1;

            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtmakiemke.Text != "")
            {
                Load_ThongtinKK();
                btnhuykiemke.Enabled = true;
                btninkiemke.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }
        private void Load_ThongtinKK()
        {
            string str;
            str = "SELECT thoigiantao FROM tblbckiemkho WHERE makiemke = N'" + txtmakiemke.Text + "'";
            txtthoigiantao.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT manv FROM tblbckiemkho WHERE makiemke = N'" + txtmakiemke.Text + "'";
            cbomanv.Text = Functions.GetFieldValues(str);
            str = "SELECT ghichu FROM tblbckiemkho WHERE makiemke = N'" + txtmakiemke.Text + "'";
            txtghichu.Text = Functions.GetFieldValues(str);

        }
        DataTable tblkiemkho;

        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT a.masanpham, b.tensanpham,a.maco, a.mamau, a.soluongnhap, a.soluongxuat, a.soluongtonkho, a.soluongtonkhothucte, a.soluongchenhlech " +
                "FROM tblchitietbckiemkho AS a, tblsanpham AS b " +
                "WHERE a.makiemke = N'" + txtmakiemke.Text + "' AND a.masanpham=b.masanpham";
            tblkiemkho = Functions.GetDataToTable(sql);
            dgridkiemke.DataSource = tblkiemkho;
            dgridkiemke.Columns[0].HeaderText = "Mã sản phẩm";
            dgridkiemke.Columns[1].HeaderText = "Tên sản phẩm";
            dgridkiemke.Columns[2].HeaderText = "Mã cỡ";
            dgridkiemke.Columns[3].HeaderText = "Mã màu";
            dgridkiemke.Columns[4].HeaderText = "Số lượng nhập";
            dgridkiemke.Columns[5].HeaderText = "Số lượng xuất";
            dgridkiemke.Columns[6].HeaderText = "Số lượng tồn kho";
            dgridkiemke.Columns[7].HeaderText = "Số lượng tồn kho thực tế";
            dgridkiemke.Columns[8].HeaderText = "Số lượng chênh lệch";
            dgridkiemke.Columns[0].Width = 120;
            dgridkiemke.Columns[1].Width = 100;
            dgridkiemke.Columns[2].Width = 100;
            dgridkiemke.Columns[3].Width = 100;
            dgridkiemke.Columns[4].Width = 100;
            dgridkiemke.Columns[5].Width = 100;
            dgridkiemke.Columns[6].Width = 120;
            dgridkiemke.Columns[7].Width = 120;
            dgridkiemke.Columns[8].Width = 120;
            dgridkiemke.AllowUserToAddRows = false;
            dgridkiemke.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtmakiemke.Text = "";
            txtthoigiantao.Text = "";
            cbomanv.Text = "";
            txttennv.Text = "";
            cbomasp.Text = "";
            txttensp.Text = "";
            cbomaco.Text = "";
            cbomamau.Text = "";
            txtsoluongnhap.Text = "";
            txtsoluongxuat.Text = "";
            txtsoluongtonkho.Text = "0";
            txtsoluongtonkhothucte.Text = "0";
            txtsoluongchenhlech.Text = "0";
            txtghichu.Text = "";
        }
        private void ResetValuesHang()
        {
            cbomasp.Text = "";
            txttensp.Text = "";
            cbomaco.Text = "";
            cbomamau.Text = "";
            txtsoluongnhap.Text = "";
            txtsoluongxuat.Text = "";
            txtsoluongtonkho.Text = "0";
            txtsoluongtonkhothucte.Text = "0";
            txtsoluongchenhlech.Text = "0";
        }

        private void btnthemkiemke_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnhuykiemke.Enabled = true;
            btnthemkiemke.Enabled = false;
            btninkiemke.Enabled = false;
            ResetValues();
            txtmakiemke.Text = Functions.CreateKey("KK");
            txtthoigiantao.Text = DateTime.Now.ToShortDateString();
            txtthoigiantao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Load_DataGridViewChitiet();

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            double chenhlech;

            // Kiểm tra xem mã kiểm kê đã tồn tại chưa
            sql = "SELECT makiemke FROM tblbckiemkho WHERE makiemke=N'" + txtmakiemke.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Lưu thông tin chung
                if (txtthoigiantao.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày tạo báo cáo kiểm kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtthoigiantao.Focus();
                    return;
                }

                DateTime ngaykiemke;
                if (!DateTime.TryParseExact(txtthoigiantao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaykiemke))
                {
                    MessageBox.Show("Định dạng ngày tháng không hợp lệ. Vui lòng nhập ngày tháng theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtthoigiantao.Focus();
                    return;
                }

                if (cbomanv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomanv.Focus();
                    return;
                }

                // Lưu thông tin chung vào bảng tblbckiemkho
                sql = "INSERT INTO tblbckiemkho(makiemke, thoigiantao, manv, ghichu) " +
                      "VALUES(N'" + txtmakiemke.Text.Trim() + "', '" +
                      Functions.ConvertDateTime(txtthoigiantao.Text.Trim()) + "', N'" +
                      cbomanv.SelectedValue + "', N'" + txtghichu.Text.Trim() + "')";
                Functions.RunSql(sql);
            }

            // Lưu thông tin mặt hàng
            if (cbomasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomasp.Focus();
                return;
            }

            if (cbomaco.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã cỡ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaco.Focus();
                return;
            }

            if (cbomamau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomamau.Focus();
                return;
            }

            // Kiểm tra xem tổ hợp sản phẩm, cỡ, màu đã tồn tại chưa
            sql = "SELECT masanpham FROM tblchitietbckiemkho " +
                "WHERE masanpham=N'" +cbomasp.SelectedValue + "' AND maco=N'" + cbomaco.SelectedValue + "' AND mamau=N'" + cbomamau.SelectedValue + "' AND makiemke = N'" + txtmakiemke.Text.Trim() + "'";

            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cbomasp.Focus();
                return;
            }

            // Tính chênh lệch
            double soluongtonkho = string.IsNullOrEmpty(txtsoluongtonkho.Text) ? 0 : Convert.ToDouble(txtsoluongtonkho.Text);
            double soluongtonkhothucte = string.IsNullOrEmpty(txtsoluongtonkhothucte.Text) ? 0 : Convert.ToDouble(txtsoluongtonkhothucte.Text);
            chenhlech = soluongtonkho - soluongtonkhothucte;

            // Lưu chi tiết mặt hàng vào bảng tblchitietbckiemkho
            sql = "INSERT INTO tblchitietbckiemkho(makiemke, masanpham, maco, mamau, soluongxuat, soluongnhap, soluongtonkho, soluongtonkhothucte, soluongchenhlech) " +
                  "VALUES(N'" + txtmakiemke.Text.Trim() + "', N'" + cbomasp.SelectedValue + "', N'" + cbomaco.SelectedValue + "', N'" +
                  cbomamau.SelectedValue + "', " + txtsoluongxuat.Text.Trim() + ", " + txtsoluongnhap.Text.Trim() + ", " +
                  soluongtonkho + ", " + soluongtonkhothucte + ", " + chenhlech + ")";
            Functions.RunSql(sql);

            // Làm mới bảng dữ liệu và đặt lại giá trị
            Load_DataGridViewChitiet();
            ResetValuesHang();
            btnhuykiemke.Enabled = true;
            btninkiemke.Enabled = true;

        }

        private void cbomanv_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomanv.Text == "")
            {
                txttennv.Text = "";
                return;
            }
            // Khi kích chọn mã nhân viên thì tên nhân viên sẽ tự động hiện ra
            str = "SELECT tennv FROM tblnhanvien WHERE manv = N'" + cbomanv.SelectedValue + "'";
            txttennv.Text = Functions.GetFieldValues(str);


        }
        private void cbomasp_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomasp.Text == "")
            {
                txttensp.Text = "";
                return;
            }
            // Khi kích chọn mã sản phẩm thì tên sản phẩm sẽ tự động hiện ra
            str = "SELECT tensanpham FROM tblsanpham WHERE masanpham = N'" + cbomasp.SelectedValue + "'";
            txttensp.Text = Functions.GetFieldValues(str);
            UpdateSoluong();
        }
        private void cbomaco_TextChanged(object sender, EventArgs e)
        {
            UpdateSoluong();
        }
        private void cbomamau_TextChanged(object sender, EventArgs e)
        {
            UpdateSoluong();
        }
        private void UpdateSoluong()
        {
            string str;
            if (cbomasp.Text == "" || cbomaco.Text == "" || cbomamau.Text == "")
            {
                txtsoluongnhap.Text = "";
                txtsoluongxuat.Text = "";
                txtsoluongtonkho.Text = "";
                return;
            }
            str = "SELECT sp.masanpham, sp.tensanpham, co.tenco, mau.tenmau, ctb.soluongnhap, ctb.soluongxuat, ctb.soluongtonkho, ctb.soluongtonkhothucte, ctb.soluongchenhlech " +
             "FROM tblchitietbckiemkho AS ctb " +
             "INNER JOIN tblsanpham AS sp ON ctb.masanpham = sp.masanpham " +
             "INNER JOIN tblco AS co ON ctb.maco = co.maco " +
             "INNER JOIN tblmau AS mau ON ctb.mamau = mau.mamau " +
             "WHERE ctb.makiemke = N'" + txtmakiemke.Text + "'";
            DataTable dt = Functions.GetDataToTable(str);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtsoluongnhap.Text = row["soluongnhap"].ToString();
                txtsoluongxuat.Text = row["soluongxuat"].ToString();

                double soluongnhap = Convert.ToDouble(row["soluongnhap"]);
                double soluongxuat = Convert.ToDouble(row["soluongxuat"]);
                double soluongtonkho = soluongnhap - soluongxuat;
                txtsoluongtonkho.Text = soluongtonkho.ToString();
            }
            else
            {
                txtsoluongnhap.Text = "0";
                txtsoluongxuat.Text = "0";
                txtsoluongtonkho.Text = "0";
            }
        }
        private void txtsoluongtonkhothucte_TextChanged(object sender, EventArgs e)
        {
            double soluongtonkho, soluongtonkhothucte, chenhlech;

            // Kiểm tra nếu txtsoluongtonkhothucte trống thì gán giá trị 0 cho soluongtonkhothucte
            if (txtsoluongtonkhothucte.Text == "")
                soluongtonkhothucte = 0;
            else
                soluongtonkhothucte = Convert.ToDouble(txtsoluongtonkhothucte.Text);

            // Kiểm tra nếu txtsoluongtonkho trống thì gán giá trị 0 cho soluongtonkho
            if (txtsoluongtonkho.Text == "")
                soluongtonkho = 0;
            else
                soluongtonkho = Convert.ToDouble(txtsoluongtonkho.Text);

            // Tính chênh lệch
            chenhlech = soluongtonkho - soluongtonkhothucte;

            // Hiển thị chênh lệch vào txtsoluongchenhlech
            txtsoluongchenhlech.Text = chenhlech.ToString();

        }

        private void btnhuykiemke_Click(object sender, EventArgs e)
        {
            // Code xóa dữ liệu của kiểm kê
            string sql;
            if (MessageBox.Show("Bạn có muốn hủy kiểm kê này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Xóa chi tiết kiểm kê
                sql = "DELETE FROM tblchitietbckiemkho WHERE makiemke=N'" + txtmakiemke.Text + "'";
                Functions.RunSqlDel(sql);

                // Xóa kiểm kê
                sql = "DELETE FROM tblbckiemkho WHERE makiemke=N'" + txtmakiemke.Text + "'";
                Functions.RunSqlDel(sql);

                ResetValues();
                Load_DataGridViewChitiet();
                btnhuykiemke.Enabled = false;
                btninkiemke.Enabled = false;
                btnluu.Enabled = false;
                btnthemkiemke.Enabled = true;
            }

        }
        private void btninkiemke_Click(object sender, EventArgs e)
        {
            // Khai báo thư viện COM Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinKiemKe, tblThongtinHang;
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
            exRange.Range["C2:J2"].Font.Size = 16;
            exRange.Range["C2:J2"].Font.Bold = true;
            exRange.Range["C2:J2"].Font.ColorIndex = 3; // Màu đỏ
            exRange.Range["C2:J2"].MergeCells = true;
            exRange.Range["C2:J2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:J2"].Value = "PHIẾU KIỂM KHO";

            // Biểu diễn thông tin chung của biên bản kiểm kê
            sql = "SELECT a.makiemke, a.thoigiantao, b.tennv FROM tblbckiemkho as a,tblnhanvien as b WHERE makiemke = N'" + txtmakiemke.Text + "' AND a.manv = b.manv";
            tblThongtinKiemKe = Functions.GetDataToTable(sql);
            exRange.Range["B6:C7"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã kiểm kê:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinKiemKe.Rows[0][0].ToString();
            //exRange.Range["B7:B7"].Value = "Ngày kiểm kê:";
            //exRange.Range["C7:E7"].MergeCells = true;
            //exRange.Range["C7:E7"].Value = Convert.ToDateTime(tblThongtinKiemKe.Rows[0][1]).ToString("dd/MM/yyyy");

            // Lấy thông tin các mặt hàng trong biên bản kiểm kê
            sql = "SELECT sp.masanpham, sp.tensanpham, co.tenco, mau.tenmau, ctb.soluongnhap, ctb.soluongxuat, ctb.soluongtonkho, ctb.soluongtonkhothucte, ctb.soluongchenhlech " +
                    "FROM tblchitietbckiemkho AS ctb " +
                    "INNER JOIN tblsanpham AS sp ON ctb.masanpham = sp.masanpham " +
                    "INNER JOIN tblco AS co ON ctb.maco = co.maco " +
                    "INNER JOIN tblmau AS mau ON ctb.mamau = mau.mamau " +
                    "WHERE ctb.makiemke = N'" + txtmakiemke.Text + "'";

            tblThongtinHang = Functions.GetDataToTable(sql);

            // Tạo dòng tiêu đề bảng
            exRange.Range["A8:J8"].Font.Bold = true;
            exRange.Range["C8:J8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A8:A8"].Value = "STT";
            exRange.Range["B8:B8"].Value = "Mã sản phẩm";
            exRange.Range["C8:C8"].Value = "Tên sản phẩm";
            exRange.Range["D8:D8"].Value = "Size";
            exRange.Range["E8:E8"].Value = "Màu sắc";
            exRange.Range["F8:F8"].Value = "Số lượng nhập";
            exRange.Range["G8:G8"].Value = "Số lượng xuất";
            exRange.Range["H8:H8"].Value = "Số lượng tồn kho";
            exRange.Range["I8:I8"].Value = "Số lượng thực tế";
            exRange.Range["J8:J8"].Value = "Số lượng chênh lệch";

            // Kéo dài ô để hiển thị hết nội dung tiêu đề
            exRange.Range["A8:A8"].Columns.AutoFit();
            exRange.Range["C8:J8"].Columns.AutoFit();

            // Điền thông tin hàng hóa và thêm đường viền
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                // Điền số thứ tự vào cột 1 từ dòng 11
                exSheet.Cells[1][hang + 9] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 9] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }

            // Thêm đường viền cho dữ liệu bảng
            exRange = exSheet.Range["A8:J" + (hang + 8).ToString()];
            exRange.Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;

            // Thêm thông tin ngày tháng và nhân viên kiểm kê
            exRange = exSheet.Cells[8][hang + 11]; // Ô A1
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinKiemKe.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên kiểm kê";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinKiemKe.Rows[0][2].ToString();

            exSheet.Name = "Phiếu kiểm kho";
            exApp.Visible = true;

        }

        private void dgridkiemke_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblkiemkho.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục kiểm kê này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string makiemke = txtmakiemke.Text;
                string masanpham = dgridkiemke.CurrentRow.Cells["masanpham"].Value.ToString();

                // Xóa mục kiểm kê từ cơ sở dữ liệu
                DelChiTietKiemKe(makiemke, masanpham);

                // Tải lại dữ liệu DataGridView
                Load_DataGridViewChitiet();
            }
        }
        private void DelChiTietKiemKe(string makiemke, string masanpham)
        {
            // Thực hiện câu lệnh SQL để xóa mục kiểm kê từ bảng chi tiết kiểm kê
            string sql = "DELETE FROM tblchitietbckiemkho WHERE makiemke = N'" + makiemke + "' AND masanpham = N'" + masanpham + "'";
            Functions.RunSqlDel(sql);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbomakiemke.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã báo cáo kiểm kê để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomakiemke.Focus();
                return;
            }
            txtmakiemke.Text = cbomakiemke.Text;
            Load_ThongtinKK();
            Load_DataGridViewChitiet();
            btnhuykiemke.Enabled = true;
            btnluu.Enabled = true;
            btninkiemke.Enabled = true;
            cbomakiemke.SelectedIndex = -1;
        }

        private void cbomakiemke_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT makiemke FROM tblbckiemkho", cbomakiemke, "makiemke", "makiemke");
            cbomakiemke.SelectedIndex = -1;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void baocaotonkho_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }   
    }
}
