using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
namespace amiral_battı_oyunu
{
    public partial class oyun : Form
    {
        public oyun()
        {
            InitializeComponent();
        }

        int i, j;
        bool suruklenmedurumu = false;
        Point ilkkonumAl;
        private string aktifgemi;
        String GemiHarfKonumu = "";
        int GemiSayiKonumu = 0;
        int mayınyenikonum = 0;
        ArrayList konum = new ArrayList(); 
       
        private void mayın_MouseDown(object sender, MouseEventArgs e)
        {
            Button mayın = sender as Button;
            if (e.Button == MouseButtons.Left)
            {
                suruklenmedurumu = true;
                mayın.Cursor = Cursors.SizeAll; 
                ilkkonumAl = e.Location; 
                aktifgemi = "mayın";// isimde hata cıkabilir


                for (i = 0; i < 10; i++)
                {
                    if (mayın.Location.X >= butonlarFormKonumuX[0, i] && mayın.Location.X < (butonlarFormKonumuX[0, i] + 45))
                    {
                        mayınyenikonum = butonlarFormKonumuX[0, i];
                        break;
                    }
                }

                for (j = 0; j < 10; j++)
                {
                    if (mayın.Location.Y >= butonlarFormKonumuY[j, 0] && mayın.Location.Y < (butonlarFormKonumuY[j, 0] + 45))
                    {
                        mayın.Location = new Point(mayınyenikonum + 3, butonlarFormKonumuY[j, 0] + 3);
                        GemiSayiKonumu = j;
                        break;
                    }
                }

                switch (i)
                {
                    case 0:
                        GemiHarfKonumu = "A";
                        break;
                    case 1:
                        GemiHarfKonumu = "B";
                        break;
                    case 2:
                        GemiHarfKonumu = "C";
                        break;
                    case 3:
                        GemiHarfKonumu = "D";
                        break;
                    case 4:
                        GemiHarfKonumu = "E";
                        break;
                    case 5:
                        GemiHarfKonumu = "F";
                        break;
                    case 6:
                        GemiHarfKonumu = "G";
                        break;
                    case 7:
                        GemiHarfKonumu = "H";
                        break;
                    case 8:
                        GemiHarfKonumu = "I";
                        break;
                    case 9:
                        GemiHarfKonumu = "J";
                        break;
                }
                if (konum.IndexOf(GemiHarfKonumu + (GemiSayiKonumu + 1)) != -1)
                {
                   konum.Remove(GemiHarfKonumu + (GemiSayiKonumu + 1));
                }
               
            }

        }

        private void mayın_MouseMove(object sender, MouseEventArgs e)
        {
            Button mayın = sender as Button;
            if (suruklenmedurumu) 
            {
                mayın.Left = e.X + mayın.Left - (ilkkonumAl.X);
                mayın.Top = e.Y + mayın.Top - (ilkkonumAl.Y);

                label47.Text = mayın.Top+","+mayın.Left;
                label48.Text = A1.Top + "," + A1.Left;
            }
        }

        private void mayın_MouseUp(object sender, MouseEventArgs e)
        {
            Button mayın = sender as Button;
            suruklenmedurumu = false; 
            mayın.Cursor = Cursors.Default;
            butoneslestirme(mayın);
        }

        public void ChangeButtonName(string name)
        {
            button1.Text = name + " Saldır";
        }

        int sayac = 0;
        int[,] butonlarX = new int[10, 10];
        int[,] butonlarY = new int[10, 10];
        int[,] butonlarFormKonumuX = new int[10, 10];
        int[,] butonlarFormKonumuY = new int[10, 10];

        private void butonKonumBelirleme()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    butonlarX[i, j] = panel1.Controls[sayac].Location.X;
                    butonlarY[i, j] = panel1.Controls[sayac].Location.Y;
                    butonlarFormKonumuX[i, j] = panel1.Controls[sayac].Location.X + panel1.Location.X;
                    butonlarFormKonumuY[i, j] = panel1.Controls[sayac].Location.Y + panel1.Location.Y;
                    sayac++;
                }
            }
        }

        public void butoneslestirme(Button Gemi)
        {

            for (i = 0; i < 10; i++)
            {
                if (Gemi.Location.X >= butonlarFormKonumuX[0, i] && Gemi.Location.X < (butonlarFormKonumuX[0, i] + 45))
                {
                    mayınyenikonum = butonlarFormKonumuX[0, i];
                    break;
                }
            }

            for (j = 0; j < 10; j++)
            {
                if (Gemi.Location.Y >= butonlarFormKonumuY[j, 0] && Gemi.Location.Y < (butonlarFormKonumuY[j, 0] + 45))
                {
                    Gemi.Location = new Point(mayınyenikonum + 3, butonlarFormKonumuY[j, 0] + 3);
                    GemiSayiKonumu = j;
                    break;
                }
            }

            switch (i)
            {
                case 0:
                    GemiHarfKonumu = "A";
                    break;
                case 1:
                    GemiHarfKonumu = "B";
                    break;
                case 2:
                    GemiHarfKonumu = "C";
                    break;
                case 3:
                    GemiHarfKonumu = "D";
                    break;
                case 4:
                    GemiHarfKonumu = "E";
                    break;
                case 5:
                    GemiHarfKonumu = "F";
                    break;
                case 6:
                    GemiHarfKonumu = "G";
                    break;
                case 7:
                    GemiHarfKonumu = "H";
                    break;
                case 8:
                    GemiHarfKonumu = "I";
                    break;
                case 9:
                    GemiHarfKonumu = "J";
                    break;
            }
            if (konumara(GemiHarfKonumu + (GemiSayiKonumu + 1)))
            {
                mayın2.Location = new Point(702,279);
                
                label47.Text = "Bu Alan Doludur !!";
            }
            else if (i == 10 || j == 10)
            {
                mayın.Location = new Point(650, 280);
               
                label47.Text = "";
            }
            else
            {
                label47.Text = aktifgemi + " " + GemiHarfKonumu + (GemiSayiKonumu + 1) + " Bölgesine Yerleştirildi.";
                string a = aktifgemi + " " + GemiHarfKonumu + (GemiSayiKonumu + 1);
                listBox1.Items.Add(a);
            }

        }

        private Boolean konumara (string aranacak)
        {
               int indexNo;

               indexNo = konum.IndexOf(aranacak);
               if (indexNo == -1)
               {
                   konum.Add(aranacak);

                   return false;
               }
               return true;
        }
       
        private void oyun_Load(object sender, EventArgs e)
        {
           butonKonumBelirleme();

        }
  
    }
}

