using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soru2
{
    public class Sayi
    {
        public int deger;

        public Sayi(int x)
        {
            deger = x;
        }

        static public void arkadasSayilar(Sayi bir, Sayi iki)
        {
            int i;
            int bolentoplam1 = 0, bolentoplam2 = 0;
            for (i = 1; i < bir.deger; i++)
            {
                if (bir.deger % i == 0)
                {
                    bolentoplam1 += i;
                }
            }
            for (i = 1; i < iki.deger; i++)
            {
                if (iki.deger % i == 0)
                {
                    bolentoplam2 += i;
                }
            }
            Console.WriteLine("*****************************");
            if (bir.deger == bolentoplam2 && iki.deger == bolentoplam1)
            {
                Console.WriteLine(bir.deger + " ve " + iki.deger + " ARKADAS SAYILARDIR");
            }
            else
            {
                Console.WriteLine(bir.deger + " ve " + iki.deger + " ARKADAS SAYI DEGILLERDIR");
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Lutfen 1. Sayiyi Giriniz :");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lutfen 2. Sayiyi Giriniz :");
            int y = Convert.ToInt32(Console.ReadLine());
            if (x < 0 || y < 0)
            {
                Console.WriteLine("Negatif Sayi Tespit Edildi. Program Kapatiliyor... :");
                Console.ReadLine();
                return;
            }
            Sayi birincisayi = new Sayi(x);
            Sayi ikincisayi = new Sayi(y);

            Sayi.arkadasSayilar(birincisayi, ikincisayi);

            Console.ReadLine();


        }


    }
}
