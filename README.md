# Site Management Billing System
- Bu projenin amacı bir sitede yönetici olarak sisteme sitede bulunan daireleri, dairelerde yaşayan kullanıcıları ve daire başına fatura ve aidat bilgilerini ekleyebilmektir. Ayrıca yönetici eklediği daire bilgilerini, kullanıcı bilgilerini ve fatura/aidat bilgilerini görüntüleyebilir. Kullanıcılarda sisteme giriş yaparak dairelerine atanan fatura/aidat bilgilerini görüntüleyebilir ve kredi kart bilgilerini girerek bu fatura/aidatları ödeyebilir.

## Başlarken
- Projeyi çalıştırabilmek için gerekli programlar: Visual Studio & pgAdmin 4
- Projemi klonladıktan sonra, dizin içerisinde ".sln" uzantılı dosyayı bulup, Visual Studio yardımı ile açın.
- Sonrasında pgAdmin4'ü açarak "SiteManagementBillingSystemDB" adında bir database oluşturun.
- Ardından projeye gelerek "Tools > NuGet Package Manager > Package Manager Console" açın
- Konsolda "Default Project" kısmından "BillingSystem.Infrastructure.EFCore" seçtiğinizden emin olun.
- Migrationlarım zaten hazır olduğu için “`update-database“` komutunu çalıştırın.
- Eğer hata alırsanız "BillingSystem.Infrastructure.EFCore" altındaki "Migrations" dosyasını silerek "Package Manager Console" konsoluna “`add-migration initMigration“` komutunu yapıştırın ve tekrar “`update-database“` komutunu çalıştırın.
- Artık tek yapmanız gereken projeyi çalıştırmak.
- "Presentation" dosyasının altında bulunan "BillingSystem.WebAPI" projesine sağ tıklayarak "Set as Startup Project" seçeneğini seçip, projeyi çalıştırın.

## Proje Hakkında
## Katmanlar
### Core / Domain
- Bu katmanda entitylerimi tanımladım.
- Proje içerisinde beş adet entity tanımladım, bunlarden dördü BaseEntity class'ından inherit alırken; biri özel classtır.

### Core / Schema
- Bu katmanda Response ve Request modellerimi tanımladım.

### Core / Application
- Bu katmanda projenin servislerini, validasyon işlemlerini, token işlemlerini ve mapping işlemlerini yaptım.

### Infrastructure / EFCore
- Bu katmanda projenin database bağlantılarını, tablo confiragutionlarını, repositoryleri ve unit of work classının tanımlamasını yaptım.

### Presentation / WebAPI
- Bu katmanda controllerlarımı yazdım. Program.cs dosyasına proje ile ilgili gerekli ayarlamaları yaptım.
- Middlewareleri yazdım.

### Presentation / PaymentAPI
- Bu projeyi ödeme simülasyonu yapmak için kullandım.

## Servisler
### UserService
- User Service standart CRUD işlemlerini yapılmasını sağlar ancak bu işlemleri yalnız Admin rolüne sahip kullanıcılar yapabilir.
- Kullanıcı oluşturulduğunda otomatik Password oluşturulur ve atanır.

### ApartmentService
- Apartment Service standart CRUD işlemlerini yapılmasını sağlar ancak bu işlemleri yalnız Admin rolüne sahip kullanıcılar yapabilir.

### TokenService
- Token Service içerisinde Login işlemleri ve Token generate işlemleri yapılır.

### InvoiceService
- Invoice servis içerisinde yönetici dairelere fatura bilgisi girer.
- Yönetici isterse tek tek daire idsi ile, tüm dairelere aynı anda veya toplam fatura tutarını girerek dairelere bölünmesini sağlayabilir.
- Ayrıca yönetici tüm faturaları veya ay bazlı olarak görüntüleyebilir.

### DuesService
- Dues servis içerisinde yönetici dairelere aidat bilgisi girer.
- Yönetici isterse tek tek daire idsi ile veya tüm dairelere aynı anda aidat tutarını girebilir.
- Ayrıca yönetici tüm aidatları veya ay bazlı olarak görüntüleyebilir.

### PaymentService
- Payment serviste ödeme yapılamk istenen tipe göre (aidat veya fatura) ödeme bilgileri sisteme eklenir.
