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

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != "" && txtUsername.Text != "")
                {
                    query = string.Format("UPDATE tbl_loginform SET password = '{0}', username = '{1}' WHERE id = '{2}'", txtPassword.Text, txtUsername.Text, txtIDbuku.Text);

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
                            FormPengaturanakun_Load(null, null);
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
                txtIDbuku.Clear();
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
                        string sandi;
                        sandi = kolom["password"].ToString();
                        if (sandi == txtPassword.Text)
                        {
 
                        }
                        else
                        {
                            MessageBox.Show("Anda salah input password");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Username tidak ditemukan");
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
                    query = string.Format("select * from tbl_loginform where username = '{0}'", txtUsername.Text);
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
                            txtIDbuku.Text = kolom["id"].ToString();
                            txtPassword.Text = kolom["password"].ToString();
                            txtUsername.Text = kolom["username"].ToString();

                        }
                        txtUsername.Enabled = true;
                        dataGridView1.DataSource = ds.Tables[0];
                        btnUpdate.Enabled = true;
                        btnCari.Enabled = false;
                        btnClear.Enabled = true;
                        btnHapus.Enabled = true;
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDbuku.Text != "") // Pastikan ada ID yang akan dihapus
                {
                    // Konfirmasi sebelum menghapus data
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("DELETE FROM tbl_loginform WHERE id = '{0}'", txtIDbuku.Text);

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
                            FormPengaturanakun_Load(null, null); // Reload form dan data
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
    }
}
