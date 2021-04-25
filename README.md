No English support :(

# Zoom Otomatik Kaydedici (ZOK)
Bu program, Zoom ve EBA derslerini/toplantılarını otomatik açmakta ve isteğe bağlı olarak OBS Studio aracılığıyla kaydetmektedir. Zaman periyodları ayarlanarak kolayca kullanılabilir.

# Nasıl Kurulur?
1. Program ilk açıldığı zaman önce "P.A." butonuna basılır. 
2. Yukarıdaki kutucuğa gün içindeki toplantı sayısı yazılarak aşağıdaki listeden başlangıç saatleri ayarlanır. "KAYDET" butonuna basılarak değişiklikler kaydedilir.
3. "AYARLAR" butonuna basılır ve Zoom'un yolu gösterilir. (Zoom.exe)
4. Toplantı otomatik başlayacaksa "Toplantıyı Otomatik Başlat" kutucuğu işaretlenir.
5. Eğer kayıt yapılacaksa "Toplantıyı Kaydet" kutucuğu işaretlenerek OBS yolu da belirtilir. (obs64.exe veya obs32.exe)
6. "Kaydet" butonuna basılarak değişiklikler kaydedilir.
7. Zoom link bilgilerini eklemek için "Düzenle" butonuna basılır.
8. İlgili bilgiler girilerek her ekleme işleminde "Ekle" butonuna basılır.
9. Toplantıları programa eklemek için ilgili günün içinden sıra seçilir ve sol taraftaki toplantı ismi sürüklenip seçilen sıraya bırakılır.
10. Program üzerindeki menüde EBA modunu açmak için ilgili toplantının üzerine sağ tıklanıp "EBA Aç" veya "EBA Kapat" seçeneklerinden biri seçilebilir.
B. Ayarlar kısmındaki "Gelişmiş" butonuna basılarak zaman aşımları ve kontrol periyotları ayarlanabilir.

# Hata Mesajları Hakkında
- Program veri tabanına erişemedi...:
  - Bu hata genellikle Database.mdb dosyasının salt okunur olmasından kaynaklanır. Programı farklı bir konuma kurmayı deneyin. Örnek: C:\Users\\<kullanıcı>\AppData\Local
  - İsteğe bağlı olarak veri tabanı salt okunurluktan çıkarılır.
- Güncellemeler kontrol edilirken bir sorun oluştu...:
  - Bu hata genellikle internet bağlantısı olmadığından kaynaklanır.
  - Bazen GitHub kaynaklı olabilir.

# Yasal Uyarı
İzinsiz ses ve görüntü almak yasak olduğundan programı kullanan kişi tüm sorumluluğu üstlenmektedir. Eğer kayıt yapılacaksa program kullanılmadan önce ilgili kişilerden izinler alınmalıdır.
