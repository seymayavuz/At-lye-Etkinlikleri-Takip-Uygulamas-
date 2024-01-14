using System;
using System.Collections.Generic;


abstract class BaseProgram
{
    public abstract void AbstractMethod();
}

class MyProgram : BaseProgram
{
    static List<Kullanici> kullaniciListesi = new List<Kullanici>();

    static void Main()
    {
        // Manuel olarak kullanıcı ekleyelim
        kullaniciListesi.Add(new Kullanici("şeyma yavuz", "987"));
        kullaniciListesi.Add(new Kullanici("rana çakır", "765"));
        kullaniciListesi.Add(new Kullanici("betül gevrek", "543"));

        bool girisBasarili = false;

        do
        {
            Console.WriteLine("Hoşgeldiniz! Lütfen kullanıcı adı ve şifrenizle giriş yapınız: ");
            string kullaniciAdi = Console.ReadLine();
            string sifre = Console.ReadLine();

            if (GirisYap(kullaniciAdi, sifre))
            {
                Console.WriteLine("Giriş başarılı. Hoş geldiniz, " + kullaniciAdi + ".");

                // Menü sistemini çağır
                Menu();
                girisBasarili = true; // Doğru giriş yapıldığında döngüden çık
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
            }
        } while (!girisBasarili);
    }

    static bool GirisYap(string kullaniciAdi, string girilenSifre)
    {
        Kullanici girisYapanKullanici = kullaniciListesi.Find(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == girilenSifre);
        if (girisYapanKullanici != null)
        {
            girisYapanKullanici.Aktif = true;
            return true;
        }
        return false;
    }

    static void Menu()
    {
        bool devamEt = true;

        while (devamEt)
        {
            Console.WriteLine("Bir işlem seçiniz:");
            Console.WriteLine("1- Hakkımızda...");
            Console.WriteLine("2- Pick & Paint Seramik Workshopu");
            Console.WriteLine("3- Buket Workshopu");
            Console.WriteLine("4- Mum Workshopu");
            Console.WriteLine("5- Giriş yapılan etkinlikleri görüntüle");
            Console.WriteLine("6- Çıkış yap");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Hakkimizda();
                    break;
                case "2":
                    EtkinlikSec("Pick & Paint Seramik Workshopu");
                    break;
                case "3":
                    EtkinlikSec("Buket Workshopu");
                    break;
                case "4":
                    EtkinlikSec("Mum Workshopu");
                    break;
                case "5":
                    GirisYapilanEtkinlikleriGoruntule();
                    break;
                case "6":
                    Console.WriteLine("Çıkış yapılıyor...");
                    devamEt = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    static void EtkinlikSec(string etkinlikAdi)
    {
        Console.WriteLine("Etkinlik seçildi: " + etkinlikAdi);
        Console.WriteLine("Bu etkinliğe katılmak istiyor musunuz? (E/H)");

        string cevap = Console.ReadLine();
        if (cevap.ToUpper() == "E")
        {
            Kullanici aktifKullanici = kullaniciListesi.Find(k => k.Aktif);
            if (aktifKullanici != null)
            {
                aktifKullanici.KatildigiEtkinlikler.Add(etkinlikAdi);
                Console.WriteLine("Etkinlik başarıyla seçildi. Katıldığınız etkinlikler: " +
                                  string.Join(", ", aktifKullanici.KatildigiEtkinlikler));
            }
            else
            {
                Console.WriteLine("Hata: Aktif kullanıcı bulunamadı.");
            }
        }
    }

    static void GirisYapilanEtkinlikleriGoruntule()
    {
        Kullanici aktifKullanici = kullaniciListesi.Find(k => k.Aktif);
        if (aktifKullanici != null)
        {
            Console.WriteLine("Giriş yapılan etkinlikler: " +
                              string.Join(", ", aktifKullanici.KatildigiEtkinlikler));
        }
        else
        {
            Console.WriteLine("Hata: Aktif kullanıcı bulunamadı.");
        }
    }
    

public override void AbstractMethod()
    {
        Hakkimizda();
    }

    static void Hakkimizda()
    {
        Console.WriteLine("Merhaba! Ranart Ceramic  iki kardeşin kurduğu bir seramik atölyesi.Bu atölyede kendin olabilirsin.Dilediğin gibi tasarımlar yapıp sanatını gösterebilir; sonucunda sana ait benzersiz ürünlere sahip olabilirsin.Neler yapabileceğini merak ediyorsan workshoplarımıza göz atmalısın"+"    "+ "Her cumartesi gerçekleştirilen pick and paint workshopunda; atölyemizde önceden yapılmış kupa, kase, vazo gibi ürünlerden seçmiş olduğunuz ürünü atölyemizdeki çeşitli renklerle dilediğiniz gibi renklendiriyorsunuz. (kontenjan 15 kişiyle sınırlıdır.)"+ "    " + "Her salı gerçekleştirilen buket workshopunda atölyemizden Beyza hanımla beraber birbirinden renkli buketler hazırlıyoruz. Bu etkinlik içinizi açacak. (Kontenjan 8 kişiyle sınırlıdır.)"+"    " + "Her cuma gerçekleştirilen bu workshopta ise mum süslüyoruz. Amacımız kokusuyla bizi iyi hissettiricek, görüntüsüyle bizi büyüleyecek mumlar yaratmak.(kontenjan 20 kişiyle sınırlıdır.)");
    }


    class Kullanici
    {
        public string KullaniciAdi { get; }
        public string Sifre { get; }
        public bool Aktif { get; set; }
        public List<string> KatildigiEtkinlikler { get; set; }

        public Kullanici(string kullaniciAdi, string sifre)
        {
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            Aktif = false;
            KatildigiEtkinlikler = new List<string>();
        }
    }
}
