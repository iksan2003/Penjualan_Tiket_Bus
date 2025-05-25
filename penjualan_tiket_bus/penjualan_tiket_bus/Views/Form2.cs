using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace penjualan_tiket_bus
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = txtUser.Text;
            string password = txtPassword.Text;

            // Contoh login manual (tanpa database, bisa diganti ke database nanti)
            if ((username == "admin" && password == "admin123") || (username == "user" && password == "user123"))
            {
                MessageBox.Show("Login berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 formUtama = new Form1(); // buka form utama
                formUtama.Show();              // tampilkan form1
                this.Hide();                   // sembunyikan form login
            }
            else
            {
                MessageBox.Show("Login gagal. Username atau Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

            // Contoh login manual (tanpa database, bisa diganti ke database nanti)
            if ((username == "admin" && password == "admin123") || (username == "user" && password == "user123"))
            {
                MessageBox.Show("Login berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 formUtama = new Form1(); // buka form utama
                formUtama.Show();              // tampilkan form1
                this.Hide();                   // sembunyikan form login
            }
            else
            {
                MessageBox.Show("Login gagal. Username atau Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
