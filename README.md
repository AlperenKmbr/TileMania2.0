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
* **Düşman Yapısı:** Düşmanlar, platformun kenarına geldiklerini (`OnTriggerExit2D`) algılayarak otomatik olarak yön değiştirirler.
* **Combat:** Oyuncu, baktığı yöne doğru fizik tabanlı mermiler ateşleyebilir; mermiler oyuncunun baktığı yöne (`localScale.x`) göre fırlatılır ve düşmana temas ettiğinde hem düşmanı hem de mermiyi yok eder.

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

Bu proje, Unity'nin **Input System**, **Tilemap**, **Physics2D** ve **Cinemachine** gibi araçlarını efektif kullanmayı öğrenmek amacıyla tamamlanmıştır. Kod yapısında modülerlik ve okunabilirlik (Clean Code) prensiplerine sadık kalınmıştır.

## 🖼️ Oyun Galerisi 



<div style="display: flex; flex-wrap: wrap; justify-content: center; gap: 10px; margin-bottom: 20px;">
    <img src="https://github.com/user-attachments/assets/7bb9d02a-d24d-4328-9bfa-6c0133bd358e" width="220" alt="Karakter Etkileşimi" style="margin: 5px;" />
    <img src="https://github.com/user-attachments/assets/b2770676-2e71-4cb3-bb92-9a9ea706fbc6" width="220" alt="Unity Editor Geliştirme Ortamı" style="margin: 5px;" />
    <img src="https://github.com/user-attachments/assets/6b479aee-2240-42e0-a693-e2a234ecd0bb" width="220" alt="Çöl Atmosferi Uzak Çekim" style="margin: 5px;" />
</div>

<div style="display: flex; flex-wrap: wrap; justify-content: center; gap: 10px; margin-bottom: 20px;">
    <img src="https://github.com/user-attachments/assets/b3e9e8dd-c3db-4b0f-b26f-a8074186c0bc" width="220" alt="Yapılandırma ve Mekanik Ayarlar" style="margin: 5px;" />
    <img src="https://github.com/user-attachments/assets/1a5f93f5-a981-44c6-848f-4bc825ccfd26" width="220" alt="Low-Poly Karakter Modeli" style="margin: 5px;" />
    <img src="https://github.com/user-attachments/assets/9e28e7c3-bb99-4ee4-af94-0902a47330fb" width="220" alt="Proje Hiyerarşisi ve Düzen" style="margin: 5px;" />
</div>

<div style="display: flex; justify-content: center; margin-top: 20px;">
    <img src="https://github.com/user-attachments/assets/3c924c3a-80ea-4cc7-8bdd-e1bd4391fe29" width="460" alt="Geniş Açılı Ekosistem Görünümü" />
</div>

<p style="text-align: center; font-style: italic;">
*Low-poly görsel stil, dinamik gökyüzü ve optimize edilmiş proje yapısı.*
</p>




**Geliştirici:** [Alperen Kamber](https://github.com/AlperenKmbr)  
**Eğitim Kaynağı:** Udemy - Unity 2D Course
