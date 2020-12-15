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
          int soNV = 0;


          string imageURL = null;
          public FormQuanLyNhanViencs()
        {
            InitializeComponent();
        }

          private void FormQuanLyNhanViencs_Load(object sender, EventArgs e)
          {
               SqlConnection con = new SqlConnection(conString);
               con.Open();

               #region Mã Nhân Viên Mới
               string qry_SoNV = "SELECT COUNT(*) FROM NhanVien";
               SqlCommand cmd_SoNV = new SqlCommand(qry_SoNV, con);
               soNV = (int)cmd_SoNV.ExecuteScalar();
               groupDSNV.Text = "Danh Sách Nhân Viên: " + soNV + " người";

               //string soNV_String = (soNV+1).ToString();
               //string soChuSo_0 = "";
               //for (int i = 0; i < 8-soNV_String.Length; i++)
               //{
               //     soChuSo_0 = soChuSo_0 + "0";
               //}

               //string maNV_moi = "NV" + soChuSo_0 + soNV_String;

               string qry_MaNV_cuoi = "SELECT TOP 1 MaNhanVien FROM NhanVien ORDER BY MaNhanVien DESC";
               SqlCommand cmd_MaNV_cuoi = new SqlCommand(qry_MaNV_cuoi, con);
               string maNV_cuoi = (string)cmd_MaNV_cuoi.ExecuteScalar();

               #region Cắt lấy mã cuối
               int viTri = 0;
               for (int l = 2; l < maNV_cuoi.Length; l++)
               {
                    if (maNV_cuoi[l] != '0')
                    {
                         viTri = l;
                         break;
                    }
               }
               int maCuoi = Convert.ToInt32(maNV_cuoi.Substring(viTri));
               int maMoi = maCuoi + 1;

               string maMoi_string = maMoi.ToString();
               string soChuSo_0 = "";
               for (int i = 0; i < 8 - maMoi_string.Length; i++)
               {
                    soChuSo_0 = soChuSo_0 + "0";
               }

               string maNV_moi = "NV" + soChuSo_0 + maMoi_string;

               #endregion

               txtMaNV.Text = maNV_moi;
               txtMaNV.Enabled = false;
               #endregion 

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

               #region lấy mã chức vụ
               if (cbxChucVu.Text == "Quản lý siêu thị")
               {
                    maCV = "AD";
               }

               if (cbxChucVu.Text == "Lao công")
               {
                    maCV = "LC";
               }

               if (cbxChucVu.Text == "Bảo vệ")
               {
                    maCV = "SC";
               }

               if (cbxChucVu.Text == "Quản lý kho")
               {
                    maCV = "TK";
               }

               if (cbxChucVu.Text == "Thu ngân")
               {
                    maCV = "TN";
               }
               #endregion

               string qry_ThemNV = "insert into NhanVien values ('" + txtMaNV.Text + "','" + txtHoTen.Text + "','" + dtpNgaySinh.Value.Date.ToString() + "','" + txtSDT.Text + "','" + txtSoCMND.Text 
                                   + "','" + txtDiaChi.Text + "','" + arr + "','" + maCV + "','" + txtQueQuan.Text + "','" + gTinh + "')";
               SqlCommand cmd_ThemNV = new SqlCommand(qry_ThemNV, con);

               cmd_ThemNV.ExecuteNonQuery();

               con.Close();
               txtHoTen.Text = "";
               txtSDT.Text = "";
               txtSoCMND.Text = "";
               cbxChucVu.Text = "";
               txtQueQuan.Text = "";
               txtDiaChi.Text = "";
               FormQuanLyNhanViencs_Load(sender, e);
          }

          private void btnSua_Click(object sender, EventArgs e)
          {

          }

          private void btnXoa_Click(object sender, EventArgs e)
          {
               SqlConnection con = new SqlConnection(conString);
               con.Open();

               string maXoa_string = txtMaNV.Text;

               string qry_XoaNV = "delete from NhanVien where MaNhanVien = '" + maXoa_string + "'";
               SqlCommand cmd_XoaNV = new SqlCommand(qry_XoaNV, con);

               string qry_XoaTK = "delete from DangNhap where MaNhanVien = '" + maXoa_string + "'";
               SqlCommand cmd_XoaTK = new SqlCommand(qry_XoaTK, con);

               cmd_XoaTK.ExecuteNonQuery();
               cmd_XoaNV.ExecuteNonQuery();

               
               con.Close();

               FormQuanLyNhanViencs_Load(sender, e);
              
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

          private void dgvDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
               txtMaNV.Enabled = true;

               string maCV = "";
               DataGridViewRow row = this.dgvDSNV.Rows[e.RowIndex];

               txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
               txtHoTen.Text = row.Cells["HoTenNhanVien"].Value.ToString();
               txtSDT.Text = row.Cells["SDT"].Value.ToString();
               txtSoCMND.Text = row.Cells["SoCMND"].Value.ToString();
               txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
               txtQueQuan.Text = row.Cells["QueQuan"].Value.ToString();

               #region Lấy chức vụ
               maCV = row.Cells["MaChucVu"].Value.ToString();
               SqlConnection con = new SqlConnection(conString);
               con.Open();

               string qry_maCV = "select TenChucVu from ChucVu where MaChucVu = '" + maCV + "'";
               SqlCommand cmd_ChucVu = new SqlCommand(qry_maCV, con);
               string ChucVu = (string)cmd_ChucVu.ExecuteScalar();

               cbxChucVu.Text = ChucVu;
               con.Close();
               #endregion
          }
     }
}
