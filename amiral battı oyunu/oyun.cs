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
        
           
            bool suruklenmedurumu = false; //Class seviyesinde bir field(değişken) tanımlıyoruz ki,MouseDown da biz bunu true yapacağız,MouseUpta false değerini alacak ve MouseMove eventında true ise hareket edecek.     
            Point ilkkonumAl; //Global bir değişken tanımlıyoruz ki, ilk tıkladığımız andaki konumunu çıkarmadığımızda buton mouse imlecinden daha aşağıdan hareket edecektir.
            private string aktifgemi;
        private void mayın_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
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
                // button.left ile soldan uzaklığını ayarlıyoruz. Yani e.X dediğimizde buton üzerinde mouseun hareket ettiği pixeli alacağız + butonun soldan uzaklığını ekliyoruz son olarakta ilk mouseın tıklandığı alanı çıkarıyoruz yoksa butonun en solunda olur mouse imleci. Alttakide aynı şekilde Y koordinati için geçerli
                mayın.Top = e.Y + mayın.Top - (ilkkonumAl.Y);
            }
        }

        private void mayın_MouseUp(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = false; //Sol tuştan elimizi çektik artık yani sürükle işlemi bitti.
            mayın.Cursor = Cursors.Default;//İmlecimiz(Cursor) default değerini alıyor.
            // buttoneslestirme(mayın);
        }
 
    }

}

