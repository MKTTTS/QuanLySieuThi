using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace QuanLySieuThi
{
    class DatabaseQLST
    {
        private string connectString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        private SqlConnection conn;
        private string sql;
        private DataTable dt;
        private SqlCommand cmd;

        public DatabaseQLST()
        {
            try
            {
                conn = new SqlConnection(connectString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connected failed" + ex.Message);
            }
        }
        public DataTable SelectData(string sql, List<CustomerParameter> lstPara)
        {
            try
            {
                conn.Open();
                //sql = "EXEC SelectAllNhanVien ";
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var para in lstPara)
                {
                    cmd.Parameters.AddWithValue(para.key, para.value);
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu : " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataRow Select(string sql)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi load thông tin chi tiết : " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public int Excute(string sql, List<CustomerParameter> lstPara, Byte[] images)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstPara.Count != 0)
                {
                    foreach (var p in lstPara)
                    {
                        cmd.Parameters.AddWithValue(p.key, p.value);
                    }
                }
                if (images != null)
                {
                    cmd.Parameters.Add(new SqlParameter("", images));
                }

                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
                //return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi thực thi lệnh : " + ex.Message);
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}

