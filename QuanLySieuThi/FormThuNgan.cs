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
using View;

namespace QuanLySieuThi
{
    public partial class FormThuNgan : Form
    {
        private DataTable GioHang = new DataTable();
        private DataTable GioHangNoCard = new DataTable();
        public FormThuNgan()
        {
            InitializeComponent();
            this.panelThongTinHoaDon.Enabled = false;
            this.textBoxHienThiDiemThuongKH.ReadOnly = true;
            this.textBoxHienThiGioiTinhKH.ReadOnly = true;
            this.textBoxHienThiSDTKH.ReadOnly = true;
            this.textBoxHienThiHoTenKH.ReadOnly = true;
            this.textBoxDuNoCard.ReadOnly = true;
            this.textBoxTongTienNoCard.ReadOnly = true;
            this.textBoxTongTienCard.ReadOnly = true;
            this.textBoxDuCard.ReadOnly = true;


        }
        public void ResetHoaDon()
        {
            this.textBoxtraCard.Text = "0";
            this.textBoxTongTienCard.Text = "0";
            this.textBoxDuCard.Text = "0";
            this.textBoxDuNoCard.Text = "0";
            this.textBoxTongTienNoCard.Text = "0";
            this.textBoxTraNocard.Text = "0";
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
        private void buttonTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            DataTable dt = new DataTable();

            if (textBoxNhapMaKhachHang.Text != "")
            {
                sqlCon.Open();
                string mkh = textBoxNhapMaKhachHang.Text;
                if (Injection(mkh))
                {
                    MessageBox.Show("Không tìm thấy khách hàng trên");
                    this.textBoxNhapMaKhachHang.Text = "";
                    this.textBoxNhapMaKhachHang.Select();
                    return;
                }
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang WHERE MaKhachHang = '" + mkh + "'", sqlCon);
                da.Fill(dt);
                try
                {
                    textBoxHienThiHoTenKH.Text = dt.Rows[0]["HoTen"].ToString();
                    textBoxHienThiSDTKH.Text = dt.Rows[0]["SDT"].ToString();
                    textBoxHienThiGioiTinhKH.Text = dt.Rows[0]["GioiTinh"].ToString();
                    textBoxHienThiDiemThuongKH.Text = dt.Rows[0]["DiemThuong"].ToString();
                    this.panelThongTinHoaDon.Enabled = true;
                    this.panelThongTinKH.Enabled = false;
                    ResetHoaDon();

                }
                catch (Exception)
                {
                    MessageBox.Show("Không tìm thấy khách hàng trên");
                }
                finally
                {
                    sqlCon.Close();

                }
            }

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            LoadThemmoiKH();
            ResetHoaDon();
            this.GioHang.Clear();
            this.GioHangNoCard.Clear();
            this.panelThongTinHoaDon.Enabled = false;
            this.panelThongTinKH.Enabled = true;
            this.textBoxNhapMaKhachHang.Text = "";
            this.textBoxHienThiDiemThuongKH.Text = "";
            this.textBoxHienThiGioiTinhKH.Text = "";
            this.textBoxHienThiSDTKH.Text = "";
            this.textBoxHienThiHoTenKH.Text = "";
        }
        public bool CheckSDT(string S)
        {

            bool Result = true;

            foreach (Char c in S)
            {
                if (!Char.IsDigit(c))
                {
                    Result = false;
                }
            }
            return Result;
        }
        public void LoadThemmoiKH()
        {
            var r = new DatabaseQLST().Select("MAKHMAX");
            int n = Int32.Parse(r["MaLonNhat"].ToString());
            n = n + 1;
            if (n < 10)
            {
                this.textBoxMaKHThemmoi.Text = String.Concat("KH", "0000000", n.ToString());
            }
            if (n > 9 && n < 100)
            {
                this.textBoxMaKHThemmoi.Text = String.Concat("KH", "000000", n.ToString());
            }
            if (n > 99 && n < 1000)
            {
                this.textBoxMaKHThemmoi.Text = String.Concat("KH", "00000", n.ToString());
            }
            if (n > 999 && n < 10000)
            {
                this.textBoxMaKHThemmoi.Text = String.Concat("KH", "0000", n.ToString());
            }
            if (n > 9999 && n < 100000)
            {
                this.textBoxMaKHThemmoi.Text = String.Concat("KH", "000", n.ToString());
            }
            if (n > 99999 && n < 1000000)
            {
                this.textBoxMaKHThemmoi.Text = String.Concat("KH", "00", n.ToString());
            }
            if (n > 999999 && n < 10000000)
            {
                this.textBoxMaKHThemmoi.Text = String.Concat("KH", "0", n.ToString());
            }
            if (n > 9999999 && n < 100000000)
            {
                this.textBoxMaKHThemmoi.Text = String.Concat("KH", n.ToString());
            }
            this.textBoxHoTenKHThemmoi.Text = "";
            this.textBoxSDTKHThemmoi.Text = "";
            this.comboBoxGioiTinhKHThemmoi.Text = "";
        }


