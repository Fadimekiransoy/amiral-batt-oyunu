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
        String GemiHarfKonumu = "";
        int GemiSayiKonumu = 0;
        int mayınyenikonum = 0;
        int gemiyenikonum = 0;
        int gemiuzunluk = 0;
        ArrayList konum = new ArrayList();
       // String[] harf = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        private void mayın_MouseDown(object sender, MouseEventArgs e)
        {

            gemiuzunluk = 1;
            if (e.Button == MouseButtons.Left)
            {
                suruklenmedurumu = true;
                mayın.Cursor = Cursors.SizeAll;
                ilkkonumAl = e.Location;
                aktifgemi = "mayın";// isimde hata cıkabilir


              

            }

        }

        private void mayın_MouseMove(object sender, MouseEventArgs e)
        {

            if (suruklenmedurumu)
            {
                mayın.Left = e.X + mayın.Left - (ilkkonumAl.X);
                mayın.Top = e.Y + mayın.Top - (ilkkonumAl.Y);

                label47.Text = mayın.Left + "," + mayın.Top;
                label48.Text = A1.Top + "," + A1.Left;//degişcek
            }
        }

        private void mayın_MouseUp(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = false;
            mayın.Cursor = Cursors.Default;
            butoneslestirme(mayın);
        }
        private void mayın2_MouseDown(object sender, MouseEventArgs e)
        {
            gemiuzunluk = 1;
            if (e.Button == MouseButtons.Left)
            {
                suruklenmedurumu = true;
                mayın2.Cursor = Cursors.SizeAll;
                ilkkonumAl = e.Location;
                aktifgemi = "mayın2";

               /* for (i = 0; i < 10; i++)
                {
                    if (mayın2.Location.X >= butonlarFormKonumuX[0, i] && mayın2.Location.X < (butonlarFormKonumuX[0, i] + 45))
                    {
                        mayınyenikonum = butonlarFormKonumuX[0, i];
                        break;
                    }
                }

                for (j = 0; j < 10; j++)
                {
                    if (mayın2.Location.Y >= butonlarFormKonumuY[j, 0] && mayın2.Location.Y < (butonlarFormKonumuY[j, 0] + 45))
                    {
                        mayın2.Location = new Point(mayınyenikonum + 3, butonlarFormKonumuY[j, 0] + 3);
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
                }*/

            }

        }

        private void mayın2_MouseMove(object sender, MouseEventArgs e)
        {
            if (suruklenmedurumu)
            {
                mayın2.Left = e.X + mayın2.Left - (ilkkonumAl.X);
                mayın2.Top = e.Y + mayın2.Top - (ilkkonumAl.Y);

                label47.Text = mayın2.Left + "," + mayın2.Top;
            }
        }

        private void mayın2_MouseUp(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = false;
            mayın2.Cursor = Cursors.Default;
            butoneslestirme(mayın2);
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


            int baslangic = i;
            int yerlestirilmis = 0;
            int bb = 0;
          
             
            if (konumara(GemiHarfKonumu + (GemiSayiKonumu + 1)))
            {
                    mayın2.Location = new Point(750, 287);
                    label47.Text = "Bu Alan Doludur !!";
                
            }
            else if (i == 10 || j == 10)
            {
               switch (aktifgemi)
               {
                  case "mayın":
                    mayın.Location = new Point(698, 288);
                    break;
                  case "mayın2":
                    mayın2.Location = new Point(746, 288);
                    break;
                  case "mayın3":
                    mayın3.Location = new Point(799, 288);
                    break;
               }

               label47.Text = "";
           
            }
            else
            {
                label47.Text = aktifgemi + " " + GemiHarfKonumu + (GemiSayiKonumu + 1) + " Bölgesine Yerleştirildi.";
                string a = aktifgemi + " " + GemiHarfKonumu + (GemiSayiKonumu + 1);
                listBox1.Items.Add(a);
                bb++;
                konum.Add(GemiHarfKonumu + (GemiSayiKonumu + 1));
                Console.WriteLine(GemiHarfKonumu + (GemiSayiKonumu + 1));
                yerlestirilmis++;
            }
              
            }
              //  catch (Exception e)
              //  {
                    /* for(int i=0; i < bb; i++)
                     {
                         listBox1.Items.RemoveAt(listBox1.Items.Count - 1);//HATA VAR
                         konum.RemoveAt(konum.Count - 1);
                     }
                   //  fırkateyn1.Location = new Point(547, 76);
                   //  fırkateyn2.Location = new Point(547, 123);
                     MessageBox.Show("Lütfen savaş kartının içine yerleştirin.");*/
              //  }

          //  }

            private Boolean konumara(string aranacak)
            {
                int indexNo;

                indexNo = konum.IndexOf(aranacak);
                if (indexNo == -1)
                {
                    return false;
                }
                return true;
            }

        private void oyun_Load_1(object sender, EventArgs e)
        {
            butonKonumBelirleme();
        }



        /*   private void fırkateyn1_MouseDown(object sender, MouseEventArgs e)
            {
                Button fırkateyn1 = sender as Button;

                if (e.Button == MouseButtons.Left)
                {
                    suruklenmedurumu = true;
                    fırkateyn1.Cursor = Cursors.SizeAll;
                    ilkkonumAl = e.Location;
                    aktifgemi = "fırkateyn";
                    gemiuzunluk = 4;
                    bool a= false;

                    for (i = 0; i < 10; i++)
                    {
                        if (fırkateyn1.Location.X >= butonlarFormKonumuX[0, i] && fırkateyn1.Location.X < (butonlarFormKonumuX[0, i] + 45))
                        {
                            gemiyenikonum = butonlarFormKonumuX[0, i];

                            break;
                        }
                    }

                    for (j = 0; j < 10; j++)
                    {
                        if (fırkateyn1.Location.Y >= butonlarFormKonumuY[j, 0] && fırkateyn1.Location.Y < (butonlarFormKonumuY[j, 0] + 45))
                        {
                            fırkateyn1.Location = new Point(gemiyenikonum + 3, butonlarFormKonumuY[j, 0] + 3);
                            GemiSayiKonumu = j;
                            break;
                        }
                    }

                    int baslangic = i;

                    for (int i = baslangic; i < baslangic + 4; i++)
                    {
                        if (i >= 10)
                        {
                            break;
                        }
                        if (konum.IndexOf(harf[i] + (GemiSayiKonumu + 1)) != -1)
                        {
                            konum.Remove(harf[i] + (GemiSayiKonumu + 1));
                        }
                    }

                }

            }


            private void fırkateyn1_MouseMove(object sender, MouseEventArgs e)
            {
               Button fırkateyn1 = sender as Button;
                if (suruklenmedurumu)
                {
                    fırkateyn1.Left = e.X + fırkateyn1.Left - (ilkkonumAl.X);
                    fırkateyn1.Top = e.Y + fırkateyn1.Top - (ilkkonumAl.Y);

                    label47.Text = fırkateyn1.Top + "," + fırkateyn1.Left;

                }
            }

            private void fırkateyn1_MouseUp(object sender, MouseEventArgs e)
            {
                Button fırkateyn1 = sender as Button;
                suruklenmedurumu = false;
                fırkateyn1.Cursor = Cursors.Default;
                butoneslestirme(fırkateyn1);
            }*/

       
    }

} 

 

