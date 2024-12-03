using System;
using System.Diagnostics.Metrics;
using System.IO;
using static NetflixZH.Enums;
namespace NetflixZH
{
    internal class Dataset
    {

        private List<User> users = [];


        public Dataset(string fileName)
        {
            string[] file = File.ReadAllLines(fileName);
            for (int i = 1; i < file.Length; i++)
            {
                users.Add(new User(file[i]));
            }

        }

        public int NumberOfUsers { get { return users.Count; } }


        public float AverageMonthlyRevenue(Enums.SubscriptionType subscriptionType)
        {
            float a = 0;
            int c = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].SubscriptionType == subscriptionType)
                {
                    a += users[i].Revenue;
                    c++;
                }
            }
            return a/c;

        }

        public List<User> CollectNonPayers(int days)
        {
             List<User> u = [];

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].DaysSinceLastPayment() >= days)
                {
                    u.Add(users[i]);
                }
            }
            return u;
        }

        public string MaximalAgeData()
        {
            int maxID = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Age > users[maxID].Age)
                {
                    maxID = i;
                }
            }
            return users[maxID].DataAsText();
        }

        public string DistributionOfDeviceType(Enums.DeviceType deviceType)
        {
            string r = $"-- Distribution of {deviceType} --\n";
            Console.WriteLine(deviceType);

            float all = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].DeviceType == deviceType)
                {
                    all++;
                }
            }

            foreach (Enums.CountryName country in Enum.GetValues(typeof(Enums.CountryName)))
            {
                float c = 0;
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Country == country && users[i].DeviceType == deviceType)
                    {
                        c ++;
                    }
                }

                r += $"{country}: {(c/all)*100:F2}%\n";
                
            }

            return r;
        }
    }
}
