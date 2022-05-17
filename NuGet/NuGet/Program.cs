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
                default:
                    return "NoErrorFound/UnknownError:";
                    
            }
        }

    }

}
