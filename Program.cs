using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new int[] { 1, 2, 3 };
            //int[] numbers = new int[5];
            //numbers[0] = 4;
            //numbers[1] = 8;
            //numbers[2] = 16;
            //numbers[3] = 32;
            //numbers[4] = 64;
            //Console.WriteLine(numbers.Length);

            string[] names = new string[] { "Reno", "Tomo", "Ruzica", "Nikola" };

            // Loop over all names in array.
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}
            //*****************************
            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}
            //******************************

            string someString = "I am Renato Lulic. I'm from city Djakovo in Croatia and I'd like to learn c#, python etc.";

            char[] charsInSomeString = someString.ToCharArray();
            //Reverse char array
            Array.Reverse(charsInSomeString);

            foreach (char c in charsInSomeString)
            {
                Console.Write(c);
            }
        }
    }
}
