using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PAT_PBO_NAUFAL
{
    internal class Data
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=pat-db");
        public void command(string query)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void showData(string query, DataGridView dg)
        {
            try
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                dg.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void getDataIdSpp(ComboBox cb)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select id_spp from spp", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            string data;
            while (reader.Read())
            {
                data = reader["id_spp"].ToString();
                cb.Items.Add(data);
            }
            reader.Close();
            conn.Close();
        }
        public void disable(KeyPressEventArgs e, object sender)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
