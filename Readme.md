# Güvenli Yazılım Geliştirme
  Bu ödevde güvenli yazılım geliştirme temel dökümanları için Tübitak'ın [dökümanı](http://www.udhb.gov.tr/doc/siberg/GYGTK_Doc.pdf) kullanılmıştır. Bu dökümana göre projenin özellikleri dökümana göre sıralanmıştır.

## 1. VERİNİN KORUNMASI

#### Uygulama, ister veya tasarım dokümanlarında aksi belirtilmedikçe her  türlü verinin gizliliğini korumalıdır.

        Veri tabanında tutulan şifrelenmiş parolalar haricinde, uygulamamızın açık kaynaklı olduğunu düşünürsek hiç bir verinin gizliliği korunmamıştır. Kullanılan keyler, dosya yolları, uygulama içinde veya veri tabanında açık olarak tutulmaktadır.
        
#### Uygulama  servisleri  “noktadan  noktaya” ya  da  “uçtan  uca” gizliliği desteklemelidir.

        Uygulama uçtan uca veri aktarımında 3DES algoritması kullanılarak gizlilik sağlanmaktadır.
        
#### Uygulama kullanıcının kimlik bilgilerini taşıma esnasında korumalıdır. SSL veya benzeri teknolojileri tüm kimlik denetimi süreci snasında kullanmalıdır.

        Uygulamada kullanıcının kimlik bilgileri Microsoftun hazır komutları kullanılarak gönderilmektedir.
        
#### Uygulama  “noktadan  noktaya”  veya  “Uçtan  uca”  veri  bütünlüğünü desteklemelidir.

        Uygulamada gönderilen mesajın içeriğinde yapılan en ufak bir değişiklikte özet fonksiyonu tamamen değişmektedir, yani uygulama uçtan uca veri bütünlüğünü desteklemektedir.
        
#### Uygulama içindeki veriler ve  çıktılar güvenlik sınıflandırmasına tabii tutulmalıdır.

        Uygulamada içindeki veriler ve çıktılar için herhangi bir sınıflandırma yapılmamıştır. 
        
#### Uygulama başka kaynaklara (örneğin  uygulama  veri  tabanına  bağlanırken) erişim için kullandığı parolaları şifrelenmiş(encrypted) bir halde saklamalıdır. 

        Uygulamada kullanıcı parolaları veritabanında şifreli bir şekilde tutulmaktadır. Ancak veritabanına erişimde herhangi bir yetkilendirme yapılmamıştır, veritabanına sahip olan herkes verileri görebilir.
        
#### Uygulama, son kullanıcıların ya da istemci durumundaki uygulama servislerini kullanan diğer sistemlerin kimliklerini doğrulamak için kullandığı parolaları kriptografik özet halinde (hash) saklamalıdır.

        Kullanıcı parolaları C#'ın RNGCryptoServiceProvider fonksiyonu kullanılarak hash üretilip, SHA256 algoritmasıyla hashlenerek veritabanında saklanmaktadırlar.
        
#### Silinmiş verilere uygulama bileşenleri üzerinden tekrar ulaşım engellenmelidir. Bellekte ye da disk sisteminde oluşturulan nesnelerin gizli veri içermesi engellenmelidir.

        Uygulamamızda herhangi bir silme işlemi yapılmamaktadır.
        
#### Tasarım uyarınca, gerektiği durumlarda veriler şifrelenirken GİD’debelirtilen standartlara uygun ya  da  belirtilen otorite tarafından onaylanmış bir kripto ürünü veya mekanizması kullanılmalı ve bu şekilde depolanmalıdır. 

        Uygulamada Captcha için zayıf algoritma olan Kare Ortası algoritması kullanılmıştır. Onun dışında şifrelemeler için 3DES, hash için SHA256 kullanılmıştır.
        
#### Uygulama içindeki veri akışı kontrol politikası belirlenmeli ve uygulanmalıdır.

        Uygulama içinde herhangi bir veri akış kontrol politikası yapılmamıştır.
        
#### Uzaktan çalıştırılabilen veya sistemin değişik parçaları arasında transfer edilen taşınabilir kodlar(mobile codes) dikkatli bir şekilde ele alınmalı, envanteri tutulmalıdır. 

        Hazır arayüz için kullandığımız paket kodlar için herhangi bir izole ortam kullanılmamıştır.
        
