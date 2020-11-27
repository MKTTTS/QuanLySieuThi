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
            FormQuanLyNhanViencs form = new FormQuanLyNhanViencs();
            form.TopLevel = false;
            panelChildForm.Controls.Add(form);
            openChildForm(form);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FormKhachHang form = new FormKhachHang();
            form.TopLevel = false;
            panelChildForm.Controls.Add(form);
            openChildForm(form);
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            FormQuanLyMatHang form = new FormQuanLyMatHang();
            form.TopLevel = false;
            panelChildForm.Controls.Add(form);
            openChildForm(form);
        }

        private void btnDoanhSo_Click(object sender, EventArgs e)
        {
            FormThongKeDoanhSo form = new FormThongKeDoanhSo();
            form.TopLevel = false;
            panelChildForm.Controls.Add(form);
            openChildForm(form);
        }
    }
}
