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
    public partial class FormHistoriAdmin : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormHistoriAdmin()
        {
            alamat = "server=localhost; database=db_library; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormPengaturanakun formPengaturanakun = new FormPengaturanakun();
            formPengaturanakun.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {

        }

        private void FormHistoriAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                // Buka koneksi
                koneksi.Open();

                // Menggunakan nama tabel yang benar sesuai database
                query = "SELECT id_peminjam, nama_peminjam, tanggal_pinjam,   tanggal_pinjam, tanggal_kembali,  tanggal_kembali, judul_buku FROM tbl_peminjaman"; // Mengubah nama tabel menjadi tbl_peminjam
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all necessary fields are filled
                if (txtJudulbuku.Text != "" && txtNamapeminjam.Text != "")
                {
                    // Step 1: Check if the username already exists
                    string checkQuery = string.Format("SELECT * FROM tbl_peminjaman WHERE nama_peminjam = '{0}'", txtNamapeminjam.Text);
                    DataSet dsCheck = new DataSet();
                    koneksi.Open();
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, koneksi);
                    MySqlDataAdapter checkAdapter = new MySqlDataAdapter(checkCmd);
                    checkAdapter.Fill(dsCheck);
                    koneksi.Close();

                    if (dsCheck.Tables[0].Rows.Count > 0)
                    {
                        // If the username already exists, show a message
                        MessageBox.Show("Username sudah terdaftar. Silakan gunakan username lain.");
                    }
                    else
                    {
                        // Step 2: Insert the new account into the database
                        string insertQuery = string.Format("INSERT INTO tbl_peminjaman (nama_peminjam, , judul_buku) VALUES ('{0}', '{1}')", txtNamapeminjam.Text, txtJudulbuku.Text);

                        koneksi.Open();
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, koneksi);
                        int result = insertCmd.ExecuteNonQuery(); // Execute the insert query
                        koneksi.Close();

                        if (result == 1) // If insert was successful
                        {
                            MessageBox.Show("Akun berhasil ditambahkan!");
                            // Clear the text fields after successful insertion
                            txtNamapeminjam.Text = "";
                            txtJudulbuku.Text = "";
                            txtPengarangbuku.Text = "";
                            txtTahunterbit.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambahkan akun.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak lengkap. Mohon lengkapi semua field.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnCari_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtJudulbuku.Text != "")
                {
                    query = string.Format("select * from tbl_loginuser where judul_buku = '{0}'", txtJudulbuku.Text);
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
                            txtTahunterbit.Text = kolom["Tahun Terbit"].ToString();
                            txtJudulbuku.Text = kolom["Judul Buku"].ToString();
                            txtPengarangbuku.Text = kolom["Pengarang Buku"].ToString();

                        }
                        txtJudulbuku.Enabled = true;
                        dataGridView1.DataSource = ds.Tables[0];
                        btnPrint.Enabled = true;
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormHistoriAdmin_Load(null, null);
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

        private void btnHapus_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNamapeminjam.Text != "" && txtJudulbuku.Text != "")
                {
                    query = string.Format("UPDATE tbl_loginuser SET judul_buku = '{0}', nama_peminjam = '{1}' ", txtJudulbuku.Text, txtNamapeminjam.Text);

                    using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
                    {
                        if (koneksi.State == ConnectionState.Closed)
                        {
                            koneksi.Open();  // Open the connection only if it's closed
                        }

                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();  // Close the connection immediately after executing the query

                        if (res == 1)
                        {
                            MessageBox.Show("Edit Data Sukses ...");
                            FormHistoriAdmin_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Gagal Edit Data ...");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak Lengkap!");
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
                txtTahunterbit.Clear();
                txtJudulbuku.Clear();
                txtNamapeminjam.Clear();
                txtPengarangbuku.Clear();
                FormHistoriAdmin_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormAdminmain formAdminmain = new FormAdminmain();
            formAdminmain.Show();
            this.Hide();    
        }
    }
}
