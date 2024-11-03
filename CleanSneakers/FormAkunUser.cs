using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanSneakers
{
    public partial class FormAkunUser : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        
        public FormAkunUser()
        {
            alamat = "server=localhost; database=db_library; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormUsermain formUsermain = new FormUsermain();
            formUsermain.Show();
            this.Hide();    
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormHistori formHistori = new FormHistori();    
            formHistori.Show();
            this.Hide();
        }

        private void FormAkunUser_Load(object sender, EventArgs e)
        {
            try
            {
                // Buat query yang mem-filter data berdasarkan pengguna yang login
                string query = string.Format("SELECT * FROM tbl_loginuser WHERE username = '{0}'", txtUsername.Text);
                DataSet ds = new DataSet();

                // Buka koneksi, eksekusi query, dan masukkan hasilnya ke dalam DataGridView
                koneksi.Open();
                MySqlCommand perintah = new MySqlCommand(query, koneksi);
                MySqlDataAdapter adapter = new MySqlDataAdapter(perintah);
                adapter.Fill(ds);
                koneksi.Close();

                // Tampilkan data di DataGridView
                dataGridView1.DataSource = ds.Tables[0];  // Pastikan ini adalah nama DataGridView yang benar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }
    }
}
