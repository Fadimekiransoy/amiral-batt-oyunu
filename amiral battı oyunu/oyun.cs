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


namespace amiral_battı_oyunu
{
    public partial class oyun : Form
    {
        public oyun()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void A1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        bool suruklenmedurumu = false; //Class seviyesinde bir field(değişken) tanımlıyoruz ki,MouseDown da biz bunu true yapacağız,
                                       //MouseUpta false değerini alacak ve MouseMove eventında true ise hareket edecek.     
        Point ilkkonumAl; //Global bir değişken tanımlıyoruz ki, ilk tıkladığımız andaki konumunu çıkarmadığımızda buton mouse imlecinden
                          //daha aşağıdan hareket edecektir.
        private string aktifgemi;
        
        private void mayın_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                suruklenmedurumu = true; //işlemi burada true diyerek başlatıyoruz.
                mayın.Cursor = Cursors.SizeAll; //SizeAll yapmamımızın amacı taşırken hoş görüntü vermek için
                ilkkonumAl = e.Location; //İlk konuma gördüğünüz gibi değerimizi atıyoruz.
                aktifgemi = "mayın";// isimde hata cıkabilir
            }

        }

        private void mayın_MouseMove(object sender, MouseEventArgs e)
        {
            if (suruklenmedurumu) // suruklenmedurumu==true ile aynı.
            {
                mayın.Left = e.X + mayın.Left - (ilkkonumAl.X);
                // button.left ile soldan uzaklığını ayarlıyoruz. Yani e.X dediğimizde buton üzerinde mouseun hareket ettiği pixeli alacağız + butonun
                // soldan uzaklığını ekliyoruz son olarakta ilk mouseın tıklandığı alanı çıkarıyoruz yoksa butonun en solunda olur mouse imleci. Alttakide aynı şekilde Y koordinati için geçerli
                mayın.Top = e.Y + mayın.Top - (ilkkonumAl.Y);

                label47.Text = mayın.Top+","+mayın.Left;
                label48.Text = A1.Top + "," + A1.Left;
            }
        }

        private void mayın_MouseUp(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = false; //Sol tuştan elimizi çektik artık yani sürükle işlemi bitti.
            mayın.Cursor = Cursors.Default;//İmlecimiz(Cursor) default değerini alıyor.
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



         private void butoneslestirme(Button Gemi)
         {

             int i, j;
             String GemiHarfKonumu = "";
             int GemiSayiKonumu = 0;
             int mayınyenikonum = 0; 

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
                     mayın.Location = new Point(mayınyenikonum+3, butonlarFormKonumuY[j, 0]+3 );
                     GemiSayiKonumu = j ;
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

             if (i == 10 || j == 10)
             {
                mayın.Location = new Point(650,280) ;
                 label47.Text = "";
             }
             else
             {
                 label47.Text = aktifgemi + " " + GemiHarfKonumu + (GemiSayiKonumu +1) +" Bölgesine Yerleştirildi.";
             }

         }

        private void oyun_Load(object sender, EventArgs e)
        {
           butonKonumBelirleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mayın_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}

