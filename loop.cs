using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user to input a number
            Console.WriteLine("Enter a number: ");
            int? num1 = Convert.ToInt32(Console.ReadLine());

            // Check for null values before performing calculations
            if (num1 != null)
            {
                // Display the multiplication table of the number
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(num1 + " x " + i + " = " + (num1 * i));
                }
            }
            else
            {
                // Handle null values
                Console.WriteLine("The input value is null.");
            }

            // Wait for the user to press a key before closing the console window
            Console.ReadKey();
        }
    }
}
