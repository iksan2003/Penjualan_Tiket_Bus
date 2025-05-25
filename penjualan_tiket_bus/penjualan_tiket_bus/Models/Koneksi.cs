using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;


namespace penjualan_tiket_bus.Models
{
    public static class Koneksi
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbTiketBus"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}