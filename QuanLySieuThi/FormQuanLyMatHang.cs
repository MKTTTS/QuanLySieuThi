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
    public partial class FormQuanLyMatHang : Form
    {
        private string maloai;
        public FormQuanLyMatHang()
        {
            InitializeComponent();
            this.textBoxSearch.Text = "";
            this.textBoxTenLoaiMatHang.ReadOnly = true;
            this.comboBoxThemMH.Enabled = false;
        }
        public void TrangThaiTimKiem(bool flag)
        {
            if (flag == true)
            {
                this.panelTimkiemLMH.Enabled = true;
                this.panelThongTinLMH.Enabled = false;
            }
            else
            {
                this.panelTimkiemLMH.Enabled = false;
                this.panelThongTinLMH.Enabled = true;
            }
        }
        public void LoadLoaiHangHoa()
        {
            DataTable dt = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            string key = this.textBoxSearch.Text;
            SqlDataAdapter da = new SqlDataAdapter("SELECT MaLoai AS N'Mã loại', TenLoai AS N'Tên loại mặt hàng' FROM LoaiMatHang WHERE LOWER(TenLoai) LIKE '%' + LOWER(N'"+key+"')+'%'", sqlCon);
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
            sqlCon.Close();
        }

        private void FormQuanLyMatHang_Load(object sender, EventArgs e)
        {
            LoadLoaiHangHoa();
            //LoadMatHang();
            TrangThaiTimKiem(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadLoaiHangHoa();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string malhh = this.dataGridView1.Rows[e.RowIndex].Cells["Mã loại"].Value.ToString();
                if (!string.IsNullOrEmpty(malhh))
                {
                    maloai = malhh;
                    List<CustomerParameter> lst = new List<CustomerParameter>();
                    lst.Add(new CustomerParameter() { key = "@maloai", value = malhh });
                    var r = new DatabaseQLST().Select("THONGTINLOAIMATHANG '"+malhh+"'");
                    this.textBoxTenLoaiMatHang.Text = r["TenLoai"].ToString();
                    this.textBoxSoLuongMoiLoai.Text = r["Soluong"].ToString();
                    TrangThaiTimKiem(false);
                }
                
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string mamh = this.dataGridView2.Rows[e.RowIndex].Cells["Mã mặt hàng"].Value.ToString();
                if (!string.IsNullOrEmpty(mamh))
                {
                    var r = new DatabaseQLST().Select("SELECT * FROM MatHang, LoaiMatHang WHERE MatHang.MaMatHang = '" + mamh + "' AND MatHang.MaLoai = LoaiMatHang.MaLoai");
                    this.textBoxMaMH.Text = r["MaMatHang"].ToString();
                    this.textBoxTenMH.Text = r["TenMatHang"].ToString();
                    this.textBoxSoLuongMH.Text = r["Soluong"].ToString();
                    this.comboBoxThemMH.Text = r["TenLoai"].ToString();
                    this.textBoxXuatXuMH.Text = r["XuatXu"].ToString();
                    this.textBoxGiabanMH.Text = r["GiaBan"].ToString();
                    this.buttonHuyMH.Enabled = true;
                    this.buttonSuaMH.Enabled = true;
                    
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrangThaiTimKiem(true);
            this.textBoxTenLoaiMatHang.Text = "";
            this.textBoxSoLuongMoiLoai.Text = "";
            this.button2.Text = "ĐỔI TÊN";
            this.panel2.Enabled = true;
            this.buttonThemMH.Text = "THÊM";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button2.Text == "ĐỔI TÊN")
            {
                this.textBoxTenLoaiMatHang.ReadOnly = false ;
                this.button2.Text = "LƯU THAY ĐỔI";
            }
            else if(this.button2.Text == "LƯU THAY ĐỔI")
            {
                if(this.textBoxTenLoaiMatHang.Text == "")
                {
                    MessageBox.Show("Chưa điền tên loại hàng hóa");
                    this.textBoxTenLoaiMatHang.Select();
                    return;
                }
                string s = this.textBoxTenLoaiMatHang.Text;
                string sql = "UPDATE LoaiMatHang SET TenLoai = N'" + s + "' WHERE Maloai = '"+maloai+"'";
                string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                using (SqlCommand cmd = sqlCon.CreateCommand())
                {
                    cmd.CommandText = sql;
                    var rows = cmd.ExecuteNonQuery();
                    if(rows >= 1)
                    {
                        MessageBox.Show("Đổi tên thành công");
                        LoadLoaiHangHoa();
                    }
                }
                sqlCon.Close();
                this.textBoxTenLoaiMatHang.ReadOnly = true;
                this.button2.Text = "ĐỔI TÊN";
            }
            else
            {
                if (this.textBoxTenLoaiMatHang.Text == "")
                {
                    MessageBox.Show("Chưa điền tên loại hàng hóa");
                    this.textBoxTenLoaiMatHang.Select();
                    return;
                }
                string s = this.textBoxTenLoaiMatHang.Text;
                string sql = "INSERT INTO LoaiMatHang(TenLoai) VALUES (N'" + s + "')";
                string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                using (SqlCommand cmd = sqlCon.CreateCommand())
                {
                    cmd.CommandText = sql;
                    var rows = cmd.ExecuteNonQuery();
                    if (rows >= 1)
                    {
                        MessageBox.Show("Thêm mới thành công");
                        LoadLoaiHangHoa();
                    }
                }
                sqlCon.Close();
                this.button2.Text = "ĐỔI TÊN";
                TrangThaiTimKiem(true);

            }

        }

        private void buttonThemLMH_Click(object sender, EventArgs e)
        {
            TrangThaiTimKiem(false);
            this.textBoxSoLuongMoiLoai.Text = "0";
            this.textBoxTenLoaiMatHang.Text = "";
            this.textBoxTenLoaiMatHang.ReadOnly = false;
            this.button2.Text = "LƯU";
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            string sql = "SELECT * FROM LoaiMatHang";
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            DataTable dt = new DataTable();
            this.comboBoxLoaiMH.Items.Clear();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
            da.Fill(dt);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                this.comboBoxLoaiMH.Items.Add(dt.Rows[i]["TenLoai"]);
                this.comboBoxThemMH.Items.Add(dt.Rows[i]["TenLoai"]);
            }
            this.comboBoxLoaiMH.Items.Add("Tất cả");
            this.comboBoxLoaiMH.Text = "Tất cả";
            this.comboBoxThemMH.Items.Add("");
            sqlCon.Close();
            Lock(true);
            this.buttonHuyMH.Enabled = false;
            this.buttonSuaMH.Enabled = false;
            
            this.dataGridView2.DataSource = null;
        }
        public void LoadMatHang()
        {
            string loaimathang = this.comboBoxLoaiMH.Text;
            string s = this.textBoxTimkiemMatHang.Text;
            string sql1 = "SELECT MaMatHang AS N'Mã mặt hàng', TenMatHang AS N'Tên mặt hàng', Soluong as N'Số lượng' FROM MatHang JOIN LoaiMatHang ON MatHang.MaLoai = LoaiMatHang.MaLoai WHERE LOWER(TenMatHang) LIKE '%' + LOWER(N'" + s + "')+'%'";
            string sql2 = "SELECT MaMatHang AS N'Mã mặt hàng', TenMatHang AS N'Tên mặt hàng', Soluong as N'Số lượng' FROM MatHang JOIN LoaiMatHang ON MatHang.MaLoai = LoaiMatHang.MaLoai WHERE LOWER(TenMatHang) LIKE '%' + LOWER(N'" + s + "')+'%' AND LoaiMatHang.TenLoai = N'"+loaimathang+"'";
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            DataTable dt = new DataTable();
            string sql;
            if(loaimathang == "Tất cả")
            {
                sql = sql1;
            }
            else
            {
                sql = sql2;
            }
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
            da.Fill(dt);
            this.dataGridView2.DataSource = dt;
            sqlCon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadMatHang();
        }
        public void Lock(bool Flag)
        {
            this.textBoxTenMH.ReadOnly = Flag;
            this.textBoxXuatXuMH.ReadOnly = Flag;
            this.textBoxGiabanMH.ReadOnly = Flag;
            
        }

        private void buttonSuaMH_Click(object sender, EventArgs e)
        {
            if(this.buttonSuaMH.Text == "SỬA")
            {
                Lock(false);
                
                this.buttonSuaMH.Text = "LƯU";
                this.panel2.Enabled = false;
            }
            else
            {
                if (this.textBoxTenMH.Text == "")
                {
                    MessageBox.Show("Tên mặt hàng không hợp lệ");
                    this.textBoxTenMH.Select();
                    return;
                }
                if(this.textBoxXuatXuMH.Text == "")
                {
                    MessageBox.Show("Xuất xứ không hợp lệ");
                    this.textBoxXuatXuMH.Select();
                    return;
                }
                string S = this.textBoxGiabanMH.Text;
                bool Result = true;
                foreach(Char c in S)
                {
                    if(!Char.IsDigit(c)){
                        Result = false;
                    }
                }
                if(Result == false)
                {
                    MessageBox.Show("Giá bán không hợp lệ");
                    this.textBoxGiabanMH.Select();
                    return;
                }
                string MaMH = this.textBoxMaMH.Text;
                string sql = "UPDATE MatHang SET TenMatHang = N'" + this.textBoxTenMH.Text + "', XuatXu = N'" + this.textBoxXuatXuMH.Text + "', GiaBan = N'" + this.textBoxGiabanMH.Text + "' WHERE MaMatHang = '" + MaMH + "'";
                string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                using (SqlCommand cmd = sqlCon.CreateCommand())
                {
                    cmd.CommandText = sql;
                    var rows = cmd.ExecuteNonQuery();
                    if (rows >= 1)
                    {
                        MessageBox.Show("Sửa mặt hàng thành công");
                        LoadLoaiHangHoa();
                    }
                }
                sqlCon.Close();
                this.buttonSuaMH.Text = "SỬA";
                this.panel2.Enabled = true;
                LoadMatHang();
                Lock(true);
                this.buttonSuaMH.Enabled = false;
                
                this.buttonHuyMH.Enabled = false;

            }
        }

        private void buttonHuyMH_Click(object sender, EventArgs e)
        {
            this.panel2.Enabled = true;
            Lock(true);
            this.buttonSuaMH.Enabled = false;
            
            this.buttonHuyMH.Enabled = false;
            this.buttonSuaMH.Text = "SỬA";
            this.buttonThemMH.Text = "THÊM";
            this.comboBoxThemMH.Enabled = false;
            this.button3.Enabled = true;
            this.textBoxTimkiemMatHang.Enabled = true;
            this.comboBoxLoaiMH.Enabled = true;
            this.dataGridView2.Enabled = true;
        }

        private void buttonThemMH_Click(object sender, EventArgs e)
        {
            if(buttonThemMH.Text == "THÊM")
            {
                Lock(false);
                this.textBoxMaMH.Text = "";
                this.comboBoxThemMH.Text = "";
                
                this.textBoxTenMH.Text = "";
                this.textBoxXuatXuMH.Text = "";
                this.textBoxGiabanMH.Text = "";
                this.textBoxSoLuongMH.Text = "0";
                this.buttonThemMH.Text = "LƯU";
                this.button3.Enabled = false;
                this.textBoxTimkiemMatHang.Enabled = false;
                this.comboBoxLoaiMH.Enabled = false;
                this.dataGridView2.Enabled = false;
                this.buttonThemMH.Enabled = true;
                this.comboBoxThemMH.Enabled = true;
                this.buttonHuyMH.Enabled = true;
                this.buttonSuaMH.Enabled = false;
            }
            else
            {
                if(this.textBoxMaMH.Text == "")
                {
                    MessageBox.Show("Chưa có mã mặt hàng");
                    return;
                }
                if(this.textBoxTenMH.Text == "")
                {
                    MessageBox.Show("Chưa có tên mặt hàng");
                    this.textBoxTenMH.Select();
                    return;
                }
                if(this.textBoxXuatXuMH.Text == "")
                {
                    MessageBox.Show("Chưa có xuất xứ mặt hàng");
                    this.textBoxXuatXuMH.Select();
                    return;
                }
                bool Result = true;
                string S = this.textBoxGiabanMH.Text;
                foreach (Char c in S)
                {
                    if (!Char.IsDigit(c))
                    {
                        Result = false;
                    }
                }
                if (Result == false)
                {
                    MessageBox.Show("Giá bán không hợp lệ");
                    this.textBoxGiabanMH.Select();
                    return;
                }
                var r = new DatabaseQLST().Select("SELECT * FROM LoaiMatHang WHERE TenLoai = N'" + this.comboBoxThemMH.Text + "'");
                string rs = r["MaLoai"].ToString();
                string sql = "INSERTMATHANG";
                List<CustomerParameter> lstpara = new List<CustomerParameter>();
                lstpara.Add(new CustomerParameter() { key = "@mamathang", value = this.textBoxMaMH.Text });
                lstpara.Add(new CustomerParameter() { key = "@tenmathang", value = this.textBoxTenMH.Text });
                lstpara.Add(new CustomerParameter() { key = "@soluong", value = this.textBoxSoLuongMH.Text });
                lstpara.Add(new CustomerParameter() { key = "@maloai", value = rs });
                lstpara.Add(new CustomerParameter() { key = "@xuatxu", value = this.textBoxXuatXuMH.Text });
                lstpara.Add(new CustomerParameter() { key = "@giaban", value = this.textBoxGiabanMH.Text });
                var s = new DatabaseQLST().Excute(sql, lstpara, null);
                if(s > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    this.buttonThemMH.Text = "THÊM";
                    this.panel2.Enabled = true;
                    Lock(true);
                    this.comboBoxThemMH.Enabled = false;
                    this.buttonSuaMH.Enabled = false;
                    
                    this.buttonHuyMH.Enabled = true;
                    this.button3.Enabled = true;
                    this.textBoxTimkiemMatHang.Enabled = true;
                    this.comboBoxLoaiMH.Enabled = true;
                    this.dataGridView2.Enabled = true;

                    LoadMatHang();
                }
                else
                {
                    return;
                }

            }
        }

        private void comboBoxThemMH_TextChanged(object sender, EventArgs e)
        {
            if (this.buttonThemMH.Text == "LƯU")
            {
                if (comboBoxThemMH.Text == "")
                {
                    this.textBoxMaMH.Text = "";
                }
                else
                {
                    string S = this.comboBoxThemMH.Text;
                    var r = new DatabaseQLST().Select("EXEC MAMHMAX N'" + S + "'");
                    string rs = r["MaLonNhat"].ToString();
                    int n;
                    if (string.IsNullOrEmpty(rs))
                    {
                        n = 1;
                    }
                    else
                    {
                        n = Int32.Parse(r["MaLonNhat"].ToString());
                        n = n + 1;
                    }
                    int m = Int32.Parse(r["MaLoai"].ToString());
                    if (n < 10)
                    {
                        this.textBoxMaMH.Text = String.Concat(m.ToString(), "#0000000", n.ToString());
                    }
                    if (n > 9 && n < 100)
                    {
                        this.textBoxMaMH.Text = String.Concat(m.ToString(), "#000000", n.ToString());
                    }
                    if (n > 99 && n < 1000)
                    {
                        this.textBoxMaMH.Text = String.Concat(m.ToString(), "#00000", n.ToString());
                    }
                    if (n > 999 && n < 10000)
                    {
                        this.textBoxMaMH.Text = String.Concat(m.ToString(), "#0000", n.ToString());
                    }
                    if (n > 9999 && n < 100000)
                    {
                        this.textBoxMaMH.Text = String.Concat(m.ToString(), "#000", n.ToString());
                    }
                    if (n > 99999 && n < 1000000)
                    {
                        this.textBoxMaMH.Text = String.Concat(m.ToString(), "#00", n.ToString());
                    }
                    if (n > 999999 && n < 10000000)
                    {
                        this.textBoxMaMH.Text = String.Concat(m.ToString(), "#0", n.ToString());
                    }
                    if (n > 9999999 && n < 100000000)
                    {
                        this.textBoxMaMH.Text = String.Concat(m.ToString(), "#", n.ToString());
                    }
                }
            }
        }


        
        private void label12_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

