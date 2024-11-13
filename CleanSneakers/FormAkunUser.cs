using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi bahwa password tidak kosong
                if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtUsername.Text))
                {
                    string folderPath = Path.Combine(Application.StartupPath, "C:\\Users\\USER\\source\\repos\\CleanSneakers\\CleanSneakers\\Foto");

                    // Pastikan folder ada, jika tidak, buat folder
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Membuat nama unik untuk file gambar agar tidak tertimpa
                    string fileName = Guid.NewGuid().ToString() + ".jpg";
                    string filePath = Path.Combine(folderPath, fileName);

                    // Simpan gambar dari PictureBox ke folder
                    pictureBox7.Image.Save(filePath);
                    // Update data dengan username yang sebelumnya login
                    query = $"UPDATE tbl_loginuser SET username = '{txtUsername.Text}', password = '{txtPassword.Text}' , foto = '{fileName}' WHERE username = '{FormUserlogin.LoggedInUsername}'";

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    int result = perintah.ExecuteNonQuery();
                    koneksi.Close();

                    if (result == 1)
                    {
                        MessageBox.Show("Username dan Password berhasil diperbarui.");

                        // Setelah update, perbarui LoggedInUsername untuk sesi berikutnya
                        FormUserlogin.LoggedInUsername = txtUsername.Text;
                    }
                    else
                    {
                        MessageBox.Show("Gagal memperbarui data.");
                    }
                }
                else
                {
                    MessageBox.Show("Mohon isi username dan password baru.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    query = $"SELECT * FROM tbl_loginuser WHERE username = '{txtUsername.Text}'";
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    adapter.Fill(ds);
                    koneksi.Close();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txtIDbuku.Text = kolom["id"].ToString();
                            txtPassword.Text = kolom["password"].ToString();
                            txtUsername.Text = kolom["username"].ToString();
                            string fileName = kolom["foto"].ToString();

                            string folderPath = Path.Combine(Application.StartupPath, "C:\\Users\\USER\\source\\repos\\CleanSneakers\\CleanSneakers\\Foto");
                            string filePath = Path.Combine(folderPath, fileName);

                            // Cek apakah file foto ada
                            if (File.Exists(filePath))
                            {
                                // Tampilkan gambar di PictureBox
                                pictureBox7.Image = Image.FromFile(filePath);
                                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            else
                            {
                                MessageBox.Show("File gambar tidak ditemukan.");
                            }

                        }
                        btnUpdate.Enabled = true;
                        btnHapus.Enabled = true;
                        btnClear.Enabled = true;
                        LblFoto.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormAkunUser_Load(null, null);
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
                if (txtIDbuku.Text != "") // Pastikan ada ID yang akan dihapus
                {
                    // Konfirmasi sebelum menghapus data
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("DELETE FROM tbl_loginuser WHERE id = '{0}'", txtIDbuku.Text);

                        if (koneksi.State == ConnectionState.Closed)
                        {
                            koneksi.Open(); // Buka koneksi sebelum menjalankan query
                        }

                        MySqlCommand perintah = new MySqlCommand(query, koneksi);
                        int res = perintah.ExecuteNonQuery(); // Jalankan perintah delete
                        koneksi.Close(); // Tutup koneksi setelah operasi

                        if (res == 1) // Cek jika penghapusan berhasil
                        {
                            MessageBox.Show("Delete Data Sukses ...");
                            FormAkunUser_Load(null, null); // Reload form dan data
                            btnHapus.Enabled = false; // Nonaktifkan tombol Delete setelah delete
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtIDbuku.Clear();
                txtPassword.Clear();
                txtUsername.Clear();
                FormAkunUser_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            LblFoto.Visible = false;
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            LblFoto.Visible = false;
        }

        private void FormAkunUser_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();

                // Tampilkan hanya data akun pengguna yang sedang login
                query = $"SELECT * FROM tbl_loginuser WHERE username = '{FormUserlogin.LoggedInUsername}'";

                var perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                // Set DataGridView untuk menampilkan data yang diambil
                dataGridView1.DataSource = ds.Tables[0];

                // Mengatur lebar dan header kolom DataGridView
                dataGridView1.Columns[0].Width = 120;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Username";
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[2].HeaderText = "Password";

                // Kosongkan dan nonaktifkan tombol yang tidak diperlukan
                txtIDbuku.Clear();
                txtUsername.Clear();
                txtPassword.Clear();

                btnCari.Enabled = true; // Nonaktifkan tombol Cari
                btnHapus.Enabled = false; // Nonaktifkan tombol Hapus jika tidak diperlukan
                btnClear.Enabled = true; // Nonaktifkan tombol Clear jika tidak diperlukan
                pictureBox7.Image = null;
                LblFoto.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}
