using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("\nPlease enter numbers you wish to add, separated by commas or a new line. \nIf you would like to set a custom separator, please use // followed by the delimiter you wish: ");

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
        private static string delimiterNotation = "//";
        // Split the string across the comma, and try to add the number to our "sum" that we will return.
        public int AddString(string inputString)
        {
            int sum = 0;

            // Check if we are getting a custom delimiter.
            inputString = this.CreateDelimiter(inputString);

            string[] numbers = inputString.Split(","); 

            List<int> validNumbers = this.ValidateNumbers(numbers);
            sum = validNumbers.Sum();

            return sum;
        }

        // Check for custom delimiters by "//" and pass them as delimiters for mathematic functions to use.
        public String CreateDelimiter(string inputString)
        {   
            List<String> delimiters = new List<String>() {"\n"};
            string convertedInputString = inputString;

            
            if (inputString.StartsWith(delimiterNotation))
            {
                string newDelimiter = "";
                int delimiterSectionIndex = inputString.IndexOf("\n") - 1;
                convertedInputString = inputString.Substring(delimiterSectionIndex);

                if (inputString[2] == '[')
                {
                    int delimiterEndIndex = inputString.IndexOf(']');
                    newDelimiter = inputString.Substring(3, delimiterEndIndex - 3);
                    delimiters.Add(newDelimiter);

                    inputString = inputString.Remove(2,newDelimiter.Length + 2);
                }
                else
                {
                    newDelimiter = inputString[delimiterSectionIndex].ToString();
                    delimiters.Add(newDelimiter);

                    inputString = inputString.Remove(2, 1);
                }
            }

            foreach (string delimiter in delimiters)
            {
                convertedInputString = convertedInputString.Replace(delimiter, ",");
            }

            return convertedInputString;
        }

        // Check to see each number inside our new string array is "valid".
        public List<int> ValidateNumbers(string[] stringNumbers)
        {
            List<int> numbers = new List<int>();

            // Loop thru each part of the the string, to check the elements if they're numbers we accept.
            foreach (string element in stringNumbers) {
                int number;
                
                try { 
                    number = Convert.ToInt32(element);    
                }
                catch(FormatException) { 
                    number = 0;
                }

                if (number < 0)
                    throw new ArgumentException($"Cannot use negative numbers. {number} is invalid.");
                else if(number > 1000)
                    number = 0;

                numbers.Add(number);
            }

            return numbers;
        }
    }
}
