using BTLLAPTRINH.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace BTLLAPTRINH.Forms
{
    public partial class Hoadonnhap : Form
    {
        public Hoadonnhap()
        {
            InitializeComponent();
        }

        private void Hoadonnhap_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            btnin.Enabled = false;
            txtmahdn.ReadOnly = true;
            mskngaynhap.ReadOnly = true;
            txtsoluong.ReadOnly = true;
            txtgianhap.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txtchietkhau.ReadOnly = true;
            txttongtienhang.ReadOnly = true;
            txttongtien.ReadOnly    = true;
            txttenncc.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            msksdt.ReadOnly = true;
            txttensp.ReadOnly = true;
            txtsoluong.Text = "0";
            txtthanhtien.Text = "0";
            txttongtienhang.Text = "0";
            txttongtien.Text = "0";
            txtchietkhau.Text = "0";
            txtgianhap.Text = "0";
            Class.Function.FillCombo("select manv,tennv from tblnhanvien", cbotennv, "manv", "tennv");
            cbotennv.SelectedIndex = -1;

            Class.Function.FillCombo("select mancc,mancc from tblnhacungcap", cboncc, "mancc", "mancc");
            cboncc.SelectedIndex = -1;

            Class.Function.FillCombo("select masanpham,masanpham from tblsanpham",cbosp, "masanpham","masanpham");
            cbosp.SelectedIndex = -1;

            Class.Function.FillCombo("select mahdn,mahdn from tblchitiethdn", cbotimkiem, "mahdn", "mahdn");
            cbotimkiem.SelectedIndex = -1;

            if(txtmahdn.Text != "")
            {
                Load_ThongtinHD();
                btnhuy.Enabled = true;
                btnin.Enabled = true;
            }
            Load_ThongtinSanpham();
        }
        private void Load_ThongtinHD()
        {
            string sql;
            sql = "select ngaynhap from tblhoadonnhap where mahdn = N'" +txtmahdn.Text + "'";
            mskngaynhap.Text = Function.ConvertDateTime(Function.GetFieldValues(sql));

            sql = "select manv from tblhoadonnhap where mahdn = N'" + txtmahdn.Text + "'";
            cbotennv.Text = Function.GetFieldValues(sql);

            sql = "select mancc from tblhoadonnhap where mahdn = N'" + txtmahdn.Text + "'";
            cboncc.Text = Function.GetFieldValues(sql);

            sql ="select tongtienhang from tblhoadonnhap where mahdn =N'"+txtmahdn.Text+"'";
            txttongtienhang.Text = Function.GetFieldValues(sql);

            sql = "select chietkhau from tblhoadonnhap where mahdn =N'" + txtmahdn.Text + "'";
            txtchietkhau.Text = Function.GetFieldValues(sql);

            sql = "select tongthanhtoan from tblhoadonnhap where mahdn =N'" + txtmahdn.Text + "'";
            txttongtien.Text = Function.GetFieldValues(sql);

            lblbangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(txttongtien.Text);

        }
        DataTable tblhdn;
        private void Load_ThongtinSanpham()
        {
            string sql;
            sql = "select a.masanpham, b.tensanpham, a.soluongnhap, a.dongianhap,a.thanhtien from tblchitiethdn as a "+" join tblsanpham as b on a.masanpham = b.masanpham where a.mahdn = N'" +txtmahdn.Text + "'";
            tblhdn = Function.GetDataToTable(sql);

            dgridnhaphang.DataSource = tblhdn;

            dgridnhaphang.Columns[0].HeaderText = "Mã sản phẩm";
            dgridnhaphang.Columns[1].HeaderText = "Tên sản phẩm";
            dgridnhaphang.Columns[2].HeaderText = "Số lượng nhập";
            dgridnhaphang.Columns[3].HeaderText = "Đơn giá nhập";
            dgridnhaphang.Columns[4].HeaderText = "Thành tiền";
            dgridnhaphang.AllowUserToAddRows = false;
            dgridnhaphang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnin.Enabled = true;
            btnhuy.Enabled = true;
            btnthem.Enabled = false;
            txtsoluong.ReadOnly = false;
            txtgianhap.ReadOnly = false;
            txtchietkhau.ReadOnly = false;
            txtmahdn.Text = Class.Function.CreateKey("HDN");
            Load_ThongtinSanpham();
            Resetvalue();
        }
        private void Resetvalue()
        {
            mskngaynhap.Text = DateTime.Now.ToShortDateString();
            cboncc.Text = "";
            cbotennv.Text="";
            cbosp.Text = "";
            txtsoluong.Text = "";
            txtthanhtien.Text = "0";
            txtgianhap.Text = "0";
            txttongtienhang.Text = "0";
            txttongtien.Text = "0";
            txtchietkhau.Text = "";
            lblbangchu.Text = "Bằng chữ: ";
            txttenncc.Text = "";
            txtdiachi.Text = "";
            msksdt.Text = "(   )    -";
        }

        private void Resetsanpham()
        {
            cbosp.Text = "";
            txtsoluong.Text = "";
            txtgianhap.Text = "0";
            txtthanhtien.Text= "0";
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            //Lưu thông tin chung
            sql ="select mahdn from tblhoadonnhap where mahdn=N'"+txtmahdn.Text+"'";
            if(!Class.Function.CheckKey(sql))
            {
                if (cbotennv.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn nhân viên trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbotennv.Focus();
                    return;
                }
                if (cboncc.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboncc.Focus();
                    return;
                }
                if (txtchietkhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập chiết khấu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtchietkhau.Focus();
                    return;
                }
                sql = "insert into tblhoadonnhap(mahdn,ngaynhap,tongtienhang,chietkhau,tongthanhtoan,manv,mancc)values(N'"+txtmahdn.Text.Trim()+"','"+Class.Function.ConvertDateTime(mskngaynhap.Text)+"','"+txttongtienhang.Text+"','"+txtchietkhau.Text+"','"+txttongtien.Text+"',N'"+cbotennv.SelectedValue+"',N'"+cboncc.SelectedValue+"')";
                Class.Function.RunSql(sql);
            }    
            //Lưu thông tin sản phẩm
            if(cbosp.Text=="")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbosp.Focus();
                return;
            }   
            if(txtsoluong.Text=="0"|| (txtsoluong.Text.Trim().Length == 0))
            {
                MessageBox.Show("Vui lòng nhập số lượng nhập trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsoluong.Focus();
                return;
            }
            sql = "select masanpham from tblchitiethdn where masanpham=N'"+cbosp.SelectedValue+"'and mahdn=N'"+txtmahdn.Text.Trim()+"'";
            if(Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, vui lòng chọn sản phẩm khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Resetsanpham();
                cbosp.Focus();
                return;
            }
            sql = "insert into tblchitiethdn(mahdn,masanpham,soluongnhap,dongianhap,thanhtien)values(N'"+txtmahdn.Text.Trim()+"',N'"+cbosp.SelectedValue+"','"+txtsoluong.Text+"','"+txtgianhap.Text+"','"+txtthanhtien.Text+"')";
            Class.Function.RunSql(sql);
            Load_ThongtinSanpham();

            //Cập nhật số lượng hàng
            double slcon = 0, sl = 0;
            sl = Convert.ToDouble(Function.GetFieldValues("select soluong from tblsanpham where masanpham = N'" +cbosp.SelectedValue+ "'"));
            slcon = sl + Convert.ToDouble(txtsoluong.Text);
            sql = "update tblsanpham set soluong =" + slcon + " where masanpham= N'" +cbosp.SelectedValue + "'";
            Function.RunSql(sql);

            //Cập nhật tổng thành tiền và tổng thanh toán

            double tongthanhtien = 0, tongthanhtienmoi = 0;
            tongthanhtien = Convert.ToDouble(Function.GetFieldValues("select tongtienhang from tblhoadonnhap where mahdn = N'"+txtmahdn.Text+"'and ngaynhap='"+Class.Function.ConvertDateTime(mskngaynhap.Text)+"'"));
            tongthanhtienmoi = tongthanhtien + Convert.ToDouble(txtthanhtien.Text);
            sql = "update tblhoadonnhap set tongtienhang = " +tongthanhtienmoi+ " where mahdn=N'"+txtmahdn.Text+"'";
            Class.Function.RunSql(sql);

            double ck=0,tongthanhtoan = 0;
            ck= Convert.ToDouble(txtchietkhau.Text);
            tongthanhtoan = tongthanhtienmoi - ((ck * tongthanhtienmoi) / 100);


            sql = "update tblhoadonnhap set tongthanhtoan= " + tongthanhtoan + " where mahdn=N'" + txtmahdn.Text + "'";
            Class.Function.RunSql(sql);

            txttongtienhang.Text = tongthanhtienmoi.ToString();
            txttongtien.Text = tongthanhtoan.ToString();

            lblbangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(tongthanhtoan.ToString());
            Resetsanpham();
            btnhuy.Enabled = true;
            btnin.Enabled = true;
            btnthem.Enabled = true;
        }

        private void cbosp_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if(cbosp.Text =="")
            {
                txtgianhap.Text = "";
            }
            sql ="select tensanpham from tblsanpham where masanpham=N'"+cbosp.SelectedValue+"'";
            txttensp.Text = Class.Function.GetFieldValue(sql);
            sql = "select dongianhap from tblsanpham where masanpham=N'"+cbosp.SelectedValue+"'";
            txtgianhap.Text = Class.Function.GetFieldValues(sql);
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dgn;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtgianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(txtgianhap.Text);
            tt = sl * dgn;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtchietkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgridnhaphang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masanpham;
            double thanhtien;
            if(tblhdn.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                masanpham = dgridnhaphang.CurrentRow.Cells["masanpham"].Value.ToString();
                DelHang(txtmahdn.Text, masanpham);

                // Cập nhật lại tổng tiền cho hóa đơn bán
                thanhtien = Convert.ToDouble(dgridnhaphang.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtien(txtmahdn.Text, thanhtien);
                Load_ThongtinSanpham();
            }

        }
        private void DelHang(string mahoadonnhap, string masanpham)
        {
            Double s, sl, slcon;
            string sql;
            sql = "select soluongnhap from tblchitiethdn where mahdn = N'" + mahoadonnhap + "' and masanpham = N'" +masanpham+ "'";
            s = Convert.ToDouble(Function.GetFieldValues(sql));

            sql = "delete tblchitiethdn where mahdn=N'" + mahoadonnhap + "' and masanpham = N'"+ masanpham + "'";
            Function.RunSqlDel(sql);

            // Cập nhật lại số lượng cho các mặt hàng
            sql = "select soluong from tblsanpham where masanpham = N'" + masanpham + "'";
            sl = Convert.ToDouble(Function.GetFieldValues(sql));
            slcon = sl - s;
            sql = "update tblsanpham set soluong =" + slcon + " where masanpham= N'" + masanpham + "'";
            Function.RunSql(sql);
        }
        private void DelUpdateTongtien(string mahoadonnhap, double thanhtien)
        {
            Double tongtienhang, tongtienhangmoi, tongthanhtoanmoi;
            string sql;
            sql = "select tongtienhang from tblhoadonnhap where mahdn = N'" + mahoadonnhap + "'";
            tongtienhang = Convert.ToDouble(Function.GetFieldValues(sql));

            tongtienhangmoi = tongtienhang - thanhtien;

            sql = "update tblhoadonnhap set tongtienhang =" + tongtienhangmoi + " where mahdn = N'" +mahoadonnhap + "'";
            Function.RunSql(sql);
            txttongtienhang.Text = tongtienhangmoi.ToString();

            double ck;
            ck = Convert.ToDouble(txtchietkhau.Text);
            tongthanhtoanmoi = tongtienhangmoi - ((tongtienhangmoi * ck) / 100);
            txttongtien.Text = tongthanhtoanmoi.ToString();

            lblbangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(tongthanhtoanmoi.ToString());
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] masanpham = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "select masanpham from tblchitiethdn where mahdn = N'" +txtmahdn.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Function.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    masanpham[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();

                //Xóa danh sách các sản phẩm của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtmahdn.Text, masanpham[i]);

                //Xóa hóa đơn
                sql = "delete tblhoadonnhap where mahdn=N'" +txtmahdn.Text + "'";
                Function.RunSqlDel(sql);
                Resetvalue();
                Load_ThongtinSanpham();
                Class.Function.FillCombo("select masanpham,masanpham from tblsanpham", cbosp, "masanpham", "masanpham");
                cbosp.SelectedIndex = -1;
                btnhuy.Enabled = false;
                btnin.Enabled = false;
            }
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
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
            exRange.Range["A1:B1"].Value = "Shop LẬP TRÌNH NET";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0332229999";

            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";

            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.mahdn, a.ngaynhap, a.tongtienhang, a.chietkhau, a.tongthanhtoan, b.tenncc, b.diachi, b.dienthoai, c.tennv from tblhoadonnhap AS a, tblnhacungcap AS b, tblnhanvien AS c WHERE a.mahdn = N'" + txtmahdn.Text + "' AND a.mancc = b.mancc AND a.manv = c.manv";
            tblThongtinHD = Function.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][5].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][6].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][7].ToString();

            //Lấy thông tin các mặt hàng
            sql = "select b.tensanpham, a.soluongnhap, b.dongianhap, a.thanhtien from tblchitiethdn as a , tblsanpham as b where a.mahdn = N'" + txtmahdn.Text + "' and a.masanpham = b.masanpham";
            tblThongtinHang = Function.GetDataToTable(sql);

            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá nhập";
            exRange.Range["E11:E11"].Value = "Thành tiền";

            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }

            // Thông tin tổng tiền hàng, chiết khấu, tổng thanh toán
            exRange = exSheet.Cells[1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền hàng:";
            exRange = exSheet.Cells[2][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();

            exRange = exSheet.Cells[1][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = "Chiết khấu:";
            exRange = exSheet.Cells[2][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][3].ToString();

            exRange = exSheet.Cells[1][hang + 16];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng thanh toán:";
            exRange = exSheet.Cells[2][hang + 16];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][4].ToString();

            // Hiển thị tổng thanh toán bằng chữ
            exRange = exSheet.Cells[1][hang + 17]; //Ô A1 
            exRange.Range["A1:H1"].MergeCells = true;
            exRange.Range["A1:H1"].Font.Bold = true;
            exRange.Range["A1:H1"].Font.Italic = true;
            exRange.Range["A1:H1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:H1"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongtinHD.Rows[0][4].ToString());

            // Thông tin ngày in hóa đơn và nhân viên bán hàng
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][8];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbotimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbotimkiem.Focus();
                return;
            }
            txtmahdn.Text = cbotimkiem.Text;
            Load_ThongtinHD();
            Load_ThongtinSanpham();
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
        }

        private void cbotimkiem_DropDown(object sender, EventArgs e)
        {
            Function.FillCombo("select mahdn from tblhoadonnhap", cbotimkiem, "mahdn", "mahdn");
            cbotimkiem.SelectedIndex = -1;
        }

        private void Hoadonnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Resetvalue();
        }

        private void cboncc_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if(cboncc.Text=="")
            {
                txttenncc.Text = "";
                txtdiachi.Text = "";
                msksdt.Text = "(   )    -";
            }    
            sql ="select tenncc from tblnhacungcap where mancc=N'"+cboncc.SelectedValue+"'";
            txttenncc.Text = Class.Function.GetFieldValues(sql);
            sql = "select diachi from tblnhacungcap where mancc=N'" + cboncc.SelectedValue + "'";
            txtdiachi.Text = Class.Function.GetFieldValues(sql);
            sql = "select dienthoai from tblnhacungcap where mancc=N'" + cboncc.SelectedValue + "'";
            msksdt.Text = Class.Function.GetFieldValues(sql);
            Class.Function.FillCombo("select masanpham,masanpham from tblsanpham  where mancc = N'" +cboncc.SelectedValue+ "'", cbosp, "masanpham", "masanpham");
            cbosp.SelectedIndex = -1;
        }

        private void txtgianhap_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dgn;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtgianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(txtgianhap.Text);
            tt = sl * dgn;
            txtthanhtien.Text = tt.ToString();
        }


    }
}
