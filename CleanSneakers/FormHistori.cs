using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class FormHistori : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormHistori()
        {
            alamat = "server=localhost; database=db_library; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormUsermain formUsermain = new FormUsermain();
            formUsermain.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormAkunUser formAkunUser = new FormAkunUser();
            formAkunUser.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();   
            this.Hide();
        }

        private void FormHistori_Load(object sender, EventArgs e)
        {
            try
            {
                // Buka koneksi
                koneksi.Open();

                // Menggunakan nama tabel yang benar sesuai database
                query = "SELECT id_peminjam, nama_peminjam, IFNULL(tanggal_pinjam, '0001-01-01') AS tanggal_pinjam, IFNULL(tanggal_kembali, '0001-01-01') AS tanggal_kembali, judul_buku FROM tbl_peminjaman"; // Mengubah nama tabel menjadi tbl_peminjam
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);

                // Bersihkan dataset dan isi dengan data baru
                ds.Clear();
                adapter.Fill(ds);

                // Tutup koneksi
                koneksi.Close();

                // Set DataSource DataGridView ke data yang sudah diambil
                dataGridView1.DataSource = ds.Tables[0];

                // Atur lebar dan judul kolom sesuai dengan kolom yang ada di database
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "ID Peminjam";

                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Nama Peminjam";

                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Tanggal Pinjam";

                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[3].HeaderText = "Tanggal Kembali";

                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[4].HeaderText = "Judul Buku";

                // Bersihkan input text box (jika ada)
                txtJudulbuku.Clear();
                txtPengarangbuku.Clear();
                txtTahunterbit.Clear();
                txtNamapeminjam.Clear();

                // Aktifkan tombol-tombol yang dibutuhkan
                btnCari.Enabled = true;
                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                // Tampilkan pesan kesalahan jika ada masalah
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }
    }
}

