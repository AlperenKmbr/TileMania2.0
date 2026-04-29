#  TileMania: 2D Platformer Journey
### Unity 2D & C# İle Geliştirilmiş Klasik Platformer Deneyimi

![Unity Version](https://img.shields.io/badge/Unity-2022.3%2B-blue?logo=unity)
![Language](https://img.shields.io/badge/Language-C%23-green?logo=c-sharp)
![Genre](https://img.shields.io/badge/Genre-2D_Platformer-orange)

**TileMania**, Unity 2D öğrenim sürecim kapsamında geliştirdiğim; karakter kontrolleri, düşman yapay zekası, veri kalıcılığı ve karmaşık Tilemap hiyerarşisi gibi temel oyun geliştirme disiplinlerini içeren kapsamlı bir platform projesidir.

---

## 🚀 Öne Çıkan Teknik Özellikler

### 🏃‍♂️ Gelişmiş Karakter Kontrol Sistemi
`PlayerMovement.cs` üzerinden yönetilen bu sistem, oyuncuya akıcı bir kontrol deneyimi sunar:
* **Merdiven Tırmanma Algoritması:** Karakter merdivene temas ettiğinde yerçekimi devre dışı bırakılır ve dikey hareket (`climbSpeed`) aktifleşir.
* **Dinamik Animasyon Kontrolü:** Hareket hızına bağlı olarak `isRunning` ve `isClimbing` parametreleri anlık olarak güncellenir.

### 🏗️ Veri Kalıcılığı ve Mimarisi (Singleton Pattern)
Oyunun genel durumu ve seviye bazlı veriler iki ana yönetici ile kontrol edilir:
* **Global Session Management:** Oyuncu canı (Lives) ve toplam skor, sahneler arası geçişte `DontDestroyOnLoad` ile korunur.
* **Scene Persistence:** Seviye içindeki toplanabilir objelerin (altınlar vb.) durumu, oyuncu ölse bile sahne resetlenene kadar kalıcı olarak saklanır.

### 👾 Düşman Yapay Zekası ve Savaş
* **Düşman Yapısı:** Düşmanlar, platformun kenarına geldiklerini  algılayarak otomatik olarak yön değiştirirler.
* **Combat:** Oyuncu, baktığı yöne doğru fizik tabanlı mermiler ateşleyebilir; mermiler oyuncunun baktığı yöne  göre fırlatılır ve düşmana temas ettiğinde hem düşmanı hem de mermiyi yok eder.

---

## 🗺️ Tilemap Mimarisi ve Katman Yönetimi
Projenin seviye tasarımı ve fiziksel etkileşimleri, Unity'nin Tilemap sistemi ve gelişmiş katman (Layer) yönetimi üzerine kurulmuştur:

* **LayerMask Tabanlı Etkileşim:** Zıplama, tırmanma ve ölüm kontrolleri; `Ground`, `Ladder`, `Enemies` ve `Hazards` katmanlarının `LayerMask` ile filtrelenmesi sayesinde yüksek performanslı bir şekilde gerçekleştirilir.
* **Platform Kontrolü (Edge Detection):** Düşmanların devriye (patrol) mantığı, Tilemap üzerindeki platform sınırlarının tespiti ile sağlanır; düşmanlar bir Tilemap kenarına ulaştığında tetiklenen `OnTriggerExit2D` ile yönlerini otomatik değiştirirler.
* **İnteraktif Zeminler:** Merdiven (Ladder) katmanı algılandığında karakterin fiziksel özellikleri (yerçekimi ölçeği) anlık olarak değiştirilerek dikey hareket alanı oluşturulur.

---

## 🛠️ Sistem Mekanikleri (Logic)

* **💰 Toplanabilir Objeler:** Altınlar toplandığında `wasCollected` kontrolü ile performans kaybı önlenir, skora puan eklenir ve konumsal ses efekti çalınır.
* **🚪 Seviye Geçişi:** Çıkış kapısına ulaşıldığında tetiklenen bir **Coroutine** ile bir sonraki sahneye belirlenen gecikme süresiyle (`levelLoadDelay`) geçiş sağlanır.
* **☠️ Ölüm Mekanizması:** Oyuncu düşmanlara veya tehlikeli katmanlara (`Hazards`) dokunduğunda ölüm animasyonu tetiklenir ve `deathKick` efektiyle can kaybı süreci başlatılır.
* 
## 👨‍💻 Geliştirme Notları
Bu proje, Unity'nin teknik araçlarını öğrenmenin yanı sıra aşağıdaki alanlarda yetkinlik kazanmamı sağlamıştır:
* **Level Design Deneyimi:** Oyuncu akışı (flow), altın yerleşimi ve düşman devriye rotalarının dengelenmesi gibi temel seviye tasarımı prensipleri uygulanmıştır.
* **Teknik Yetkinlik:** Unity **Input System**, **Tilemap**, **Physics2D** ve **Cinemachine** gibi araçlar efektif kullanılmıştır.
* **Kod Standartları:** Kod yapısında modülerlik ve okunabilirlik (Clean Code) prensiplerine sadık kalınmıştır.




