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
                    query = $"SELECT * FROM tbl_buku WHERE judul_buku = '{txtJudulbuku.Text}'";
                    ds.Clear();

                    if (koneksi.State == ConnectionState.Closed) koneksi.Open(); // Pastikan koneksi tertutup sebelum dibuka

                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    adapter.Fill(ds);

                    koneksi.Close(); // Tutup koneksi setelah selesai

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txtJudulbuku.Text = kolom["judul_buku"].ToString();
                            txtPengarangbuku.Text = kolom["pengarang"].ToString();
                            txtTahunterbit.Text = kolom["tahun_terbit"].ToString();
                            txtStok.Text = kolom["stok_buku"].ToString();
                            txtBatasPinjaman.Text = kolom["batas_peminjaman"].ToString();
                            txtDenda.Text = kolom["denda"].ToString();
                        }

                        dtpTanggalpinjam.Value = DateTime.Now;

                        if (int.TryParse(txtBatasPinjaman.Text, out int batasHari))
                        {
                            dtpTanggalkembali.Value = dtpTanggalpinjam.Value.AddDays(batasHari);
                        }

                        dtpTanggalpinjam.Enabled = false;
                        dtpTanggalkembali.Enabled = false;

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
                    MessageBox.Show("Masukkan judul buku yang ingin dicari!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (koneksi.State == ConnectionState.Open) koneksi.Close(); // Tutup koneksi jika ada error
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
            if (string.IsNullOrWhiteSpace(txtNamapeminjam.Text) || string.IsNullOrWhiteSpace(txtJudulbuku.Text))
            {
                MessageBox.Show("Lengkapi semua data sebelum menyimpan!");
                return;
            }

            try
            {
                if (koneksi.State == ConnectionState.Closed) koneksi.Open(); // Pastikan koneksi tertutup sebelum dibuka

                // Cek stok
                string cekStokQuery = "SELECT stok_buku FROM tbl_buku WHERE judul_buku = @judul";
                perintah = new MySqlCommand(cekStokQuery, koneksi);
                perintah.Parameters.AddWithValue("@judul", txtJudulbuku.Text);
                int stok = Convert.ToInt32(perintah.ExecuteScalar());

                if (stok > 0)
                {
                    // Simpan data peminjaman
                    string pinjamQuery = @"INSERT INTO tbl_peminjaman 
                                   (nama_peminjam, tanggal_pinjam, tanggal_kembali, judul_buku, denda) 
                                   VALUES (@nama, @pinjam, @kembali, @judul, @denda)";
                    perintah = new MySqlCommand(pinjamQuery, koneksi);
                    perintah.Parameters.AddWithValue("@nama", txtNamapeminjam.Text);
                    perintah.Parameters.AddWithValue("@pinjam", dtpTanggalpinjam.Value.ToString("yyyy-MM-dd"));
                    perintah.Parameters.AddWithValue("@kembali", dtpTanggalkembali.Value.ToString("yyyy-MM-dd"));
                    perintah.Parameters.AddWithValue("@judul", txtJudulbuku.Text);
                    perintah.Parameters.AddWithValue("@denda", txtDenda.Text); // Tambahkan denda
                    perintah.ExecuteNonQuery();

                    // Update stok
                    string updateStokQuery = "UPDATE tbl_buku SET stok_buku = stok_buku - 1 WHERE judul_buku = @judul";
                    perintah = new MySqlCommand(updateStokQuery, koneksi);
                    perintah.Parameters.AddWithValue("@judul", txtJudulbuku.Text);
                    perintah.ExecuteNonQuery();

                    MessageBox.Show("Peminjaman berhasil!");
                    FormUsermain_Load(null, null); // Memuat ulang data buku
                }
                else
                {
                    MessageBox.Show("Stok buku habis!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open) koneksi.Close(); // Tutup koneksi
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormPengembalian formpengembalian = new FormPengembalian();
            formpengembalian.Show();
            this.Hide();
        }

        private void FormUsermain_Load(object sender, EventArgs e)
        {
            try
            {
                if (koneksi.State == ConnectionState.Closed) koneksi.Open(); // Pastikan koneksi tertutup sebelum dibuka
                query = "SELECT * FROM tbl_buku";
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close(); // Tutup koneksi setelah selesai
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "ID Buku";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Judul Buku";
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Pengarang Buku";
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[3].HeaderText = "Tahun Terbit";
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].HeaderText = "Stok";
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[5].HeaderText = "Batas Harian Peminjaman";
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[6].HeaderText = "Denda";


                txtID.Clear();
                txtJudulbuku.Clear();
                txtPengarangbuku.Clear();
                txtTahunterbit.Clear();
                txtBatasPinjaman.Clear();
                txtNamapeminjam.Clear();  
                txtDenda.Clear();
                txtStok.Clear();
                dtpTanggalkembali.Enabled = true;
                dtpTanggalpinjam.Enabled = true;
                txtID.Focus();
                btnClear.Enabled = true;
                btnPinjam.Enabled = true;
                btnCari.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open) koneksi.Close(); // Tutup koneksi jika terbuka
            }
        }
    }
}
