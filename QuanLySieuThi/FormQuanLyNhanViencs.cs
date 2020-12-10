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
          string conString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
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
     }
}