#### GİD’de  uygulama   içindeki   tüm   verilerin  korunması  öngörülüyorsa,  veriler uygulama bileşenleri arasında şifreli olarak(gizliliği korunarak)iletilmelidir. 

        Uygulamamızda birden fazla bileşen bulunmadığı için, şifreli bir aktarım söz konusu değildir.
        
#### Uygulama,  herhangi  bir  fonksiyonu  çalışmaya  başlamadan  önce  güvenlik fonksiyonlarının çalışır ve ayakta olduğunu garanti etmelidir.

        Herhangi bir test veya güvenlik fonksiyonlarının çalışıp çalışmadığının kontrolü yapılmamaktadır.
        
        Örneğin, veri tabanına yazma izninin olduğu, veri tabanının çalışır durumda olduğu, dosyaya yazma izninin olduğuna dair kontroller yapılabilirdi ama yapılmadı.
        
#### Uygulama veri dağıtım servisleri(DDS)*kullanılıyorsa, bunlara kesinlikle gizliliği korunmuş bir kanal üzerinden (Örn. SSL kullanarak) erişmelidir.

        Uygulamamızda veri dağıtım servisleri kullanılmamaktadır.
        
#### Uygulama  varlıkları  arasında  karşılıklı  bütünlüğü(referential integrity) sağlamakla yükümlü olmalıdır.

        Veri bütünlüğü, veri tabanında tablolar arası foreign keyler kullanılarak sağlanmıştır.
        
#### Uygulama geri dönüşü olmayacak şekilde silinmiş verilerin artık uygulama içinde erişilememesini ve yeni üretilen verilerin, geri dönüşü olmayacak şekilde silinmiş bilgi içermemesini garanti etmelidir.

        Uygulamamızda herhangi bir silme işlemi olmamaktadır.
        
#### Son kullanıcı, uygulamayı birden  fazla ekranda kullanıyorsa bu ekranlarya  da raporlama arayüzleri üzerinden sunulan bilginin tutarlılığını sağlamalıdır.

        Uygulamamızda birden fazla ekran kullanılmamaktadır.
        
## 2.  KİMLİK DOĞRULAMA

#### Uygulama,  kimlik doğrulama yapmadan, anonim erişime  kapalı olan servislerine/ara-yüzlerine/sayfalarına erişimi engellemelidir ya da bu tür erişimlerin denetlenebileceği ve yönetilebileceği mekanizmalar sunmalıdır.

        Login olduktan sonraki formlar arasında geçişlerde kullanıcı bilgileri de denetlenmektedir.
        
#### Uygulamanın, müşteri tarafından tanımlanmış olan kritik servisleri ve ayarları için 2 veya 3 faktörlü kimlik doğrulama kullanılmalıdır. 

        Uygulamada kullanıcı şifre oluştururken veya değiştirken, şifrenin güvenliği için herhangi bir denetleme bulunmamaktadır. Kullanıcı kendi belirlediği herhangi bir şifre ile uygulamayı kullanabilmektedir.
        
#### Uygulama, önceden belirlenmiş sayıda yanlış kimlik doğrulama denemesinden sonra kullanıcıdan CAPTCHA talep  etmelidir.  DOSya da kaba kuvvet saldırısı (bruteforce) ihtimalinin olmadığı ortamlarda, önceden belirlenmişhatalı kimlik doğrulama denemesinin ardından hesap kitlenmelidir. Uygulama hesabı tekrar aktive etmek için bir mekanizmasunulmalıdır.

        Uygulamamızda kare ortası algoritmasıyla Captcha kullanılmaktadır. 3 hatalı girişten sonra kullanıcıyı bekletmeye başlamakta ve 5 hatalı şifre girişin ardından kullanıcnın yeni bir şifre girmesi engellenmektedir.
        
#### Kimlik  doğrulama  esnasında ve  hata  durumlarında uygulama,kullanıcıya mümkün olduğunca az bilgi ile geri-bildirim yapmalıdır. 

        Kullanıcının şifresi veya kullanıcı adı yanlış olduğunda tek bir ortak hata mesajı verilmektedir.
        
#### Uygulama, kimlik doğrulamaları yapılmış kullanıcılara kendi parolalarını ve güvenlik kontrolleri için kullanılan profil bilgilerini(Örn. e-mail adresi) değiştirme imkanı vermelidir.

        Uygulamada kullanıcı adı ve şifreden başka herhangi bir kişisel bilgi istenmemektedir.
        
