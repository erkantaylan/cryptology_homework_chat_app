##Görüntü Şifreleme

  ```
  public static void Picture3DES() {
      
      var path = @"C:\Users\erkan\Pictures\Saved Pictures\eric.png";
      var bitmap = new Bitmap(path);
      var text = ImageToBase64(bitmap, ImageFormat.Png);
  
      var encrypt = ThreeDesEngine.Encrypt(text, key);
      var dec = ThreeDesEngine.Decrypt(encrypt, key);
      Console.WriteLine(encrypt);
      var image = Base64ToImage(dec);
      image.Save(@"C:\Users\erkan\Pictures\Saved Pictures\eric3.png");
  }
  ```
  
  Orjinal görüntü
  
  ![alt tag](/Pictures/eric.png)
  
  Şifrelenmiş görüntü
  
  ![alt tag](/Pictures/cyper_pic.PNG)
  
##Görüntüye Mesaj Gizleme

  ```
  public static void StegaConvert() {
      var path = @"C:\Users\erkan\Pictures\Saved Pictures\eric.png";
      var bitmap = new Bitmap(path);
      StegaCrypter crypter = new StegaCrypter();
  
      var ed = crypter.Encrypt(bitmap, "resim icinde metin");
      ed.Save(@"C:\Users\erkan\Pictures\Saved Pictures\eric2.png");
      var message= crypter.Decrypt(ed);
      Console.WriteLine(message);
  }
  ```
  
  StegaCrpter sınıfı resmin mavi piksellerini textin her bir harfinin ASCII karşılığı ile değiştirir.
  
  Bu resim için bu değerler şu şekildedir.
  
  ```
  Orjinal Deger      : 60
  Degistirilen Deger : 114
  
  Orjinal Deger      : 58
  Degistirilen Deger : 101
  
  Orjinal Deger      : 59
  Degistirilen Deger : 115
  
  Orjinal Deger      : 59
  Degistirilen Deger : 105
  
  Orjinal Deger      : 58
  Degistirilen Deger : 109
  
  Orjinal Deger      : 58
  Degistirilen Deger : 32
  
  Orjinal Deger      : 58
  Degistirilen Deger : 105
  
  Orjinal Deger      : 58
  Degistirilen Deger : 99
  
  Orjinal Deger      : 59
  Degistirilen Deger : 105
  
  Orjinal Deger      : 60
  Degistirilen Deger : 110
  
  Orjinal Deger      : 61
  Degistirilen Deger : 100
  
  Orjinal Deger      : 62
  Degistirilen Deger : 101
  
  Orjinal Deger      : 60
  Degistirilen Deger : 32
  
  Orjinal Deger      : 60
  Degistirilen Deger : 109
  
  Orjinal Deger      : 60
  Degistirilen Deger : 101
  
  Orjinal Deger      : 59
  Degistirilen Deger : 116
  
  Orjinal Deger      : 61
  Degistirilen Deger : 105
  
  Orjinal Deger      : 60
  Degistirilen Deger : 110
  ```
  
  NOT: Malesef en küçük bitiyle değil değerin kendisiyle değiştirme işlemi yapar!
  
## Görüntü için özet hesaplama ve karşılaştırma
  
  Orjinal görüntü olan eric.png ile önceden içine metin gömülü eric2.png'nin özetlerinin karşılaştırılması;
  
  ```
    public static void CompareImageHashs() {
      var path1 = @"C:\Users\erkan\Pictures\Saved Pictures\eric.png";
      var path2 = @"C:\Users\erkan\Pictures\Saved Pictures\eric2.png";
      var img1 = new Bitmap(path1);
      var img2 = new Bitmap(path2);
      var img1String = ImageToBase64(img1, ImageFormat.Png);
      var img2String = ImageToBase64(img2, ImageFormat.Png);

      HashingWithSalt hws = new HashingWithSalt();
      var hash1 = hws.GenerateSHa256Hash(img1String, "");
      var hash2 = hws.GenerateSHa256Hash(img2String, "");
      Console.WriteLine(hash1);
      Console.WriteLine(hash2);
  }
  ```
  
  SHA256 ile özetlenip bu özetler ekrana yazdırılır ve farklılıkların görülmesi sağlanır;
  
  `Console Çıktısı`
  ```
  e9f3744d0014caa6513f901511dde5e03fd8b790738734fc88c1754701661971
  eecc5a9dbee9dc13a7165d391f2cb41a690710da04f6e2c4cc7137322506e083
  ```
  
