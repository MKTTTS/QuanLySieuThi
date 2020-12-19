using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FormThongKeDoanhSo : Form
    {
        public FormThongKeDoanhSo()
        {
            InitializeComponent();
            this.textBoxNamNhap.Text = DateTime.Now.Year.ToString();
            this.textBoxNam.Text = DateTime.Now.Year.ToString();
            string thang = DateTime.Now.Month.ToString();
            this.comboBoxThangNhap.Text = string.Concat("Tháng ", thang);
            this.comboBoxThang.Text = string.Concat("Tháng ", thang);
        }
        public bool CheckNam(string s)
        {
            bool result = true;
            if (string.IsNullOrEmpty(s)){
                return false;
            }
            foreach(Char c in s)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            int k = Int32.Parse(s);
            int year = Int32.Parse(DateTime.Now.Year.ToString());
            if(k > year)
            {
                result = false;
            }
            return result;
        }
        public string Cast(string s)
        {
            Stack<string> temp = new Stack<string>();
            while (!string.IsNullOrEmpty(s))
            {
                int n = s.Length;
                if(n <= 3)
                {
                    temp.Push(s);
                    s = "";
                }
                else
                {
                    temp.Push(s.Substring(n - 3));
                    s.Remove(n - 3);
                }
            }
            string result = "";
            while(temp.Count != 0)
            {
                result = string.Concat(result, ",", temp.Pop());
            }
            return result;
        }

        public void LoadPhieuNhap()
        {
            this.textBoxNamNhap.Text = DateTime.Now.Year.ToString();
            string thang = DateTime.Now.Month.ToString();
            this.comboBoxThangNhap.Text = string.Concat("Tháng ", thang);
            DataTable dt = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            string sql;
            if (this.comboBoxThangNhap.Text == "Cả năm")
            {
                sql = "SELECT MaphieuNhap as 'Mã phiếu nhập', CONVERT(varchar(10), NgayNhap, 103) as N'Ngày nhập', TongTien as N'Tổng tiền' FROM PhieuNhap WHERE YEAR(NgayNhap) = '" + this.textBoxNamNhap.Text + "'";
            }
            else
            {
                int k = 0;
                foreach (char c in this.comboBoxThangNhap.Text)
                {
                    if (char.IsDigit(c))
                    {
                        k = k * 10 + Int32.Parse(c.ToString());
                    }
                }
                sql = "SELECT MaphieuNhap as 'Mã phiếu nhập', CONVERT(varchar(10), NgayNhap, 103) as N'Ngày nhập', TongTien as N'Tổng tiền' FROM PhieuNhap WHERE YEAR(NgayNhap) = '" + this.textBoxNamNhap.Text + "' AND MONTH(NgayNhap) = '" + k.ToString() + "'";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
            da.Fill(dt);
            this.dataGridViewPhieuNhap.DataSource = dt;
            sqlCon.Close();
            int n = dt.Rows.Count;
            if (n == 0)
            {
                txtTongTienNhap.Text = "0";
            }
            else
            {
                int temp = 0;
                foreach (DataRow r in dt.Rows)
                {
                    temp = temp + Int32.Parse(r["Tổng tiền"].ToString());
                }

                //txtTongTienNhap.Text = String.Format("{ 0:0,0 }", temp.ToString());
                //this.txtTongTienNhap.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", temp.ToString());
                this.txtTongTienNhap.Text = temp.ToString();
            }
        
           
        }
        public void LoadHoaDon()
        {
            this.textBoxNam.Text = DateTime.Now.Year.ToString();
            string thang = DateTime.Now.Month.ToString();
            this.comboBoxThang.Text = string.Concat("Tháng ", thang);
            DataTable dt = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            string sql;
            if (this.comboBoxThang.Text == "Cả năm")
            {
                sql = "SELECT MaHoaDon as 'Mã hóa đơn', CONVERT(varchar(10), NgayTao, 103) as N'Ngày tạo', TongTien as N'Tổng tiền', (CASE WHEN MaKhachHang is null THEN 'Trống' ELSE MaKhachHang END) as N'Mã khách hàng' FROM HoaDon WHERE YEAR(NgayTao) = '" + this.textBoxNamNhap.Text + "'";
            }
            else
            {
                int k = 0;
                foreach (char c in this.comboBoxThangNhap.Text)
                {
                    if (char.IsDigit(c))
                    {
                        k = k * 10 + Int32.Parse(c.ToString());
                    }
                }
                sql = "SELECT MaHoaDon as 'Mã hóa đơn', CONVERT(varchar(10), NgayTao, 103) as N'Ngày tạo', TongTien as N'Tổng tiền', (CASE WHEN MaKhachHang is null THEN N'Trống' ELSE MaKhachHang END) as N'Mã khách hàng' FROM HoaDon WHERE YEAR(NgayTao) = '" + this.textBoxNamNhap.Text + "' AND MONTH(NgayTao) = '" + k.ToString() + "'";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
            da.Fill(dt);
            this.dataGridViewHoaDon.DataSource = dt;
            sqlCon.Close();
            int n = dt.Rows.Count;
            if (n == 0)
            {
                this.guna2TextBoxDoanhSo.Text = "0";
            }
            else
            {
                int temp = 0;
                foreach (DataRow r in dt.Rows)
                {
                    temp = temp + Int32.Parse(r["Tổng tiền"].ToString());
                }

                //txtTongTienNhap.Text = String.Format("{ 0:0,0 }", temp.ToString());
                //this.txtTongTienNhap.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", temp.ToString());
                this.guna2TextBoxDoanhSo.Text = temp.ToString();
                this.textBoxMKH.Text = "";
                this.textBoxHoTenKH.Text = "";
            }


        }
        private void label12_Click_1(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadPhieuNhap();
            LoadHoaDon();
        }

        private void FormThongKeDoanhSo_Load(object sender, EventArgs e)
        {
            LoadPhieuNhap();
            LoadHoaDon();
        }
        private void buttonThongKeNhap_Click(object sender, EventArgs e)
        {
            if (!CheckNam(this.textBoxNamNhap.Text))
            {
                MessageBox.Show("Năm không hợp lệ");
                this.textBoxNam.Select();
                return;
            }
            else
            {

                DataTable dt = new DataTable();
                string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                string sql;
                if (this.comboBoxThangNhap.Text == "Cả năm")
                {
                    sql = "SELECT MaphieuNhap as 'Mã phiếu nhập', CONVERT(varchar(10), NgayNhap, 103) as N'Ngày nhập', TongTien as N'Tổng tiền' FROM PhieuNhap WHERE YEAR(NgayNhap) = '" + this.textBoxNamNhap.Text + "'";
                }
                else
                {
                    int k = 0;
                    foreach (char c in this.comboBoxThangNhap.Text)
                    {
                        if (char.IsDigit(c))
                        {
                            k = k * 10 + Int32.Parse(c.ToString());
                        }
                    }
                    sql = "SELECT MaphieuNhap as 'Mã phiếu nhập', CONVERT(varchar(10), NgayNhap, 103) as N'Ngày nhập', TongTien as N'Tổng tiền' FROM PhieuNhap WHERE YEAR(NgayNhap) = '" + this.textBoxNamNhap.Text + "' AND MONTH(NgayNhap) = '" + k.ToString() + "'";
                }

                SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
                da.Fill(dt);
                this.dataGridViewPhieuNhap.DataSource = dt;
                sqlCon.Close();
                int n = dt.Rows.Count;
                if (n == 0)
                {
                    txtTongTienNhap.Text = "0";
                }
                else
                {
                    int temp = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        temp = temp + Int32.Parse(r["Tổng tiền"].ToString());
                    }

                    //txtTongTienNhap.Text = String.Format("{ 0:0,0 }", temp.ToString());
                    //this.txtTongTienNhap.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", temp.ToString());
                    this.txtTongTienNhap.Text = temp.ToString();
                }
                this.dataGridViewTTPhieuNhap.DataSource = null;
            }
        }

        private void dataGridViewPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string mapn = this.dataGridViewPhieuNhap.Rows[e.RowIndex].Cells["Mã phiếu nhập"].Value.ToString();
                if (!string.IsNullOrEmpty(mapn))
                {
                    DataTable dt = new DataTable();
                    string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    SqlConnection sqlCon = new SqlConnection(conString);
                    sqlCon.Open();
                    string sql = "EXEC ChiTietPhieuNhap '" + mapn + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
                    da.Fill(dt);
                    this.dataGridViewTTPhieuNhap.DataSource = dt;
                    sqlCon.Close();
                }
            }
        }

        private void txtThongkeDoanhso_Click(object sender, EventArgs e)
        {
            if (!CheckNam(this.textBoxNam.Text))
            {
                MessageBox.Show("Năm không hợp lệ");
                this.textBoxNam.Select();
                return;
            }
            else
            {

                DataTable dt = new DataTable();
                string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                string sql;
                if (this.comboBoxThang.Text == "Cả năm")
                {
                    sql = "SELECT MaHoaDon as 'Mã hóa đơn', CONVERT(varchar(10), NgayTao, 103) as N'Ngày tạo', TongTien as N'Tổng tiền', (CASE WHEN MaKhachHang is null THEN 'Trống' ELSE MaKhachHang END) as N'Mã khách hàng' FROM HoaDon WHERE YEAR(NgayTao) = '" + this.textBoxNam.Text + "'";
                }
                else
                {
                    int k = 0;
                    foreach (char c in this.comboBoxThang.Text)
                    {
                        if (char.IsDigit(c))
                        {
                            k = k * 10 + Int32.Parse(c.ToString());
                        }
                    }
                    sql = "SELECT MaHoaDon as 'Mã hóa đơn', CONVERT(varchar(10), NgayTao, 103) as N'Ngày tạo', TongTien as N'Tổng tiền', (CASE WHEN MaKhachHang is null THEN N'Trống' ELSE MaKhachHang END) as N'Mã khách hàng' FROM HoaDon WHERE YEAR(NgayTao) = '" + this.textBoxNam.Text + "' AND MONTH(NgayTao) = '" + k.ToString() + "'";
                }

                SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
                da.Fill(dt);
                this.dataGridViewHoaDon.DataSource = dt;
                sqlCon.Close();
                int n = dt.Rows.Count;
                if (n == 0)
                {
                    this.guna2TextBoxDoanhSo.Text = "0";
                }
                else
                {
                    int temp = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        temp = temp + Int32.Parse(r["Tổng tiền"].ToString());
                    }

                    //txtTongTienNhap.Text = String.Format("{ 0:0,0 }", temp.ToString());
                    //this.txtTongTienNhap.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", temp.ToString());
                    this.guna2TextBoxDoanhSo.Text = temp.ToString();
                }
            }
            this.dataGridViewTTHoaDon.DataSource = null;
            this.textBoxMKH.Text = "";
            this.textBoxHoTenKH.Text = "";
        }

        private void dataGridViewHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mahd = this.dataGridViewHoaDon.Rows[e.RowIndex].Cells["Mã hóa đơn"].Value.ToString();
                if (!string.IsNullOrEmpty(mahd))
                {
                    DataTable dt = new DataTable();
                    string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                    SqlConnection sqlCon = new SqlConnection(conString);
                    sqlCon.Open();
                    string sql = "EXEC ChiTietHoaDon '" + mahd + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
                    da.Fill(dt);
                    this.dataGridViewTTHoaDon.DataSource = dt;
                    sqlCon.Close();
                    
                    string mkh = this.dataGridViewHoaDon.Rows[e.RowIndex].Cells["Mã khách hàng"].Value.ToString();
                    if(mkh == "Trống")
                    {
                        this.textBoxMKH.Text = "Trống";
                        this.textBoxHoTenKH.Text = "Trống";
                    }
                    else
                    {
                        var r = new DatabaseQLST().Select("SELECT* FROM KhachHang WHERE MaKhachHang = '" + mkh + "'");
                        this.textBoxMKH.Text = r["MaKhachHang"].ToString();
                        this.textBoxHoTenKH.Text = r["HoTen"].ToString();
                    }
                }
                
            }
        }
    }
}
