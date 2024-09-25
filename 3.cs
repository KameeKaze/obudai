using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> szavak = new List<string>();
        string szo;

        Console.WriteLine("szo");

        while (true)
        {
            szo = Console.ReadLine();
            if (szo == "STOP")
            {
                break;
            }
            szavak.Add(szo);
        }

        // Kérjünk be egy új szót a felhasználótól
        Console.WriteLine("szo");
        string keresettSzo = Console.ReadLine();

        // Benne van-e a gyűjteményben?
        int index = szavak.IndexOf(keresettSzo);
        if (index >= 0)
        {
            Console.WriteLine($"bene {index + 1}");
        }
        else
        {
            Console.WriteLine("nincs benne");
        }
    }
}
