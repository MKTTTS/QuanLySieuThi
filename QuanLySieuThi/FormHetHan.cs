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
    public partial class FormHetHan : Form
    {
        public FormHetHan()
        {
            InitializeComponent();
        }

        private void FormHetHan_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            string sql = "exec PROC_LoadHangHetHan";
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
            da.Fill(dt);
            this.donViHangHoaBindingSource.DataSource = dt;
            sqlCon.Close();
        }


        private void DeSau_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XuLy_btn_Click(object sender, EventArgs e)
        {
            var rows = this.donViHangHoaDataGridView.SelectedRows;
            foreach(DataGridViewRow r in rows)
            {
                string MaMatHang = r.Cells[0].Value.ToString();
                DateTime NgaySanXuat = (DateTime)r.Cells[5].Value;
                DateTime HanSuDung = (DateTime)r.Cells[6].Value;
                string sqlHanSuDung = HanSuDung.ToString("yyyy-MM-dd HH:mm:ss").Split(' ')[0];
                string sqlNgaySanXuat = NgaySanXuat.ToString("yyyy-MM-dd HH:mm:ss").Split(' ')[0];

                string sql = "exec PROC_XoaMatHang @MaMatHang = '" + MaMatHang + "', @NgaySanXuat = '" + sqlNgaySanXuat + "', @HanSuDung = '" + sqlHanSuDung + "'";
                string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(sql, sqlCon);
                da.Fill(dt);
                this.donViHangHoaBindingSource.DataSource = dt;
                sqlCon.Close();

                LoadTable();

            }
        }
    }
}