#### Uygulama, kullanıcıya parola  kurtarma (password recovery) mekanizmaları sunmalıdır. Parola kurtarma  fonksiyonu  güvenlik  zafiyeti  içermeyecek şekilde gerçeklenmelidir.

        Kullanıcıdan username/password dışında bir bilgi istenmediği için, unutulan bir şifreyi kurtarma (password recovery) yapılmamaktadır. Kullanıcı dilerse eski şifresi ile yeni bir şifre oluşturabilir.
        
#### Uygulama kullanıcısının parolasını unuttuğu veya başka bir nedenle mevcut parola  ile  uygulamada oturum  açamadığı durumlar için kullanıcıya parolayı sıfırlayabileceği bir ekran veya fonksiyon sunmalıdır.

        Kullanıcıdan username/password dışında bir bilgi istenmediği için, unutulan bir şifreyi kurtarma (password recovery) yapılmamaktadır. Kullanıcı dilerse eski şifresi ile yeni bir şifre oluşturabilir.
        
#### Kullanıcıya uygulamaya erişebilmek için otomatik olarak verilen ilk parola, saldırılara dirençli, benzersiz ve sınırlı geçerlilik süresine sahip olmalıdırlar. 

        Otomatik bir ilk parola sistemi uygulamada bulunmamaktadır.
        
#### Uygulama kullanıcıları, parola belirlerken veya mevcut parolalarını değiştirirken GİD’de belirtilmiş parola politikalarına uymaya zorlamalıdır.

        Herhangi bir GİD politikası parola değiştirken veya belirlenirken uygulanmamaktadır.
        
#### En  iyi  uygulama  tavsiyesi  olarak (best  practice) önerilen “autocomplete=off” bayrağı  kullanılara kinternet  tarayıcılarınınkimlik  bilgilerini  tutmasının engellenmesidir.

        Uygulamamız form uygulaması olduğu için böyle bir özellik zaten bulunmamaktadır.
        
#### Kimlik doğrulama, parola sıfırlama vs. işlemleri sonrası uygulamanın başka bir sayfasına internet tarayıcının yönlendirilmesini(redirect) sağlamak amacıyla HTML “HTTP-EQUIV=REFRESH“ kullanmaktan kaçınılmalıdır.

        Uygulamamız form uygulaması olduğu için böyle bir özellik zaten bulunmamaktadır.
        
#### Uygulama tarafından bırakılan çerez(cookie) için “httponly” aktive edilmelidir. Buna ek olarak, HTTPS protokolü kullanılan bağlantılarda çerezler için “secure” parametresi aktif olmalıdır.

        Uygulamamız form uygulaması olduğu için böyle bir özellik zaten bulunmamaktadır.
        
#### Uygulamanın,  kimlik  doğrulamada  Tek  Giriş*(Single  Sign-On)(SSO) teknolojilerini  kullanması  ön  görülüyorsa,  uygulamaya  özel  Tek  Giriş mekanizması yazmaktan ziyade, piyasada hali hazırda bir kısmı açık kaynaklı olarak sunuluna Tek Giriş teknolojilerini  kullanmak  güvenlik açısından daha uygun olacaktır.

        Uygulamamızda SSO kullanılmamaktadır.
        
## 3. OTURUM YÖNETİMİ

#### Uygulama, oturum tekil tanımlayıcısını(Session ID) korumalıdır.

        Uygulamada herhangi bir Session ID kullanılmamaktadır.
        
#### Oturum tekil tanımlayıcısı (Session  ID) URL’de  gönderilmemeli veya  referrer başlığı içine dâhil edilmemelidir.

        Uygulamamız form uyuglaması olduğu için URL üzerinden göndermek zaten mümkün olmamaktadır.
        
#### Oturum yönetimi için kullanılan ve uygulamayı kullanan bütün kullanıcılar için tekil olması gereken değerler (session id, token v.b.) güçlü bir rastgele veri üretecinden temin edilmeli ve tahmin edilemez derecede karmaşık olmalıdır.

        Uygulamamızda Session ID, token vb özellikler bulunmamaktadır.
        
#### Belirlenen süre boyunca aktif olmayan oturumlar otomatik olarak kapatılmalıdır. Uygulama, sistem yöneticilerine bu süreyi ayarlayabilecekleri bir ekran sunmalıdır. 

        Uygulamamızda aktif olmayınca oturumu kapakmak ile ilgili bir özellik bulunmamaktadır.
        
