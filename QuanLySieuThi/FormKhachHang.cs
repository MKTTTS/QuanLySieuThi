﻿using System;
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
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
            this.textBoxSearch.Text = "";
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }
        public void LoadKhachHang()
        {
            string key = this.textBoxSearch.Text;
            string sql = "SELECT KhachHang.MaKhachHang as N'Mã khách hàng', KhachHang.HoTen as N'Họ tên', KhachHang.GioiTinh as N'Giới tính', (CASE WHEN SUM(HoaDon.TongTien) is null THEN 0 ELSE SUM(HoaDon.TongTien) END) as N'Số tiền đã mua' FROM KhachHang LEFT JOIN HoaDon ON KhachHang.MaKhachHang = HoaDon.MaKhachHang WHERE LOWER(KhachHang.MaKhachHang) like '%'+LOWER((N'"+key+"'))+'%' OR LOWER(KhachHang.HoTen) like  '%'+LOWER((N'"+key+"'))+'%' GROUP BY KhachHang.MaKhachHang, KhachHang.HoTen, KhachHang.GioiTinh ";
            DataTable dt = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
            sqlCon.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public bool Injection(string s)
        {
            bool result = false;
            foreach (Char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    if (!Char.IsWhiteSpace(c))
                    {
                        result = true;
                    } 
                }
            }
            return result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string mkh = this.dataGridView1.Rows[e.RowIndex].Cells["Mã khách hàng"].Value.ToString();
                if (!string.IsNullOrEmpty(mkh))
                {
                    var r = new DatabaseQLST().Select("THONGTINKHACHHANG '" + mkh + "'");
                    this.guna2TextBoxHoTen.Text = r["HoTen"].ToString();
                    this.guna2TextBoxGioiTinh.Text = r["GioiTinh"].ToString();
                    this.guna2TextBoxSDT.Text = r["SDT"].ToString();
                    this.guna2TextBoxDiemThuong.Text = r["DiemThuong"].ToString();
                    this.guna2TextBoxMua.Text = r["Mua"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Injection(this.textBoxSearch.Text))
            {
                MessageBox.Show("Từ khóa không hợp lệ");
                return;
            }
            LoadKhachHang();
        }
    }
}
