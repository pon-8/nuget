using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace NuGet
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = 0;
            int loop = 0;

            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "--interactive":
                        Console.WriteLine("Hello!");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        Console.WriteLine("How many persons should I print?");
                        try
                        {
                            amount = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            errorMessage(2);
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case "--personcount":
                        Console.WriteLine("Hello!");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        try
                        {
                            amount = Convert.ToInt32(args[1]);
                        }
                        catch
                        {
                            errorMessage(1);
                        }
                        break;
                    default:
                        Console.WriteLine("Hello!");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        errorMessage(1);
                        break;
                }
            } else
            {
                errorMessage(0);
            }

            List<string> persons = GeneratePerson(amount);
            List<string> addresses = GenerateAddress(amount);
            List<string> passports = GeneratePassport(amount);
            List<string> phones = GeneratePhone(amount);
            List<string> formatted = Format(persons, addresses, passports, phones);

            Console.WriteLine($"generating {amount} people");
            Console.WriteLine();
            Thread.Sleep(1000);

            Output(formatted);
        }
        public static List<string> GeneratePerson(int amount)
        {
            List<string> output = new List<string>();

            for (int i = 0; i < amount; i++)
            {
                output.Add(Faker.Name.FullName());
            }

            return output;
        }
        public static List<string> GenerateAddress(int amount)
        {
            List<string> street = new List<string>();
            List<string> city = new List<string>();
            List<string> country = new List<string>();

            for (int i = 0; i < amount; i++)
            {
                street.Add(Faker.Address.StreetAddress());
                city.Add(Faker.Address.City());
                country.Add(Faker.Address.Country());
            }

            List<string> output = FormatAddress(street, city, country);

            return output;
        }
        public static List<string> FormatAddress(List<string> street, List<string> city, List<string> country)
        {
            List<string> output = new List<string>();

            for (int i = 0; i < street.Count; i++)
            {
                output.Add($"{street[i]}, {city[i]}, {country[i]}");
            }

            return output;
        }
        public static List <string> GeneratePassport(int amount)
        {
            List<string> output = new List<string>();

            for (int i = 0; i < amount; i++)
            {
                output.Add(Faker.Identification.UsPassportNumber());
            }

            return output;
        }
        public static List<string> GeneratePhone(int amount)
        {
            List<string> output = new List<string>();

            for (int i = 0; i < amount; i++)
            {
                output.Add(Faker.Phone.Number());
            }

            return output;
        }
        public static List<string> Format(List<string> person, List<string> address, List<string> passport, List<string> phone)
        {
            List<string> output = new List<string>();
            
            output.Add($"{"Number", -10}{"Name",-40}{"Address",-85}{"Passport Number",-25}{"Phone Number"}");
            output.Add("");
            
            for (int i = 0; i < person.Count; i++)
            {
                output.Add($"{i + 1, -10}{person[i],-40}{address[i],-85}{passport[i],-25}{phone[i]}");
            }

            return output;
        }
        public static void Output(List<string> input)
        {
            foreach (string line in input)
            {
                Console.WriteLine(line);
                Thread.Sleep(20);
            }
        }
        static public void errorMessage(int errorNum)
        {
            Thread.Sleep(1000);
            Console.WriteLine(errorSwitch(errorNum));
            Thread.Sleep(1000);
            Console.WriteLine("Terminating Program");
            Thread.Sleep(2000);
            Environment.Exit(errorNum);
        }
        static public string errorSwitch(int errorNum)
        {
            switch (errorNum)
            {
                case 0:
                    return "No startup arguments were given:";
                case 1:
                    return "Invalid startup arguments:";
                case 2:
                    return "not an interger:";
                default:
                    return "NoErrorFound/UnknownError:";
                    
            }
        }

    }

}
