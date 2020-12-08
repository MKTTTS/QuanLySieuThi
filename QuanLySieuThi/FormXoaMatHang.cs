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
    public partial class FormXoaMatHang : Form
    {
        private string mamh;
        public FormXoaMatHang(string s)
        {
            this.mamh = s;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM MatHang WHERE MaMatHang = '"+this.mamh+"'";
            string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            using (SqlCommand cmd = sqlCon.CreateCommand())
            {
                cmd.CommandText = sql;
                var rows = cmd.ExecuteNonQuery();
                if (rows >= 1)
                {
                    MessageBox.Show("Xóa mặt hàng thành công");
                }
            }
            sqlCon.Close();
            this.Dispose();
        }
    }
}
