using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAT_PBO_NAUFAL
{
    public partial class DataK : Form
    {
        public DataK()
        {
            InitializeComponent();
        }
        Data f = new Data();

        void clear()
        {
            txtIdkelas.Text = string.Empty;
            txtNamakelas.Text = string.Empty;
            txtJurusan.Text = string.Empty;
            f.showData("select * from kelas", dataGridView1);
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

        private void DataK_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtIdkelas.Text == string.Empty || txtNamakelas.Text == string.Empty || txtJurusan.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("insert into kelas(id_kelas, nama_kelas, kompetensi_keahlian) values ('" + txtIdkelas.Text + "', '" + txtNamakelas.Text + "', '" + txtJurusan.Text + "')");
                clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtIdkelas.Text == string.Empty || txtNamakelas.Text == string.Empty || txtJurusan.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("update kelas set nama_kelas = '" + txtNamakelas.Text + "', kompetensi_keahlian = '" + txtJurusan.Text + "' where id_kelas = '" + txtIdkelas.Text + "'");
                clear();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtIdkelas.Text == string.Empty || txtNamakelas.Text == string.Empty || txtJurusan.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                f.command("delete from kelas where id_kelas =  '" + txtIdkelas.Text + "'");
                clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

            txtIdkelas.Text = dr.Cells[0].Value.ToString();
            txtNamakelas.Text = dr.Cells[1].Value.ToString();
            txtJurusan.Text = dr.Cells[2].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
