using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
namespace DeterminantBulma
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("3x3 boyutundaki bir A matrisinin determinantını, kofaktör yönetemiyle bulma programına hoş geldiniz.\nDevam etmek için bir tuşa basınız!");
            Console.ReadKey();
            while (true)
            {
            Don:
                double determinant = 0;
                Console.Clear();
                Console.WriteLine("Lütfen A matrisinizi giriniz.");
                double[,] matris = new double[3, 3];
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        Console.Write("A{0}{1} = ", i, j);
                        try
                        {
                            matris[i - 1, j - 1] = double.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Hatanız : {0} Tekrardan matrisi girmek için herhangi bir tuşa basınız!", e.Message);
                            Console.ReadKey();
                            goto Don;
                        }
                    }
                }
                Console.WriteLine("----------------------------");
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        Console.Write(matris[i - 1, j - 1] + " ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("----------------------------\nMatrisiniz doğru mu?\nDoğruysa ---> 2 dışında herhangi bir tuş Yanlış ise ---> 2\n----------------------------");
                if (Console.ReadLine() == "2")
                    goto Don;
                List<double> list = new List<double>();
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        if (i == 1)
                        {
                            double katsayi = matris[i - 1, j - 1];
                            for (int k = 1; k <= 3; k++)
                            {
                                for (int m = 1; m <= 3; m++)
                                {
                                    if (k != i && m != j)
                                        list.Add(matris[k - 1, m - 1]);
                                }
                            }
                            double Cij = (double)(Math.Pow(-1, i + j)) * katsayi * ((list[0] * list[3]) - (list[1] * list[2]));
                            determinant += Cij;
                            list.Clear();
                        }
                    }
                }
                Console.WriteLine("A matrisinizin determinantı, det(A) = {0}", determinant);
                Console.WriteLine("\n\nUygulamadan çıkmak için klavyeden 'E || e' tuşuna basınız! Devam etmek için 'E || e' dışında herhangi bir tuşa basınız!");
                char c = Console.ReadKey().KeyChar;
                if (c == 'E' || c == 'e')
                    break;
            }
            Console.Clear();
            Console.WriteLine("Ugulamadan çıkış yaptınız!");
            Console.ReadKey();
        }
    }
}