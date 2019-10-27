using System;

namespace challenge_calculator
{
    public class ConsoleApp
    {
        private static StringCalculator stringCalculator = new StringCalculator();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the string calculator! Enter Q to quit at anytime.");

            // Continuous loop to test more easily on the "frontend"
            while(true) {
                Console.WriteLine("\nPlease enter numbers you wish to add, separated by commas: ");

                string userInput = Console.ReadLine();
                if(userInput.ToUpper() == "Q")
                    break;
                int answer = stringCalculator.AddString(userInput);

                Console.WriteLine($"Answer to {userInput} is {answer}.");
            }
        }
    }

    public class StringCalculator : ICalculator
    {
        // Split the string across the comma, and try to add the number to our "sum" that we will return.
        public int AddString(string inputString)
        {
            int sum = 0;
            string[] numbers = inputString.Split(","); 

            foreach (string number in numbers) {
                try { 
                    sum += Convert.ToInt32(number); 
                }
                catch(FormatException) { 
                    sum += 0; 
                }
            }

            return sum;
        }
    }
}