        private void buttonHuyHoaDon_Click(object sender, EventArgs e)
        {
            this.panelThongTinHoaDon.Enabled = false;
            this.panelThongTinKH.Enabled = true;
            this.GioHang.Clear();
        }
        public bool CheckGioHang(int flag, string s)
        {
            if (flag == 1)
            {
                bool result = false;
                int n = GioHang.Rows.Count;
                if (n >= 1)
                {
                    foreach (DataRow r in this.GioHang.Rows)
                    {
                        if (r["ID"].ToString() == s)
                        {
                            result = true;
                        }
                    }
                }
                return result;
            }
            else
            {
                bool result = false;
                int n = GioHangNoCard.Rows.Count;
                if (n >= 1)
                {
                    foreach (DataRow r in this.GioHangNoCard.Rows)
                    {
                        if (r["ID"].ToString() == s)
                        {
                            result = true;
                        }
                    }
                }
                return result;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);


            if (this.textBoxIDSanpham.Text != "")
            {
                sqlCon.Open();
                string mkh = this.textBoxIDSanpham.Text;
                if (Injection(mkh))
                {
                    MessageBox.Show("Không có mặt hàng này");
                    this.textBoxIDSanpham.Text = "";
                    this.textBoxIDSanpham.Select();
                    return;
                }
                if (CheckGioHang(0, mkh))
                {
                    MessageBox.Show("ID không hợp lệ");
                    this.textBoxIDSanpham.Text = "";
                    this.textBoxIDSanpham.Select();
                    return;
                }
                SqlDataAdapter da = new SqlDataAdapter("SELECT DonViHangHoa.ID as ID, MatHang.TenMatHang as N'Tên mặt hàng', MatHang.XuatXu as N'Xuất xứ', MatHang.GiaBan as N'Giá bán' FROM MatHang, DonViHangHoa WHERE MatHang.MaMatHang = DonViHangHoa.MaMatHang AND DonViHangHoa.ID = '" + mkh + "'", sqlCon);

                if (da == null)
                {
                    MessageBox.Show("Không có mặt hàng này");
                    return;
                }
                else
                {
                    da.Fill(GioHangNoCard);
                    this.dataGridViewHoaDonNoCard.DataSource = GioHangNoCard;
                    sqlCon.Close();
                }

            }
            this.textBoxIDSanpham.Text = "";
            this.textBoxIDSanpham.Select();
            int n = 0;
            foreach (DataRow r in GioHangNoCard.Rows)
            {
                n = n + Int32.Parse(r["Giá bán"].ToString());
            }
            this.textBoxTongTienNoCard.Text = n.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);


