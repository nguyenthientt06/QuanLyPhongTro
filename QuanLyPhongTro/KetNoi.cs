using System.Data.SqlClient;

namespace QuanLyPhongTro
{
    public class KetNoi
    {
        public static string chuoiKetNoi =
            @"Data Source=localhost;
              Initial Catalog=QuanLyPhongTro;
              Integrated Security=True;
              TrustServerCertificate=True";

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(chuoiKetNoi);
        }
    }
}