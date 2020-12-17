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
    public partial class FormXoaNhanVien : Form
    {
        private string MaNV;
        private string HoTen;
        
        public FormXoaNhanVien(string MaNV, string HoTen)
        {
            this.MaNV = MaNV;
            this.HoTen = HoTen;
            
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FromThemNhanVien_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Bạn muốn xóa nhân viên \n" + this.HoTen + " ?";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString; //link csdl
            SqlConnection con = new SqlConnection(conString);
            con.Open();



            string qry_XoaNV = "delete from NhanVien where MaNhanVien = '" + this.MaNV + "'";
            SqlCommand cmd_XoaNV = new SqlCommand(qry_XoaNV, con);

            string qry_XoaTK = "delete from DangNhap where MaNhanVien = '" + this.MaNV + "'";
            SqlCommand cmd_XoaTK = new SqlCommand(qry_XoaTK, con);

            var r = cmd_XoaTK.ExecuteNonQuery();
            var s = cmd_XoaNV.ExecuteNonQuery();
            if (r >= 1)
            {
                MessageBox.Show("Xóa nhân viên thành công");
                con.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
                con.Close();
                this.Dispose();
            }


            //cmd_ThemNV.ExecuteNonQuery();


        }
    }
}
