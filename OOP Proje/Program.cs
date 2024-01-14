
using OOP_Proje.BL;
using OOP_Proje.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;

// Oyun sınıfı
class Game
{
    public string Türü {  get; set; }
    public string Adi { get; set; }
    public int Stok { get; set; }
    public decimal Fiyat { get; set; }
}


// Oyun işlemleri arayüzü
interface IOyunIslemleri
{
    void OyunEkle();
    void OyunSil();
    void OyunDuzenle();
    void OyunListesiGoruntule();
}

// Oyun stoğu sınıfı oluşturuluyor ve arayüzden metotları miras alıyor
class OyunStogu : IOyunIslemleri
{
    private List<Game> oyunlar = new List<Game>();

    //Oyunları adına, Türüne, Stok Adedine ve Fiyatına Göre Eklememizi Sağlayan Kod Bloğu
    public void OyunEkle()
    {

        Console.Write("Oyun Türü: ");
        string tür = Console.ReadLine();

        Console.Write("Oyun Adı: ");
        string adi = Console.ReadLine();

        Console.Write("Stok Adedi: ");
        int stok = Convert.ToInt32(Console.ReadLine());

        Console.Write("Fiyat(Türk Lirası): ");
        decimal fiyat = Convert.ToDecimal(Console.ReadLine());



        Game yeniOyun = new Game { Türü=tür , Adi = adi, Stok = stok, Fiyat = fiyat };
        oyunlar.Add(yeniOyun);

        Console.WriteLine($"{yeniOyun.Adi} eklendi.");
        Console.WriteLine("Devam etmek için bir tuşa tıklayınız...");
        Console.ReadKey();
        Console.Clear();
    }

    //Eklenen oyunu bulup silmemizi sağlayan kod bloğu
    public void OyunSil()
    {

        foreach (var oyun in oyunlar)
        {
            Console.WriteLine("Oyun Listesi:");
            Console.WriteLine($"Adı:{oyun.Adi}, Türü:{oyun.Türü},  Stok: {oyun.Stok}, Fiyat: {oyun.Fiyat} Türk Lirası");
        }

        Console.WriteLine("\n");

        Console.Write("Silinecek Oyun Adı: ");
        string silinecekOyunAdi = Console.ReadLine();

        Game silinecekOyun = oyunlar.Find(e => e.Adi.Equals(silinecekOyunAdi, StringComparison.OrdinalIgnoreCase));

        if (silinecekOyun != null)
        { 
            oyunlar.Remove(silinecekOyun);
            Console.WriteLine($"{silinecekOyunAdi} silindi.");
        }
        else
        {
            Console.WriteLine($"{silinecekOyunAdi} bulunamadı.");
        }
    }
    
    // Oyun düzenlememizi ve mevcut oyunun gösterilmesi
    public void OyunDuzenle()
    {

        foreach (var oyun in oyunlar)
        {
            Console.WriteLine("Oyun Listesi:");
            Console.WriteLine($"Adı:{oyun.Adi}," +
                $" Türü:{oyun.Türü} " +
                $" Stok: {oyun.Stok}" +
                $" Fiyat: {oyun.Fiyat} Türk Lirası");
        }

        Console.WriteLine("\n");

        Console.Write("Düzenlenecek Oyun Adı: ");
        string duzenlenecekOyunAdi = Console.ReadLine();


        Game duzenlenecekOyun = oyunlar.Find(e => e.Adi.Equals(duzenlenecekOyunAdi, StringComparison.OrdinalIgnoreCase));

        if (duzenlenecekOyun != null)
        {
            Console.Write("Yeni Oyun Türü: ");
            duzenlenecekOyun.Türü = Console.ReadLine();

            Console.Write("Yeni Oyun Adı: ");
            duzenlenecekOyun.Adi = Console.ReadLine();

            Console.Write("Yeni Stok Adedi: ");
            duzenlenecekOyun.Stok = Convert.ToInt32(Console.ReadLine());

            Console.Write("Yeni Fiyat: ");
            duzenlenecekOyun.Fiyat = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine($"{duzenlenecekOyunAdi} düzenlendi.");
        }
        else
        {
            Console.WriteLine($"{duzenlenecekOyunAdi} bulunamadı.");
        }
    }

    //Oyun listesini görüntülememizi sağlayan metot
    public void OyunListesiGoruntule()
    {
        if (oyunlar.Count == 0)
        {
            Console.WriteLine("Lütfen Oyun Ekleyiniz!");
        }
        else
        {
            foreach (var oyun in oyunlar)
            {
                Console.WriteLine("Oyun Listesi:");
                Console.WriteLine($"Adı:{oyun.Adi}");
                Console.WriteLine($"Türü:{oyun.Türü}");
                Console.WriteLine($"Stok: {oyun.Stok}");
                Console.WriteLine($"Fiyat: {oyun.Fiyat} Türk Lirası\n");
            }            
         }
    }
}

// Konsol üzerinden oyun stoğunu yönettiğimiz sınıf
class KonsolOyunIslemleri
{
    private IOyunIslemleri oyunIslemleri;
    private Users currentUser;

    public KonsolOyunIslemleri(IOyunIslemleri oyunIslemleri, Users user)
    {
        this.oyunIslemleri = oyunIslemleri;
        this.currentUser = user;
    }

