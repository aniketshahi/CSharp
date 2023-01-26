using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string age = Console.ReadLine();
            // Console.WriteLine(age);
            // Console.ReadLine();
            // int a = 6;
            // float b = 87.9F;
            // Console.WriteLine(a);
            // Console.WriteLine(b);
            // Console.WriteLine("Sum od a and b is " + (a + b));
            Console.Write("Enter your Name:");
            String name=Console.ReadLine();
            Console.Write("How many candies do you want:");
            String num=Console.ReadLine();
            Console.WriteLine("Hey "+name);
            Console.Write("Congo you got " +num );
            Console.WriteLine(" Candies");
        }
    }
}
