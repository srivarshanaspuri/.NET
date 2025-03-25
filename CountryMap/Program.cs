using System;
using System.Collections.Generic;

namespace CountryMap
{
    class CountryCapitalMap
    {
        private Dictionary<string, string> countriesAndCapitals = new Dictionary<string, string>();

        public void StoreCountryCapital(string country, string capital)
        {
            countriesAndCapitals[country] = capital;
        }

        public string RetrieveCapital(string country)
        {
            if (countriesAndCapitals.ContainsKey(country))
            {
                return countriesAndCapitals[country];
            }
            else
            {
                return "Country not found";
            }
        }

        public string RetrieveCountry(string capital)
        {
            foreach (var entry in countriesAndCapitals)
            {
                if (entry.Value == capital)
                {
                    return entry.Key;
                }
            }
            return "Capital not found";
        }

        public Dictionary<string, string> CreateCapitalToCountryMap()
        {
            Dictionary<string, string> capitalToCountryMap = new Dictionary<string, string>();
            foreach (var entry in countriesAndCapitals)
            {
                capitalToCountryMap[entry.Value] = entry.Key;
            }
            return capitalToCountryMap;
        }

        public List<string> GetAllCountries()
        {
            return new List<string>(countriesAndCapitals.Keys);
        }

        static void Main()
        {
            CountryCapitalMap map = new CountryCapitalMap();

            map.StoreCountryCapital("India", "Delhi");
            map.StoreCountryCapital("Japan", "Tokyo");

            Console.WriteLine("Capital of India: " + map.RetrieveCapital("India"));
            Console.WriteLine("Country for capital Tokyo: " + map.RetrieveCountry("Tokyo"));

            Dictionary<string, string> capitalToCountryMap = map.CreateCapitalToCountryMap();
            Console.WriteLine("\nCapital to Country Map:");
            foreach (var entry in capitalToCountryMap)
            {
                Console.WriteLine(entry.Key + " -> " + entry.Value);
            }

            List<string> countries = map.GetAllCountries();
            Console.WriteLine("\nList of all countries:");
            foreach (var country in countries)
            {
                Console.WriteLine(country);
            }
        }
    }
}
