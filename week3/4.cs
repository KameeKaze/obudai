using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> nevek = new List<string>();
        List<int> eletkorok = new List<int>();
        List<bool> tapasztalatok = new List<bool>();

        while (true)
        {
            Console.WriteLine("nev");
            string nev = Console.ReadLine();
            if (string.IsNullOrEmpty(nev))
            {
                break;
            }
            nevek.Add(nev);

            Console.WriteLine("kor");
            int eletkor = int.Parse(Console.ReadLine());
            eletkorok.Add(eletkor);

            Console.WriteLine("programoz");
            string tapasztalatValasz = Console.ReadLine().ToLower();
            bool tapasztalat = tapasztalatValasz == "igen";
            tapasztalatok.Add(tapasztalat);
        }

        int osszesKor = 0;
        foreach (int kor in eletkorok)
        {
            osszesKor += kor;
        }
        double atlageletkor = (double)osszesKor / eletkorok.Count;
        Console.WriteLine($"atlageletkor {atlageletkor:F2}");

        int osszesKorTapasztalatNelkul = 0;
        int tapasztalatNelkuliekSzama = 0;
        for (int i = 0; i < tapasztalatok.Count; i++)
        {
            if (!tapasztalatok[i])
            {
                osszesKorTapasztalatNelkul += eletkorok[i];
                tapasztalatNelkuliekSzama++;
            }
        }
        if (tapasztalatNelkuliekSzama > 0)
        {
            double atlagTapasztalatNelkul = (double)osszesKorTapasztalatNelkul / tapasztalatNelkuliekSzama;
            Console.WriteLine($"tapasztalat nelkul: {atlagTapasztalatNelkul:F2}");
        }


        int legidosebbKor = 0;
        string legidosebbNev = "";
        for (int i = 0; i < tapasztalatok.Count; i++)
        {
            if (tapasztalatok[i] && eletkorok[i] > legidosebbKor)
            {
                legidosebbKor = eletkorok[i];
                legidosebbNev = nevek[i];
            }
        }

        if (legidosebbKor != 0)
        {
            Console.WriteLine($"boomer {legidosebbNev} {legidosebbKor}");
        }
        else
        {
            Console.WriteLine("nope");
        }
    }
}
