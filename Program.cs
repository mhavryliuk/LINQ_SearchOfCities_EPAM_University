using System;
using System.Collections.Generic;
using System.Linq;

/* Write a program in C# Sharp to find the string which starts and ends with a specific character.
 * Test Data:
 * The cities are: 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABUDHABI','PARIS'
 * Input starting character for the string: A
 * Input ending character for the string: M
 * Expected Output: The city starting with A and ending with M is : AMSTERDAM 
 *
 * Напишите программу на C#, чтобы найти строку, которая начинается и заканчивается определенным символом.
 * Тестовые данные:
 * Города: «ROME», «LONDON», «NAIROBI», «CALIFORNIA», «ZURICH», «NEW DELHI», «AMSTERDAM», «ABUDHABI», «PARIS»
 * Начальный символ для строки: A
 * Символ окончания строки: M
 * Ожидаемый результат: Городом, начинающимся с A и заканчивающимся на M, является: AMSTERDAM */

namespace _20180327_Task3_LINQ1
{
    internal class Program
    {
        private static void Main()
        {
            string[] cities = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };

            // Output to the console list of cities.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("List of cities available for search:");
            Console.ForegroundColor = ConsoleColor.Gray;

            foreach (var city in cities)
            {
                Console.WriteLine("> " + city);
            }
            Console.WriteLine();

            // Search of cities.
            const string toTryOneMoreTime = "Y";
            do
            {
                SearchСity(cities);

                Console.Write("\n\nPress [Y] to continue or any other button to exit: ");
            } while ((Console.ReadLine()?.ToUpper() ?? throw new InvalidOperationException("N")).Equals(toTryOneMoreTime));

            Console.ReadKey();
        }

        private static void SearchСity(IEnumerable<string> cities)
        {
            // Request the first and last letters of the city.
            char firsLetter, lastLetter;

            do
            {
                Console.Write("Enter the first letter of the city: ");
            } while (!char.TryParse(Console.ReadLine()?.ToUpper(), out firsLetter) || firsLetter < 'A' || firsLetter > 'Z');

            do
            {
                Console.Write("Enter the last letter of the city: ");
            } while (!char.TryParse(Console.ReadLine()?.ToUpper(), out lastLetter) || lastLetter < 'A' || lastLetter > 'Z');

            // Search for the city where the first and last letters are the same as the specified users.
            var answer = from city in cities
                         where city.StartsWith(firsLetter.ToString())
                         where city.EndsWith(lastLetter.ToString())
                         select city;

            // Output the result to the console.
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var element in answer)
            {
                Console.Write($"\nThe city that starting on {firsLetter} and ending on {lastLetter} is : {element}");
            }
            Console.ResetColor();
        }
    }
}