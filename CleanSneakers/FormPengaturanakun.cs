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
    public partial class FormPengaturanakun : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormPengaturanakun()
        {
            alamat = "server=localhost; database=db_library; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormHistoriAdmin formHistoriAdmin = new FormHistoriAdmin();
            formHistoriAdmin.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormAdminmain formAdmin = new FormAdminmain();  
            formAdmin.Show();
            this.Hide();
        }

        private void FormPengaturanakun_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tbl_loginuser");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "ID Pengguna";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Username";
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Password";


                txtID.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtID.Focus();
                btnUpdate.Enabled = false;
                btnHapus.Enabled = false;
                btnClear.Enabled = true;
                btnTambah.Enabled = true;
                btnCari.Enabled = true;
                pictureBox7.Image = null;
                LblFoto.Visible = true;
                btnGanti.Visible = false;

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
                if (txtPassword.Text != "" && txtUsername.Text != "" && txtID.Text != "")
                {
                    // Tentukan folder tempat menyimpan gambar
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

                    query = string.Format("update tbl_loginuser set password = '{0}', username = '{1}', foto = '{2}' where id = '{3}'", txtPassword.Text, txtUsername.Text, fileName, txtID.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Update Data Suksess ...");
                        FormPengaturanakun_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Update Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
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
                txtID.Clear();
                txtPassword.Clear();
                txtUsername.Clear();
                FormPengaturanakun_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "" )
                {
                    // Tentukan folder tempat menyimpan gambar
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

                    query = string.Format("insert into tbl_loginuser  values ('{0}','{1}','{2}','{3}');", txtID.Text, txtUsername.Text, txtPassword.Text, fileName);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        FormPengaturanakun_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal inser Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "")
                {
                    query = string.Format("select * from tbl_loginuser where username = '{0}'", txtUsername.Text);
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
                            txtID.Text = kolom["id"].ToString();
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


                        btnTambah.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnHapus.Enabled = true;
                        btnClear.Enabled = true;
                        LblFoto.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormPengaturanakun_Load(null, null);
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCRakun formCRakun = new FormCRakun();
            formCRakun.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            LblFoto.Visible = false;
            btnGanti.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGanti_Click(object sender, EventArgs e)
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("Delete from tbl_loginuser where id = '{0}'", txtID.Text);
                        ds.Clear();
                        koneksi.Open();
                        perintah = new MySqlCommand(query, koneksi);
                        adapter = new MySqlDataAdapter(perintah);
                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();
                        if (res == 1)
                        {
                            MessageBox.Show("Delete Data Suksess ...");
                        }
                        else
                        {
                            MessageBox.Show("Gagal Delete data");
                        }
                    }
                    FormPengaturanakun_Load(null, null);
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
    }
}
