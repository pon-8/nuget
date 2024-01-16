using System;

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
                        errorMessage(1);
                        break;
                }
            } else
            {
                errorMessage(0);
            }

            Console.WriteLine($"{"Name", -20} {"Address",-25} {"Passport Number",-15} {"Phone Number",-15} ");
            while (loop < amount)
            {
                Console.WriteLine($"{Faker.Name.FullName(),-20}{Faker.Address.StreetAddress()}, {Faker.Address.City()}, {Faker.Address.Country(),-25}{Faker.Identification.UsPassportNumber(),-15}{Faker.Phone.Number(),-15}");
                loop++;
            }
        }


        /*
        static void Main(string[] args)
        {
            int amount = 0;
            int loop = 0;

            if (args.Length != 0)
            {
                if (args[0] == "interactive")
                {
                    Console.WriteLine("How many persons should I print?");
                    amount = Convert.ToInt32(Console.ReadLine());
                } 
                else if (args[0] == "personcount")
                {
                    try
                    {
                        amount = Convert.ToInt32(args[1]);
                    }
                    catch
                    {
                        errorMessage(1);
                    }
                }
            } 
            else
            {
                errorMessage(0);
            }

            while (loop < amount)
            {
                Console.WriteLine(Faker.Name.FullName());
                Console.Write(Faker.Address.StreetAddress() + ", ");
                Console.Write(Faker.Address.City() + ", ");
                Console.WriteLine(Faker.Address.Country());
                Console.WriteLine(Faker.Identification.UsPassportNumber());
                Console.WriteLine(Faker.Identification.SocialSecurityNumber());
                Console.WriteLine();
                Console.WriteLine();
                loop++;
            }
        }
        */
        static public void errorMessage(int errorNum)
        {
            Console.WriteLine(errorSwitch(errorNum));
            Console.WriteLine("Terminating Program");
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
