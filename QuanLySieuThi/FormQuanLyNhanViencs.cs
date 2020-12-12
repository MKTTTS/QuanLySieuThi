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
using System.Data.SqlClient;

namespace QuanLySieuThi
{
    public partial class FormQuanLyNhanViencs : Form
    {
          
          string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString; //link csdl
          string maCV = "";
          string gTinh = " ";


          string imageURL = null;
          public FormQuanLyNhanViencs()
        {
            InitializeComponent();
        }

          private void FormQuanLyNhanViencs_Load(object sender, EventArgs e)
          {
               SqlConnection con = new SqlConnection(conString);
               con.Open();

               string qry_DSNV = "SELECT * FROM NhanVien";
               SqlDataAdapter da_DSNV = new SqlDataAdapter(qry_DSNV,con);

               DataTable dt_DSNV = new DataTable();
               da_DSNV.Fill(dt_DSNV);

               dgvDSNV.DataSource = dt_DSNV;


               con.Close();
          }

          private void btnThemAnh_Click(object sender, EventArgs e)
          {
               using(OpenFileDialog ofd = new OpenFileDialog())
               {
                    if(ofd.ShowDialog()==DialogResult.OK)
                    {
                         imageURL = ofd.FileName;
                         pbAnh.Image = Image.FromFile(ofd.FileName);
                    }
                    /*
                     
                     */
               }
          }

          private void btnThem_Click(object sender, EventArgs e)
          {
               Image img = pbAnh.Image;
               byte[] arr;
               ImageConverter converter = new ImageConverter();
               arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

               SqlConnection con = new SqlConnection(conString);
               con.Open();

               

               string qry_ThemNV = "insert into NhanVien values ('" + txtMaNV.Text + "','" + txtHoTen.Text + "','" + dtpNgaySinh.Value.Day + "','" + txtSDT.Text + "','" + txtSoCMND.Text 
                                   + "','" + txtDiaChi.Text + "','" + arr + "','" + maCV + "','" + txtQueQuan.Text + "','" + gTinh + "')";
               SqlCommand cmd = new SqlCommand(qry_ThemNV, con);

               con.Close();
          }

          private void btnSua_Click(object sender, EventArgs e)
          {

          }

          private void btnXoa_Click(object sender, EventArgs e)
          {

          }

          private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
          {
               char ch = e.KeyChar;
               if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
               {
                    e.Handled = true;
               }
          }

          private void checkNam_CheckedChanged(object sender, EventArgs e)
          {
               if(checkNam.Checked == true)
               {
                    gTinh = "Nam";
                    checkNu.Checked = false;
               }
          }

          private void checkNu_CheckedChanged(object sender, EventArgs e)
          {
               if (checkNu.Checked == true)
               {
                    gTinh = "Nữ";
                    checkNam.Checked = false;
               }
          }
     }
}