## 4. YETKİLENDİRME

#### Uygulama,  kullanıcının  sadece  bilmesi  gereken  bilgilere  erişim sağlayabilecekleri şekilde kısıtlamalar getiren mekanizmalar barındırmalıdır.

        Uygulamamızda kullanıcı, yetkisi dışında herhangi bir veriye ulaşması mümkün değildir.
        
#### Yetkilendirme  sunucu  tarafında yapılmalıdır. Sadece  istemci  tarafında yetkilendirme kontrolü yapılmamalıdır.

        Uygulamamızda birden fazla yetkilendirme yoktur. Sadece kullanıcılar vardır.
        
#### Yetkilendirme yaparken “Rol bazlı” yetkilendir metavsiye edilmektedir.

        Uygulamamızda birden fazla yetkilendirme yoktur.
        
#### Uygulamada, kullanıcıların yetkilerinin sistem  yöneticisi ya da yetkilendirilmiş kişiler tarafından ayarlanabildiği kimlik yönetimi ekranı olmalıdır.

        Uygulamada herhangi bir üst düzey yetkili veya kullanıcı sistemi bulunmamaktadır.
        
#### Uygulamada kimlik yönetim ekranlarında belirlenen kullanıcılar ve yetkiler dışında yetkilendirme olmamalıdır.

        Uygulamamızda birden fazla yetkilendirme yoktur.
        
#### Uygulama dokümante  edilmemiş  ve  sistemin  çalışmasını  etkileyebilecek parametreleri ya da kullanıcı hesaplarını içermemelidir.

        Uygulamamızda diğer kullanıcıları veya sistemin çalışmasını engelleyebilecek parametreler veya kullanıcı hesapları bulunmamaktadır.
        
#### Güvenlik  fonksiyonları ile  alakalı görüntüleme ve yapılandırma ara yüzlerine/sayfalarına/servislerine  sadece güvenlikten sorumlu ve yetkilendirilmiş hesaplar erişebilmelidir.

        Uygulamamızda yetkisi veya keyi olmayan kimse başka bir kimsenin bilgisini görüntüleyememektedir.
        
#### Her bir İş nesnesi (business object) için read/write/modify/delete gibi yetkiler tanımlanmalıdır.

        Uygulamamızda gönderilen mesajlar silinememektedir. Gönderilmiş bir mesaj ve keyi değiştirilemez ama sonraki mesajların keyleri göndermeden önce değiştirilebilir.
        
#### Kimlik  yönetim  servisleri (kimlik  doğrulama  (authentication), yetkilendirme (authorisation) ve kimlik veri depoları (user data store) merkezileştirilmelidir.

        Bütün bilgiler tek bir veri tabanı üzerinde tutulmaktadır ve ayrı bir servis bulunmamaktadır. Tek bir uyuglama içinde büyün işlemler yapılmaktaıdr.
        
#### Yetkilendirme dinamik olmalı ve yetki kaldırıldığında nesneye ya da servislere erişim mümkün olmamalıdır.

        Uygulamamızda herhangi bir yetkilendirme bulunmamaktadır.
        
#### Kullanıcı organizasyondan ayrıldığında erişim izinleri ve yetkileri kaldırılmalıdır. 

        Uygulamamızda bir organizasyon bulunmamaktadır.
        
#### Veriye ya da nesnelere erişim imkânı sunan bütün yollar erişim denetimine tabii tutulmalıdır.

        Veritabanına erişimde herhangi bir denetim yoktur.
        
#### Bir kullanıcının birden fazla rolü var ise oturumu kapatmadan roller arası geçiş yapabilmesi sağlanmalıdır.

        Bir kullanıcının birden fazla rolü olması söz konusu değildir.
        
#### Uygulama kullanıcıya sadece yetkisi ve  izni  olan fonksiyonları,  servisleri  ve nesneleri(sayfa, iş nesnesi, ekran vs.) göstermelidir.

        Uygulama kullanıcıya sadece yetkisi ve izni olan fonksiyonları, servisleri ve nesneleri göstermektedir.
        
#### İşletim  sistemi  üzerinde  bulunan  bir  araçla uygulama  hesaplarına  ait parolalarının doğrudan değiştirilmesini engelleyecek mekanizmalar sunulmalıdır.

        Uygulamamızda böyle bir mekanızma sunulmamaktadır. Veritabanına erişimi olan herkes kullanıcının bilgilerini veya mesaj bilgilerini istediği gibi değiştirebilir.
        
