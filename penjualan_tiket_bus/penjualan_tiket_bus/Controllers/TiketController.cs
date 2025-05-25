using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;

namespace penjualan_tiket_bus.Controllers
{
    internal class TiketController
    {
        public bool TambahTiket(string nama, string alamat, string tujuan, decimal harga, DateTime tanggal, string metode)
        {
            try
            {
                using (var db = new DatabaseHelper())
                {
                    db.TambahData(nama, alamat, tujuan, harga, tanggal, metode);
                }
                return true;
            }
            catch { return false; }
        }

        public DataTable GetSemuaTiket()
        {
            using (var db = new DatabaseHelper())
            {
                return db.AmbilData();
            }
        }

        public bool EditTiket(string nama, string alamat, string tujuan, decimal harga, DateTime tanggal, string metode)
        {
            try
            {
                using (var db = new DatabaseHelper())
                {
                    db.EditData(nama, alamat, tujuan, harga, tanggal, metode);
                }
                return true;
            }
            catch { return false; }
        }

        public bool HapusTiket(string nama)
        {
            try
            {
                using (var db = new DatabaseHelper())
                {
                    db.HapusData(nama);
                }
                return true;
            }
            catch { return false; }
        }

    }
}
