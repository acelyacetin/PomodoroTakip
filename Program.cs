using System;
using System.Collections.Generic;
using System.Threading;

namespace PomodoroTakip
{
    class Görev
    {
        public string Ad { get; set; }
        public string Proje { get; set; }
        public int HarcananDakika { get; set; }
    }

    class Program
    {
        static List<Görev> gorevListesi = new List<Görev>();

        static void Main(string[] args)
        {
            bool devam = true;
            while (devam)
            {
                Console.Clear();
                Console.WriteLine("=== POMODORO & ZAMAN TAKİP UYGULAMASI ===");
                Console.WriteLine("1. Pomodoro Başlat (25 Dk Çalışma / 5 Dk Mola)");
                Console.WriteLine("2. Geçmiş Kayıtları / Raporu Gör");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminiz: ");
                
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        PomodoroBaslat();
                        break;
                    case "2":
                        RaporGoster();
                        break;
                    case "3":
                        devam = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim! Devam etmek için bir tuşa basın.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void PomodoroBaslat()
        {
            Console.Clear();
            Console.Write("Çalışacağınız Proje Adı: ");
            string proje = Console.ReadLine();

            Console.Write("Görev Tanımı: ");
            string gorevAd = Console.ReadLine();

            Console.WriteLine("\n[ÇALIŞMA MODU] 25 dakikalık Pomodoro başladı!");
            
            // Gerçek 25 dakika: 25 * 60 saniye
            // Hızlı test etmek istersen bu sayıyı 5 yapabilirsin.
            int saniye = 25 * 60; 

            for (int i = saniye; i > 0; i--)
            {
                TimeSpan t = TimeSpan.FromSeconds(i);
                Console.Write($"\rKalan Süre: {t.Minutes:D2}:{t.Seconds:D2} ");
                Thread.Sleep(1000);
            }

            Console.WriteLine("\n\nTebrikler! 25 dakikalık çalışma bitti.");
            
            gorevListesi.Add(new Görev { Proje = proje, Ad = gorevAd, HarcananDakika = 25 });

            Console.WriteLine("\n[MOLA MODU] 5 dakikalık mola başladı!");
            int molaSaniye = 5 * 60;
            for (int i = molaSaniye; i > 0; i--)
            {
                TimeSpan t = TimeSpan.FromSeconds(i);
                Console.Write($"\rMola Kalan Süre: {t.Minutes:D2}:{t.Seconds:D2} ");
                Thread.Sleep(1000);
            }

            Console.WriteLine("\n\nMola bitti! Ana menüye dönmek için bir tuşa basın.");
            Console.ReadKey();
        }

        static void RaporGoster()
        {
            Console.Clear();
            Console.WriteLine("=== TAMAMLANAN GÖREVLER VE ZAMAN RAPORU ===");
            if (gorevListesi.Count == 0)
            {
                Console.WriteLine("Henüz tamamlanmış bir Pomodoro kaydı yok.");
            }
            else
            {
                foreach (var g in gorevListesi)
                {
                    Console.WriteLine($"Proje: {g.Proje} | Görev: {g.Ad} | Süre: {g.HarcananDakika} Dk");
                }
            }
            Console.WriteLine("\nAna menüye dönmek için bir tuşa basın.");
            Console.ReadKey();
        }
    }
}