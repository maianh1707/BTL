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
    public partial class Baocaocuoingay : Form
    {
        public Baocaocuoingay()
        {
            InitializeComponent();
        }

        private void Baocaocuoingay_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnhuy.Enabled = false;
            btnin.Enabled = false;
            btnluu.Enabled = false;
            btndong.Enabled = true;
            txtmabaocao.ReadOnly = true;
            mskngay.ReadOnly = true;
            txttensp.ReadOnly = true;
            txtsoluongnhap.ReadOnly = true;
            txtsoluongban.ReadOnly = true;
            txttongtienban.ReadOnly = true;
            txttongtiennhap.ReadOnly = true;
            txtdoanhthu.ReadOnly = true;
            txttongdoanhthu.ReadOnly=true;
            txtsoluongban.Text = "0";
            txtsoluongnhap.Text = "0";
            txtgiaban.Text = "0";
            txtgianhap.Text = "0";
            txtgianhap.ReadOnly = true;
            txtgiaban.ReadOnly = true;
            txttongtienban.Text = "0";
            txttongtiennhap.Text="0";
            txtdoanhthu.Text = "0";
            txttongdoanhthu.Text="0";
            Class.Function.FillCombo("select manv,tennv from tblnhanvien", cbonv, "manv", "tennv");
            cbonv.SelectedIndex = -1;
            Class.Function.FillCombo("select masanpham,masanpham from tblsanpham", cbosp, "masanpham", "masanpham");
            cbosp.SelectedIndex = -1;
            if(txtmabaocao.Text != "")
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
            sql = "select ngaybaocao from tblbaocaocuoingay where mabaocao = N'" + txtmabaocao.Text + "'";
            mskngay.Text = Function.ConvertDateTime(Function.GetFieldValues(sql));

            sql = "select manv from tblbaocaocuoingay where mabaocao = N'" + txtmabaocao.Text + "'";
            cbonv.Text = Function.GetFieldValues(sql);

            sql = "select tongdoanhthu from tblbaocaocuoingay where mabaocao =N'" + txtmabaocao.Text + "'";
            txttongdoanhthu.Text = Function.GetFieldValues(sql);

        }
        DataTable tblbccn;
        private void Load_ThongtinSanpham()
        {
            string sql;
            sql = "select a.masanpham, b.tensanpham, a.soluongnhap, a.dongianhap, a.tongtiennhap, a.soluongban, a.dongiaban, a.tongtienban, a.doanhthu from tblchitietbaocaocn as a " + " join tblsanpham as b on a.masanpham = b.masanpham where a.mabaocao= N'" + txtmabaocao.Text + "'";
            tblbccn = Function.GetDataToTable(sql);

            dgridbccn.DataSource = tblbccn;

            dgridbccn.Columns[0].HeaderText = "Mã sản phẩm";
            dgridbccn.Columns[1].HeaderText = "Tên sản phẩm";
            dgridbccn.Columns[2].HeaderText = "Số lượng nhập";
            dgridbccn.Columns[3].HeaderText = "Đơn giá nhập";
            dgridbccn.Columns[4].HeaderText = "Tổng tiền nhập";
            dgridbccn.Columns[5].HeaderText = "Số lượng bán";
            dgridbccn.Columns[6].HeaderText = "Đơn giá bán";
            dgridbccn.Columns[7].HeaderText = "Tổng tiền bán";
            dgridbccn.Columns[8].HeaderText = "Doanh thu";
            dgridbccn.AllowUserToAddRows = false;
            dgridbccn.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Resetvalue()
        {
            mskngay.Text = DateTime.Now.ToShortDateString();
            cbonv.Text = "";
            cbosp.Text = "";
            txttensp.Text = "";
            txtsoluongban.Text = "";
            txtsoluongnhap.Text = "0";
            txtgianhap.Text = "0";
            txtgiaban.Text = "0";
            txttongtienban.Text = "0";
            txttongtiennhap.Text = "0";
            txtdoanhthu.Text = "0";
            txttongdoanhthu.Text = "0";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnin.Enabled = true;
            btnhuy.Enabled = true;
            btnthem.Enabled = false;
            txtmabaocao.Text = Class.Function.CreateKey("BCCN");
            Load_ThongtinSanpham();
            Resetvalue();
        }
        private void Resetsanpham()
        {
            cbosp.Text = "";
            txttensp.Text = "";
            txtsoluongnhap.Text = "";
            txtsoluongban.Text = "";
            txtgianhap.Text = "0";
            txtgiaban.Text = "0";
            txttongtiennhap.Text = "0"; 
            txttongtienban.Text = "0";
            txtdoanhthu.Text = "0";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            //Lưu thông tin chung
            sql = "select mabaocao from tblbaocaocuoingay where mabaocao=N'" + txtmabaocao.Text + "'";
            if (!Class.Function.CheckKey(sql))
            {
                if (cbonv.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn nhân viên trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbonv.Focus();
                    return;
                }
                sql = "insert into tblbaocaocuoingay(mabaocao,ngaybaocao,manv,tongdoanhthu)values(N'" + txtmabaocao.Text.Trim() + "','" + Class.Function.ConvertDateTime(mskngay.Text) + "',N'"+cbonv.SelectedValue+"','"+txttongdoanhthu.Text+"')";
                Class.Function.RunSql(sql);
            }
            //Lưu thông tin sản phẩm
            if (cbosp.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbosp.Focus();
                return;
            }
            sql = "select masanpham from tblchitietbaocaocn where masanpham=N'" + cbosp.SelectedValue + "'and mabaocao=N'" + txtmabaocao.Text.Trim() + "'";
            if (Class.Function.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, vui lòng chọn sản phẩm khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Resetsanpham();
                cbosp.Focus();
                return;
            }
            sql = "insert into tblchitietbaocaocn(mabaocao,masanpham,soluongnhap,dongianhap,tongtiennhap,soluongban,dongiaban,tongtienban,doanhthu)values(N'"+txtmabaocao.Text.Trim()+"',N'"+cbosp.SelectedValue+"','"+txtsoluongnhap.Text+"','"+txtgianhap.Text+"','"+txttongtiennhap.Text+"','"+txtsoluongban.Text+"','"+txtgiaban.Text+"','"+txttongtienban.Text+"','"+txtdoanhthu.Text+"')";
            Class.Function.RunSql(sql);
            Load_ThongtinSanpham();

            //Cập nhật tổng doanh thu
            double tongdoanhthu = 0, tongdoanhthumoi = 0;
            tongdoanhthu = Convert.ToDouble(Function.GetFieldValues("select tongdoanhthu from tblbaocaocuoingay where mabaocao= N'" + txtmabaocao.Text + "'"));
            tongdoanhthumoi = tongdoanhthu + Convert.ToDouble(txtdoanhthu.Text);

            sql = "update tblbaocaocuoingay set tongdoanhthu = " + tongdoanhthumoi + " where mabaocao=N'" + txtmabaocao.Text + "'";
            Class.Function.RunSql(sql);

            txttongdoanhthu.Text= tongdoanhthumoi.ToString();
            Resetsanpham();
            btnhuy.Enabled = true;
            btnin.Enabled = true;
            btnthem.Enabled = true;
        }

        private void cbosp_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cbosp.Text == "")
            {
                txttensp.Text = "";
                txtgianhap.Text = "0";
                txtgiaban.Text = "0";
            }
            
            sql = "select tensanpham from tblsanpham where masanpham=N'" + cbosp.SelectedValue + "'";
            txttensp.Text = Class.Function.GetFieldValues(sql);

            sql = "select dongianhap from tblsanpham where masanpham=N'" + cbosp.SelectedValue + "'";
            txtgianhap.Text = Class.Function.GetFieldValues(sql);

            sql = "select dongiaban from tblsanpham where masanpham=N'" + cbosp.SelectedValue + "'";
            txtgiaban.Text = Class.Function.GetFieldValues(sql);

            sql = "select sum(soluongnhap) from tblchitiethdn as a " + " join tblhoadonnhap as b on a.mahdn = b.mahdn where a.masanpham=N'" + cbosp.SelectedValue + "'and b.ngaynhap='" + Class.Function.ConvertDateTime(mskngay.Text) + "'";
            txtsoluongnhap.Text = Class.Function.GetFieldValue(sql);

            sql = "select sum(soluongxuat) from tblchitiethdb as a " + " join tblhoadonban as b on a.mahdb = b.mahdb where a.masanpham=N'" + cbosp.SelectedValue + "'and b.ngayban='" + Class.Function.ConvertDateTime(mskngay.Text) + "'";
            txtsoluongban.Text = Class.Function.GetFieldValue(sql);
        }

        private void txtsoluongnhap_TextChanged(object sender, EventArgs e)
        {
            double ttn, sln, dgn;
            if (txtsoluongnhap.Text == "")
                sln = 0;
            else
                sln = Convert.ToDouble(txtsoluongnhap.Text);
            if (txtgianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(txtgianhap.Text);
            ttn = sln * dgn;
            txttongtiennhap.Text = ttn.ToString();
        }

        private void txtsoluongban_TextChanged(object sender, EventArgs e)
        {
            double ttb, slb, dgb;
            if (txtsoluongban.Text == "")
                slb = 0;
            else
                slb = Convert.ToDouble(txtsoluongban.Text);
            if (txtgiaban.Text == "")
                dgb = 0;
            else
                dgb = Convert.ToDouble(txtgiaban.Text);
            ttb = slb * dgb;
            txttongtienban.Text = ttb.ToString();
        }

        private void txttongtiennhap_TextChanged(object sender, EventArgs e)
        {
            double ttn, ttb, tdt;
            if (txttongtiennhap.Text == "")
                ttn = 0;
            else
                ttn = Convert.ToDouble(txttongtiennhap.Text);
            if(txttongtienban.Text=="")
                ttb = 0;
            else
                ttb= Convert.ToDouble(txttongtienban.Text);
            tdt = ttb - ttn;
            txtdoanhthu.Text = tdt.ToString();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgridbccn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masanpham;
            double doanhthu;
            if (tblbccn.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                masanpham = dgridbccn.CurrentRow.Cells["masanpham"].Value.ToString();
                DelHang(txtmabaocao.Text, masanpham);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                doanhthu = Convert.ToDouble(dgridbccn.CurrentRow.Cells["doanhthu"].Value.ToString());
                DelUpdateTongdoanhthu(txtmabaocao.Text, doanhthu);
                Load_ThongtinSanpham();
            }
        }
        private void DelHang(string mabaocao, string masanpham)
        {
            string sql;
            sql = "delete tblchitietbccn where mabaocao=N'" + mabaocao + "' and masanpham = N'" + masanpham + "'";
            Function.RunSqlDel(sql);
        }
        private void DelUpdateTongdoanhthu(string mabaocao, double doanhthu)
        {
            Double tongdoanhthu, tongdoanhthumoi;
            string sql;
            sql = "select tongdoanhthu from tblbaocaocuoingay where mabaocao = N'" + mabaocao + "'";
            tongdoanhthu = Convert.ToDouble(Function.GetFieldValues(sql));
            tongdoanhthumoi= tongdoanhthu - doanhthu;

            sql = "update tblbaocaocuoingay set tongdoanhthu=" + tongdoanhthumoi + " where mabaocao = N'" +mabaocao + "'";
            Function.RunSql(sql);
            txttongdoanhthu.Text = tongdoanhthumoi.ToString();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] masanpham = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "select masanpham from tblchitietbaocaocn where mabaocao= N'" + txtmabaocao.Text + "'";
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
                    DelHang(txtmabaocao.Text, masanpham[i]);

                //Xóa hóa đơn
                sql = "delete tblbaocaocuoingay where mabaocao=N'" + txtmabaocao.Text + "'";
                Function.RunSqlDel(sql);
                Resetvalue();
                Load_ThongtinSanpham();
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
            exRange.Range["C2:E2"].Value = "BÁO CÁO CUỐI NGÀY";

            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.mabaocao, a.ngaybaocao,a.tongdoanhthu, b.tennv from tblbaocaocuoingay AS a, tblnhanvien AS b WHERE a.mabaocao = N'" +txtmabaocao.Text + "' AND a.manv = b.manv";
            tblThongtinHD = Function.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã báo cáo:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Ngày báo cáo:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][1].ToString();

            //Lấy thông tin các mặt hàng
            sql = "select b.tensanpham, a.soluongnhap,a.dongianhap,a.tongtiennhap, a.soluongban, a.dongiaban,a.tongtienban,a.doanhthu  from tblchitietbaocaocn as a , tblsanpham as b where a.mabaocao = N'" + txtmabaocao.Text + "' and a.masanpham = b.masanpham";
            tblThongtinHang = Function.GetDataToTable(sql);

            // Lấy thông tin các mặt hàng
            sql = "select b.tensanpham, a.soluongnhap, a.dongianhap, a.tongtiennhap, a.soluongban, a.dongiaban, a.tongtienban, a.doanhthu " +
                  "from tblchitietbaocaocn as a, tblsanpham as b " +
                  "where a.mabaocao = N'" + txtmabaocao.Text + "' and a.masanpham = b.masanpham";
            tblThongtinHang = Function.GetDataToTable(sql);

            // Tạo dòng tiêu đề bảng
            exRange.Range["A11:I18"].Font.Bold = true;
            exRange.Range["A11:I18"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:I18"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sản phẩm";
            exRange.Range["C11:C11"].Value = "Số lượng nhập";
            exRange.Range["D11:D11"].Value = "Đơn giá nhập";
            exRange.Range["E11:E11"].Value = "Tổng tiền nhập";
            exRange.Range["F11:F11"].Value = "Số lượng bán";
            exRange.Range["G11:G11"].Value = "Đơn giá bán";
            exRange.Range["H11:H11"].Value = "Tổng tiền bán";
            exRange.Range["I11:I11"].Value = "Doanh thu";

            exRange.Range["I17:I17"].Value = "Tổng doanh thu:";
            exRange.Range["I18:I18"].MergeCells = true;
            exRange.Range["I18:I18"].Value = tblThongtinHD.Rows[0][2].ToString();

            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                // Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[hang + 12, 1] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                {
                    // Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[hang + 12, cot + 2] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }
            // Thông tin ngày in hóa đơn và nhân viên báo cáo
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên báo cáo";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][3];
            exSheet.Name = "Báo cáo cuối ngày";
            exApp.Visible = true;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbotimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã báo cáo để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbotimkiem.Focus();
                return;
            }
            txtmabaocao.Text = cbotimkiem.Text;
            Load_ThongtinHD();
            Load_ThongtinSanpham();
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
        }

        private void cbotimkiem_DropDown(object sender, EventArgs e)
        {
            Function.FillCombo("select mabaocao from tblbaocaocuoingay", cbotimkiem, "mabaocao", "mabaocao");
            cbotimkiem.SelectedIndex = -1;
        }

        private void Baocaocuoingay_FormClosing(object sender, FormClosingEventArgs e)
        {
            Resetvalue();
        }
    }
}
