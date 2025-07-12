using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocVien.Model;

namespace QuanLyHocVien.Ultilities
{
    internal class DB_Connector
    {
        MySqlConnection? connection = null;
        string connectionString = "server=localhost;user id=root;password= DanTDM12!";

        public void TestConnection()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                // MessageBox.Show("Kết nối thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public StudentInfo GetStudentList()
        {
            return null;
        }
    }
}
