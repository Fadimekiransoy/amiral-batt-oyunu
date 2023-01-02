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
                oyun ac = new oyun();
                ac.Show();
                this.Hide();
            }else
            {
                TextboxTemizle(panel1);

                MessageBox.Show("oyuncu adı yada sifre yanlış");
            }
            con.Close();
        }


        bool boslukkontrol()
        {
            if (txtoyuncu_adi.Text == "")
            {
                MessageBox.Show("Lütfen Oyuncu Adı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtoyuncu_adi.Focus();
                return false;
            }
            else if (txtsifre.Text == "")
            {
                MessageBox.Show("Lütfen Şifre Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtsifre.Focus();
                return false;
            }
            else return true;
        }


        private static void TextboxTemizle(Panel item)
        {
            foreach (Control a in item.Controls)
            {
                if (!(a is TextBox)) continue;
                a.Text = "";
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (boslukkontrol())
            { 
                con.Open();
                SqlCommand cmd = new SqlCommand(" insert into oyuncular(oyuncu_adi,sifre)values(@a,@s)", con);
                cmd.Parameters.AddWithValue("@a", txtoyuncu_adi.Text);
                cmd.Parameters.AddWithValue("@s", txtsifre.Text);
                cmd.ExecuteNonQuery();
                TextboxTemizle(panel2);
                MessageBox.Show("Kayıt başarılı giriş yapabilirsiniz");
                con.Close();
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Şifreyi Gizle";
                textBox2.PasswordChar = '\0';
            }

            else
            {
                checkBox1.Text = "Şifreyi Göster";
                textBox2.PasswordChar = '*';
            }
        }

        private void txtoyuncu_adi_Enter(object sender, EventArgs e)
        {
            if (txtoyuncu_adi.Text=="OYUNCU ADI")
            {
                txtoyuncu_adi.Text = "";
            }
        }

        private void txtoyuncu_adi_Leave(object sender, EventArgs e)
        {

            if (txtoyuncu_adi.Text == "")
            {
                txtoyuncu_adi.Text = "OYUNCU ADI";
            }
        }

        private void txtsifre_Enter(object sender, EventArgs e)
        {

            if (txtsifre.Text == "SİFRE")
            {
                txtsifre.Text = "";
            }
        }

        private void txtsifre_Leave(object sender, EventArgs e)
        {
            if (txtsifre.Text == "")
            {
                txtsifre.Text = "SİFRE";
            }
        }

        private void giris_Load(object sender, EventArgs e)
        {

        }
    }
}


