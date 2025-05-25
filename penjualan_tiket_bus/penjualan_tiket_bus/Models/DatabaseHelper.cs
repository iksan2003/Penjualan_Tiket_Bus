using System;
using System.Data;
using System.Data.SqlClient;
using penjualan_tiket_bus.Models;

namespace penjualan_tiket_bus
{
    public class DatabaseHelper : IDisposable
    {
        private SqlConnection _conn;

        public DatabaseHelper()
        {
            _conn = Koneksi.GetConnection();
            _conn.Open();
        }

        // Fungsi bantu untuk eksekusi perintah non-query
        private void ExecuteCommand(string query, Action<SqlCommand> addParameters)
        {
            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                addParameters(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        public void TambahData(string nama, string alamat, string tujuan, decimal harga_tiket, DateTime tanggal, string metodePembayaran)
        {
            string query = "INSERT INTO tiket_bus (nama, alamat, tujuan, harga_tiket, tanggal_berangkat, metode_pembayaran) " +
                           "VALUES (@nama, @alamat, @tujuan, @harga, @tanggal, @metode)";

            ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                cmd.Parameters.AddWithValue("@tujuan", tujuan);
                cmd.Parameters.AddWithValue("@harga", harga_tiket);
                cmd.Parameters.AddWithValue("@tanggal", tanggal);
                cmd.Parameters.AddWithValue("@metode", metodePembayaran);
            });
        }

        public void EditData(string nama, string alamat, string tujuan, decimal harga_tiket, DateTime tanggal, string metodePembayaran)
        {
            string query = "UPDATE tiket_bus SET alamat = @alamat, tujuan = @tujuan, harga_tiket = @harga, tanggal_berangkat = @tanggal, metode_pembayaran = @metode WHERE nama = @nama";

            ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                cmd.Parameters.AddWithValue("@tujuan", tujuan);
                cmd.Parameters.AddWithValue("@harga", harga_tiket);
                cmd.Parameters.AddWithValue("@tanggal", tanggal);
                cmd.Parameters.AddWithValue("@metode", metodePembayaran);
            });
        }

        public void HapusData(string nama)
        {
            string query = "DELETE FROM tiket_bus WHERE nama = @nama";

            ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@nama", nama);
            });
        }

        public DataTable AmbilData()
        {
            string query = "SELECT * FROM tiket_bus";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, _conn))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Dispose()
        {
            if (_conn != null && _conn.State == ConnectionState.Open)
            {
                _conn.Close();
                _conn.Dispose();
            }
        }
    }
}
