using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FormQuanLyKho : Form
    {
        private DataTable PhieuNhap = new DataTable();
        public FormQuanLyKho()
        {
            InitializeComponent();
            this.textBoxTimkiemMatHang.Text = "";
            string sql = "SELECT * FROM LoaiMatHang";
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            DataTable dt = new DataTable();
            this.comboBoxLoaiMH.Items.Clear();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.comboBoxLoaiMH.Items.Add(dt.Rows[i]["TenLoai"]);
            }
            this.comboBoxLoaiMH.Items.Add("Tất cả");
            this.comboBoxLoaiMH.Text = "Tất cả";
            sqlCon.Close();
            this.textBoxTongTien.Text = "0";
        }

        private void FormQuanLyKho_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            string sql = "SELECT (CASE WHEN EXISTS(SELECT * FROM DonViHangHoa WHERE DATEDIFF(Day, getdate(), HanSuDung) <= 0 and HanSuDung is not null) THEN 1 ELSE 0 END ) AS HetHan";
            var r = new DatabaseQLST().Select(sql);
            if (r["HetHan"].ToString() == "1")
            {
                FormHetHan f = new FormHetHan();
                f.ShowDialog();
            }
            VietPhieu(false);

        }
        public void LoadMatHang()
        {
            string loaimathang = this.comboBoxLoaiMH.Text;
            string s = this.textBoxTimkiemMatHang.Text;
            string sql1 = "SELECT MaMatHang AS N'Mã mặt hàng', TenMatHang AS N'Tên mặt hàng' FROM MatHang JOIN LoaiMatHang ON MatHang.MaLoai = LoaiMatHang.MaLoai WHERE LOWER(TenMatHang) LIKE '%' + LOWER(N'" + s + "')+'%'";
            string sql2 = "SELECT MaMatHang AS N'Mã mặt hàng', TenMatHang AS N'Tên mặt hàng' FROM MatHang JOIN LoaiMatHang ON MatHang.MaLoai = LoaiMatHang.MaLoai WHERE LOWER(TenMatHang) LIKE '%' + LOWER(N'" + s + "')+'%' AND LoaiMatHang.TenLoai = N'" + loaimathang + "'";
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            DataTable dt = new DataTable();
            string sql;
            if (loaimathang == "Tất cả")
            {
                sql = sql1;
            }
            else
            {
                sql = sql2;
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
            da.Fill(dt);
            this.dataGridViewThongTinMH.DataSource = dt;
            sqlCon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadMatHang();
        }

        private void dataGridViewThongTinMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mamh = this.dataGridViewThongTinMH.Rows[e.RowIndex].Cells["Mã mặt hàng"].Value.ToString();
                if (!string.IsNullOrEmpty(mamh))
                {
                    var r = new DatabaseQLST().Select("SELECT * FROM MatHang, LoaiMatHang WHERE MatHang.MaMatHang = '" + mamh + "' AND MatHang.MaLoai = LoaiMatHang.MaLoai");
                    this.textBoxMaMH.Text = r["MaMatHang"].ToString();
                    this.textBoxTenMH.Text = r["TenMatHang"].ToString();
                    this.textBoxSoLuongMH.Text = r["Soluong"].ToString();
                    this.textBoxLoaiMH.Text = r["TenLoai"].ToString();
                    this.textBoxXuatXuMH.Text = r["XuatXu"].ToString();
                    this.textBoxGiabanMH.Text = r["GiaBan"].ToString();

                }
                this.maskedTextBoxHSD.Text = "";
                this.maskedTextBoxNSX.Text = "";
                this.textBoxSoLuongLo.Text = "";

            }
        }
        public void VietPhieu(bool Flag)
        {
            this.panel3.Visible = Flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.button1.Text == "VIẾT PHIẾU NHẬP")
            {
                VietPhieu(true);
                this.button1.Text = "LƯU";
                this.maskedTextBoxHSD.Visible = this.checkBox1.Checked;
                this.textBoxGiaNhap.Text = "";
            }
            else
            {
                string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                DateTime now = DateTime.Now;
                string sql;
                string sql1 = "SELECT MAX(MaphieuNhap) as MaPN FROM PhieuNhap";
                string sql2 = "SELECT MAX(ID) as IDMAx FROM DonViHangHoa";
                int n = 1;
                int k = 1000000001;
                using (SqlCommand cmd = sqlCon.CreateCommand())
                {
                    cmd.CommandText = sql1;
                    var rows = cmd.ExecuteScalar().ToString();
                    if (!string.IsNullOrEmpty(rows))
                    {
                        n = Int32.Parse(rows);
                        n = n + 1;
                    }
                    cmd.CommandText = sql2;
                    rows = cmd.ExecuteScalar().ToString();
                    if (!string.IsNullOrEmpty(rows))
                    {
                        k = Int32.Parse(rows);
                        k = k + 1;
                    }
                }
                string ngayvietphieu = now.ToString("yyyy-MM-dd");
                sql = "INSERT INTO PhieuNhap (MaphieuNhap, NgayNhap, TongTien) VALUES ('"+n.ToString()+"','"+ngayvietphieu+"','"+this.textBoxTongTien.Text+"')";
                using (SqlCommand cmd = sqlCon.CreateCommand())
                {
                    cmd.CommandText = sql;
                    int numberofRow = PhieuNhap.Rows.Count;
                    
                    if(numberofRow >= 1)
                    {
                        var rrr = cmd.ExecuteNonQuery();
                        foreach( DataRow r in PhieuNhap.Rows)
                        {
                            int i = Int32.Parse(r["Số lượng"].ToString());
                            string stringNhapMatHang;
                            string ngaysanxuat = DateTime.ParseExact(r["Ngày sản xuất"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                            string hansudung = "";
                            try
                                {
                                hansudung = DateTime.ParseExact(r["Hạn sử dụng"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                                }
                                catch (Exception)
                                {

                                }
                            string mamh = r["Tên mặt hàng"].ToString();
                            cmd.CommandText = "SELECT MaMatHang FROM MatHang WHERE TenMatHang = N'" + mamh + "'";
                            var id = cmd.ExecuteScalar().ToString();
                            for (int j = 0; j < i; j++)
                            {
                                if(hansudung == "")
                                {
                                    stringNhapMatHang = "INSERT INTO DonViHangHoa(ID, MaMatHang, NgaySanXuat, HanSuDung) VALUES ('" + k.ToString() + "','"+id+"','" + ngaysanxuat + "',null)";
                                }
                                else
                                {
                                    stringNhapMatHang = "INSERT INTO DonViHangHoa(ID, MaMatHang, NgaySanXuat, HanSuDung) VALUES ('" + k.ToString() + "','"+id+"','" + ngaysanxuat + "', '" + hansudung + "')";
                                }
                                cmd.CommandText = stringNhapMatHang;
                                var rr = cmd.ExecuteNonQuery();
                                k = k + 1;
                                
                            }
                            string tonggia = r["Giá lô hàng"].ToString();
                            string phieunhap_chitiet;
                            if (hansudung == "")
                            {
                                phieunhap_chitiet = "INSERT INTO PhieuNhap_ChiTiet (MaphieuNhap, MaMatHang, NgaySanXuat, HanSuDung, SoLuong, TongGia) VALUES ('" + n.ToString() + "', '" + id + "', '" + ngaysanxuat + "', null, '" + i.ToString() + "', '" + tonggia + "')";
                            }
                            else
                            {
                                phieunhap_chitiet = "INSERT INTO PhieuNhap_ChiTiet (MaphieuNhap, MaMatHang, NgaySanXuat, HanSuDung, SoLuong, TongGia) VALUES ('" + n.ToString() + "', '" + id + "', '" + ngaysanxuat + "', '"+hansudung+"', '" + i.ToString() + "', '" + tonggia + "')";
                            }
                            cmd.CommandText = phieunhap_chitiet;
                            var rrrr = cmd.ExecuteNonQuery();
                            


                        }
                        MessageBox.Show("Viết phiếu nhập thành công");
                        }
                    else
                    {
                        MessageBox.Show("Viết phiếu nhập không thành công");
                        return; 
                    }
                    
                    }
                this.button1.Text = "VIẾT PHIẾU NHẬP";
                VietPhieu(false);
                this.maskedTextBoxHSD.Text = "";
                this.maskedTextBoxNSX.Text = "";
                this.textBoxSoLuongLo.Text = "";
                this.textBoxTongTien.Text = "0";
                PhieuNhap.Clear();
                this.dataGridViewPN.DataSource = null;
                sqlCon.Close();
                    
                }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.textBoxMaMH.Text == "")
            {
                MessageBox.Show("Chưa có mặt hàng");
                return;
            }
            DateTime ngaysx;
            DateTime ngayhsd;
            DateTime now = DateTime.Now;
            
            try
            {
                ngaysx = DateTime.ParseExact(this.maskedTextBoxNSX.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày sản xuất không hợp lệ");
                this.maskedTextBoxNSX.Select();
                return;
            }
            if (DateTime.Compare(ngaysx, now) >= 0)
            {
                MessageBox.Show("Ngày sản xuất không hợp lệ");
                this.maskedTextBoxNSX.Select();
                return;
            }
            if (this.checkBox1.Checked)
            {
                try
                {
                    ngayhsd = DateTime.ParseExact(this.maskedTextBoxHSD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hạn sử dụng không hợp lệ");
                    this.maskedTextBoxHSD.Select();
                    return;
                }
                if (DateTime.Compare(ngayhsd, now) <= 0)
                {
                    MessageBox.Show("Hạn sử dụng không hợp lệ");
                    this.maskedTextBoxHSD.Select();
                    return;
                }
                if(DateTime.Compare(ngaysx, ngayhsd) >= 0)
                {
                    MessageBox.Show("Hạn sử dụng không hợp lệ");
                    this.maskedTextBoxHSD.Select();
                    return;
                }
            }
            bool check = true;
            string S = this.textBoxGiaNhap.Text;
            if (string.IsNullOrEmpty(S))
            {
                MessageBox.Show("Chưa có giá nhập");
                this.textBoxGiaNhap.Select();
                return;
            }
            foreach(Char c in S)
            {
                if (!Char.IsDigit(c))
                {
                    check = false;
                }
            }
            if(check == false)
            {
                MessageBox.Show("Giá nhập không hợp lệ");
                this.textBoxGiaNhap.Select();
                return;
            }
            int m = Int32.Parse(S);
            string s = this.textBoxSoLuongLo.Text;
            int n;
            try
            {
                n = Int32.Parse(s);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng lô hàng không hợp lệ");
                this.textBoxSoLuongLo.Select();
                return;
            }
            if(n <= 0)
            {
                MessageBox.Show("Số lượng lô hàng không hợp lệ");
                this.textBoxSoLuongLo.Select();
                return;
            }
            string nsx = this.maskedTextBoxNSX.Text;
            string hsd = "";
            if (checkBox1.Checked)
            {
                hsd = this.maskedTextBoxHSD.Text;
            }
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            string mmh = this.textBoxMaMH.Text;
            SqlDataAdapter da;
            if(this.checkBox1.Checked)
            {
                da = new SqlDataAdapter("SELECT MatHang.TenMatHang as N'Tên mặt hàng', '" + n + "' as N'Số lượng', '" + n*m + "' as N'Giá lô hàng', '" + nsx + "' as N'Ngày sản xuất', '"+hsd+"' as N'Hạn sử dụng' FROM MatHang WHERE MatHang.MaMatHang = '" + mmh + "'", sqlCon);
            }
            else
            {
                da = new SqlDataAdapter("SELECT MatHang.TenMatHang as N'Tên mặt hàng', '" + n + "' as N'Số lượng', '" + n*m + "' as N'Giá lô hàng', '" + nsx + "' as N'Ngày sản xuất', N'Không' as N'Hạn sử dụng' FROM MatHang WHERE MatHang.MaMatHang = '" + mmh + "'", sqlCon);
            }
            if (da == null)
            {
                MessageBox.Show("Không có mặt hàng này");
                return;
            }
            else
            {
                da.Fill(PhieuNhap);
                this.dataGridViewPN.DataSource = PhieuNhap;
                sqlCon.Close();
            }
            int k = 0;
            foreach (DataRow r in PhieuNhap.Rows)
            {
                k = k + Int32.Parse(r["Giá lô hàng"].ToString());
            }
            this.textBoxTongTien.Text = k.ToString();
            this.textBoxGiaNhap.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.maskedTextBoxHSD.Visible = this.checkBox1.Checked;
            this.maskedTextBoxHSD.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int m = PhieuNhap.Rows.Count;
            if (m >= 1)
            {
                PhieuNhap.Rows[m - 1].Delete();
                PhieuNhap.AcceptChanges();
                int n = 0;
                foreach (DataRow r in PhieuNhap.Rows)
                {
                    n = n + Int32.Parse(r["Giá lô hàng"].ToString());
                }
                this.textBoxTongTien.Text = n.ToString();
            }
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.button1.Text = "VIẾT PHIẾU NHẬP";
            VietPhieu(false);
            this.maskedTextBoxHSD.Text = "";
            this.maskedTextBoxNSX.Text = "";
            this.textBoxSoLuongLo.Text = "";
            this.textBoxTongTien.Text = "0";
            PhieuNhap.Clear();
            this.dataGridViewPN.DataSource = null;
        }
    }
}
