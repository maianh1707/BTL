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
    public partial class Hoadonnhapnew : Form
    {
        public Hoadonnhapnew()
        {
            InitializeComponent();
        }

        private void Hoadonnhapnew_Load(object sender, EventArgs e)
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
            txttongtien.ReadOnly = true;
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

            Class.Function.FillCombo("select masanpham,masanpham from tblsanpham", cbosp, "masanpham", "masanpham");
            cbosp.SelectedIndex = -1;

            Class.Function.FillCombo("select maco,tenco from tblco", cboco, "maco", "tenco");
            cboco.SelectedIndex = -1;

            Class.Function.FillCombo("select mamau, tenmau from tblmau", cbomau, "mamau", "tenmau");
            cbomau.SelectedIndex = -1;

            Class.Function.FillCombo("select mahdn,mahdn from tblchitiethdn", cbotimkiem, "mahdn", "mahdn");
            cbotimkiem.SelectedIndex = -1;

            if (txtmahdn.Text != "")
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
            sql = "select ngaynhap from tblhoadonnhap where mahdn = N'" + txtmahdn.Text + "'";
            mskngaynhap.Text = Function.ConvertDateTime(Function.GetFieldValues(sql));

            sql = "select manv from tblhoadonnhap where mahdn = N'" + txtmahdn.Text + "'";
            cbotennv.Text = Function.GetFieldValues(sql);

            sql = "select mancc from tblhoadonnhap where mahdn = N'" + txtmahdn.Text + "'";
            cboncc.Text = Function.GetFieldValues(sql);

            sql = "select tongtienhang from tblhoadonnhap where mahdn =N'" + txtmahdn.Text + "'";
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
            sql = "select a.masanpham, b.tensanpham, a.maco, c.tenco,a.mamau, d.tenmau, a.soluongnhap, a.dongianhap,a.thanhtien from tblchitiethdn as a,tblsanpham as b, tblco as c, tblmau as d where a.mahdn = N'" + txtmahdn.Text + "' and a.masanpham = b.masanpham and a.maco=c.maco and a.mamau=d.mamau ";
            tblhdn = Function.GetDataToTable(sql);

            dgridnhaphang.DataSource = tblhdn;

            dgridnhaphang.Columns[0].HeaderText = "Mã sản phẩm";
            dgridnhaphang.Columns[1].HeaderText = "Tên sản phẩm";
            dgridnhaphang.Columns[2].HeaderText = "Mã kích cỡ";
            dgridnhaphang.Columns[3].HeaderText = "Kích cỡ";
            dgridnhaphang.Columns[4].HeaderText = "Mã màu";
            dgridnhaphang.Columns[5].HeaderText = "Màu";
            dgridnhaphang.Columns[6].HeaderText = "Số lượng nhập";
            dgridnhaphang.Columns[7].HeaderText = "Đơn giá nhập";
            dgridnhaphang.Columns[8].HeaderText = "Thành tiền";
            dgridnhaphang.AllowUserToAddRows = false;
            dgridnhaphang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Resetvalue()
        {
            mskngaynhap.Text = DateTime.Now.ToShortDateString();
            cboncc.Text = "";
            cbotennv.Text = "";
            cbosp.Text = "";
            cbomau.Text = "";
            cboco.Text = "";
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnin.Enabled = true;
            btnhuy.Enabled = true;
            btnthem.Enabled = false;
            txtsoluong.ReadOnly = false;
            txtgianhap.ReadOnly = false;
            txtchietkhau.ReadOnly = false;
            mskngaynhap.ReadOnly = false;
            txtmahdn.Text = Class.Function.CreateKey("HDN");
            Load_ThongtinSanpham();
            Resetvalue();
        }
        private void Resetsanpham()
        {
            cbosp.Text = "";
            txtsoluong.Text = "";
            txttensp.Text = "";
            cboco.Text = "";
            cbomau.Text = "";
            txtgianhap.Text = "";
            txtthanhtien.Text = "0";
        }

        private void cboncc_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboncc.Text == "")
            {
                txttenncc.Text = "";
                txtdiachi.Text = "";
                msksdt.Text = "(   )    -";
            }
            sql = "select tenncc from tblnhacungcap where mancc=N'" + cboncc.SelectedValue + "'";
            txttenncc.Text = Class.Function.GetFieldValues(sql);
            sql = "select diachi from tblnhacungcap where mancc=N'" + cboncc.SelectedValue + "'";
            txtdiachi.Text = Class.Function.GetFieldValues(sql);
            sql = "select dienthoai from tblnhacungcap where mancc=N'" + cboncc.SelectedValue + "'";
            msksdt.Text = Class.Function.GetFieldValues(sql);
            Class.Function.FillCombo("select masanpham,masanpham from tblsanpham  where mancc = N'" + cboncc.SelectedValue + "'", cbosp, "masanpham", "masanpham");
            cbosp.SelectedIndex = -1;
        }

        private void cbosp_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cbosp.Text == "")
            {
                txtgianhap.Text = "";
            }
            sql = "select tensanpham from tblsanpham where masanpham=N'" + cbosp.SelectedValue + "'";
            txttensp.Text = Class.Function.GetFieldValue(sql);
            sql = "select dongianhap from tblsanpham where masanpham=N'" + cbosp.SelectedValue + "'";
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
        
        private void btnluu_Click(object sender, EventArgs e)
        {

            string sql;
            //Lưu thông tin chung
            sql = "select mahdn from tblhoadonnhap where mahdn=N'" + txtmahdn.Text + "'";
            if (!Class.Function.CheckKey(sql))
            {
                if (!Function.IsDatenow(mskngaynhap.Text))
                {
                    MessageBox.Show("Ngày nhập lớn hơn hiện tại, hãy nhập lại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskngaynhap.Focus();
                    mskngaynhap.Text = "  /  /";
                    return;
                }
                if (!Function.IsDate(mskngaynhap.Text))
                {
                    MessageBox.Show("Nhập sai ngày nhập, hãy nhập lại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskngaynhap.Focus();
                    mskngaynhap.Text = "  /  /";
                    return;
                }
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
                sql = "insert into tblhoadonnhap(mahdn,ngaynhap,tongtienhang,chietkhau,tongthanhtoan,manv,mancc)values(N'" + txtmahdn.Text.Trim() + "','" + Class.Function.ConvertDateTime(mskngaynhap.Text) + "','" + txttongtienhang.Text + "','" + txtchietkhau.Text + "','" + txttongtien.Text + "',N'" + cbotennv.SelectedValue + "',N'" + cboncc.SelectedValue + "')";
                Class.Function.RunSql(sql);
            }
            //Lưu thông tin sản phẩm
            if (cbosp.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbosp.Focus();
                return;
            }
            if (txtsoluong.Text == "0" || (txtsoluong.Text.Trim().Length == 0))
            {
                MessageBox.Show("Vui lòng nhập số lượng nhập trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsoluong.Focus();
                return;
            }
            if (txtgianhap.Text == "0" || (txtgianhap.Text.Trim().Length == 0))
            {
                MessageBox.Show("Vui lòng nhập giá nhập trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgianhap.Focus();
                return;
            }
            sql = "select masanpham,maco,mamau from tblchitiethdn where masanpham=N'" + cbosp.SelectedValue + "' and maco =N'" + cboco.SelectedValue + "' and mamau=N'" + cbomau.SelectedValue + "' and mahdn=N'" + txtmahdn.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm có kích cỡ và màu sắc này đã có, vui lòng chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Resetsanpham();
                cbosp.Focus();
                cboco.Focus();
                cbomau.Focus();
                return;
            }
            sql = "insert into tblchitiethdn(mahdn,masanpham,maco,mamau,soluongnhap,dongianhap,thanhtien)values(N'" + txtmahdn.Text.Trim() + "',N'" + cbosp.SelectedValue + "',N'" + cboco.SelectedValue + "',N'" + cbomau.SelectedValue + "','" + txtsoluong.Text + "','" + txtgianhap.Text + "','" + txtthanhtien.Text + "')";
            Class.Function.RunSql(sql);

            //Cập nhật đơn giá nhập và đơn giá bán của sản phẩm
            sql = "update tblsanpham set dongianhap='" + txtgianhap.Text + "', dongiaban=" + txtgianhap.Text + " * 1.1 where masanpham=N'" + cbosp.SelectedValue + "'";
            Class.Function.RunSql(sql);
            Load_ThongtinSanpham();


            //Cập nhật số lượng hàng 
            double slcon = 0, sl = 0;
            try
            {
                sl = Convert.ToDouble(Function.GetFieldValues("select soluong from tblchitietsanpham where masanpham = N'" + cbosp.SelectedValue + "' and maco=N'" + cboco.SelectedValue + "' and mamau=N'" + cbomau.SelectedValue + "'"));
                slcon = sl + Convert.ToDouble(txtsoluong.Text);
            }
            catch (FormatException)
            {
                sl = 0;
                slcon= Convert.ToDouble(txtsoluong.Text);
            }
            sql = "update tblchitietsanpham set soluong =" + slcon + " where masanpham = N'" + cbosp.SelectedValue + "' and maco=N'" + cboco.SelectedValue + "' and mamau=N'" + cbomau.SelectedValue + "'";
            Function.RunSql(sql);


            //Cập nhật tổng thành tiền và tổng thanh toán

            double tongthanhtien = 0, tongthanhtienmoi = 0;

            tongthanhtien = Convert.ToDouble(Function.GetFieldValues("select tongtienhang from tblhoadonnhap where mahdn = N'" + txtmahdn.Text + "'and ngaynhap='" + Class.Function.ConvertDateTime(mskngaynhap.Text) + "'"));
            
            tongthanhtienmoi = tongthanhtien + Convert.ToDouble(txtthanhtien.Text);
            
            sql = "update tblhoadonnhap set tongtienhang = " + tongthanhtienmoi + " where mahdn=N'" + txtmahdn.Text + "'";
            Class.Function.RunSql(sql);

            double ck = 0, tongthanhtoan = 0;
            ck = Convert.ToDouble(txtchietkhau.Text);
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

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtchietkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgridnhaphang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masanpham, maco, mamau;
            double thanhtien;
            if (tblhdn.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                masanpham = dgridnhaphang.CurrentRow.Cells["masanpham"].Value.ToString();
                maco = dgridnhaphang.CurrentRow.Cells["maco"].Value.ToString();
                mamau = dgridnhaphang.CurrentRow.Cells["mamau"].Value.ToString();
                DelHang(txtmahdn.Text, masanpham,maco,mamau);

                // Cập nhật lại tổng tiền cho hóa đơn bán
                thanhtien = Convert.ToDouble(dgridnhaphang.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtien(txtmahdn.Text, thanhtien);
                Load_ThongtinSanpham();
            }
        }
        private void DelHang(string mahoadonnhap, string masanpham,string maco, string mamau)
        {
            double s, sl, slcon;
            string sql;

            try
            {
                sql = "select soluongnhap from tblchitiethdn where mahdn = N'" + mahoadonnhap + "' and masanpham = N'" + masanpham + "' and maco = N'" + maco + "' and mamau = N'" + mamau + "'";
                s = Convert.ToDouble(Function.GetFieldValues(sql));
            }
            catch
            {
                s = 0;
            }
            sql = "delete from tblchitiethdn where mahdn = N'" + mahoadonnhap + "' and masanpham = N'" + masanpham + "' and maco = N'" + maco + "' and mamau = N'" + mamau + "'";
            Function.RunSqlDel(sql);

            // Cập nhật lại số lượng cho các mặt hàng
            try
            {
                sql = "select soluong from tblchitietsanpham where masanpham = N'" + masanpham + "' and maco = N'" + maco + "' and mamau = N'" + mamau + "'";
                sl = Convert.ToDouble(Function.GetFieldValues(sql));
            }
            catch
            {
                sl = 0;
            }

            slcon = sl - s;
            sql = "update tblchitietsanpham set soluong = " + slcon + " where masanpham = N'" + masanpham + "' and maco = N'" + maco + "' and mamau = N'" + mamau + "'";
            Function.RunSql(sql);
            
        }
        private void DelUpdateTongtien(string mahoadonnhap, double thanhtien)
        {
            Double tongtienhang, tongtienhangmoi, tongthanhtoanmoi;
            string sql;
            sql = "select tongtienhang from tblhoadonnhap where mahdn = N'" + mahoadonnhap + "'";
            tongtienhang = Convert.ToDouble(Function.GetFieldValues(sql));

            tongtienhangmoi = tongtienhang - thanhtien;

            sql = "update tblhoadonnhap set tongtienhang =" + tongtienhangmoi + " where mahdn = N'" + mahoadonnhap + "'";
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
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] masanpham = new string[20];
                string[] maco =new string[20];
                string[] mamau = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "select masanpham, maco,mamau from tblchitiethdn where mahdn = N'" + txtmahdn.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Function.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    masanpham[n] = reader.GetString(0).ToString();
                    maco[n] = reader.GetString(1).ToString();
                    mamau[n] = reader.GetString(2).ToString();
                    n = n + 1;
                }
                reader.Close();

                //Xóa danh sách các sản phẩm của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtmahdn.Text, masanpham[i], maco[i], mamau[i]);

                //Xóa hóa đơn
                sql = "delete tblhoadonnhap where mahdn=N'" + txtmahdn.Text + "'";
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
            exRange.Range["B10:B10"].Value = "Nhân viên nhập:";
            exRange.Range["C10:E10"].MergeCells = true;
            exRange.Range["C10:E10"].Value = tblThongtinHD.Rows[0][8].ToString();
            exRange.Range["B11:B11"].Value = "Ngày nhập:";
            exRange.Range["C11:E11"].MergeCells = true;
            exRange.Range["C11:E11"].Value = tblThongtinHD.Rows[0][1].ToString();

            // Lấy thông tin các mặt hàng
            sql = "SELECT b.tensanpham, c.tenco, d.tenmau, a.soluongnhap, a.dongianhap, a.thanhtien " +
                  "FROM tblchitiethdn AS a, tblsanpham AS b, tblco AS c, tblmau AS d " +
                  "WHERE a.mahdn = N'" + txtmahdn.Text + "' AND a.masanpham = b.masanpham AND a.maco = c.maco AND a.mamau = d.mamau";
            tblThongtinHang = Function.GetDataToTable(sql);

            // Tạo dòng tiêu đề bảng
            exRange.Range["A13:F13"].Font.Bold = true;
            exRange.Range["A13:F13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C13:F13"].ColumnWidth = 12;
            exRange.Range["A13:A13"].Value = "STT";
            exRange.Range["B13:B13"].Value = "Tên sản phẩm";
            exRange.Range["C13:C13"].Value = "Kích cỡ";
            exRange.Range["D13:D13"].Value = "Màu sắc";
            exRange.Range["E13:E13"].Value = "Số lượng";
            exRange.Range["F13:F13"].Value = "Đơn giá";
            exRange.Range["G13:G13"].Value = "Thành tiền";

            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                // Điền số thứ tự hàng
                exSheet.Cells[2][hang + 14] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 14] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }

            // Tổng kết
            exRange = exSheet.Cells[2][hang + 17];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền hàng:";
            exRange = exSheet.Cells[3][hang + 17];
            exRange.Font.Bold = true;
            exRange.Value2 = txttongtienhang.Text;

            exRange = exSheet.Cells[2][hang + 18];
            exRange.Font.Bold = true;
            exRange.Value2 = "Chiết khấu:";
            exRange = exSheet.Cells[3][hang + 18];
            exRange.Font.Bold = true;
            exRange.Value2 = txtchietkhau.Text;

            exRange = exSheet.Cells[2][hang + 19];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng thanh toán:";
            exRange = exSheet.Cells[3][hang + 19];
            exRange.Font.Bold = true;
            exRange.Value2 = txttongtien.Text;

            exRange = exSheet.Cells[1][hang + 21];
            exRange.Range["A1:G1"].MergeCells = true;
            exRange.Range["A1:G1"].Font.Italic = true;
            exRange.Range["A1:G1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:G1"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(txttongtien.Text);

            // Kết thúc biểu mẫu
            exRange = exSheet.Cells[4][hang + 24];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập hàng";

            exRange.Range["A5:C5"].MergeCells = true;
            exRange.Range["A5:C5"].Font.Italic = true;
            exRange.Range["A5:C5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:C5"].Value = tblThongtinHD.Rows[0][8];

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

        private void Hoadonnhapnew_FormClosing(object sender, FormClosingEventArgs e)
        {
            Resetvalue();
        }
    }
}
