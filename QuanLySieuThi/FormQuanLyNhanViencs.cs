using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
          public void Mode(bool flag)
        {
            this.txtHoTen.ReadOnly = flag;
            this.dtpNgaySinh.Enabled = !flag;
            this.guna2CustomGradientPanel1.Enabled = !flag;
            this.txtSDT.ReadOnly = flag;
            this.txtSoCMND.ReadOnly = flag;
            this.cbxChucVu.Enabled = !flag;
            this.txtQueQuan.ReadOnly = flag;
            this.txtDiaChi.ReadOnly = flag;
            this.btnThemAnh.Enabled = !flag;
        }

          private void FormQuanLyNhanViencs_Load(object sender, EventArgs e)
          {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            Mode(true);
            
            // TODO: This line of code loads data into the 'nhanVien.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.nhanVien.NhanVien);
               SqlConnection con = new SqlConnection(conString);
               con.Open();

               #region Mã Nhân Viên Mới
               /*string qry_SoNV = "SELECT COUNT(*) FROM NhanVien";
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
               //txtMaNV.Enabled = false;*/
            #endregion

            //string qry_DSNV = "SELECT * FROM NhanVien";
            string qry_DSNV = "SELECT MaNhanVien, HoTenNhanVien, CONVERT(VARCHAR(10),NgaySinh, 103) as NgaySinh , SDT, GioiTinh FROM NhanVien";
               SqlDataAdapter da_DSNV = new SqlDataAdapter(qry_DSNV, con);

               DataTable dt_DSNV = new DataTable();
               da_DSNV.Fill(dt_DSNV);

               dgvDSNV.DataSource = dt_DSNV;


               con.Close();
          }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.btnThem.Text == "Thêm")
            {
                Mode(false);
                this.txtHoTen.Text = "";
                this.dtpNgaySinh.Text = DateTime.Now.ToString();

                this.txtSDT.Text = "";
                this.txtSoCMND.Text = "";
                this.cbxChucVu.Text = "";
                this.txtQueQuan.Text = "";
                this.txtDiaChi.Text = "";

                this.nhanVienTableAdapter.Fill(this.nhanVien.NhanVien);
                SqlConnection conn = new SqlConnection(conString);
                conn.Open();

                #region Mã Nhân Viên Mới
                string qry_SoNV = "SELECT COUNT(*) FROM NhanVien";
                SqlCommand cmd_SoNV = new SqlCommand(qry_SoNV, conn);
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
                SqlCommand cmd_MaNV_cuoi = new SqlCommand(qry_MaNV_cuoi, conn);
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
                //txtMaNV.Enabled = false;
                #endregion
                this.btnThem.Text = "Lưu";
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                this.txtThoat.Text = "Hủy";
            }
            else
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

                //string qry_ThemNV = "insert into NhanVien values ('" + txtMaNV.Text + "','" + txtHoTen.Text + "','" + dtpNgaySinh.Value.Date.ToString() + "','" + txtSDT.Text + "','" + txtSoCMND.Text 
                //                    + "','" + txtDiaChi.Text + "','" + arr + "','" + maCV + "','" + txtQueQuan.Text + "','" + gTinh + "')";
                //SqlCommand cmd_ThemNV = new SqlCommand(qry_ThemNV, con);

                string qry_Them = "insert into NhanVien values(@MaNV,@HoTen,@NgaySinh,@SDT,@SoCMND,@DiaChi,@Anh,@MaChucVu,@QueQuan,@GioiTinh)";
                SqlCommand cmd_Them = new SqlCommand(qry_Them, con);

                cmd_Them.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd_Them.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd_Them.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date.ToString());
                cmd_Them.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd_Them.Parameters.AddWithValue("@SoCMND", txtSoCMND.Text);
                cmd_Them.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd_Them.Parameters.AddWithValue("@Anh", arr);
                cmd_Them.Parameters.AddWithValue("@MaChucVu", maCV);
                cmd_Them.Parameters.AddWithValue("@QueQuan", txtQueQuan.Text);
                cmd_Them.Parameters.AddWithValue("@GioiTinh", gTinh);
                cmd_Them.ExecuteNonQuery();


                //cmd_ThemNV.ExecuteNonQuery();

                con.Close();
                txtHoTen.Text = "";
                txtSDT.Text = "";
                txtSoCMND.Text = "";
                cbxChucVu.Text = "";
                txtQueQuan.Text = "";
                txtDiaChi.Text = "";
                pbAnh.Image = null;
                Mode(true);
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.txtThoat.Text = "Thoát";
                this.btnThem.Text = "Thêm";
                FormQuanLyNhanViencs_Load(sender, e);
            }
          }

          private void btnThemAnh_Click(object sender, EventArgs e)
          {
               using (OpenFileDialog ofd = new OpenFileDialog())
               {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                         imageURL = ofd.FileName;
                         pbAnh.Image = Image.FromFile(ofd.FileName);
                    }
                    /*
                     
                     */
               }
          }

          private void btnSua_Click(object sender, EventArgs e)
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

               //@MaNV,@HoTen,@NgaySinh,@SDT,@SoCMND,@DiaChi,@Anh,@MaChucVu,@QueQuan,@GioiTinh
               string qry_Sua = "update NhanVien set HoTenNhanVien = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, SDT = @SDT, SoCMND = @SoCMND, MaChucVu = @MaChucVu, QueQuan = @QueQuan, DiaChi = @DiaChi, AnhDaiDien = @Anh where MaNhanVien = '" + txtMaNV.Text + "'";
               SqlCommand cmd_Sua = new SqlCommand(qry_Sua, con);

               cmd_Sua.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
               cmd_Sua.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date.ToString());
               cmd_Sua.Parameters.AddWithValue("@SDT", txtSDT.Text);
               cmd_Sua.Parameters.AddWithValue("@SoCMND", txtSoCMND.Text);
               cmd_Sua.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
               cmd_Sua.Parameters.AddWithValue("@Anh", arr);
               cmd_Sua.Parameters.AddWithValue("@MaChucVu", maCV);
               cmd_Sua.Parameters.AddWithValue("@QueQuan", txtQueQuan.Text);
               cmd_Sua.Parameters.AddWithValue("@GioiTinh", gTinh);
               cmd_Sua.ExecuteNonQuery();

               con.Close();

               txtHoTen.Text = "";
               txtSDT.Text = "";
               txtSoCMND.Text = "";
               cbxChucVu.Text = "";
               txtQueQuan.Text = "";
               txtDiaChi.Text = "";
               pbAnh.Image = null;
               FormQuanLyNhanViencs_Load(sender, e);
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
               txtHoTen.Text = "";
               txtSDT.Text = "";
               txtSoCMND.Text = "";
               cbxChucVu.Text = "";
               txtQueQuan.Text = "";
               txtDiaChi.Text = "";
               pbAnh.Image = null;

               FormQuanLyNhanViencs_Load(sender, e);
          }

          private void txtSoCMND_KeyPress(object sender, KeyPressEventArgs e)
          {
               char ch = e.KeyChar;
               if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
               {
                    e.Handled = true;
               }
          }

          private void checkNam_CheckedChanged(object sender, EventArgs e)
          {
               if (checkNam.Checked == true)
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

          

        private void txtThoat_Click(object sender, EventArgs e)
          {
            if (this.txtThoat.Text == "Thoát")
            {
                this.Close();
            }
            else
            {
                this.guna2Panel1.Enabled = true;
                this.guna2GroupBox1.Enabled = false;
                this.txtThoat.Text = "Thoát";
                this.btnThem.Text = "Thêm";
                this.btnThem.Enabled = true;
                this.btnSua.Text = "Sửa";
                this.btnSua.Enabled = true;
                this.btnXoa.Text = "Xóa";
                this.btnXoa.Enabled = true;

            }
          }

        private void dgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maNV = this.dgvDSNV.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
                if (!string.IsNullOrEmpty(maNV))
                {
                    var r = new DatabaseQLST().Select("SELECT * FROM NhanVien WHERE MaNhanVien = '" + maNV + "'");
                    this.txtMaNV.Text = maNV;
                    this.txtHoTen.Text = r["HoTenNhanVien"].ToString();
                    this.dtpNgaySinh.Text = r["NgaySinh"].ToString();
                    if(r["GioiTinh"].ToString() == "Nam")
                    {
                        this.checkNam.Checked = true;
                    }
                    else
                    {
                        this.checkNu.Checked = true;
                    }
                    this.txtSDT.Text = r["SDT"].ToString();
                    this.txtSoCMND.Text = r["SoCMND"].ToString();
                    this.txtDiaChi.Text = r["DiaChi"].ToString();
                    this.txtQueQuan.Text = r["QueQuan"].ToString();
                    try
                    {
                        byte[] images = (byte[])r["AnhDaiDien"];
                        if (images == null)
                        {
                            pbAnh.Image = null;
                        }
                        else
                        {
                            MemoryStream mst = new MemoryStream(images);
                            pbAnh.Image = Image.FromStream(mst);
                        }
                    }
                    catch (Exception)
                    {
                        pbAnh.Image = null;
                    }


                    /*DataGridViewRow row = this.dgvDSNV.Rows[e.RowIndex];

                    txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                    txtHoTen.Text = row.Cells["HoTenNhanVien"].Value.ToString();
                    txtSDT.Text = row.Cells["SDT"].Value.ToString();
                    //txtSoCMND.Text = row.Cells["SoCMND"].Value.ToString();
                    //txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                    //txtQueQuan.Text = row.Cells["QueQuan"].Value.ToString();
                    //var s = row.Cells["AnhDaiDien"].ToString();
                    //if (!string.IsNullOrEmpty(s))
                    //{
                    //    byte[] imgData = (byte[])row.Cells["AnhDaiDien"].Value;
                    //    MemoryStream ms = new MemoryStream(imgData);
                    //    pbAnh.Image = Image.FromStream(ms);
                    //}*/

                    #region Lấy chức vụ
                    string maCV = r["MaChucVu"].ToString();
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
    }
}