            if (this.textBoxNhapIDSanPham.Text != "")
            {
                sqlCon.Open();
                string mkh = this.textBoxNhapIDSanPham.Text;
                if (Injection(mkh))
                {
                    MessageBox.Show("Không có mặt hàng này");
                    this.textBoxNhapIDSanPham.Text = "";
                    this.textBoxNhapIDSanPham.Select();
                    return;
                }
                if (CheckGioHang(1, mkh))
                {
                    MessageBox.Show("ID không hợp lệ");
                    this.textBoxNhapIDSanPham.Text = "";
                    this.textBoxNhapIDSanPham.Select();
                    return;

                }
                SqlDataAdapter da = new SqlDataAdapter("SELECT DonViHangHoa.ID as ID, MatHang.TenMatHang as N'Tên mặt hàng', MatHang.XuatXu as N'Xuất xứ', MatHang.GiaBan as N'Giá bán' FROM MatHang, DonViHangHoa WHERE MatHang.MaMatHang = DonViHangHoa.MaMatHang AND DonViHangHoa.ID = '" + mkh + "'", sqlCon);

                if (da == null)
                {
                    MessageBox.Show("Không có mặt hàng này");
                    return;
                }
                else
                {
                    da.Fill(GioHang);
                    this.dataGridViewHoaDonCARD.DataSource = GioHang;
                    sqlCon.Close();
                }

            }
            this.textBoxNhapIDSanPham.Text = "";
            this.textBoxNhapIDSanPham.Select();
            int n = 0;
            foreach (DataRow r in GioHang.Rows)
            {
                n = n + Int32.Parse(r["Giá bán"].ToString());
            }
            this.textBoxTongTienCard.Text = n.ToString();
        }

        private void FormThuNgan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void textBoxTongTienCard_TextChanged(object sender, EventArgs e)
        {
            int tongtien, tra;
            try
            {
                tongtien = Int32.Parse(this.textBoxTongTienCard.Text);
            }
            catch (Exception)
            {
                tongtien = 0;
            }
            try
            {
                tra = Int32.Parse(this.textBoxtraCard.Text);
            }
            catch (Exception)
            {
                tra = 0;
            }

            this.textBoxDuCard.Text = (tra - tongtien).ToString();
        }

