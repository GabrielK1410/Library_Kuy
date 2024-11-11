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
                koneksi.Open();
                query = string.Format("select * from tbl_peminjaman");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 120;
                dataGridView1.Columns[0].HeaderText = "ID Peminjaman";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Nama Peminjam";
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[2].HeaderText = "Tanggal Pinjam";
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[3].HeaderText = "Tanggal Kembali";
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[4].HeaderText = "Judul Buku";



                txtJudulbuku.Clear();
                txtNamapeminjam.Clear();
   
        

                btnHapus.Enabled = false;
                btnClear.Enabled = true;
                btnCari.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCari_Click_1(object sender, EventArgs e)
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

                            // Set the DateTimePickers with values from the database
                            dtpTanggalpinjam.Value = Convert.ToDateTime(kolom["tanggal_pinjam"]);
                            dtpTanggalkembali.Value = Convert.ToDateTime(kolom["tanggal_kembali"]);
                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                        btnHapus.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormHistoriAdmin_Load(null, null);
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

                            // Set the DateTimePickers with values from the database
                            dtpTanggalpinjam.Value = Convert.ToDateTime(kolom["tanggal_pinjam"]);
                            dtpTanggalkembali.Value = Convert.ToDateTime(kolom["tanggal_kembali"]);
                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                        btnHapus.Enabled = true;
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
            try
            {
                if (txtID.Text != "")
                {
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("DELETE FROM tbl_peminjaman WHERE id_peminjam = '{0}'", txtID.Text);

                        if (koneksi.State == ConnectionState.Closed)
                        {
                            koneksi.Open();
                        }

                        MySqlCommand perintah = new MySqlCommand(query, koneksi);
                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();

                        if (res == 1)
                        {
                            MessageBox.Show("Delete Data Sukses ...");
                            FormHistoriAdmin_Load(null, null);
                            btnHapus.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Gagal Delete Data");
                        }
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

        private void btnUpdate_Click(object sender, EventArgs e)
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

                            // Set the DateTimePickers with values from the database
                            dtpTanggalpinjam.Value = Convert.ToDateTime(kolom["tanggal_pinjam"]);
                            dtpTanggalkembali.Value = Convert.ToDateTime(kolom["tanggal_kembali"]);
                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormHistoriAdmin_Load(null, null);
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

                            // Set the DateTimePickers with values from the database
                            dtpTanggalpinjam.Value = Convert.ToDateTime(kolom["tanggal_pinjam"]);
                            dtpTanggalkembali.Value = Convert.ToDateTime(kolom["tanggal_kembali"]);
                        }

                        dataGridView1.DataSource = ds.Tables[0];
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
              
                txtJudulbuku.Clear();
                txtID.Clear();
                txtNamapeminjam.Clear();
                FormHistoriAdmin_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtPengarangbuku_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTahunterbit_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click_1(object sender, EventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FormCRHistori formCRhistori = new FormCRHistori();
            formCRhistori.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormAdminmain formAdminmain = new FormAdminmain();
            formAdminmain.Show();
            this.Hide();    
        }
    }
}
