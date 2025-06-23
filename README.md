# WebApi-ConsumeApi-JWT

Bu proje, bir ASP.NET Core Web API'sinin JWT (JSON Web Token) ile nasıl güvence altına alındığını ve başka bir ASP.NET Core uygulamasının bu güvenli API'yi nasıl tükettiğini (consume ettiğini) gösteren bir örnek uygulamadır.

## Projenin Amacı

Projenin temel amacı, iki servis arasındaki kimlik doğrulama ve yetkilendirme akışını JWT kullanarak göstermektir. Bu senaryo, özellikle mikroservis mimarilerinde veya birbirinden ayrı çalışan frontend ve backend uygulamalarında sıkça karşılaşılan bir durumdur.

Proje iki ana bölümden oluşur:
1.  **ReadyApi:** JWT üreten ve korumalı kaynakları sunan ana API.
2.  **ConsumeWebApi:** `ReadyApi`'den bir JWT alıp bu token ile korumalı kaynaklara erişim sağlayan istemci (client) uygulaması.

## Nasıl Çalışır?

Projenin işleyişi aşağıdaki adımları takip eder:

1.  **Token Alma:** `ConsumeWebApi`, `ReadyApi` üzerinde bulunan ve kimlik doğrulaması yapan bir uç noktaya (endpoint) istek gönderir.
2.  **JWT Üretimi:** `ReadyApi`, gelen kullanıcı bilgileri doğru ise geçerli bir JWT oluşturur ve bu token'ı `ConsumeWebApi`'ye geri döner.
3.  **Korumalı Kaynağa Erişim:** `ConsumeWebApi`, elde ettiği bu JWT'yi sonraki isteklerinin `Authorization` başlığına (Header) `Bearer <token>` formatında ekler.
4.  **Token Doğrulama:** `ReadyApi`, korumalı uç noktalarına gelen isteklerdeki JWT'yi doğrular. Eğer token geçerli ise kaynağı istemciye sunar, değilse `401 Unauthorized` hatası döndürür.

## Proje Yapısı

* **ReadyApi:**
    * Kaynakları (örneğin ürünler, siparişler vb.) barındıran ve sunan projedir.
    * `[Authorize]` attribute'u ile korunan controller'lar içerir.
    * Kullanıcı kimliğini doğrulayan ve JWT üreten bir kimlik doğrulama (authentication) mekanizmasına sahiptir.

* **ConsumeWebApi:**
    * `ReadyApi` tarafından sunulan korumalı kaynakları tüketmek isteyen istemci projesidir.
    * `HttpClient` veya benzeri bir kütüphane kullanarak `ReadyApi`'ye HTTP istekleri gönderir.
    * İlk olarak token almak için, ardından aldığı token ile diğer kaynaklara erişmek için isteklerde bulunur.

## Kullanılan Teknolojiler

* **Backend:** ASP.NET Core
* **Kimlik Doğrulama:** JSON Web Tokens (JWT)
* **API İstemcisi:** HttpClientFactory

## Kurulum ve Çalıştırma

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

1.  **Repoyu Klonlayın:**
    ```sh
    git clone [https://github.com/SametDulger/WebApi-ConsumeApi-JWT.git](https://github.com/SametDulger/WebApi-ConsumeApi-JWT.git)
    ```

2.  **Proje Dizinine Gidin:**
    ```sh
    cd WebApi-ConsumeApi-JWT
    ```

3.  **Çoklu Proje Başlatma (Multiple Startup Projects):**
    Bu çözüm, iki projenin aynı anda çalışmasını gerektirir. Visual Studio kullanıyorsanız, Solution'a sağ tıklayıp `Properties` -> `Common Properties` -> `Startup Project` menüsünden `Multiple startup projects` seçeneğini işaretleyin. `ReadyApi` ve `ConsumeWebApi` projeleri için `Action` olarak `Start` seçeneğini ayarlayın.

4.  **Uygulamaları Çalıştırın:**
    Visual Studio üzerinden `F5` tuşu ile veya aşağıdaki komutlarla her bir projeyi ayrı terminallerde başlatın:
    ```sh
    # Terminal 1
    dotnet run --project ReadyApi/ReadyApi.csproj

    # Terminal 2
    dotnet run --project ConsumeWebApi/ConsumeWebApi.csproj
    ```
    *Not: `ConsumeWebApi` projesinin `appsettings.json` dosyasında, `ReadyApi`'nin çalıştığı adresi doğru şekilde belirttiğinizden emin olun.*

