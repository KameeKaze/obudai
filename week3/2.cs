using System;

class Program
{
    static void Main()
    {
        string[] szinek = { "Kőr", "Káró", "Treff", "Pikk" };
        string[] magassagok = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A" };

        string[] kartyak = new string[szinek.Length * magassagok.Length];
        int index = 0;

        foreach (string szin in szinek)
        {
            foreach (string magassag in magassagok)
            {
                kartyak[index] = $"{szin} {magassag}";
                index++;
            }
        }

        FisherYatesKeveres(kartyak);

        Console.WriteLine("Keverse");
        foreach (string kartya in kartyak)
        {
            Console.WriteLine(kartya);
        }
    }

    static void FisherYatesKeveres(string[] pakli)
    {
        Random random = new Random();
        for (int i = pakli.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1); 
            string temp = pakli[i];
            pakli[i] = pakli[j];
            pakli[j] = temp;
        }
    }
}
