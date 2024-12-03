namespace NetflixZH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dataset data = null;
            Console.WriteLine(Math.Round(3213.32121213,2));

            bool run = true;
            while (run)
            {
                Console.WriteLine("1. Load data file");
                Console.WriteLine("2. Get average monthly revenue");
                Console.WriteLine("3. List non-paying users");
                Console.WriteLine("4. Show distribution of devices");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        Console.Write("Filename: ");
                        string filename = Console.ReadLine();
                        data = new Dataset(filename); // netflix_data.csv
                        Console.WriteLine("Done!");

                        break;
                    case 2:
                        Console.Write("SubscriptionType: ");
                        string revenue = Console.ReadLine();
                        Enums.SubscriptionType type = ((Enums.SubscriptionType)Enum.Parse(typeof(Enums.SubscriptionType), revenue));
                        Console.WriteLine(data.AverageMonthlyRevenue(type));
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Write("Not Payed since: ");
                        int since = int.Parse(Console.ReadLine());
                        List<User> u = data.CollectNonPayers(since);
                        foreach (User user in u)
                        {
                            Console.WriteLine(user.DataAsText());
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Device type: ");
                        string device = Console.ReadLine();
                        Enums.DeviceType devicetype = ((Enums.DeviceType)Enum.Parse(typeof(Enums.DeviceType), device));
                        Console.WriteLine(data.DistributionOfDeviceType(devicetype));
                        Console.WriteLine();
                        break;
                    case 5:
                        run = false;
                        break;


                }
            }

        }
    }
}
