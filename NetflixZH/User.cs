using System;
using static NetflixZH.Enums;


namespace NetflixZH
{
    internal class User
    {

        private int id;
        private Enums.SubscriptionType subscriptionType;
        private int revenue;
        private DateTime join;
        private DateTime payment;
        private Enums.CountryName country;
        private int age;
        private Enums.DeviceType deviceType;

        public int ID => id;
        public Enums.SubscriptionType SubscriptionType => subscriptionType;
        public int Revenue => revenue;
        public DateTime Join => join;
        public DateTime Payment => payment;
        public Enums.CountryName Country => country;
        public int Age => age;
        public Enums.DeviceType DeviceType => deviceType;

        public User(string input)
        {
            string[] headers = input.Split(',');

            id = int.Parse(headers[0]);
            subscriptionType = (Enums.SubscriptionType)Enum.Parse(typeof(Enums.SubscriptionType), headers[1]);
            revenue = int.Parse(headers[2]);
            join = DateTime.Parse(headers[3]);
            payment = DateTime.Parse(headers[4]);
            country = (Enums.CountryName)Enum.Parse(typeof(Enums.CountryName), headers[5]);
            age = int.Parse(headers[6]);
            deviceType = (Enums.DeviceType)Enum.Parse(typeof(Enums.DeviceType), headers[7]);
        }

        public int SubscriptionInDays()
        {
            return (payment- join).Days;
        }

        public int DaysSinceLastPayment()
        {
            return (DateTime.Now-payment).Days;
        }

        public string DataAsText()
        {
            return $"User ID {id} ({country}, {subscriptionType}, {deviceType}). Subscription: {SubscriptionInDays()}, last payment: {DaysSinceLastPayment()}"; 
        }
    }
}
