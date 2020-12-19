using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FormQuanLy : Form
    {
        private Form activeForm = null;
        public FormQuanLy()
        {
            
            InitializeComponent();
            this.panel1.Visible = false;
        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnQuanLyNV_Click(object sender, EventArgs e)
        {
            bool r = this.panel1.Visible;
            this.panel1.Visible = !r;
        }

        





        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            
        }

        private void btnHangHoa_Click_1(object sender, EventArgs e)
        {
            FormQuanLyMatHang f = new FormQuanLyMatHang();
            //f.Dock = System.Windows.Forms.DockStyle.Fill;
            f.TopLevel = false;
            panelChildForm.Controls.Add(f);
            openChildForm(f);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormQuanLyNhanViencs f = new FormQuanLyNhanViencs();
            f.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormQuanLyDangNhapNV f = new FormQuanLyDangNhapNV();
            //f.Dock = System.Windows.Forms.DockStyle.Fill;
            f.TopLevel = false;
            panelChildForm.Controls.Add(f);
            openChildForm(f);
        }

        private void btnKhachHang_Click_1(object sender, EventArgs e)
        {
            FormKhachHang f = new FormKhachHang();
            f.TopLevel = false;
            panelChildForm.Controls.Add(f);
            openChildForm(f);
        }
    }
}
