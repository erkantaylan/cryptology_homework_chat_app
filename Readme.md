# cryptology_homework_chat_app

- Erkan Taylan

- Ecem Eroğlu

# Frameworks [1/1]

  [X] A toolkit for creating Metro / Modern UI styled WPF apps. https://github.com/MahApps/MahApps.Metro

~ TODO LIST
- [X] Tablolari olustur

- [X] Veritabani diagramini olustur

- [X] Login Ekranini Yap

- [X] Git commit

- [ ] Kullanicilarin sirasi 
mesajlasma sirasina gore gelsin

- [ ] Logout

- [ ] Mesajlar gondereninse SOLDA 
alicininsa SAGda olacak

- [X] Thread ile yeni public mesajlari goruntule

- [X] Thread ile yeni private mesajlari goruntule

- [ ] login ekraninda txt lerde ENTER basinca BUTON CLICk

- [X] message gonderme txt sinde ENTER basinca BUTON Click

- [X] txtleri silmeyi unutma

* Mesaj gonder butonuna basildiginda olacaklar [4/4]

-   [X] once mesaji veri tabanina ekle

-   [X] eklenen mesajin id sini cek

-   [X] MessageKey sinifina gerekli bilgileri doldur

-   [X] Veri tabanina kaydet

* Mesaj alindiginda olacaklar [2/2]

-   [X] Varolan secili keyi al

-   [X] Bu keye gore decode yapip ekrana yazdir

* Secili key degistiginde yapilcaklar [1/1]

-   [X] Sifreli mesaj ekranindaki butun mesajlar degisen yeni keye gore tekrardan desifrelenecek

#Uygulamanın Ekran Görüntüsüyle Anlatımı

alt_tag : https://github.com/ecemeroglu/cryptology_homework_chat_app/blob/master/Pictures/login.PNG
##Kullanıcı Giriş Penceresi
  -Kullanıcı adı ve şifre ile sisteme giriş yapılıyor.
  -Kullanıcı adı ya da şifre hatalı ise hata mesajı verip, giriş engelleniyor.
  -Eğer aynı isimden başka kullanıcı varsa giriş yapılamaz.

alt_tag : https://github.com/ecemeroglu/cryptology_homework_chat_app/blob/master/Pictures/two_window_same_time.png
##Kullanıcıların Sohbet Penceresi
  -Giriş yapan kullanıcı sistemden istediği kullanıcıya mesaj gönderebilir.
  -Gönderilen şifreli mesaj eşzamanlı olarak alıcıya düşer.
  
alt_tag : https://github.com/ecemeroglu/cryptology_homework_chat_app/blob/master/Pictures/key_list.png
##Key List
  -Kullanıcı şifreleme algoritmasında kullanılmak üzere sistemdeki keylerden birini seçebilir.

alt_tag : https://github.com/ecemeroglu/cryptology_homework_chat_app/blob/master/Pictures/chat_window_1.PNG
##Şifreli Mesajların Görülmesi
  -Kullanıcı sistemdeki keylerden birini seçip, istediği kullanıcıya şifreli mesaj gönderir.
  -Alıcı şifreli mesajı simetrik anahtarla çözümler.
  -Anahtarı olmayan(aradaki adam E)  gizli metni açık metine dönüştüremez.Sohbeti şifreli halde görür.
  

  


