using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnusp_Click(object sender, EventArgs e)
        {
            SP a = new SP();
            a.Show();
        }

        private void mnubcnv_Click(object sender, EventArgs e)
        {
            BCNV b = new BCNV();
            b.Show();
        }

        private void mnulsp_Click(object sender, EventArgs e)
        {
            LoaiSP a = new LoaiSP();
            a.Show();
        }

        private void mnutknv_Click(object sender, EventArgs e)
        {
            TimKiemNV a = new TimKiemNV();
            a.Show();
        }

        private void mnugiamgia_Click(object sender, EventArgs e)
        {
            GiamGia giam = new GiamGia();
            giam.Show();
        }
    }
}
