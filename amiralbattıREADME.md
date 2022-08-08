# amiral-battı-oyunu
Amiral battı  2 kişilik düşünce ve strateji tabanlı bir kutu (masa) oyunudur. Her oyuncu kendi gemi filosunu diğer oyuncudan gizlediği, önceden yatay ve dikey 
koordinatların belli olduğu bir alanda oynanır. Oyuncular sırayla koordinat belirtip "atış" yaparak diğer oyuncunun gemilerinin yerlerini bulup batırmaya çalışırlar
Bu oyun hem kagıt hemde onlıne ortamda oynanabilir .Bizde bu oyunu online bır ortamda oynanması için kodluyoruz.
Oyuna baslarken kullanıcıların kayıt olması ve giriş yapmaları gerekiyor.Daha sonra oyun için gemilerin dizildiği gemi kartı ve atıs yaptıgımız atıs kartımiz var.
Oyuncular gemileri gemi kartına yerleştirirr ve oyunu başlatır ve bu iki oyuncu tcp/ıp üzerinden haberleşme olayını sağlayacak.

Girişekranı.cs formu



Bu formda kullanıcılar oyunu oynamak için önce kayıt ol ekranından kayıt olacak ve oyuna giriş yapabilecek.Daha sonra oyunu tekrar oynamak için geldiğinde oluşturmuş olduğu isim ve şifre bilgisi ile oyuna giriş yapıp kaldığı yerden devam edebilecek.

Oyun.cs formu



Oyuncu ilk defa oyunu oynamak için geldi ise kayıt olup daha sonra giriş yaparak oyunu oynayabilecek.Ama daha önce kayıt bilgisi varsa giriş ekranında veritabanında kayıdın olup olmadığını kontrol edip oyuna giriş sağlayabilecek.

Oyuncu bu ekranda önce gemilerini gemi kartına yerleştirecek ve oyunun başlatılması için diğer oyuncuya ben hazırım gibi bir haber gönderecek.Diğer oyuncuda gemilerini yerleştirildi ise oyun başlayacak.
