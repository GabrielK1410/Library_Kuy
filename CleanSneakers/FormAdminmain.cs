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
                    query = string.Format("select * from tbl_buku where username = '{0}'", txtJudulbuku.Text);
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

                        }
                        txtJudulbuku.Enabled = true;
                        dataGridView1.DataSource = ds.Tables[0];
                        btnTambah.Enabled = true;
                        btnEdit.Enabled = true;
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
                if (txtJudulbuku.Text != "" && txtPengarangbuku.Text != "" && txtTahunterbit.Text != "")
                {

                    query = string.Format("insert into tbl_buku  values ('{0}','{1}','{2}','{3}');", txtIDbuku.Text, txtJudulbuku.Text, txtPengarangbuku.Text, txtTahunterbit.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        FormAdminmain_Load(null, null);
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDbuku.Text != "")
                {
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("Delete from tbl_buku where id_buku = '{0}'", txtIDbuku.Text);
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
                    FormAdminmain_Load(null, null);
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
                query = string.Format("select * from tbl_buku");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "ID Buku";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Judul Buku";
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Pengarang Buku";
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[3].HeaderText = "Tahun Terbit";
               

                txtIDbuku.Clear();
                txtJudulbuku.Clear();
                txtPengarangbuku.Clear();
                txtTahunterbit.Clear();
                txtIDbuku.Focus();
                btnEdit.Enabled = false;
                btnHapus.Enabled = false;
                btnClear.Enabled = false;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
