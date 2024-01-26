using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Runtime.InteropServices;

namespace NuGet
{
    class Program
    {
        #region main
        static void Main(string[] args)
        {
            #region variables
            // common variables to program
            int amount = 0;
            #endregion
            #region argument detection
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    // Interactive mode. Ask user amount to generate
                    case "--interactive":
                        Console.WriteLine("Hello!");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        Console.WriteLine("How many persons should I print?");
                        try
                        {
                            // Read user input
                            amount = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            // faulty input
                            errorMessage(2);
                        }
                        Console.WriteLine();
                        break;
                    // Personcount mode. Predefined parameters
                    case "--personcount":
                        Console.WriteLine("Hello!");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        try
                        {
                            // translate arguments to integer
                            amount = Convert.ToInt32(args[1]);
                        }
                        catch
                        {
                            // faulty parameters
                            errorMessage(1);
                        }
                        break;
                    default:
                        // incorrect parameters defined
                        Console.WriteLine("Hello!");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        errorMessage(1);
                        break;
                }
            } else
            {
                // no parameters given
                Console.WriteLine("Hello!");
                Console.WriteLine();
                Thread.Sleep(1000);
                errorMessage(0);
            }
            #endregion
            #region generation process
            // generate amount of people based on input
            List<string> persons = GeneratePerson(amount);
            List<string> addresses = GenerateAddress(amount);
            List<string> passports = GeneratePassport(amount);
            List<string> phones = GeneratePhone(amount);
            List<string> formatted = Format(persons, addresses, passports, phones);
            #endregion
            #region output
            // print people
            Console.WriteLine($"generating {amount} people");
            Console.WriteLine();
            Thread.Sleep(1000);
            Output(formatted);
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Printing complete");
            #endregion

            //end program
            TerminateProgram();
        }
        #endregion
        #region output
        // print the formatted text for each person
        public static void Output(List<string> input)
        {
            if (input.Count < 200)
            {
                foreach (string line in input)
                {
                    Console.WriteLine(line);
                    Thread.Sleep(20);
                }
            } else
            {
                foreach (string line in input)
                {
                    Console.WriteLine(line);
                }
            }
        }
        #endregion
        #region generation
        // generators for each person's attributes
        public static List<string> GeneratePerson(int amount)
        {
            //list for storing names
            List<string> output = new List<string>();

            // generate names based on given input and add to the list
            for (int i = 0; i < amount; i++)
            {
                output.Add(Faker.Name.FullName());
            }

            // return list of names
            return output;
        }
        public static List<string> GenerateAddress(int amount)
        {
            // lists for storing different aspects of addresses
            List<string> street = new List<string>();
            List<string> city = new List<string>();
            List<string> country = new List<string>();

            // generate each part of an address and add them to the lists
            for (int i = 0; i < amount; i++)
            {
                street.Add(Faker.Address.StreetAddress());
                city.Add(Faker.Address.City());
                country.Add(Faker.Address.Country());
            }

            // format addresses into single strings and store in list
            List<string> output = FormatAddress(street, city, country);

            // return formatted, single line addresses
            return output;
        }
        public static List <string> GeneratePassport(int amount)
        {
            // list for storing passport numbers
            List<string> output = new List<string>();

            // create passports with amount based on input and add to list
            for (int i = 0; i < amount; i++)
            {
                output.Add(Faker.Identification.UsPassportNumber());
            }
            
            // return list of addresses
            return output;
        }
        public static List<string> GeneratePhone(int amount)
        {
            // list for phone numbers
            List<string> output = new List<string>();

            // generate phone numbers ´with amount based on input and  add to list
            for (int i = 0; i < amount; i++)
            {
                output.Add(Faker.Phone.Number());
            }

            // return list of addresses
            return output;
        }
        #endregion
        #region formatting
        // formatters to transform information into readable text
        public static List<string> FormatAddress(List<string> street, List<string> city, List<string> country)
        {
            // list to store formatted addresses
            List<string> output = new List<string>();

            // read all address lists and add to output list in a single string per address
            for (int i = 0; i < street.Count; i++)
            {
                output.Add($"{street[i]}, {city[i]}, {country[i]}");
            }

            // return formatted addresses list
            return output;
        }
        public static List<string> Format(List<string> person, List<string> address, List<string> passport, List<string> phone)
        {
            // list to store persons in a formatted string with spacing for easy reading
            List<string> output = new List<string>();
            
            // add first line to output list with headers for each column
            output.Add($"{"Number", -10}{"Name",-40}{"Address",-85}{"Passport Number",-25}{"Phone Number"}");
            // add an empty string to list to create sapcing between hearders and information
            output.Add("");
            
            // Convert each person and their attributes to single lines with spacing for easier reading
            for (int i = 0; i < person.Count; i++)
            {
                output.Add($"{i + 1, -10}{person[i],-40}{address[i],-85}{passport[i],-25}{phone[i]}");
            }

            // return formatted list of strings
            return output;
        }
        #endregion
        #region error handling and program termination
        // send message to user describing error and/or terminate program
        static public void errorMessage(int errorNum)
        {
            Thread.Sleep(1000);

            // search and print error information from switch
            Console.WriteLine(errorSwitch(errorNum));

            //terminate program
            TerminateProgram(errorNum);
        }
        static public string errorSwitch(int errorNum)
        {
            // switch for storing each errors description
            switch (errorNum)
            {
                case 0:
                    return "No startup arguments were given:" + "\ntry using \"--personcount [AMOUNT]\" or \"--interactive\"";
                case 1:
                    return "Invalid startup arguments:" + "\ntry using \"--personcount [AMOUNT]\" or \"--interactive\"";
                case 2:
                    return "not an interger:";
                default:
                    return "NoErrorFound/UnknownError:";    
            }
        }
        static public void TerminateProgram([Optional] int errorNum)
        {
            // send message to user informing of program termination
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Terminating Program");
            Thread.Sleep(2000);

            // terminate program
            Environment.Exit(errorNum);
        }
        #endregion
    }
}