#### Canlı uygulama ortamı, test ve geliştirme veri tabanlarına (örneğin operasyonel, eğitim, alıştırma veri tabanları) bağlanmamalıdır. Aynı şekilde gerçek  veri tabanı asla geliştirme ve test ortamlarında kullanılmamalıdır.

        Test ortamımız bulunmamaktadır, bütün denemeler orjinal tek bir veritabanı üzerinde gerçekleşmektedir.
        
#### Yığın görevleri (batch jobs) için yetkilendirme ve izleme yapılmalıdır.

        Uygulamada yığın görevi bulunmamaktadır.
        
## 5. ERİŞİLEBİLİRLİK

#### Kullanıcı sayısının fazla olduğu ve yoğun olarak kullanılan sistemlerde kimlik yönetim servislerinin yük dengeli (load-balancer) olarak çalıştırılması öngörülmelidir.

        Kullanıcı sayımız fazla olmadığı için herhangi bir load balancera gerek duyulmamıştır.
        
#### Uygulamanın belirlenecek bant genişliği (bandwidth)alt sınırında da çalışabilir olması gerekmektedir.

        Uygulamamız ağ üzerinden çalışmadığı için bandwidth önemli değildir.
        
#### Uygulamanın belirlenecek  bir  paket  gecikme  süresinde (latency) ya  da  ondan daha aşağıda çalışması gerekmektedir.

        Uygulamamız ağ üzerinden çalışmadığı için latency yoktur.
        
#### Uygulama, yetkilendirilmiş kullanıcılara tekil bir kullanıcının açabileceği oturum sayısını yönetebilme imkânı sunmalıdır.

        Yetkilendirilmiş kullanıcı yoktur.
        
#### Uygulama, en iyi bağlantı zamanı ve performans prensiplerini uygulamalıdır.

        Uygulamada bağlantı zamanı ve performans prensipleri en üst düzeydedir.
        
#### Uygulama,  iş  tanımlama  dokümanında  ya  da  güvenlik  gereksinimlerinde belirtilmesi  durumunda,  uygulama  ara yüzlerinden işlenen ya da saklanan bütün verilerin yedeklerinin alınabilmesine imkân sağlamalıdır. 

        Veritabanının yedeği MSSQL Management Studio üzerinden alınabilir, uygulamamızın üzerinden bir yedek alma 2.1.0 sürümünde mümkün değildir.
        
#### GİD’de  tüm  verilerin yedeklenmesi ön görülüyorsa, uygulama yedekleme işleminin  düzenli  olarak  yapılabilmesi  ve  takvimlenebilmesini  sağlayan mekanizmalar ile yedekleme işlemlerinin sonlanma durumunu ve hatalarını raporlayabileceği bir arayüz sunmalıdır.

        Uygulamada verilerin yedeklenmesi ön görülmemektedir.
        
#### Uygulama, iş tanımlama dokümanında ya da GİD’de belirtilmesi  durumunda, uygulama  arayüzlerinden alınan yedekler üzerinden veri kurtarma işlemini gerçekleştirebilmelidir. 

        Uygulamada verilerin yedeklenmesi ön görülmemektedir.
        
#### GİD’de  yedekleme  isteri  bulunuyorsa,  hem   yedekleme  hem   de   yedekten kurtarma işlemleri ve süreçleri dokümante edilmelidir. 

        Uygulamada verilerin yedeklenmesi ön görülmemektedir.
        
## 6. İZLEME VE DENETİM 

#### Uygulamamızda herhangi bir izleme veya denetleme bulunmamaktadır.


# [Steganografi Homework](/Steganografi.md)

#Version 2.1.0

- [X] 1-Bir kullanıcı giriş ekranı tasarlamalısınız. 

  - [X] 1.a) 3 Hatalı Giriş (tekrar giriş yapmadan bekletilsin)

  3 hatalı giriş yaptıktan sonra uygulama, kullanıcıyı 10 saniye boyunca bekletir ve giriş yapmasını bu süre boyunca engeller.

  ![alt tag](/Pictures/3_wrong_login.png)

  - [X] 1.b) 5 Hatalı Giriş (kilitlenerek başka giriş yapılması önlensin)

  5 defa hata yapıldığında, uygulama kilitlenerek kullanıcının yeni giriş yapmasını engeller. (Pencere kilitlenmez ama kullanıcıyı sürekli bekletir.)

  ![alt tag](/Pictures/wrong_login.png)

