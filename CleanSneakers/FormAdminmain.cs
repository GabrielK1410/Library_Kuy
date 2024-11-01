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

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void FormAdminmain_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
