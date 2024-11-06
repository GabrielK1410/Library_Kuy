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
                    query = string.Format("select * from tbl_peminjaman where nama_peminjam = '{0}'", txtNamapeminjam.Text);
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
                            txtNamapeminjam.Text = kolom["nama_pengguna"].ToString();
                            

                        }

                        dataGridView1.DataSource = ds.Tables[0];
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

