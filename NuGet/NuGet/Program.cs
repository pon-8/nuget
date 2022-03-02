using System;

namespace NuGet
{
    class Program
    {
        static void Main(string[] args)
        {
            int loop = 0;

            while (loop < 3)
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

    }

}
