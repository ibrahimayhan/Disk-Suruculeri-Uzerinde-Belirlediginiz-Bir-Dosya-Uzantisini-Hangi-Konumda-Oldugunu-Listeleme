// Disk Sürücüleri Listeleme Konusunda Belirtilen Repositories Kullanabilirsiniz [ https://github.com/ibrahimayhan/Bilgisayar-Uzerinde-Mantiksal-Olarak-Bagli-Bulunan-Diskleri-Listeleme ]
// Burada BirimListesi List İçerisinde Aşağıdaki Nesnelerinin Olduğunu Varsayarak İnceleyebilirsiniz, Eğer Siz Disk Sürücüleri Listeleyek BirimListesinde Kullanmak İstiyorsanız Yukarıda Belirtilen Repositories İnceleyebilirsiniz

List<Yapilandirma.YerelDiskBirimleriListesi> BirimListesi = new List<Yapilandirma.YerelDiskBirimleriListesi>();

// Liste İçerisinde Sürücü Adı Belirtilen Şekilde Bulunmaktadır [ "C:\", "D:\", "E:\" ]

List<string> PSTBulunanDosyaKonumlari = new List<string>();

// Bizler .pst Dosyalarını Arayağımız İçin Kendimize string Türünde Bir Array Tanımlıyoruz

// Birim Listesi İçerisindeki Tüm Sürücüleri foreach Döngüsünde Dosya ve Alt Klasörleri Tarama
foreach (var BilgisayarDizini in BirimListesi)
{
    DosyaTarama(BilgisayarDizini.SurucuAdi);
    AltKlasorTarama(BilgisayarDizini.SurucuAdi);
}

private void DosyaTarama(string BilgisayarDizini)
{
    try
    {
        // *.pst Yerine Aramak İstediğiniz Dosya Uzantısını Belirleyebilirsiniz
        string[] DizinDosyalari = Directory.GetFiles(BilgisayarDizini, "*.pst");
        
        foreach (var DizinIcerigi in DizinDosyalari)
        {
            // Taranılan Konumda .pst Dosyası Varsa Oluşturğumuz Array İçerisine Dizin Bilgisini Aktarma
            PSTBulunanDosyaKonumlari.Add(DizinIcerigi);
        }
    }
    catch (Exception)
    {
        // Geliştirdiğim Ortam Standart User Yetkisinde Olduğundan Dosya Burada catch Alanını Dikkate Almıyorum Siz Loglama İşleminde Kullanabilirsiniz
    }
}

// Taranılan Dizin İçerisinde Alt Klasörleri Listeleme
private void AltKlasorTarama(string BilgisayarDizini)
{
    try
    {
        string[] AltDizinGirisler = Directory.GetDirectories(BilgisayarDizini);

        foreach (string AltDizin in AltDizinGirisler)
        {
            // Tekrardan Alt Klasörlerde Dosya Uzantısı Tarama
            DirectoryInfo di = new DirectoryInfo(AltDizin);
            DosyaTarama(AltDizin);
            AltKlasorTarama(AltDizin);
        }
    }
    catch (Exception)
    {
        // Geliştirdiğim Ortam Standart User Yetkisinde Olduğundan Dosya Burada catch Alanını Dikkate Almıyorum Siz Loglama İşleminde Kullanabilirsiniz
    }
}