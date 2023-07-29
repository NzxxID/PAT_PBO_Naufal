using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PAT_PBO_NAUFAL
{
    public partial class Login : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=pat-db";
        public void login()
        {
            string query = "SELECT * FROM login WHERE username='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Login Berhasil");
                        HalamanU Form1 = new HalamanU();
                        Form1.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Maaf Username dan Password Anda Salah");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
