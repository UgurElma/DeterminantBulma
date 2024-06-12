using System;
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        Console.Write("nxn boyutundaki bir kare matrisinin determinantını, kofaktör yöntemiyle bulan uygulamaya hoş geldiniz.\nDevam etmek için klavyeden herhangi bir tuşa basınız!");
        Console.ReadKey();
        while (true)
        {
            Console.Clear();
            int n = 0;
            while (n < 2)
            {
                string hatan = string.Empty;
                Console.Clear();
                Console.Write("Lütfen, determinantını bulmak istediğiniz kare matrisin n değerini (en az 2 olmalı) giriniz: ");
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n < 2)
                        hatan = "n değeri en az 2 olmalıdır!";

                }
                catch (Exception hata)
                {
                    hatan = hata.Message;
                }
                if (hatan != string.Empty)
                {
                    Console.Write(hatan + " Devam etmek için klavyeden herhangi bir tuşa basınız!");
                    Console.ReadKey();
                }
            }
        geriDon:
            double[,] firstMatris = new double[n, n];
            Console.Clear();
            Console.WriteLine("Lütfen, determinantını bulmak istediğiniz matrisin indislerini giriniz.");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write("A{0}{1} = ", i, j);
                    try
                    {
                        firstMatris[i - 1, j - 1] = double.Parse(Console.ReadLine());
                    }
                    catch
                    { Console.Write("Hatalı giriş yaptınız! Tekrardan indisleri girmek için herhangi bir tuşa basınız."); Console.ReadKey(); goto geriDon; }
                }
            }
            Console.Clear();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(firstMatris[i - 1, j - 1] + "  ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("-------------------------------------------------\nMatrisiniz doğru mu? (Doğruysa ---> 1  Yanlışsa ---> 2  Çıkış ---> 'Diğer Tuşlar')");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine("{0}x{0} boyutundaki kare matrisinizin determinantı = {1}", n, matrisConvertor(firstMatris, n));
                Console.Write("\nDevam etmek için klavyeden herhangi bir tuşa basınız!");
                Console.ReadKey();

            }
            else if (answer == "2")
            {
                goto geriDon;
            }
            else
            {
                Console.Clear();
                Console.Write("Uygulama kapatıldı!");
                Console.ReadKey();
                break;
            }
        }

    }

    static double matrisConvertor(double[,] firstMatris, int boyut)
    {
        double determinant = 0;
        if (boyut > 2)
        {
            for (int i = 1; i <= boyut; i++)
            {
                double katsayi = firstMatris[0, i - 1] * Math.Pow(-1, 1 + i);
                double[,] secondMatris = new double[boyut - 1, boyut - 1];
                List<double> list = new List<double>();
                for (int k = 1; k <= boyut; k++)
                {
                    for (int l = 1; l <= boyut; l++)
                    {
                        if (k != 1 && l != i)
                        {
                            list.Add(firstMatris[k - 1, l - 1]);
                        }
                    }
                }
                int sayac = 0;
                for (int m = 1; m <= boyut - 1; m++)
                {
                    for (int n = 1; n <= boyut - 1; n++)
                    {
                        secondMatris[m - 1, n - 1] = list[sayac];
                        sayac++;
                    }
                }
                if (secondMatris.GetLength(0) > 2)
                {
                    determinant += katsayi * matrisConvertor(secondMatris, secondMatris.GetLength(0));
                }
                else
                {
                    determinant += katsayi * ikiBoyutu(secondMatris);
                }
            }
            return determinant;
        }
        else
        {
            return ikiBoyutu(firstMatris);
        }
    }

    static double matrisReturn(double[,] inMatris, double katsayi)
    {
        return katsayi * (inMatris[0, 0] * inMatris[1, 1] - inMatris[0, 1] * inMatris[1, 0]);
    }

    static double ikiBoyutu(double[,] inMatris)
    {
        return (inMatris[0, 0] * inMatris[1, 1] - inMatris[0, 1] * inMatris[1, 0]);
    }
}
