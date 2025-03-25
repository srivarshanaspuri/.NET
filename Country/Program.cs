using System;
using System.Collections.Generic;

public class CountryStore
{
    private HashSet<string> H1;

    public CountryStore()
    {
        H1 = new HashSet<string>();
    }

    // Method to add a country to the HashSet
    public void StoreCountryNames(string countryName)
    {
        H1.Add(countryName);
    }

    // Method to retrieve a country from the HashSet
    public string RetrieveCountry(string countryName)
    {
        foreach (string country in H1)
        {
            if (country.Equals(countryName, StringComparison.OrdinalIgnoreCase))
            {
                return country;
            }
        }
        return null;
    }

   
    public void DisplayCountries()
    {
        Console.WriteLine("Countries in HashSet:");
        foreach (string country in H1)
        {
            Console.WriteLine(country);
        }
    }

    public static void Main(string[] args)
    {
        CountryStore countryStore = new CountryStore();

       
        countryStore.StoreCountryNames("India");
        countryStore.StoreCountryNames("USA");
        countryStore.StoreCountryNames("Canada");

       
        countryStore.DisplayCountries();

        
        Console.WriteLine("Enter a country name to search:");
        string countryNameToSearch = Console.ReadLine();

       
        string country = countryStore.RetrieveCountry(countryNameToSearch);
        if (country != null)
        {
            Console.WriteLine($"Country found: {country}");
        }
        else
        {
            Console.WriteLine("Country not found.");
        }
    }
}
