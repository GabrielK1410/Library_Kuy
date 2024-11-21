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

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNamapeminjam.Text != "")
                {
                    query = string.Format("SELECT * FROM tbl_peminjaman WHERE nama_peminjam = '{0}'", txtNamapeminjam.Text);
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
                            txtID.Text = kolom["id_peminjam"].ToString();
                            txtJudulbuku.Text = kolom["judul_buku"].ToString();
                            txtNamapeminjam.Text = kolom["nama_peminjam"].ToString();
                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                        btnHapus.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormHistori_Load(null, null);
                    }
                }
                else if (txtJudulbuku.Text != "")
                {
                    query = string.Format("SELECT * FROM tbl_peminjaman WHERE judul_buku = '{0}'", txtJudulbuku.Text);
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
                            txtID.Text = kolom["id_peminjam"].ToString();
                            txtJudulbuku.Text = kolom["judul_buku"].ToString();
                            txtNamapeminjam.Text = kolom["nama_peminjam"].ToString();
                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                        btnHapus.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormHistori_Load(null, null);
                    }

                }
                else if (txtID.Text != "")
                {
                    query = string.Format("SELECT * FROM tbl_peminjaman WHERE id_peminjam = '{0}'", txtID.Text);
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
                            txtID.Text = kolom["id_peminjam"].ToString();
                            txtJudulbuku.Text = kolom["judul_buku"].ToString();
                            txtNamapeminjam.Text = kolom["nama_peminjam"].ToString();

                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                        btnHapus.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormHistori_Load(null, null);
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
                FormHistori_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        koneksi.Open();

                        // Ambil judul buku yang akan dihapus
                        string judulBuku = "";
                        query = string.Format("SELECT judul_buku FROM tbl_peminjaman WHERE id_peminjam = '{0}'", txtID.Text);
                        perintah = new MySqlCommand(query, koneksi);
                        var result = perintah.ExecuteScalar();
                        if (result != null)
                        {
                            judulBuku = result.ToString();
                        }

                        // Hapus data dari tbl_peminjaman
                        query = string.Format("DELETE FROM tbl_peminjaman WHERE id_peminjam = '{0}'", txtID.Text);
                        perintah = new MySqlCommand(query, koneksi);
                        int res = perintah.ExecuteNonQuery();

                        // Jika berhasil menghapus, tambahkan stok buku
                        if (res == 1 && !string.IsNullOrEmpty(judulBuku))
                        {
                            query = string.Format("UPDATE tbl_buku SET stok_buku = stok_buku + 1 WHERE judul_buku = '{0}'", judulBuku);
                            perintah = new MySqlCommand(query, koneksi);
                            perintah.ExecuteNonQuery();

                            MessageBox.Show("Peminjaman berhasil dihapus, stok buku telah diperbarui.");
                        }
                        else
                        {
                            MessageBox.Show("Gagal menghapus peminjaman.");
                        }

                        koneksi.Close();
                        FormHistori_Load(null, null);
                        btnHapus.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormPengembalian formpengembalian = new FormPengembalian();
            formpengembalian.Show();
            this.Hide();
        }

        private void FormHistori_Load(object sender, EventArgs e)
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

                txtID.Clear();
                txtJudulbuku.Clear();
                txtNamapeminjam.Clear();
                txtID.Focus();
                btnClear.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

