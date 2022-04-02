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
            Console.WriteLine("Enter your gender:");
            var gender = Console.ReadLine();
            Console.WriteLine("Enter your birthday:");
            var birthday = DateTime.Parse(Console.ReadLine());  //TODO: try parse
            Console.WriteLine("Enter your weight:");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your height:");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();
        }
    }
}
