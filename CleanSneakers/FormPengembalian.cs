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
    public partial class FormPengembalian : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormPengembalian()
        {
            alamat = "server=localhost; database=db_library; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtDenda_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtID.Text) ||
                    !string.IsNullOrWhiteSpace(txtNamapeminjam.Text) ||
                    !string.IsNullOrWhiteSpace(txtJudulbuku.Text))
                {
                    string kondisi = "";

                    // Tentukan kondisi pencarian berdasarkan input yang diberikan
                    if (!string.IsNullOrWhiteSpace(txtID.Text))
                    {
                        kondisi = string.Format("id_peminjam = '{0}'", txtID.Text);
                    }
                    else if (!string.IsNullOrWhiteSpace(txtNamapeminjam.Text))
                    {
                        kondisi = string.Format("nama_peminjam = '{0}'", txtNamapeminjam.Text);
                    }
                    else if (!string.IsNullOrWhiteSpace(txtJudulbuku.Text))
                    {
                        kondisi = string.Format("judul_buku = '{0}'", txtJudulbuku.Text);
                    }

                    // Query berdasarkan kondisi yang dipilih
                    query = $"SELECT * FROM tbl_peminjaman WHERE {kondisi}";

                    ds.Clear();

                    // Eksekusi query
                    using (koneksi = new MySqlConnection(alamat))
                    {
                        koneksi.Open();
                        perintah = new MySqlCommand(query, koneksi);
                        adapter = new MySqlDataAdapter(perintah);
                        adapter.Fill(ds);
                    }

                    // Jika data ditemukan
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txtID.Text = kolom["id_peminjam"].ToString();
                            txtJudulbuku.Text = kolom["judul_buku"].ToString();
                            txtNamapeminjam.Text = kolom["nama_peminjam"].ToString();
                            txtDenda.Text = kolom["denda"].ToString();

                            // Set DateTimePickers dengan data dari database
                            dtpTanggalpinjam.Value = Convert.ToDateTime(kolom["tanggal_pinjam"]);
                            dtpTanggalkembali.Value = Convert.ToDateTime(kolom["tanggal_kembali"]);
                        }

                        // Tampilkan data di DataGridView
                        dataGridView1.DataSource = ds.Tables[0];

                        // Aktifkan tombol yang relevan
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                        btnHapus.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormPengembalian_Load(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Masukkan ID, Nama Peminjam, atau Judul Buku untuk mencari data!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    if (MessageBox.Show("Anda Yakin Ingin Mengembalikan Buku Ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        koneksi.Open();

                        // Ambil data tanggal_kembali dan denda_per_hari dari database
                        string judulBuku = "";
                        DateTime tanggalKembali = DateTime.Now;
                        double dendaPerHari = 0;

                        query = string.Format("SELECT judul_buku, tanggal_kembali, denda FROM tbl_peminjaman WHERE id_peminjam = '{0}'", txtID.Text);
                        perintah = new MySqlCommand(query, koneksi);
                        var reader = perintah.ExecuteReader();

                        if (reader.Read())
                        {
                            judulBuku = reader["judul_buku"].ToString();
                            tanggalKembali = Convert.ToDateTime(reader["tanggal_kembali"]);
                            dendaPerHari = Convert.ToDouble(reader["denda"]);
                        }
                        reader.Close();

                        // Hitung apakah ada keterlambatan
                        DateTime tanggalSekarang = DateTime.Now;
                        double totalDenda = 0;

                        if (tanggalSekarang > tanggalKembali)
                        {
                            int hariTerlambat = (tanggalSekarang - tanggalKembali).Days;
                            totalDenda = hariTerlambat * dendaPerHari;

                            MessageBox.Show($"Buku terlambat dikembalikan! Anda dikenakan denda sebesar Rp {totalDenda}.", "Pemberitahuan");
                        }
                        else
                        {
                            MessageBox.Show("Pengembalian berhasil! Anda tidak dikenakan denda.", "Pemberitahuan");
                        }

                        // Hapus data peminjaman dari database
                        query = string.Format("DELETE FROM tbl_peminjaman WHERE id_peminjam = '{0}'", txtID.Text);
                        perintah = new MySqlCommand(query, koneksi);
                        int res = perintah.ExecuteNonQuery();

                        // Tambahkan stok buku jika data berhasil dihapus
                        if (res == 1 && !string.IsNullOrEmpty(judulBuku))
                        {
                            query = string.Format("UPDATE tbl_buku SET stok_buku = stok_buku + 1 WHERE judul_buku = '{0}'", judulBuku);
                            perintah = new MySqlCommand(query, koneksi);
                            perintah.ExecuteNonQuery();

                            MessageBox.Show("Stok buku telah diperbarui.", "Informasi");
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengembalikan buku.", "Kesalahan");
                        }

                        koneksi.Close();
                        FormPengembalian_Load(null, null);
                        btnHapus.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Data yang Anda pilih tidak ada!", "Kesalahan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Kesalahan");
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                FormPengembalian_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormPengembalian_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = "SELECT * FROM tbl_peminjaman";
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                dataGridView1.DataSource = ds.Tables[0];
                // Adjust column headers
                dataGridView1.Columns[0].HeaderText = "ID Peminjaman";
                dataGridView1.Columns[1].HeaderText = "Nama Peminjam";
                dataGridView1.Columns[2].HeaderText = "Tanggal Pinjam";
                dataGridView1.Columns[3].HeaderText = "Tanggal Kembali";
                dataGridView1.Columns[4].HeaderText = "Judul Buku";
                dataGridView1.Columns[5].HeaderText = "Denda";

                txtID.Clear();
                txtJudulbuku.Clear();
                txtNamapeminjam.Clear();
                txtID.Focus();
                txtDenda.Clear();
                btnClear.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
