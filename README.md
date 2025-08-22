# TaskTwoKayraExport

**TaskTwoKayraExport**, .NET 7 ile geliştirilmiş, katmanlı mimariyi (Onion / Clean Architecture) kullanan bir Web API uygulamasıdır. Projede PostgreSQL veritabanı, JWT tabanlı kimlik doğrulama ve Redis cache entegrasyonu bulunmaktadır. Clean Architecture prensipleri ile Domain, Application, Infrastructure ve API katmanları ayrılmıştır.

---

## Başlangıç

Projeyi kendi bilgisayarınıza almak için:  

git clone https://github.com/osmg63/TaskTwoKayraExport.git

Projeyi klonladıktan sonra gerekli NuGet paketlerini yükleyin ve veritabanı için migration çalıştırın:  

dotnet restore

dotnet ef database update


## Veritabanı Ayarları (PostgreSQL)

Projede PostgreSQL kullanılmaktadır. `appsettings.json` dosyasında aşağıdaki bağlantı ayarlarını kendi ortamınıza göre düzenlemelisiniz:

- **Host:** Veritabanı sunucunuz (örneğin: localhost)  
- **Port:** PostgreSQL portu (varsayılan: 5432)  
- **Database:** Kullanılacak veritabanı adı (`TaskTwo`)  
- **Username / Password:** PostgreSQL kullanıcı adı ve şifre  


## Redis Cache Ayarları

Projede performansı artırmak için Redis cache kullanılmaktadır. `appsettings.json` dosyasında Redis ile ilgili ayarları kendi ortamınıza göre düzenlemelisiniz:

- **ConnectionString:** Redis sunucusunun adresi (örneğin: localhost:6379)  


