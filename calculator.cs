using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            // Ask the user to input two numbers
            Console.WriteLine("Enter the first number: ");
            double? num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            double? num2 = Convert.ToDouble(Console.ReadLine());

            // Check for null values before performing calculations
            if (num1 != null && num2 != null)
            {
                // Display the addition, subtraction, multiplication, and division of the two numbers
                Console.WriteLine("Addition: " + (num1 + num2));
                Console.WriteLine("Subtraction: " + (num1 - num2));
                Console.WriteLine("Multiplication: " + (num1 * num2));
                Console.WriteLine("Division: " + (num1 / num2));
            }
            else
            {
                // Handle null values
                Console.WriteLine("One or both input values are null.");
            }

            // Wait for the user to press a key before closing the console window
            Console.ReadKey();
        }
    }
}