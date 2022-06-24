using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amiral_battı_oyunu
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source = CODERKIZTR; Initial Catalog = amiral_batti; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            string oyuncuadi = textBox1.Text;
            string sifre = textBox2.Text;
            cmd =new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select*from oyuncular where oyuncu_adi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                OYUNEKRANI ac = new OYUNEKRANI();
                ac.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("oyuncu adı yada sifre yanlış");
            }
            con.Close();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.TextBox") item.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            int sonuc;
            SqlCommand cmd = new SqlCommand(" insert into oyuncular(oyuncu_adi,sifre)values(@a,@s)", con);

            cmd.Parameters.AddWithValue("@a", txtoyuncu_adi.Text);
            cmd.Parameters.AddWithValue("@s", txtsifre.Text);

            sonuc = cmd.ExecuteNonQuery();



            if (sonuc > 0)
            {
                MessageBox.Show("Kayıt başarılı giriş yapabilirsiniz");
            }
            else
            { 

            
                if (txtoyuncu_adi.Text == "")
                {
                    MessageBox.Show("Lütfen Kullanıcı Adı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtoyuncu_adi.Focus();
                    
                  
                }
                else if (txtsifre.Text == "")
                {
                    MessageBox.Show("Lütfen Şifre Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsifre.Focus();
                   
                }
               
            }

            con.Close();
        }
    }
}
