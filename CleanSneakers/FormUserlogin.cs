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
    public partial class FormUserlogin : Form
    {
        public static string LoggedInUsername;
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormUserlogin()
        {

            alamat = "server=localhost; database=db_library; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormUserlogin_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all necessary fields are filled
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {
                    // Step 1: Check if the username already exists
                    string checkQuery = string.Format("SELECT * FROM tbl_loginuser WHERE username = '{0}'", txtUsername.Text);
                    DataSet dsCheck = new DataSet();
                    koneksi.Open();
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, koneksi);
                    MySqlDataAdapter checkAdapter = new MySqlDataAdapter(checkCmd);
                    checkAdapter.Fill(dsCheck);
                    koneksi.Close();

                    if (dsCheck.Tables[0].Rows.Count > 0)
                    {
                        // If the username already exists, show a message
                        MessageBox.Show("Username sudah terdaftar. Silakan gunakan username lain.");
                    }
                    else
                    {
                        // Step 2: Insert the new account into the database
                        string insertQuery = string.Format("INSERT INTO tbl_loginuser (username, password) VALUES ('{0}', '{1}')", txtUsername.Text, txtPassword.Text);

                        koneksi.Open();
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, koneksi);
                        int result = insertCmd.ExecuteNonQuery(); // Execute the insert query
                        koneksi.Close();

                        if (result == 1) // If insert was successful
                        {
                            MessageBox.Show("Akun berhasil ditambahkan!");
                            // Clear the text fields after successful insertion
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambahkan akun.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak lengkap. Mohon lengkapi semua field.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    string query = "SELECT * FROM tbl_loginuser WHERE username = @username AND password = @password";
                    koneksi.Open();
                    MySqlCommand perintah = new MySqlCommand(query, koneksi);
                    perintah.Parameters.AddWithValue("@username", username);
                    perintah.Parameters.AddWithValue("@password", password);
                    MySqlDataReader reader = perintah.ExecuteReader();

                    if (reader.HasRows)
                    {
                        LoggedInUsername = username;  // Menyimpan username pengguna yang berhasil login
                        MessageBox.Show("Login berhasil!");
                        reader.Close();
                        koneksi.Close();

                        // Buka form akun pengguna
                        FormAkunUser formAkunUser = new FormAkunUser();
                        formAkunUser.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah.");
                    }

                    reader.Close();
                    koneksi.Close();
                }
                else
                {
                    MessageBox.Show("Masukkan username dan password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}
