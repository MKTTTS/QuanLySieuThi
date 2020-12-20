using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }


        public bool Injection(string s)
        {
            bool result = false;
            foreach(Char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    result = true;
                }
            }
            return result;
        }



        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                string username = this.textBox1.Text;
                string password = this.textBox2.Text;
                if (Injection(username) || Injection(password))
                {
                    MessageBox.Show("Mã nhân viên hoặc tài khoản chưa chính xác");
                    return;
                }
                var r = new DatabaseQLST().Select("SELECT (CASE WHEN EXISTS (SELECT * FROM DangNhap WHERE MaNhanVien = '" + username + "' AND MatKhau = '" + password + "') THEN 1 ELSE 0 END) AS DangNhap");
                if (r["DangNhap"].ToString() == "0")
                {
                    MessageBox.Show("Mã nhân viên hoặc tài khoản chưa chính xác");
                    return;
                }
                else
                {
                    var s = new DatabaseQLST().Select("SELECT MaChucVu FROM NhanVien WHERE MaNhanVien = '" + username + "'");
                    string mcv = s["MaChucVu"].ToString();
                    if (mcv == "TN")
                    {
                        FormThuNgan f = new FormThuNgan();
                        this.Hide();
                        f.ShowDialog();
                        this.Dispose();

                    }
                    if (mcv == "AD")
                    {
                        FormQuanLy f = new FormQuanLy();
                        this.Hide();
                        f.ShowDialog();
                        this.Dispose();

                    }
                    if (mcv == "TK")
                    {
                        FormQuanLyKho f = new FormQuanLyKho();
                        this.Hide();
                        f.ShowDialog();
                        this.Dispose();


                    }
                }
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
