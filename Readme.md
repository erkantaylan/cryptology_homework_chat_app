#Version 2.1.0

[X] 1-Bir kullanıcı giriş ekranı tasarlamalısınız. 

  [X] 1.a) 3 Hatalı Giriş (tekrar giriş yapmadan bekletilsin)

  [X] 1.b) 5 Hatalı Giriş (kilitlenerek başka giriş yapılması önlensin)

[X] 2- Captcha uygulaması:kendi yapacağınız ve derste gördüğümüz bir sözde rasgele sayı üretecini kullanarak min 4 basamaklı bir alfanumerik captcha üretip giriş yaptırmalısınız

[X] 3- Parola değiştirme yapısı

[X] 4- şifreleme Anahtarı saklama

[ ] 5- parola güvenli saklama (Tuzlama)

[X] 6- şifreleme anahtarı değişikliği

[ ] 7- A,B ve E kişileri için bir test senaryosu yazınız. (Hatalı girişler, anahtarı öğrenme, anahtar değişimi )

[ ] 8- Uygulamanızla birlikte yine bir tasarım ve senaryo dokümanı göndermeniz beklenmektedir.

# Version 2.0.0

## cryptology_homework_chat_app

- Erkan Taylan

- Ecem Eroğlu

## Frameworks

- [X] A toolkit for creating Metro / Modern UI styled WPF apps. https://github.com/MahApps/MahApps.Metro

~ TODO LIST

- [X] Tablolari olustur

- [X] Veritabani diagramini olustur

- [X] Login Ekranini Yap

- [X] Git commit

- [ ] Kullanicilarin sirasi mesajlasma sirasina gore gelsin

- [ ] Logout

- [ ] Mesajlar gondereninse SOLDA alicininsa SAGda olacak

- [X] Thread ile yeni public mesajlari goruntule

- [X] Thread ile yeni private mesajlari goruntule

- [ ] login ekraninda txt lerde ENTER basinca BUTON CLICk

- [X] message gonderme txt sinde ENTER basinca BUTON Click

- [X] txtleri silmeyi unutma

* Mesaj gonder butonuna basildiginda olacaklar

-   [X] once mesaji veri tabanina ekle

-   [X] eklenen mesajin id sini cek

-   [X] MessageKey sinifina gerekli bilgileri doldur

-   [X] Veri tabanina kaydet

* Mesaj alindiginda olacaklar

-   [X] Varolan secili keyi al

-   [X] Bu keye gore decode yapip ekrana yazdir

* Secili key degistiginde yapilcaklar

-   [X] Sifreli mesaj ekranindaki butun mesajlar degisen yeni keye gore tekrardan desifrelenecek

#### Özellikler

1.  Gönderilen her bir mesaj farklı keyler ile şifrelenebilir.

2.  Eğer herhangi bir key seçili değilse ekrandaki metinler çözümlenmez.

3.  Eğer herhangi bir key seçili değilse gönderilen metinler şifrelenmez.

4.  Bir key seçildiğinde sadece o keyle şifrelenmiş metinler çözümlenir. Diğer mesajlar olduğu gibi kalır. (Bulduğumuz 3DES algoritması çözümleyemediği zaman hata verdiği için bizde metni değişitirmedik.)

5.  2 kişi arasındaki mesajlar farklı keyler ile şifrelenmiş ise sadece seçili keyli olan mesajlar deşifrelenir. Deşifrelenemeyenler olduğu gibi bırakılır. Böylece keyleri dolaşarak bütün mesajlarıda açmak mümkündür.

6.  Ortada görülen ekran private chat ekranıdır, yani sol taraftan seçtiğimiz kişiye gider.

7.  Sağ taraftaki herkesin mesajlarını görüntüleyebildiğimiz ama çözümleyemediğimiz ekrandır. Kimin kime ne mesajı gönderdiğini gösterir.


##Uygulamanın Ekran Görüntüsüyle Anlatımı


####Kullanıcı Giriş Penceresi

![alt tag](https://github.com/ecemeroglu/cryptology_homework_chat_app/blob/master/Pictures/login.PNG)

  -Kullanıcı adı ve şifre ile sisteme giriş yapılıyor.
  
  -Kullanıcı adı ya da şifre hatalı ise hata mesajı verip, giriş engelleniyor.
  
  -Eğer aynı isimden başka kullanıcı varsa giriş yapılamaz.


####Kullanıcıların Sohbet Penceresi

![alt tag](https://github.com/ecemeroglu/cryptology_homework_chat_app/blob/master/Pictures/two_window_same_time.png)

  -Giriş yapan kullanıcı sistemden istediği kullanıcıya mesaj gönderebilir.
  
  -Gönderilen şifreli mesaj eşzamanlı olarak alıcıya düşer.
  

####Key List

![alt tag](https://github.com/ecemeroglu/cryptology_homework_chat_app/blob/master/Pictures/key_list.png)

  -Kullanıcı şifreleme algoritmasında kullanılmak üzere sistemdeki keylerden birini seçebilir.


####Şifreli Mesajların Görülmesi

![alt tag]( https://github.com/ecemeroglu/cryptology_homework_chat_app/blob/master/Pictures/chat_window_1.PNG)

  -Kullanıcı sistemdeki keylerden birini seçip, istediği kullanıcıya şifreli mesaj gönderir.
  
  -Alıcı şifreli mesajı simetrik anahtarla çözümler.
  
  -Anahtarı olmayan(aradaki adam E)  gizli metni açık metine dönüştüremez.Sohbeti şifreli halde görür.