        private void textBoxtraCard_TextChanged(object sender, EventArgs e)
        {
            int tongtien, tra;
            try
            {
                tongtien = Int32.Parse(this.textBoxTongTienCard.Text);
            }
            catch (Exception)
            {
                tongtien = 0;
            }
            try
            {
                tra = Int32.Parse(this.textBoxtraCard.Text);
            }
            catch (Exception)
            {
                tra = 0;
            }

            this.textBoxDuCard.Text = (tra - tongtien).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int m = GioHang.Rows.Count;
            if (m >= 1)
            {
                GioHang.Rows[m - 1].Delete();
                GioHang.AcceptChanges();
                int n = 0;
                foreach (DataRow r in GioHang.Rows)
                {
                    n = n + Int32.Parse(r["Giá bán"].ToString());
                }
                this.textBoxTongTienCard.Text = n.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int m = GioHangNoCard.Rows.Count;
            if (m >= 1)
            {
                GioHangNoCard.Rows[m - 1].Delete();
                GioHangNoCard.AcceptChanges();
                int n = 0;
                foreach (DataRow r in GioHangNoCard.Rows)
                {
                    n = n + Int32.Parse(r["Giá bán"].ToString());
                }
                this.textBoxTongTienNoCard.Text = n.ToString();
            }
        }

        private void textBoxTongTienNoCard_TextChanged(object sender, EventArgs e)
        {
            int tongtien, tra;
            try
            {
                tongtien = Int32.Parse(this.textBoxTongTienNoCard.Text);
            }
            catch (Exception)
            {
                tongtien = 0;
            }
            try
            {
                tra = Int32.Parse(this.textBoxTraNocard.Text);
            }
            catch (Exception)
            {
                tra = 0;
            }

            this.textBoxDuNoCard.Text = (tra - tongtien).ToString();
        }

        private void textBoxTraNocard_TextChanged(object sender, EventArgs e)
        {
            int tongtien, tra;
            try
            {
                tongtien = Int32.Parse(this.textBoxTongTienNoCard.Text);
            }
            catch (Exception)
            {
                tongtien = 0;
            }
            try
            {
                tra = Int32.Parse(this.textBoxTraNocard.Text);
            }
            catch (Exception)
            {
                tra = 0;
            }

            this.textBoxDuNoCard.Text = (tra - tongtien).ToString();
        }

        private void buttonNhapHoaDon_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(this.textBoxDuCard.Text) >= 0)
            {
                int numberOfRow = this.GioHang.Rows.Count;
                if (numberOfRow >= 1)
                {
                    try
                    {
                        string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                        SqlConnection sqlCon = new SqlConnection(conString);
                        sqlCon.Open();
                        DateTime now = DateTime.Now;
                        string ngaynhap = now.ToString("yyyy-MM-dd");
                        string sql = "SELECT MAX(MaHoaDon) as MaxMHD FROM HoaDon";
                        int n = 1;
                        using (SqlCommand cmd = sqlCon.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            var r = cmd.ExecuteScalar().ToString();
                            if (!string.IsNullOrEmpty(r))
                            {
                                n = Int32.Parse(r);
                                n = n + 1;
                            }
                        }
                        int Sum = Int32.Parse(this.textBoxTongTienCard.Text);
                        if (Sum >= 100000)
                        {
                            Sum = Sum / 100000;
                        }
                        sql = "INSERT INTO HoaDon (MaHoaDon, MaKhachHang, NgayTao, TongTien) VALUES ('" + n.ToString() + "','" + this.textBoxNhapMaKhachHang.Text + "','" + ngaynhap + "','" + this.textBoxTongTienCard.Text + "')";
                        using (SqlCommand cmd = sqlCon.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            if (Sum >= 1)
                            {
                                cmd.CommandText = "UPDATE KhachHang SET DiemThuong = DiemThuong + '" + Sum + "' WHERE MaKhachHang = '" + this.textBoxNhapMaKhachHang.Text + "'";
                                cmd.ExecuteNonQuery();
                            }
                            List<CustomerParameter> lst = new List<CustomerParameter>();
                            foreach (DataRow r in GioHang.Rows)
                            {
                                bool exist = false;
                                foreach (CustomerParameter cst in lst)
                                {
                                    if (r["Tên mặt hàng"].ToString() == cst.key)
                                    {
                                        exist = true;
                                        int m = Int32.Parse(cst.value);
                                        m++;
                                        cst.value = m.ToString();
                                    }
                                }
                                if (exist == false)
                                {
                                    lst.Add(new CustomerParameter() { key = r["Tên mặt hàng"].ToString(), value = "1" });
                                }
                                string sql1 = "DELETE FROM DonViHangHoa WHERE ID = '" + r["ID"].ToString() + "'";
                                cmd.CommandText = sql1;
                                cmd.ExecuteNonQuery();
                            }
                            string sqlMatHang;
                            foreach (CustomerParameter cst in lst)
                            {
                                sqlMatHang = "SELECT MaMatHang, GiaBan FROM MatHang WHERE TenMatHang = N'" + cst.key + "'";

                                var r = new DatabaseQLST().Select(sqlMatHang);
                                string MaMH = r["MaMatHang"].ToString();
                                int Gia = Int32.Parse(r["GiaBan"].ToString());
                                Gia = Gia * (Int32.Parse(cst.value));


                                string sqlHD_MH = "INSERT INTO HoaDon_MatHang (MaHoaDon, MaMatHang, Soluong, ThanhTien) VALUES ('" + n.ToString() + "','" + MaMH + "','" + cst.value + "','" + Gia.ToString() + "')";
                                cmd.CommandText = sqlHD_MH;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        sqlCon.Close();
                        this.panelThongTinHoaDon.Enabled = false;
                        this.panelThongTinKH.Enabled = true;
                        ResetHoaDon();
                        GioHang.Clear();
                        this.dataGridViewHoaDonCARD.DataSource = null;
                        this.textBoxNhapMaKhachHang.Text = "";
                        this.textBoxNhapMaKhachHang.Select();
                        this.textBoxHienThiHoTenKH.Text = "";
                        this.textBoxHienThiGioiTinhKH.Text = "";
                        this.textBoxHienThiSDTKH.Text = "";
                        this.textBoxHienThiDiemThuongKH.Text = "";
                        MessageBox.Show("Thanh toán thành công");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Viết hóa đơn không thành công");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Hóa đơn trống");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Khách hàng chưa thanh toán đủ tiền");
                return;
            }
        }

        private void buttonInHoaDonNoCard_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(this.textBoxDuNoCard.Text) >= 0)
            {
                int numberOfRow = this.GioHangNoCard.Rows.Count;
                if (numberOfRow >= 1)
                {
                    try
                    {
                        string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                        SqlConnection sqlCon = new SqlConnection(conString);
                        sqlCon.Open();
                        DateTime now = DateTime.Now;
                        string ngaynhap = now.ToString("yyyy-MM-dd");
                        string sql = "SELECT MAX(MaHoaDon) as MaxMHD FROM HoaDon";
                        int n = 1;
                        using (SqlCommand cmd = sqlCon.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            var r = cmd.ExecuteScalar().ToString();
                            if (!string.IsNullOrEmpty(r))
                            {
                                n = Int32.Parse(r);
                                n = n + 1;
                            }
                        }
                        sql = "INSERT INTO HoaDon (MaHoaDon, MaKhachHang, NgayTao, TongTien) VALUES ('" + n.ToString() + "',null,'" + ngaynhap + "','" + this.textBoxTongTienNoCard.Text + "')";
                        using (SqlCommand cmd = sqlCon.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            List<CustomerParameter> lst = new List<CustomerParameter>();
                            foreach (DataRow r in GioHangNoCard.Rows)
                            {
                                bool exist = false;
                                foreach (CustomerParameter cst in lst)
                                {
                                    if (r["Tên mặt hàng"].ToString() == cst.key)
                                    {
                                        exist = true;
                                        int m = Int32.Parse(cst.value);
                                        m++;
                                        cst.value = m.ToString();
                                    }
                                }
                                if (exist == false)
                                {
                                    lst.Add(new CustomerParameter() { key = r["Tên mặt hàng"].ToString(), value = "1" });
                                }
                                string sql1 = "DELETE FROM DonViHangHoa WHERE ID = '" + r["ID"].ToString() + "'";
                                cmd.CommandText = sql1;
                                cmd.ExecuteNonQuery();
                            }
                            string sqlMatHang;
                            foreach (CustomerParameter cst in lst)
                            {
                                sqlMatHang = "SELECT MaMatHang, GiaBan FROM MatHang WHERE TenMatHang = N'" + cst.key + "'";

                                var r = new DatabaseQLST().Select(sqlMatHang);
                                string MaMH = r["MaMatHang"].ToString();
                                int Gia = Int32.Parse(r["GiaBan"].ToString());
                                Gia = Gia * (Int32.Parse(cst.value));


                                string sqlHD_MH = "INSERT INTO HoaDon_MatHang (MaHoaDon, MaMatHang, Soluong, ThanhTien) VALUES ('" + n.ToString() + "','" + MaMH + "','" + cst.value + "','" + Gia.ToString() + "')";
                                cmd.CommandText = sqlHD_MH;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        sqlCon.Close();

                        GioHangNoCard.Clear();
                        this.dataGridViewHoaDonNoCard.DataSource = null;
                        this.textBoxIDSanpham.Text = "";
                        this.textBoxIDSanpham.Select();
                        ResetHoaDon();
                        MessageBox.Show("Thanh toán thành công");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Viết hóa đơn không thành công");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Hóa đơn trống");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Khách hàng chưa thanh toán đủ tiền");
                return;
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (textBoxHoTenKHThemmoi.Text == "")
            {
                MessageBox.Show("Chưa nhập họ tên khách hàng");
                return;
            }
            if (comboBoxGioiTinhKHThemmoi.Text == "")
            {
                MessageBox.Show("Chưa nhập giới tính khách hàng");
                return;
            }
            if (textBoxSDTKHThemmoi.Text == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại khách hàng");
                return;
            }
            if (!CheckSDT(textBoxSDTKHThemmoi.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }
            string sql = "THEMKHACHHANG";
            List<CustomerParameter> lst = new List<CustomerParameter>();
            lst.Add(new CustomerParameter() { key = "@makhachhang", value = this.textBoxMaKHThemmoi.Text });
            lst.Add(new CustomerParameter() { key = "@hoten", value = this.textBoxHoTenKHThemmoi.Text });
            lst.Add(new CustomerParameter() { key = "@gioitinh", value = this.comboBoxGioiTinhKHThemmoi.Text });
            lst.Add(new CustomerParameter() { key = "@sdt", value = this.textBoxSDTKHThemmoi.Text });
            var r = new DatabaseQLST().Excute(sql, lst, null);
            if (r > 0)
            {
                MessageBox.Show("Thêm khách hàng thành công.");
                LoadThemmoiKH();
            }
        }
    }
}
