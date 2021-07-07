using System;

namespace soru1
{
    class Program
    {
        static int AltSinir;
        static int UstSinir;
        static int Adet;
        static void Main(string[] args)
        {
            Console.WriteLine("Alt sinir = ");
            AltSinir = Convert.ToInt32(Console.ReadLine()); //alt sinir degeri icin input aldik
            Console.WriteLine("Ust sinir = ");
            UstSinir = Convert.ToInt32(Console.ReadLine()); // ust sinir degeri icin input aldik
            Console.WriteLine("Kac sayi uretilsin = ");
            Adet = Convert.ToInt32(Console.ReadLine()); // kac adet rastgele sayi uretidigini belirlemek icin input aldik



            DiziIslemleri diziIslemleri = new DiziIslemleri();                   // DiziIslemleri sinifindan diziIslemleri adinda bir obje yarattim
            int[] arrayy = diziIslemleri.SayilariUret(AltSinir, UstSinir, Adet); // DiziIslemleri sinifindaki SayilariUret metodunu diziIslemleri objesiyle cagirdik
                                                                                 // ve bu metoddan donen degeri arrayy isimli bir arraye atadik

            diziIslemleri.DiziYazdir(arrayy);                   // Bir onceki islemde atadigimiz arrayy isimli array'i DiziYazdir metodunda parametre olarak kullandik
                                                                // Bu metodda dizimizde olusturdugumuz rastgele sayilari konsola yazdirdik

            int[][] array2d = diziIslemleri.DiziAyir(arrayy);   // DiziAyir metodunda arrayy isimli arrayi parametre olarak aliyoruz ve bu metodda diziyi pozitif ve
                                                                // negatif degerleri ayiriyor ve bu degerleri array2d isimli multi dimensional bir arraye atiyor


            diziIslemleri.DuzensizDiziYazdir(array2d);          // atadigimiz array2d arrayini DuzensizDiziYazdir metodunda paremetre olarak kullaniyoruz
                                                                // bu metodda ise negatif ve pozitif sayilari ayri bir sekilde konsola yazdiriyoruz
            Console.ReadLine();
        }

    }
    public class DiziIslemleri
    {
        static Random r = new Random();
        public static int[] adet;
        public int[] SayilariUret(int AltSinir, int UstSinir, int Adet)
        {

            adet = new int[Adet];
            for (int i = 0; i < Adet; i++)
            {
                int random = r.Next(AltSinir, UstSinir);

                adet[i] = random;
            }
            return adet;

        }
        public void DiziYazdir(int[] Dizi)
        {
            Console.WriteLine("Rastgele sayilarla olusturulan Karma Dizi");
            Console.WriteLine("=========================================");
            for (int i = 0; i < adet.Length; i++)
            {
                Console.Write(" " + adet[i]);
            }
        }
        public int[][] Birlestir(int[] dizi1, int[] dizi2)
        {
            int[][] birlesik = new int[2][];

            birlesik[0] = new int[dizi1.Length];
            birlesik[1] = new int[dizi2.Length];
            for (int i = 0; i < dizi1.Length; i++)
            {
                birlesik[0][i] = dizi1[i];
            }
            for (int a = 0; a < dizi2.Length; a++)
            {
                birlesik[1][a] = dizi2[a];
            }
            return birlesik;

        }
        public int[][] DiziAyir(int[] Dizi)
        {
            int[][] ayrilmis = new int[2][];
            int p = 0;
            int n = 0;
            int pCount = 0;
            int nCount = 0;

            for (int o = 0; o < Dizi.Length; o++)
            {
                if (Dizi[o] < 0)
                {
                    nCount++;
                }
                else
                {
                    pCount++;
                }
            }


            ayrilmis[0] = new int[nCount];
            ayrilmis[1] = new int[pCount];
            for (int i = 0; i < Dizi.Length; i++)
            {
                if (Dizi[i] < 0)
                {
                    ayrilmis[0][n] = Dizi[i];
                    n++;
                }
                else
                {
                    ayrilmis[1][p] = Dizi[i];
                    p++;
                }
            }
            return ayrilmis;
        }
        public void DuzensizDiziYazdir(int[][] Dizi)
        {
            //Negatif sayilarin konsola yazdirimi
            Console.WriteLine("\n\nNegatif sayilar dizisi");
            Console.WriteLine("======================");
            for (int i = 0; i < Dizi[0].Length; i++)
            {

                Console.Write(Dizi[0][i] + " ");
            }
            Console.WriteLine("\n\nPozitif Sayilar Dizisi");
            Console.WriteLine("======================");
            for (int a = 0; a < Dizi[1].Length; a++)
            {
                Console.Write(Dizi[1][a] + " ");
            }
        }

    }
}

