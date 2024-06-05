using BTL.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms
{
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
        }

        

        private void frmDangnhap_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
            //MessageBox.Show("Kết nối thành công");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txtDangnhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDangnhap.Focus();
                return;
            }
            if (txtMatkhau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatkhau.Focus();
                return;
            }
            string tk = txtDangnhap.Text;
            string mk = txtMatkhau.Text;
            string sql = "SELECT tendangnhap, matkhau FROM tbltaikhoan WHERE tendangnhap='"+tk+"'and matkhau='"+mk+"'";
            SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
            SqlDataReader data =cmd.ExecuteReader();
            
            if (data.Read() == true)
            {
               // MessageBox.Show("Đăng nhập thành công");
                frmMain frmMain = new frmMain(tk);
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                txtDangnhap.Focus();
                txtDangnhap.Text = "";
                txtMatkhau.Text = "";
                return;
            }
        }
    }
}

