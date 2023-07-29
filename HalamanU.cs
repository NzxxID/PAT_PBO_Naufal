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
    public partial class HalamanU : Form
    {
        public HalamanU()
        {
            InitializeComponent();
        }
        Data f = new Data();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            new DataS().Show();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void HalamanU_Load(object sender, EventArgs e)
        {
            f.showData("select * from siswa", dataGridView1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
