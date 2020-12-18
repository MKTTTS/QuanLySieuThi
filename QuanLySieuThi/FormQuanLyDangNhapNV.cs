using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FormQuanLyDangNhapNV : Form
    {
        public FormQuanLyDangNhapNV()
        {
            InitializeComponent();
        }



        private void label12_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadDangNhap()
        {
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string qry_DSNV = "SELECT DangNhap.MaNhanVien as USERNAME, HoTenNhanVien as N'HỌ TÊN NHÂN VIÊN', MatKhau as PASSWORD FROM DangNhap JOIN NhanVien ON DangNhap.MaNhanVien = NhanVien.MaNhanVien";
            SqlDataAdapter da_DSNV = new SqlDataAdapter(qry_DSNV, con);
            DataTable dt_DSNV = new DataTable();
            da_DSNV.Fill(dt_DSNV);

            this.dataGridView1.DataSource = dt_DSNV;
            this.guna2Button1.Enabled = false;
            con.Close();

        }
        private void FormQuanLyDangNhapNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dangNhap.DangNhap' table. You can move, or remove it, as needed.
            
            LoadDangNhap();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mnv = this.dataGridView1.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();
                if (!string.IsNullOrEmpty(mnv))
                {
                    string sql = "SELECT HoTenNhanVien, TenChucVu, NhanVien.MaNhanVien, MatKhau FROM (DangNhap JOIN NhanVien ON NhanVien.MaNhanVien = DangNhap.MaNhanVien) JOIN ChucVu ON NhanVien.MaChucVu = ChucVu.MaChucVu WHERE NhanVien.MaNhanVien = '" + mnv + "'";
                    var r = new DatabaseQLST().Select(sql);
                    this.guna2TextBoxHoTen.Text = r["HoTenNhanVien"].ToString();
                    this.guna2TextBoxChucVu.Text = r["TenChucVu"].ToString();
                    this.guna2TextBoxUsername.Text = r["MaNhanVien"].ToString();
                    this.guna2TextBoxLastPW.Text = r["MatKhau"].ToString();
                    this.guna2TextBoxNP.Text = "";
                    this.guna2TextBoxNP.Select();
                    this.guna2Button1.Enabled = true;
                }
            }
        }
        public bool Injection(string s)
        {
            bool result = false;
            foreach (Char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    result = true;
                }
            }
            return result;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(this.guna2TextBoxNP.Text == "")
            {
                MessageBox.Show("Mật khẩu mới không hợp lệ");
                this.guna2TextBoxNP.Select();
                return;
            }
            if (Injection(this.guna2TextBoxNP.Text))
            {
                MessageBox.Show("Mật khẩu chỉ được bao gồm chữ và số");
                this.guna2TextBoxNP.Select();
                return;
            }
            string sql = "UPDATE DangNhap SET MatKhau = '" + this.guna2TextBoxNP.Text + "' WHERE MaNhanVien = '" + this.guna2TextBoxUsername.Text + "'";
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            var r = cmd.ExecuteNonQuery();
            if (r >= 1)
            {
                MessageBox.Show("Đổi mật khẩu thành công");
                con.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại");
                con.Close();
            }
            LoadDangNhap();


        }
    }
}
