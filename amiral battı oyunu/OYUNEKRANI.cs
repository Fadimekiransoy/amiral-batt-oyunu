using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amiral_battı_oyunu
{
    public partial class OYUNEKRANI : Form
    {
        public OYUNEKRANI()
        {
            InitializeComponent();
        }
        int sayac = 0;
        int satır=0;
        int sütun=1;

        private void OYUNEKRANI_Load(object sender, EventArgs e)
        {
            
            
            comboBox1.Items.Add("mayın1");
            comboBox1.Items.Add("mayın2");
            comboBox1.Items.Add("mayın3");

            comboBox1.Items.Add("mayın gemisi1");
            comboBox1.Items.Add("mayın gemisi2");
            comboBox1.Items.Add("mayın gemisi3"); 
            comboBox1.Items.Add("mayın gemisi4");

            comboBox1.Items.Add("kruvazör gemisi1");
            comboBox1.Items.Add("kruvazör gemisi2");
            comboBox1.Items.Add("kruvazör gemisi3");

            comboBox1.Items.Add("frakateyn1");
            comboBox1.Items.Add("frakateyn2");

            comboBox1.Items.Add("amiral gemisi");

            comboBox2.Items.Add("yatay");
            comboBox2.Items.Add("dikey");
            if (comboBox1.SelectedIndex==0)
            {
                
            }
           /* if (shipBox.getSelectionModel().getSelectedItem()==("mayın"))
            {
                length = 3;
            }
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button101_Click(object sender, EventArgs e)
        {

        }
    }
}
