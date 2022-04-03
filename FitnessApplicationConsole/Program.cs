using BL.Fitness;
using BL.Fitness.Controller;
using System;

namespace FitnessApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to FittnessApplicationConsole!\n Enter your name:");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender:");
                var gender = Console.ReadLine();
                DateTime birthday = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                userController.SetNewUserData(gender, birthday, weight, height);
            }

            Console.WriteLine(userController.CurrentUser.ToString());
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthday;
            while (true)
            {
                Console.WriteLine("Enter your birthday:");
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                    return birthday;
                else
                    Console.WriteLine("Incorrect date!");
            }
        }

        private static double ParseDouble(string param)
        {
            while (true)
            {
                Console.WriteLine($"Enter your {param}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else
                    Console.WriteLine($"Incorrect {param}!");
            }
        }
    }
}
