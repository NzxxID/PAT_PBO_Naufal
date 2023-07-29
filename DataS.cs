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
    public partial class DataS : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=pat-db");
        public DataS()
        {
            InitializeComponent();
        }
        Data f = new Data();

        void clear()
        {
            txtNisn.Text = string.Empty;
            txtNis.Text = string.Empty;
            txtNama.Text = string.Empty;
            cbIdkelas.Text = string.Empty;
            txtAlamat.Text = string.Empty;
            txtNotelpn.Text = string.Empty;
            cbIdspp.Text = string.Empty;
            f.showData("select * from siswa", dataGridView1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataP().Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataK().Show();
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

        private void DataS_Load(object sender, EventArgs e)
        {
            clear();
            f.getDataIdSpp(cbIdspp);
            getDataIdKelas();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtNisn.Text == string.Empty || txtNis.Text == string.Empty || txtNama.Text == string.Empty || cbIdkelas.Text == string.Empty || txtAlamat.Text == string.Empty || txtNotelpn.Text == string.Empty || cbIdspp.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("insert into siswa(nisn, nis, nama, id_kelas, alamat, no_telpn, id_spp) values ('" + txtNisn.Text + "', '" + txtNis.Text + "', '" + txtNama.Text + "', '" + cbIdkelas.Text.Split('-')[0].Trim() + "', '" + txtAlamat.Text + "', '" + txtNotelpn.Text + "', '" + cbIdspp.Text + "')");
                clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtNisn.Text == string.Empty || txtNis.Text == string.Empty || txtNama.Text == string.Empty || cbIdkelas.Text == string.Empty || txtAlamat.Text == string.Empty || txtNotelpn.Text == string.Empty || cbIdspp.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("update siswa set nis = '" + txtNis.Text + "', nama = '" + txtNama.Text + "', id_kelas = '" + cbIdkelas.Text + "', alamat = '" + txtAlamat.Text + "', no_telpn = '" + txtNotelpn.Text + "', id_spp = '" + cbIdspp.Text + "' where nisn = '" + txtNisn.Text + "'");
                clear();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtNisn.Text == string.Empty || txtNis.Text == string.Empty || txtNama.Text == string.Empty || cbIdkelas.Text == string.Empty || txtAlamat.Text == string.Empty || txtNotelpn.Text == string.Empty || cbIdspp.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("delete from siswa where nisn = '" + txtNisn.Text + "'");
                clear();
            } 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

            txtNisn.Text = dr.Cells[0].Value.ToString();
            txtNis.Text = dr.Cells[1].Value.ToString();
            txtNama.Text = dr.Cells[2].Value.ToString();
            cbIdkelas.Text = dr.Cells[3].Value.ToString();
            txtAlamat.Text = dr.Cells[4].Value.ToString();
            txtNotelpn.Text = dr.Cells[5].Value.ToString();
            cbIdspp.Text = dr.Cells[6].Value.ToString();
        }

        void getDataIdKelas()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select id_kelas, nama_kelas from kelas", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            string data;
            string nama;
            while (reader.Read())
            {
                data = reader["id_kelas"].ToString();
                nama = reader["nama_kelas"].ToString();
                cbIdkelas.Items.Add(data + "-" + nama);
            }
            reader.Close();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNisn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
