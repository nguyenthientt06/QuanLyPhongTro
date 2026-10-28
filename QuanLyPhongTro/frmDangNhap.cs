
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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu");
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoi.TaoKetNoi())
                {
                    string sql = @"SELECT COUNT(*)
                           FROM TaiKhoan
                           WHERE TenDangNhap = @TenDangNhap
                           AND MatKhauHash = @MatKhau
                           AND TrangThai = 1";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TenDangNhap",
                            txtTenDangNhap.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@MatKhau",
                            txtMatKhau.Text);

                        conn.Open();

                        int ketQua = Convert.ToInt32(cmd.ExecuteScalar());

                        if (ketQua > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!");

                            frmPhongTro f = new frmPhongTro();
                            f.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Tên đăng nhập hoặc mật khẩu không đúng!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message);
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
