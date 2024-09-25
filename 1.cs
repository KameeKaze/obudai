using System;

class Kartyak
{
    static void Main()
    {
        string[] szinek = { "Kőr", "Káró", "Treff", "Pikk" };
        string[] magassagok = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jumbó", "Dáma", "Király", "Ász" };

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

        foreach (string kartya in kartyak)
        {
            Console.WriteLine(kartyak);
        }
    }
}
