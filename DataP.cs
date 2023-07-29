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
    public partial class DataP : Form
    {
        public DataP()
        {
            InitializeComponent();
        }
        Data f = new Data();

        void clear()
        {
            txtIdPetugas.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtNamaPtgs.Text = string.Empty;
            cbLevel.Text = string.Empty;
            f.showData("select * from petugas", dataGridView1);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataK().Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataS().Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataSPP().Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Close();
            new HalamanU().Show();
        }

        private void DataP_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIdPetugas.Text == string.Empty || txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || txtNamaPtgs.Text == string.Empty || cbLevel.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("insert into petugas(id_petugas, username, password, nama_petugas, level) values ('" + txtIdPetugas.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "', '" + txtNamaPtgs.Text + "', '" + cbLevel.Text + "')");
                clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtIdPetugas.Text == string.Empty || txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || txtNamaPtgs.Text == string.Empty || cbLevel.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("update petugas set username = '" + txtUsername.Text + "', password = '" + txtPassword.Text + "', nama_petugas = '" + txtNamaPtgs.Text + "', level = '" + cbLevel.Text + "' where id_petugas = '" + txtIdPetugas.Text + "'");
                clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtIdPetugas.Text == string.Empty || txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || txtNamaPtgs.Text == string.Empty || cbLevel.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("delete from petugas where id_petugas =  '" + txtIdPetugas.Text + "'");
                clear();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

            txtIdPetugas.Text = dr.Cells[0].Value.ToString();
            txtUsername.Text = dr.Cells[1].Value.ToString();
            txtPassword.Text = dr.Cells[2].Value.ToString();
            txtNamaPtgs.Text = dr.Cells[3].Value.ToString();
            cbLevel.Text = dr.Cells[4].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