    public void MenuGoster()
    {
        while (true)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.WriteLine("\nYapmak istediğiniz işlemi seçiniz:");
            Console.WriteLine("1- Oyun Ekle");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2- Oyun Sil");
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("3- Oyun Düzenle");
            Console.ForegroundColor = originalColor;
            Console.WriteLine("4- Oyun Listesini Görüntüle");
            Console.WriteLine("5- Konsolu Temizle");
            Console.WriteLine("6- Hesap Değiştir");
            Console.WriteLine("7- Çıkış\n");

            int secim = Convert.ToInt32(Console.ReadLine());

            // Kullanıcı tipine göre işlem yapmamızı ve yapmak istediğimiz işlemleri seçtiren kod bloğu

            switch (currentUser.UserType)
            {
                case UserType.Admin:

                    switch (secim)
                    {
                        case 1:
                            oyunIslemleri.OyunEkle();
                            break;

                        case 2:
                            oyunIslemleri.OyunSil();
                            break;

                        case 3:
                            oyunIslemleri.OyunDuzenle();
                            break;

                        case 4:
                            oyunIslemleri.OyunListesiGoruntule();
                            break;

                        case 5:
                            Console.Clear();
                            break;

                        case 6:
                            DegistirKullanici();
                            break;

                        case 7:
                            
                            Console.WriteLine("Çıkılıyor...");
                            Environment.Exit(0);
                            break;


                        default:
                            Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                            break;
                    }
                    break;

                case UserType.User:
                    switch (secim)
                    {
                        case 4:
                            oyunIslemleri.OyunListesiGoruntule();
                            break;
                     
                        case 5:
                            Console.Clear();
                            break;

                        case 6:
                            DegistirKullanici();
                            break;

                        case 7:                
                            Console.WriteLine("Çıkılıyor...");
                            Environment.Exit(0);
                            break;
                        

                        default:
                            if (secim < 8)
                                Console.WriteLine("Bu işlem için yetkiniz yok");
                            else Console.WriteLine("Geçersiz seçim!");
                            break;
                    }
                            break;

                        default:
                            Console.WriteLine("Geçersiz kullanıcı tipi. Programdan çıkılıyor.");
                            Environment.Exit(0);
                            break;

            }
        }
      }

    //Konsol uygulamasındayken kullanıcı değiştirmemizi sağlayan fonksiyon
    private void DegistirKullanici()
    {
        Console.WriteLine("Yeni Kullanıcı Girişi: ");
        Console.Write("Kullanıcı Adı: ");
        string username = Console.ReadLine();

        Console.Write("Şifre: ");
        string password = Console.ReadLine();

        Users yeniUser = login(username, password);
        
        if (yeniUser != null)
        {
            Console.WriteLine($"Kullanıcı değiştirildi. Yeni kullanıcı: {yeniUser.UserName}");
            currentUser = yeniUser;
        }
        else
        {
            Console.WriteLine("Kullanıcı adı veya şifre hatalı. Kullanıcı değiştirilemedi.");
        }
    }
    private Users login(string username, string password)
    {
        UserBL userBL = new UserBL();
        return userBL.login(username, password);
    }
}

class Program
{
    static void Main()
    {

        Console.WriteLine("" +
            "\n" +
            "\n" +
            "\n" +
            "\n" +
            "\n" +
            "                              ==== VİDEO OYUN STOĞU UYGULAMASINA HOŞ GELDİNİZ ====");
        Thread.Sleep(500);
        Console.Clear();

        Console.WriteLine("                    ---------- Kullanım Kılavuzu ----------\n");

        Console.WriteLine("1- Yapacağınız işlemi seçerken sayı kullanmaya özen gösteriniz aksi taktirde uygulamanız hata verecektir.\n");
        Console.WriteLine("2- Eklediğiniz oyunu silmek veya düzeltmek için oyunun ismini nasıl eklediyseniz öyle girmelisiniz.\n");
        Console.WriteLine("Lütfen Devam etmek için bir tuşa basınız...");
        Console.ReadKey();
        Console.Clear();

        //

        OyunStogu oyunStogu = new OyunStogu();
        UserBL userBL = new UserBL();

        Users loggedInUser = null;

        while (true)
        {
            Console.WriteLine("Giriş Türünü Seçiniz:");
            Console.WriteLine("1-Admin Girişi");
            Console.WriteLine("2-Kullanıcı Girişi");

            int secim;
            while (!int.TryParse(Console.ReadLine(), out secim) || (secim < 1 || secim > 2))
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin:");
            }

            Console.Clear();

            Console.Write("Kullanıcı Adınız: ");
            string username = Console.ReadLine();

            Console.Write("Şifreniz: ");
            string password = Console.ReadLine();

            Console.Clear();



            if (secim == 1)
            {
                loggedInUser = userBL.login(username, password);

                if (loggedInUser != null && loggedInUser.UserType == UserType.Admin)
                {
                    Console.WriteLine($"Hoş geldiniz, {loggedInUser.UserName}!");
                    Console.WriteLine("Admin girişi başarılı.");
                    break;
                }
                else
                {
                    if (loggedInUser == null)
                        Console.WriteLine("Kullanıcı bulunamadı!");
                }
            }
            else if (secim == 2)
            {
                loggedInUser = userBL.login(username, password);
                if (loggedInUser != null && loggedInUser.UserType == UserType.User)
                {
                    Console.WriteLine($"Hoş geldiniz, {loggedInUser.UserName}!");
                    Console.WriteLine("Normal kullanıcı girişi başarılı.");
                    break;
                }
                else
                {
                    if (loggedInUser == null)
                        Console.WriteLine("Kullanıcı bulunamadı!");
                }
            }
        }

        Console.WriteLine("\n");
        Console.WriteLine("Lütfen Devam etmek için bir tuşa basınız...");
        Console.ReadKey();
        Console.Clear();

        KonsolOyunIslemleri konsolOyunIslemleri = new KonsolOyunIslemleri(oyunStogu, loggedInUser);
        konsolOyunIslemleri.MenuGoster();

    }
}