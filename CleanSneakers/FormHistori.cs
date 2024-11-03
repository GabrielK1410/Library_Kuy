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
                txtJudulbuku.Clear();
                txtPengarangbuku.Clear();
                txtTahunterbit.Clear();
                FormHistori_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormHistori_Load(object sender, EventArgs e)
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
    }
}