- [X] 2- Captcha uygulaması:kendi yapacağınız ve derste gördüğümüz bir sözde rasgele sayı üretecini kullanarak min 4 basamaklı bir alfanumerik captcha üretip giriş yaptırmalısınız

  Captcha üretmek için `Kare Ortası` algoritması kullanıldı. Başlangıç değeri olarakta o anki saatin saniyesi ve milisaniyesi alınarak program her çalıştığında farklı bir başlangıç değeri ile başlanması sağlandı.

  ![alt tag](/Pictures/captcha.png)


- [X] 3- Parola değiştirme yapısı

  Kullanıcı `Change Password` butonuna bastığında;

    0. Yeni girilen şifreler birbirine eşit mi ve kullanıcı adı ile şifre alanları boş mu diye kontrol edilir.

      Eğer bir eksik bilgi varsa kullanıcıya hata mesajı gösterilir.

    1. Kullanıcı adına göre veri tabanından bütün bilgileri çekilir.

      Kullanıcı adı kayıtlı değilse hata verilir.

    2. Yazdığı eski şifre veri tabanındaki `salt` ile hash algoritmasına gönderilir.

    3. Hash algoritmasından dönen değere göre karşılaştırma yapılır.

      Eğer yanlış ise kullanıcıya hata mesajı gösterilir.

    4. Doğru ise yeni bir `salt` oluşturulur.

    5. Yeni parola yeni salt ile tuzlanıp hash algoritmasına gönderilir.

    6. Yeni oluşan `hash` ve `salt` veri tabanına kaydedilir.

  ![alt tag](/Pictures/change_password.png)


- [X] 4- şifreleme Anahtarı saklama

  Veri tabanında gönderilen her bir mesaja özgü anahtar saklanır.

  ![alt tag](/Pictures/tblMessageKey.png)

- [X] 5- parola güvenli saklama (Tuzlama)

  Tuzlama işleminde önce CreateSalt fonksiyonu çağrılarak tuz oluşturulur. İçine herhangi bir değer girilmezse 20 bytelık buffer ile tuz oluşturur. 

    Tuzlama işleminde Microsoftun hazır kütüphanesi olan RNGCryptoServiceProvider kullanılmıştır.

  Oluşturulan bu tuz ile birlikte şifre GenerateSHa256Hash fonksiyonuna girilerek hash üretimi sağlanır.

    Hash oluşturma işleminde Microsoftun hazır kütüphanesi olan SHA256Managed kullanılmıştır.

  ![alt tag](/Pictures/tblUser.png)

- [X] 6- şifreleme anahtarı değişikliği

  Veri tabanındaki bütün mesajlar ayrı keyler ile şifrelenebilmekte olduğu için şifreleme anahtarı değişikliğine ihtiyaç yoktur. 

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

- [X] login ekraninda txt lerde ENTER basinca BUTON CLICk

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

![alt tag](/Pictures/login.PNG)

  -Kullanıcı adı ve şifre ile sisteme giriş yapılıyor.
  
  -Kullanıcı adı ya da şifre hatalı ise hata mesajı verip, giriş engelleniyor.
  
  -Eğer aynı isimden başka kullanıcı varsa giriş yapılamaz.


####Kullanıcıların Sohbet Penceresi

![alt tag](/Pictures/two_window_same_time.png)

  -Giriş yapan kullanıcı sistemden istediği kullanıcıya mesaj gönderebilir.
  
  -Gönderilen şifreli mesaj eşzamanlı olarak alıcıya düşer.
  

####Key List

![alt tag](/Pictures/key_list.png)

  -Kullanıcı şifreleme algoritmasında kullanılmak üzere sistemdeki keylerden birini seçebilir.


####Şifreli Mesajların Görülmesi

![alt tag](/Pictures/chat_window_1.PNG)

  -Kullanıcı sistemdeki keylerden birini seçip, istediği kullanıcıya şifreli mesaj gönderir.
  
  -Alıcı şifreli mesajı simetrik anahtarla çözümler.
  
  -Anahtarı olmayan(aradaki adam E)  gizli metni açık metine dönüştüremez.Sohbeti şifreli halde görür.
