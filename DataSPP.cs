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
    public partial class DataSPP : Form
    {
        public DataSPP()
        {
            InitializeComponent();
        }
        Data f = new Data();

        void clear()
        {
            txtIdspp.Text = string.Empty;
            txtTahun.Text = string.Empty;
            txtNominal.Text = string.Empty;
            f.showData("select * from spp", dataGridView1);
        }

        private void DataSPP_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataS().Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataP().Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataK().Show();
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtIdspp.Text == string.Empty || txtTahun.Text == string.Empty || txtNominal.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("insert into spp(id_spp, tahun, nominal) values ('" + txtIdspp.Text + "', '" + txtTahun.Text + "', '" + txtNominal.Text + "')");
                clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtIdspp.Text == string.Empty || txtTahun.Text == string.Empty || txtNominal.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("update spp set tahun = '" + txtTahun.Text + "', nominal = '" + txtNominal.Text + "' where id_spp = '" + txtIdspp.Text + "'");
                clear();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtIdspp.Text == string.Empty || txtTahun.Text == string.Empty || txtNominal.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("delete from spp where id_spp =  '" + txtIdspp.Text + "'");
                clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

            txtIdspp.Text = dr.Cells[0].Value.ToString();
            txtTahun.Text = dr.Cells[1].Value.ToString();
            txtNominal.Text = dr.Cells[2].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
