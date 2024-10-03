namespace HW
{
    internal class Program
    {
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            string[] words;
            words = new string[n];
            for (int i = 0; i < n; i++) {
                words[i] = Console.ReadLine();
            }

            string w = Console.ReadLine();
            char[] letters;
            for (int i = 0; i < n; i++)
            {
                w = w.Replace(words[i], "");
            }
            w = Reverse(w); // reverse search
            for (int i = 0; i < n; i++)
            {
                w = w.Replace(words[i], "");
            }
            w = Reverse(w); // get back original string
            Console.WriteLine(w);


        }
    }


}
