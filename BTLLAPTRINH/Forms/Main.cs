using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLLAPTRINH.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.Khachhang a = new Forms.Khachhang();
            a.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Kichco a = new Forms.Kichco();
            a.Show();
        }


        private void báoCáoCuốiNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Baocaocuoingay a = new Forms.Baocaocuoingay();
            a.Show();
        }

        private void tìmKiếmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Timkiemkh a = new Forms.Timkiemkh();
            a.Show();
        }

        private void hóaĐơnNhậpNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Hoadonnhapnew a = new Forms.Hoadonnhapnew();
            a.Show();
        }
    }
}
