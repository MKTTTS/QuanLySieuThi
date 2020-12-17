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
    public partial class FromThemNhanVien : Form
    {
        private string MaNV;
        private string HoTen;
        private string DateOfBirth;
        private string SDT;
        private string SoCMND;
        private string DiaChi;
        private byte[] avatar;
        private string MaCV;
        private string QueQuan;
        private string GioiTinh;
        public FromThemNhanVien(string MaNV, string HoTen, string Dat, string SDT, string CMND, string Address, byte[] avatar, string MCV, string QQ, string GioiTinh)
        {
            this.MaNV = MaNV;
            this.HoTen = HoTen;
            this.DateOfBirth = Dat;
            this.SDT = SDT;
            this.SoCMND = CMND;
            this.DiaChi = Address;
            this.avatar = avatar;
            this.MaCV = MCV;
            this.QueQuan = QQ;
            this.GioiTinh = GioiTinh;
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FromThemNhanVien_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Bạn muốn thêm nhân viên \n" + this.HoTen + " ?";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString; //link csdl
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string qry_Them = "insert into NhanVien values(@MaNV,@HoTen,@NgaySinh,@SDT,@SoCMND,@DiaChi,@Anh,@MaChucVu,@QueQuan,@GioiTinh)";
            SqlCommand cmd_Them = new SqlCommand(qry_Them, con);

            cmd_Them.Parameters.AddWithValue("@MaNV", this.MaNV);
            cmd_Them.Parameters.AddWithValue("@HoTen", this.HoTen);
            cmd_Them.Parameters.AddWithValue("@NgaySinh", this.DateOfBirth);
            cmd_Them.Parameters.AddWithValue("@SDT", this.SDT);
            cmd_Them.Parameters.AddWithValue("@SoCMND", this.SoCMND);
            cmd_Them.Parameters.AddWithValue("@DiaChi", this.DiaChi);
            cmd_Them.Parameters.AddWithValue("@Anh", this.avatar);
            cmd_Them.Parameters.AddWithValue("@MaChucVu", this.MaCV);
            cmd_Them.Parameters.AddWithValue("@QueQuan", this.QueQuan);
            cmd_Them.Parameters.AddWithValue("@GioiTinh", this.GioiTinh);
            var r = cmd_Them.ExecuteNonQuery();
            if(this.MaCV != "LC" && this.MaCV != "SC")
            {
                string sql = "insert into DangNhap values(@MaNV, @MatKhau)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaNV", this.MaNV);
                cmd.Parameters.AddWithValue("@MatKhau", "123456");
                var s = cmd.ExecuteNonQuery();
            }
            if (r >= 1)
            {
                MessageBox.Show("Thêm nhân viên thành công");
                con.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
                con.Close();
                this.Dispose();
            }


            //cmd_ThemNV.ExecuteNonQuery();

            
        }
    }
}
