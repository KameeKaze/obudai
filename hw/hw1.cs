namespace HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            string[] words;
            words = new string[n];
            for (int i = 0; i < n; i++)
            {
                words[i] = Console.ReadLine();
            }
 
            string w = Console.ReadLine();
            for (int i = 0; i < n; i++){
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (w.Contains(words[i][j]))
                    {
                        w = w.Remove(w.IndexOf(words[i][j]),1);
                    }
                }
            }
 
            Console.WriteLine(w);
 
 
        }
    }
 
}
