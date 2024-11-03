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
    public partial class FormUsermain : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormUsermain()
        {
            alamat = "server=localhost; database=db_library; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show ();
            this.Hide ();

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJudulbuku.Text != "")
                {
                    query = string.Format("select * from tbl_buku where judul_buku = '{0}'", txtJudulbuku.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txtJudulbuku.Text = kolom["judul_buku"].ToString();
                            txtPengarangbuku.Text = kolom["pengarang"].ToString();
                            txtTahunterbit.Text = kolom["tahun_terbit"].ToString();

                        }
                        txtJudulbuku.Enabled = true;
                        dataGridView1.DataSource = ds.Tables[0];
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                        btnPinjam.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormUsermain_Load(null, null);
                    }

                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                FormUsermain_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnPinjam_Click(object sender, EventArgs e)
        {
            try
            {
                // Check that all required fields are filled out
                if (txtNamapeminjam.Text != "" && txtJudulbuku.Text != "")
                {
                    // Get dates from DateTimePickers and format them for MySQL
                    string formattedTanggalPinjam = dtpTanggalpinjam.Value.ToString("yyyy-MM-dd");
                    string formattedTanggalKembali = dtpTanggalkembali.Value.ToString("yyyy-MM-dd");

                    // Define the insert query
                    string query = "INSERT INTO tbl_peminjaman (nama_peminjam, tanggal_pinjam, tanggal_kembali, judul_buku) " +
                                   "VALUES (@NamaPeminjam, @TanggalPinjam, @TanggalKembali, @JudulBuku)";

                    // Set up the MySQL connection and command
                    using (MySqlConnection koneksi = new MySqlConnection("server=localhost; database=db_library; username=root; password=;"))
                    using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
                    {
                        // Add parameters to the command
                        perintah.Parameters.AddWithValue("@NamaPeminjam", txtNamapeminjam.Text);
                        perintah.Parameters.AddWithValue("@TanggalPinjam", formattedTanggalPinjam);
                        perintah.Parameters.AddWithValue("@TanggalKembali", formattedTanggalKembali);
                        perintah.Parameters.AddWithValue("@JudulBuku", txtJudulbuku.Text);

                        // Open the connection and execute the command
                        koneksi.Open();
                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();

                        // Check if the insert operation was successful
                        if (res == 1)
                        {
                            MessageBox.Show("Data berhasil ditambahkan.");
                            // Optionally, reload the form or clear the input fields
                            txtNamapeminjam.Clear();
                            txtJudulbuku.Clear();
                            dtpTanggalpinjam.Value = DateTime.Now;
                            dtpTanggalkembali.Value = DateTime.Now;
                            txtNamapeminjam.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambahkan data.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lengkapi semua data sebelum menyimpan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormHistori formHistori = new FormHistori();
            formHistori.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormAkunUser formAkunUser = new FormAkunUser();
            formAkunUser.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void FormUsermain_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tbl_buku");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "ID Buku";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Judul Buku";
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Pengarang Buku";
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[3].HeaderText = "Tahun Terbit";


                txtID.Clear();
                txtJudulbuku.Clear();
                txtPengarangbuku.Clear();
                txtTahunterbit.Clear();
                txtID.Focus();     
                btnClear.Enabled = true;
                btnPinjam.Enabled = true;
                btnCari.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
