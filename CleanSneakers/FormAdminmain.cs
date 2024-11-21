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
    public partial class FormAdminmain : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        public FormAdminmain()
        {
            alamat = "server=localhost; database=db_library; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJudulbuku.Text != "")
                {
                    query = string.Format("select * from tbl_buku where judul_buku = '{0}'", txtJudulbuku.Text);
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
                            txtIDbuku.Text = kolom["id_buku"].ToString();
                            txtJudulbuku.Text = kolom["judul_buku"].ToString();
                            txtPengarangbuku.Text = kolom["pengarang"].ToString();
                            txtTahunterbit.Text = kolom["tahun_terbit"].ToString();
                            txtStok.Text = kolom["stok_buku"].ToString() ;
                            txtBatasPinjaman.Text = kolom["batas_peminjaman"].ToString() ;
                            txtDenda.Text = kolom["denda"].ToString();

                        }
                        txtJudulbuku.Enabled = true;
                        dataGridView1.DataSource = ds.Tables[0];
                        btnTambah.Enabled = true;
                        btnHapus.Enabled = true;
                        btnCari.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormAdminmain_Load(null, null);
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJudulbuku.Text != "" && txtPengarangbuku.Text != "" && txtTahunterbit.Text != "" &&
                    txtStok.Text != "" && txtDenda.Text != "" && txtBatasPinjaman.Text != "")
                {
                    query = string.Format("INSERT INTO tbl_buku (judul_buku, pengarang, tahun_terbit, stok_buku, denda, batas_peminjaman) " +
                                          "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                                          txtJudulbuku.Text, txtPengarangbuku.Text, txtTahunterbit.Text,
                                          txtStok.Text, txtDenda.Text, txtBatasPinjaman.Text);

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();

                    if (res == 1)
                    {
                        MessageBox.Show("Data berhasil ditambahkan.");
                        FormAdminmain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menambahkan data.");
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak lengkap!");
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
                if (txtIDbuku.Text != "")
                {
                    if (MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("DELETE FROM tbl_buku WHERE id_buku = '{0}'", txtIDbuku.Text);

                        koneksi.Open();
                        perintah = new MySqlCommand(query, koneksi);
                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();

                        if (res == 1)
                        {
                            MessageBox.Show("Data berhasil dihapus.");
                            FormAdminmain_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Gagal menghapus data.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silakan pilih data untuk dihapus.");
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
                FormAdminmain_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormAdminmain_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = "SELECT * FROM tbl_buku";
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].HeaderText = "ID Buku";
                dataGridView1.Columns[1].HeaderText = "Judul Buku";
                dataGridView1.Columns[2].HeaderText = "Pengarang";
                dataGridView1.Columns[3].HeaderText = "Tahun Terbit";
                dataGridView1.Columns[4].HeaderText = "Stok Buku";
                dataGridView1.Columns[5].HeaderText = "Batas Peminjaman";
                dataGridView1.Columns[6].HeaderText = "Denda";

                txtIDbuku.Clear();
                txtJudulbuku.Clear();
                txtPengarangbuku.Clear();
                txtTahunterbit.Clear();
                txtStok.Clear();
                txtDenda.Clear();
                txtBatasPinjaman.Clear();
                txtIDbuku.Focus();
                btnHapus.Enabled = false;
                btnClear.Enabled = true;
                btnTambah.Enabled = true;
                btnCari.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJudulbuku.Text != "" && txtPengarangbuku.Text != "" && txtTahunterbit.Text != "" && txtIDbuku.Text != "")
                {

                    query = string.Format("update tbl_buku set judul_buku = '{0}', pengarang = '{1}', tahun_terbit = '{2}' where id_pengguna = '{3}'", txtJudulbuku.Text, txtPengarangbuku.Text, txtTahunterbit.Text, txtIDbuku.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Update Data Suksess ...");
                        FormAdminmain_Load(null, null);
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            FormHistoriAdmin formHistoriAdmin = new FormHistoriAdmin();
            formHistoriAdmin.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormPengaturanakun formPengaturanakun = new FormPengaturanakun();
            formPengaturanakun.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJudulbuku.Text != "" && txtPengarangbuku.Text != "" && txtTahunterbit.Text != "" &&
                    txtStok.Text != "" && txtDenda.Text != "" && txtBatasPinjaman.Text != "" && txtIDbuku.Text != "")
                {
                    query = string.Format("UPDATE tbl_buku SET judul_buku = '{0}', pengarang = '{1}', tahun_terbit = '{2}', " +
                                          "stok_buku = '{3}', batas_peminjaman = '{4}', denda = '{5}' " +
                                          "WHERE id_buku = '{6}'",
                                          txtJudulbuku.Text, txtPengarangbuku.Text, txtTahunterbit.Text,
                                          txtStok.Text, txtBatasPinjaman.Text, txtDenda.Text, txtIDbuku.Text);

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();

                    if (res == 1)
                    {
                        MessageBox.Show("Data berhasil diperbarui.");
                        FormAdminmain_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal memperbarui data.");
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak lengkap!");
                }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
