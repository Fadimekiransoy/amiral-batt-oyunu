using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amiral_battı_oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=CODERKIZTR;Initial Catalog=amiral_batti;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            int sonuc;
            SqlCommand cmd = new SqlCommand(" insert into oyuncular(oyuncu_adi,sifre,id)values(@a,@s,@id)", baglan);

            cmd.Parameters.AddWithValue("@a", txtoyuncu_adi.Text);
            cmd.Parameters.AddWithValue("@s",txtsifre.Text);
            cmd.Parameters.AddWithValue("@id", txtsifre.Text);
            sonuc =cmd.ExecuteNonQuery();
          

            baglan.Close();
            if (sonuc > 0)
                MessageBox.Show("kayıt basarılı");
                giris f2 = new giris();
                f2.Show();
                this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris f2 = new giris();
            f2.Show();
            this.Hide();
        }
    }
}
