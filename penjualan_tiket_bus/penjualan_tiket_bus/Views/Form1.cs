using System;
using System.Data;
using System.Windows.Forms;
using penjualan_tiket_bus.Controllers;

namespace penjualan_tiket_bus
{
    public partial class Form1 : Form
    {
        TiketController controller = new TiketController();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMetode.Items.AddRange(new string[] { "Cash", "Transfer Bank", "E-Wallet", "BRImo" });
            cmbMetode.SelectedIndex = 0;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtHarga.Text, out decimal harga))
            {
                MessageBox.Show("Harga tidak valid."); return;
            }

            if (controller.TambahTiket(txtNama.Text, txtAlamat.Text, txtTujuan.Text, harga, dtpTanggal.Value, cmbMetode.Text))
                MessageBox.Show("Data berhasil ditambahkan!");
            else
                MessageBox.Show("Gagal menambahkan data!");
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.GetSemuaTiket();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (controller.HapusTiket(txtNama.Text))
                MessageBox.Show("Data berhasil dihapus!");
            else
                MessageBox.Show("Gagal menghapus data!");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtHarga.Text, out decimal harga))
            {
                MessageBox.Show("Harga tidak valid."); return;
            }

            if (controller.EditTiket(txtNama.Text, txtAlamat.Text, txtTujuan.Text, harga, dtpTanggal.Value, cmbMetode.Text))
                MessageBox.Show("Data berhasil diedit!");
            else
                MessageBox.Show("Gagal mengedit data!");
        }

        // Tambahan Event Kosong (boleh dihapus kalau tidak digunakan)
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtHarga_TextChanged(object sender, EventArgs e) { }
        private void txtTujuan_TextChanged(object sender, EventArgs e) { }
        private void txtNama_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void cmbMetode_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label7_Click_1(object sender, EventArgs e) { }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Batasi input hanya angka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
