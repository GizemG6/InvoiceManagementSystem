# InvoiceManagementSystem
-------------------------
Bu proje, Patika Academy Orta Seviye .Net Core Patikası için hazırlanmıştır. Patika'ya aşağıdaki linkten ulaşabilirsin.
https://academy.patika.dev/tr/courses/net-core-projeleri/faturayonetimsistemi

Bu proje, bir sitenin aidat ve ortak kullanım giderlerini (elektrik, su, doğalgaz vb.) yönetmek için geliştirilmiştir. Sistem, iki farklı kullanıcı tipi (Admin ve Kullanıcı) için farklı işlevler sunar.

Proje Özellikleri
-------------------------
Admin İşlevleri
-------------------------

•Daire bilgilerini ekleyebilir, düzenleyebilir ve silebilir.

•Kullanıcı bilgilerini ekleyebilir ve düzenleyebilir. Kullanıcılar için otomatik şifre oluşturulur.

•Dairelere kullanıcıları atayabilir.

•Aidat ve fatura bilgilerini aylık bazda ekleyebilir.

•Gelen ödeme bilgilerini görebilir.

•Gelen mesajları görüntüleyebilir.

Kullanıcı İşlevleri
-------------------------

•Kendisine atanmış aidat ve fatura bilgilerini görüntüleyebilir.

•Kredi kartı ile ödeme yapabilir.

•Yöneticiye mesaj gönderebilir.

Daire/Konut Bilgileri
-------------------------

•Hangi blokta olduğu.

•Durumu (Dolu/Boş).

•Tipi (2+1 vb.).

•Bulunduğu kat.

•Daire numarası.

•Daire sahibi veya kiracı bilgisi.

Kullanıcı Bilgileri
-------------------------

•Ad-Soyad.

•TC Kimlik No.

•E-posta.

•Telefon.

•Araç bilgisi (varsa plaka no).

Kullanılan Teknolojiler
-------------------------
•Backend/Web Projesi: ASP.NET Core 8 MVC

•Veritabanı: MS SQL Server

•Kredi Kartı Servisi: .NET WebAPI ve MongoDB

Kurulum Talimatları

1-Web Projesini Çalıştırma
-------------------------

Gereksinimler:

•.NET 8 SDK

•Visual Studio 2022 veya üzeri

•MS SQL Server

Projesinin Çalıştırılması:

•Proje dosyalarını bilgisayarınıza klonlayın:

```csharp
git clone https://github.com/GizemG6/InvoiceManagementSystem
```
•appsettings.json dosyasını açarak SQL Server bağlantı dizesini düzenleyin:

```csharp
"ConnectionStrings": {
  "DefaultConnection": "Server=YourServerName;Database=ApartmentManagementDB;Trusted_Connection=True;"
}
```
•Terminalden proje klasörüne giderek aşağıdaki komutları çalıştırın:

```csharp
dotnet build
dotnet run
```
2-Kredi Kartı Servisinin Çalıştırılması
-------------------------

Gereksinimler:

•.NET 8 SDK

•MongoDB Community Server

Projesinin Çalıştırılması:

•MongoDB bağlantısını ayarlamak için appsettings.json dosyasını düzenleyin:

```csharp
"MongoSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "CreditCardServiceDB"
}
```
•Terminalden WebAPI klasörüne giderek çalıştırın:

```csharp
dotnet build
dotnet run
}
```
Veri Tabanı Şeması
-------------------------
1-SQL SERVER
![Ekran görüntüsü 2024-11-19 224306](https://github.com/user-attachments/assets/a3184e7d-2798-4001-8135-0ce2ef76bf37)

