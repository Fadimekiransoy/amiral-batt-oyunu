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
        string aktifgemi;
        string GemiHarfKonumu = "";
        int GemiSayiKonumu = 0;
        int mayınyenikonum = 0;
        int gemiuzunluk = 0;
        ArrayList konum = new ArrayList();// matrise cevırsek

        private void mayın1_MouseDown(object sender, MouseEventArgs e)
        {
            mayın1.BringToFront();
            konumbelirle(mayın1);
            gemiuzunluk = 1;

            if (e.Button != MouseButtons.Left) return;
            suruklenmedurumu = true;
            mayın1.Cursor = Cursors.SizeAll;
            ilkkonumAl = e.Location;
            aktifgemi = "mayın1";
            sil();

            Console.WriteLine(konum.Count);
        }

        private void mayın1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!suruklenmedurumu) return;
            mayın1.Left = e.X + mayın1.Left - (ilkkonumAl.X);
            mayın1.Top = e.Y + mayın1.Top - (ilkkonumAl.Y);

            label47.Text = mayın1.Left + "," + mayın1.Top;
        }

        private void mayın1_MouseUp(object sender, MouseEventArgs e)
        {
            konumbelirle(mayın1);
            suruklenmedurumu = false;
            mayın1.Cursor = Cursors.Default;
            butoneslestirme();
            
        }


        private void mayın2_MouseDown(object sender, MouseEventArgs e)
        {
            mayın2.BringToFront();
            konumbelirle(mayın2);
            gemiuzunluk = 1;
            if (e.Button != MouseButtons.Left) return;
            suruklenmedurumu = true;
            mayın2.Cursor = Cursors.SizeAll;
            ilkkonumAl = e.Location;
            aktifgemi = "mayın2";
           sil();
           Console.WriteLine(konum.Count);
        }

        private void mayın2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!suruklenmedurumu) return;
            mayın2.Left = e.X + mayın2.Left - (ilkkonumAl.X);
            mayın2.Top = e.Y + mayın2.Top - (ilkkonumAl.Y);

            label47.Text = mayın2.Left + "," + mayın2.Top;
        }

        private void mayın2_MouseUp(object sender, MouseEventArgs e)
        {
            konumbelirle(mayın2);
            suruklenmedurumu = false;
            mayın2.Cursor = Cursors.Default;
            butoneslestirme();
        }


        private void mayın3_MouseDown(object sender, MouseEventArgs e)
        {
            mayın3.BringToFront();
            konumbelirle(mayın3);
            gemiuzunluk = 1;
            if (e.Button != MouseButtons.Left) return;
            suruklenmedurumu = true;
            mayın3.Cursor = Cursors.SizeAll;
            ilkkonumAl = e.Location;
            aktifgemi = "mayın3";
            sil();
        }

        private void mayın3_MouseMove(object sender, MouseEventArgs e)
        {
            if (!suruklenmedurumu) return;
            mayın3.Left = e.X + mayın3.Left - (ilkkonumAl.X);
            mayın3.Top = e.Y + mayın3.Top - (ilkkonumAl.Y);

            label47.Text = mayın3.Left + "," + mayın3.Top;

        }

        private void mayın3_MouseUp(object sender, MouseEventArgs e)
        {
            konumbelirle(mayın3);
            suruklenmedurumu = false;
            mayın3.Cursor = Cursors.Default;
            butoneslestirme();
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


        public void konumbelirle(Button Gemi)
        {
            GemiHarfKonumu = "";// belirsiz
           GemiSayiKonumu = 0;//rasgele verdik
            for (i = 0; i < 10; i++)
            {
                if (Gemi.Location.X >= butonlarFormKonumuX[0, i] && Gemi.Location.X < (butonlarFormKonumuX[0, i] + 50))
                {
                    mayınyenikonum = butonlarFormKonumuX[0, i];

                    for (j = 0; j < 10; j++)
                    {
                        if (Gemi.Location.Y >= butonlarFormKonumuY[j, 0] &&
                            Gemi.Location.Y < (butonlarFormKonumuY[j, 0] + 50))
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

                    break;
                }
            }

        }
        public void butoneslestirme()
        {
    
           if (i == 10 || j == 10)
           {
               switch (aktifgemi)
               {
                  case "mayın1":
                    mayın1.Location = new Point(698, 288);
                    break;
                  case "mayın2":
                    mayın2.Location = new Point(746, 288);
                    break;
                  case "mayın3":
                    mayın3.Location = new Point(799, 288);
                    break;
               }

               label47.Text = "";
               MessageBox.Show("Savaş kartına yerleştiriniz.","UYARI");

           }
           else if (konumara(GemiHarfKonumu + (GemiSayiKonumu + 1)))
           {    
               Console.WriteLine("konum var");
               switch (aktifgemi)
               {
                       case "mayın1":
                           mayın1.Location = new Point(698, 288);//bunlar mayının nır onceki konumu olcak
                           break;
                       case "mayın2":
                           mayın2.Location = new Point(746, 288);
                           break;
                       case "mayın3":
                           mayın3.Location = new Point(799, 288);
                           break;
               }
           
               label47.Text = "Bu Alan Doludur !!";
              // MessageBox.Show("Bu Alan Doludur !!");

           }
           else 
           {
               label47.Text =  GemiHarfKonumu + (GemiSayiKonumu + 1) + " Bölgesine Yerleştirildi.";
               string a = aktifgemi + " " + GemiHarfKonumu + (GemiSayiKonumu + 1);
               listBox1.Items.Add(a);
               konum.Add( GemiHarfKonumu + (GemiSayiKonumu + 1));
                Console.WriteLine(konum.Count);
           }
              
        }
        private Boolean konumara(string aranacak)
        {
            Console.WriteLine(aranacak);
            foreach (var e in konum)
            {
                Console.WriteLine(e);
            }
            int indexNo;
            indexNo = konum.IndexOf(aranacak);
            Console.WriteLine(indexNo);

            if (indexNo != -1) return true;
            return false;
        }
        private void  sil()
        {
            if (konum.IndexOf( GemiHarfKonumu + (GemiSayiKonumu + 1)) != -1)
            {
                konum.Remove( GemiHarfKonumu + (GemiSayiKonumu + 1));
            }

           
           
        }

        private void oyun_Load(object sender, EventArgs e)
        {
            butonKonumBelirleme();
        }

       
    }

} 