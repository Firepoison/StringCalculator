using System;

namespace challenge_calculator
{
    public class ConsoleApp
    {
        private static StringCalculator stringCalculator = new StringCalculator();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the string calculator!");
            Console.WriteLine("\n Please enter the string you want to calculate: ");

            string userInput = Console.ReadLine();
            int answer = stringCalculator.AddString(userInput);

            Console.WriteLine($"Answer to {userInput} is {answer}.");
        }
    }

    public class StringCalculator : ICalculator
    {
        public int AddString(string inputString)
        {
            throw new NotImplementedException();
        }
    }
}
