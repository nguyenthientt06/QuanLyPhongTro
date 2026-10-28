using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyPhongTro
{
    public partial class frmPhongTro : Form
    {
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;TrustServerCertificate=True";
        private void KiemTraKetNoi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();

                    MessageBox.Show(
                        "Kết nối SQL Server thành công!",
                        "Thông báo"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối SQL Server: " + ex.Message
                );
            }
        }

        public frmPhongTro()
        {
            InitializeComponent();
        }
    }
}
