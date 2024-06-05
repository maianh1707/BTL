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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace BTL
{
    public partial class SP : Form
    {
        public SP()
        {
            InitializeComponent();
        }
        DataTable tblsp;
        private void SP_Load(object sender, EventArgs e)
        {
            txtma.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            Functions.FillCombo("SELECT machatlieu, tenchatlieu FROM tblchatlieu", cbocl, "machatlieu", "tenchatlieu");
            cbocl.SelectedIndex = -1;
            
            Functions.FillCombo("SELECT mancc, tenncc FROM tblnhacungcap", cboncc, "mancc", "tenncc");
            cboncc.SelectedIndex = -1;
           
            Functions.FillCombo("SELECT maloai, tenloai FROM tblloai", cboloai, "maloai", "tenloai");
            cboloai.SelectedIndex = -1;
            Functions.FillCombo("SELECT mamau, tenmau FROM tblmau", cbomau, "mamau", "tenmau");
            cbomau.SelectedIndex = -1;
            Functions.FillCombo("SELECT mamua, tenmua FROM tblmua", cbomua, "mamua", "tenmua");
            cbomua.SelectedIndex = -1;
            Functions.FillCombo("SELECT maco, tenco FROM tblco", cbokc, "maco", "tenco");
            cbokc.SelectedIndex = -1;
            ResetValues();

        }
        private void ResetValues()
        {
            txtma.Text = "";
            txtten.Text = "";
            cboncc.Text = "";
            cbocl.Text = "";
            cbomua.Text = "";
            cbomau.Text = "";
            cbokc.Text = "";
            cboloai.Text = "";
            txtsl.Text = "0";
            txtdgn.Text = "0";
            txtdgb.Text = "0";
            txtsl.Enabled = false;
            txtdgn.Enabled = false;
            txtdgb.Enabled = false;

            txtAnh.Text = "";
            picAnh.Image = null;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.masanpham, tensanpham,soluong,dongianhap, dongiaban,maloai,maco,machatlieu,mamau,mamua,mancc  FROM tblsanpham a join tblchitietsp b on a.masanpham = b.masanpham\r\n";
            tblsp = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblsp;
            DataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridView.Columns[2].HeaderText = "Số lượng";
            DataGridView.Columns[3].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[4].HeaderText = "Đơn giá bán";
            DataGridView.Columns[5].HeaderText = "Loại sản phẩm";
            DataGridView.Columns[6].HeaderText = "Kích cỡ";
            DataGridView.Columns[7].HeaderText = "Chất liệu";
            DataGridView.Columns[8].HeaderText = "Màu";
            DataGridView.Columns[9].HeaderText = "Mùa";
            DataGridView.Columns[10].HeaderText = "Nhà cung cấp";
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string cl, kc, mau, mua, loai, ncc;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtma.Focus();
                return;
            }
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtma.Text = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
            txtten.Text = DataGridView.CurrentRow.Cells["tensanpham"].Value.ToString();
            ncc= DataGridView.CurrentRow.Cells["mancc"].Value.ToString();
            cboncc.Text = Functions.GetFieldValues("SELECT tenncc FROM tblnhacungcap WHERE mancc = N'" + ncc + "'");

            loai = DataGridView.CurrentRow.Cells["maloai"].Value.ToString();
            cboloai.Text = Functions.GetFieldValues("SELECT tenloai FROM tblloai WHERE maloai = N'" + loai + "'");

            cl = DataGridView.CurrentRow.Cells["machatlieu"].Value.ToString();
            cbocl.Text = Functions.GetFieldValues("SELECT tenchatlieu FROM tblchatlieu WHERE machatlieu = N'" + cl + "'");

            mau = DataGridView.CurrentRow.Cells["mamau"].Value.ToString();
            cbomau.Text = Functions.GetFieldValues("SELECT tenmau FROM tblmau WHERE mamau = N'" + mau + "'");

            mua = DataGridView.CurrentRow.Cells["mamua"].Value.ToString();
            cbomua.Text = Functions.GetFieldValues("SELECT tenmua FROM tblmua WHERE mamua = N'" + mua + "'");

            kc = DataGridView.CurrentRow.Cells["maco"].Value.ToString();
            cbokc.Text = Functions.GetFieldValues("SELECT tenco FROM tblco WHERE maco = N'" + kc + "'");


            txtsl.Text = DataGridView.CurrentRow.Cells["Soluong"].Value.ToString();
            txtdgn.Text = DataGridView.CurrentRow.Cells["dongianhap"].Value.ToString();
            txtdgb.Text = DataGridView.CurrentRow.Cells["dongiaban"].Value.ToString();
            txtAnh.Text = Functions.GetFieldValues("SELECT anh FROM tblsanpham WHERE masanpham = N'" + txtma.Text + "'");

            picAnh.Image = Image.FromFile(txtAnh.Text);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            ////  sql = "INSERT INTO tblsanpham(masanpham,tensanpham,soluong,anh,dongianhap, dongiaban,maloai,maco,machatlieu,mamau,mamua,mancc) VALUES(N'\" + txtma.Text.Trim() +\"',N'\" + txtten.Text.Trim() + \"','\" + txtsl.Text.Trim() + \"','\" + txtAnh.Text + \"','\" + txtdgn.Text + \"','\" + txtdgb.Text + \"',N'\" + txtloai.Text.Trim() + \"',N'\" + cbokc.SelectedValue.ToString() + \"',N'\" + cbocl.SelectedValue.ToString() + \"',N'\" + cbomau.SelectedValue.ToString() + \"',N'\" + cbomua.SelectedValue.ToString() + \"',N'\" + txtncc.Text.Trim() + \"');\r\n";
            //sql = "UPDATE tblsanpham SET " +
            //   "tensanpham=N'" + txtten.Text.Trim() + "', " +
            //   "anh='" + txtAnh.Text + "', " +
            //   "maloai=N'" + cboloai.SelectedValue.ToString() + "', " +
            //   "machatlieu=N'" + cbocl.SelectedValue.ToString() + "', " +
            //   "mamau=N'" + cbomau.SelectedValue.ToString() + "', " +
            //   "mamua=N'" + cbomua.SelectedValue.ToString() + "', " +
            //   "mancc=N'" + Functions.GetFieldValues("SELECT mancc FROM tblnhacungcap WHERE tenncc = N'" + txtncc.Text.Trim() + "'") + "' " +
            //   "WHERE masanpham=N'" + txtma.Text.Trim() + "'";

            //Functions.RunSql(sql);
            //Load_DataGridView();
            //ResetValues();
            //btnXoa.Enabled = true;
            //btnThem.Enabled = true;
            //btnSua.Enabled = true;
            //btnBoqua.Enabled = false;
            //btnLuu.Enabled = false;
            //txtma.Enabled = false;
            ////Thêm số lượng khi nhập hàng
            ////float sl, SLcon;
            ////sl= Convert.ToSingle(Class.Functions.GetFieldValues("SELECT soluong FROM tblsanpham WHERE masp = N'" + txtma + "'"));
            ////SLcon = sl + Convert.ToSingle(txtsl);
            ////sql = "UPDATE tblsanpham SET soluong =" + SLcon + " WHERE masp = N'" + txtma + "'";
            ////Class.Functions.RunSql(sql);

          //  string sql;
            if (txtma.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Focus();
                return;
            }
            if (txtten.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtten.Focus();
                return;
            }

            if (cboloai.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboloai.Focus();
                return;
            }
            if (cbocl.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbocl.Focus();
                return;
            }
            if (cbomau.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn màu sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomau.Focus();
                return;
            }
            if (cbomua.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn mùa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomua.Focus();
                return;
            }
            if (cbokc.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn kích cỡ sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbokc.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }
            if (cboncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboncc.Focus();
                return;
            }


            // Thêm sản phẩm mới vào cơ sở dữ liệu với giá trị ban đầu cho giá bán, giá nhập và số lượng là 0
            //sql = "INSERT INTO tblsanpham (masanpham, tensanpham, soluong, anh, dongianhap, dongiaban, maloai, maco, machatlieu, mamau, mamua, mancc) VALUES (N'" +
            //      txtma.Text.Trim() + "', N'" +
            //      txtten.Text.Trim() + "', '0', '" +
            //      txtAnh.Text + "', '0', '0', N'" +
            //      cboloai.SelectedValue.ToString() + "', N'" +
            //      cbokc.SelectedValue.ToString() + "', N'" +
            //      cbocl.SelectedValue.ToString() + "', N'" +
            //      cbomau.SelectedValue.ToString() + "', N'" +
            //      cbomua.SelectedValue.ToString() + "', N'" +
            //      Functions.GetFieldValues("SELECT mancc FROM tblnhacungcap WHERE tenncc = N'" + txtncc.Text.Trim() + "'") + "')";

            //string sqlSanPham = "INSERT INTO tblsanpham (masanpham, tensanpham, anh,dongianhap,dongiaban, maloai, mancc) VALUES (N'" +
            //       txtma.Text.Trim() + "', N'" +
            //       txtten.Text.Trim() + "', '" +
            //       txtAnh.Text + "', '0', '0', N'" +
            //       cboloai.SelectedValue.ToString() + "', N'" +
            //       cboncc.SelectedValue.ToString() + "')"; 
            string sqlSanPham = "INSERT INTO tblsanpham (masanpham, tensanpham, anh, dongianhap, dongiaban, maloai, mancc, machatlieu,mamua) VALUES (N'" +
   txtma.Text.Trim() + "', N'" +
   txtten.Text.Trim() + "', '" +
   txtAnh.Text + "', '0', '0', N'" +
   cboloai.SelectedValue.ToString() + "', N'" +
   cboncc.SelectedValue.ToString() + "', N'" +
   cbocl.SelectedValue.ToString() + "', N'" +
   cbomua.SelectedValue.ToString() + "')";


            // Thêm dữ liệu vào bảng tblchitietsp
            string sqlChiTietSP = "INSERT INTO tblchitietsp (masanpham, maco, mamau, soluong) VALUES (N'" +
               txtma.Text.Trim() + "', N'" + // Thiết lập giá trị mặc định cho dongianhap và dongiaban
               cbokc.SelectedValue.ToString() + "', N'" +
               cbomau.SelectedValue.ToString() + "', '0')";

            // Thực thi câu lệnh SQL
            try
            {
                Functions.RunSql(sqlSanPham);
                Functions.RunSql(sqlChiTietSP);
                MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DataGridView(); // Cập nhật lại DataGridView sau khi thêm mới sản phẩm
                ResetValues(); // Reset các giá trị nhập liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CapNhatSanPhamTuHoaDonNhap(string maSanPham)
        {
            try
            {
                // Lấy giá nhập từ chi tiết hóa đơn nhập
                string queryGiaNhap = "SELECT TOP 1 dongianhap FROM tblchitietHDN WHERE masanpham = N'" + maSanPham + "' ORDER BY ngaynhap DESC";
                double giaNhap = Convert.ToDouble(Functions.GetFieldValues(queryGiaNhap));

                // Tính giá bán (110% giá nhập)
                double giaBan = giaNhap * 1.1;

                // Lấy tổng số lượng nhập từ chi tiết hóa đơn nhập
                string querySoLuongNhap = "SELECT SUM(soluong) FROM tblchitietHDN WHERE masanpham = N'" + maSanPham + "'";
                int soLuongNhap = Convert.ToInt32(Functions.GetFieldValues(querySoLuongNhap));

                // Lấy tổng số lượng bán từ chi tiết hóa đơn bán
                string querySoLuongBan = "SELECT SUM(soluong) FROM tblchitietHDB WHERE masanpham = N'" + maSanPham + "'";
                int soLuongBan = Convert.ToInt32(Functions.GetFieldValues(querySoLuongBan));

                // Tính số lượng tồn kho
                int soLuongTon = soLuongNhap - soLuongBan;

                // Cập nhật sản phẩm với giá nhập, giá bán và số lượng mới
                string sqlUpdate = "UPDATE tblsanpham SET dongianhap = " + giaNhap + ", dongiaban = " + giaBan + ", soluong = " + soLuongTon + " WHERE masanpham = N'" + maSanPham + "'";
                Functions.RunSql(sqlUpdate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CapNhatSanPhamTuHoaDonBan(string maSanPham)
        {
            try
            {
                // Lấy tổng số lượng nhập từ chi tiết hóa đơn nhập
                string querySoLuongNhap = "SELECT SUM(soluong) FROM tblchitietHDN WHERE masanpham = N'" + maSanPham + "'";
                int soLuongNhap = Convert.ToInt32(Functions.GetFieldValues(querySoLuongNhap));

                // Lấy tổng số lượng bán từ chi tiết hóa đơn bán
                string querySoLuongBan = "SELECT SUM(soluong) FROM tblchitietHDB WHERE masanpham = N'" + maSanPham + "'";
                int soLuongBan = Convert.ToInt32(Functions.GetFieldValues(querySoLuongBan));

                // Tính số lượng tồn kho
                int soLuongTon = soLuongNhap - soLuongBan;

                // Cập nhật sản phẩm với số lượng mới
                string sqlUpdate = "UPDATE tblsanpham SET soluong = " + soLuongTon + " WHERE masanpham = N'" + maSanPham + "'";
                Functions.RunSql(sqlUpdate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "bitmap(*.jpg)|*.jpg|png(*.png)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "D:\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
             string sql;
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtma.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Focus();
                return;
            }
            if (txtten.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtten.Focus();
                return;
            }
            if (cboloai.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboloai.Focus();
                return;
            }
            if (cbocl.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbocl.Focus();
                return;
            }
            if (cbomau.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn màu sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomau.Focus();
                return;
            }
            if (cbomua.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn mùa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomua.Focus();
                return;
            }
            if (cbokc.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn kích cỡ sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbokc.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }
            if (cboncc.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboncc.Focus();
                return;
            }

            try
            {

                //sql = "UPDATE tblsanpham SET tensanpham=N'" + txtten.Text.Trim().ToString() + "',anh='" + txtAnh.Text + "',maloai=N'" + cboloai.SelectedValue.ToString() + "',mamua=N'" + cbomua.SelectedValue.ToString() + "',mancc=N'" + txtncc.Text.Trim() + "'  WHERE masanpham=N'" + txtma.Text.Trim().ToString() + "'";
             sql = "UPDATE tblsanpham SET tensanpham=N'" + txtten.Text.Trim().ToString() + "',anh='" + txtAnh.Text + "',maloai=N'" + cboloai.SelectedValue.ToString() + "',mamua=N'" + cbomua.SelectedValue.ToString() + "'  WHERE masanpham=N'" + txtma.Text.Trim().ToString() + "'";

                // Chạy câu lệnh SQL
                Class.Functions.RunSql(sql);

        // Cập nhật lại DataGridView sau khi cập nhật
        Load_DataGridView();

        // Reset các trường dữ liệu
        ResetValues();

        // Vô hiệu hóa nút bỏ qua
        btnBoqua.Enabled = false;

        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtma.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblsanpham WHERE masanpham=N'" + txtma.Text + "'";
                Class.Functions.RunSqlDel(sql);
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

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtma.Text == "") && (txtten.Text == "") && (cboloai.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblsanpham WHERE 1=1 ";
            if (txtma.Text != "")
                sql = sql + " AND masanpham Like N'%" + txtma.Text + "%'";
            if (txtten.Text != "")
                sql = sql + " AND tensanpham Like N'%" + txtten.Text + "%'";
            if (cbocl.Text != "")
                sql = sql + " AND machatlieu Like N'%" + cbocl.SelectedValue + "%'";
            if (cbomua.Text != "")
                sql = sql + " AND mamua Like N'%" + cbomua.SelectedValue + "%'";
            if (cbomau.Text != "")
                sql = sql + " AND mamau Like N'%" + cbomau.SelectedValue + "%'";
            tblsp = Functions.GetDataToTable(sql);
            if (tblsp.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblsp.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblsp;
            ResetValues();
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT masanpham, tensanpham,soluong,dongianhap, dongiaban,maloai,maco,machatlieu,mamau,mamua,mancc  FROM tblsanpham";
            tblsp = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblsp;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cbocl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }       
}
