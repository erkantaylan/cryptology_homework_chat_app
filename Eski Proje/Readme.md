# cryptology_homework_chat_app

- erkan taylan
- ecem eroğlu

# Features [5/7]
- [ ]  A User login with password
- [X]  A User can send messages to another user
- [X]  A user can recieve mesasges
- [ ]  Json for user infos; username, password
- [X]  Unlimited users
- [X]  Users send messages to just 1 user, not broadcast
- [X]  Unique usernames

# Frameworks [2/4]
  - [X] TCP Server/Client Communication and RMI Framework https://github.com/hikalkan/scs
  - [X] A toolkit for creating Metro / Modern UI styled WPF apps. https://github.com/MahApps/MahApps.Metro
  - [ ] Json.NET is a popular high-performance JSON framework for .NET https://github.com/JamesNK/Newtonsoft.Json
    - Kullanıcı bilgileri saklanılması istenildiğinde bu framework kullanılacaktır.

# Uyglamanın ekran görüntüleriyle anlatımı
- Server Penceresi
  - Bu Pencerede Port numarasını belirleyip Server statusumusu Offdan On konumuna getiriyoruz.

![alt tag](https://github.com/erkantaylan/cryptology_homework_chat_app/blob/master/Pictures/server01.png)

- Kullanıcı giriş penceresi

  - Kullanıcı bilgilerimizi girip onaylıyoruz.
  - Eğer aynı isimden başka kullanıcı varsa giriş yapılamaz.
  - Seçilen port numarası ve/veya ip adresinde çalışan bir server uygulaması yoksa giriş yapamayız.

![alt tag](https://github.com/erkantaylan/cryptology_homework_chat_app/blob/master/Pictures/client01.png)

- Birden fazla kullanıcı giriş yaptığı zaman bu bizim ekranımıza düşer ve yeni giren kullanıcının ekranına da bizim bilgimiz gider.

![alt tag](https://github.com/erkantaylan/cryptology_homework_chat_app/blob/master/Pictures/client02.png)

- Aynı zamanda bu bilgi server üzerinden de geçer ve server tarafında ekrana yansıtılması

![alt tag](https://github.com/erkantaylan/cryptology_homework_chat_app/blob/master/Pictures/server02.png)

- Giriş yapan kullanıcılar diğer kullanıcıların üzerine çift tıkladığında bir private chat penceresi açılır
- Açılan bu pencerede bir kullanıcı başka bir kullanıcıya mesaj gönderebilirler.
- Gönderilen bu mesajlar 3. bir kullanıcı  tarafından görülmez.
- Mesaj gönderme sırasına msn messenger mesaj sesi gönderilir.

![alt tag](https://github.com/erkantaylan/cryptology_homework_chat_app/blob/master/Pictures/client03.png)

- Serverdan status switch'i OFF yapılırsa bütün kullanıcılar log-out olurlar.

![alt tag](https://github.com/erkantaylan/cryptology_homework_chat_app/blob/master/Pictures/server03.png)

#Projenin güçlü yanları
- Modüllerine ayrılarak yazıldığı için geliştirmesi kolay.
- TCP üzerinden RMI Framework kullanılarak yazıldığı için serverin IPsine ulaşıldığı sürece clientler istediği networkten bağlanabilirler.

#Projede olmayan özellikler
- Sadece windows platformunda .NET Framework 4.0 ile çalışıyor.
- Kullanıcıların şifresi yoktur.
   - Şifreleri tutma işini sunucu tarafı mı yoksa client  tarafımı yapacağını tam kararlaştıramadığım ve sona bıraktığım için yetişmedi.
- Mesaj geçmişini saklama yoktur. 
- Eğer bir kullanıcı o anda çevrimiçi değilse mesaj gönderilemez.


# NOT
- Uygulamanın tasarımı RMI Frameworkunu yazan kişinin [burada](http://www.codeproject.com/Articles/153938/A-Complete-TCP-Server-Client-Communication-and-RMI)ki tasarımına benzerdir yazdığı projeye bakılarak yazılmıştır ama copy paste değildir. Kodlama sırasında [livecoding.tv](https://www.livecoding.tv/livestreams/) üzerinden stream yapıldığı için buradan kodlama aşamasının büyük bir kısmı [izlenebilir](https://www.livecoding.tv/erkantaylan/videos/).
