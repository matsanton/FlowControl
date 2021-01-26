// Lexicon NA21 - Övning 2: Flöde vid loopar och strängmanipulation
using System;
using System.Text.RegularExpressions;

namespace FlowControl
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                DisplayMainMenu();
                switch (Console.ReadLine())
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Discounts();
                        break;
                    case "2":
                        RepeatTenTimes();
                        break;
                    case "3":
                        WriteTheThird();
                        break;
                    case "4":
                        GroupCalculations();
                        break;
                    default:
                        Console.WriteLine("Felaktigt val: Försök igen.");
                        break;
                }
            }
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine("\n*** Huvudmeny ***");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("1. Ungdom eller pensionär");
            Console.WriteLine("2. Upprepa tio gånger");
            Console.WriteLine("3. Det tredje ordet");
            Console.WriteLine("4. Gruppkostnadsberäkning");
            Console.WriteLine("Tryck en siffra och sedan Enter:");
        }

        private static void GroupCalculations()
        {
            bool success = false;
            while (!success)
            {
                Console.WriteLine("Hur många är ni?");
                success = int.TryParse(Console.ReadLine(), out int noOfMembers);
                if (!success)
                {
                    Console.WriteLine("Felaktigt värde: Försök igen.");
                    continue;
                }
                int totalPrice = 0;
                for (int i = 0; i < noOfMembers; i++)
                {
                    Console.Write($"[Person {i+1}] ");
                    // Get price from every member in group and sum up the total
                    totalPrice += Discounts();
                }
                Console.WriteLine($"Grupp med {noOfMembers} medlemmar:");
                Console.WriteLine($"Totalkostnad: {totalPrice} kr");
            }
        }

        private static void WriteTheThird()
        {
            bool success = false;
            string theThird = "";
            Console.WriteLine("Skriv en text med minst tre ord:");
            while (!success)
            {
                string input = Console.ReadLine();
                Console.WriteLine($"Input string: [{input}]");

                // Replace all whitespace characters in input with a single space character
                // and remove leading and trailing spaces (Trim).
                string trimmed = Regex.Replace(input, @"\s+", " ").Trim(' ');
                Console.WriteLine($"Trimmed string: [{trimmed}]");
                // Split string with space character as delimiter and return an array with all words.
                var words = trimmed.Split(' ');
                if (words.Length >= 3)
                {
                    theThird = words[2];
                    success = true;

                    int i = 1;
                    foreach (string w in words)
                    {
                        Console.WriteLine($"[{i}] {w}");
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("Skriv minst tre ord. Försök igen:");
                    continue;
                }
            }
            Console.WriteLine($"Det tredje ordet är \"{theThird}\"");
        }

        private static void RepeatTenTimes()
        {
            Console.WriteLine("Ange text: ");
            string textToPrint = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i}. {textToPrint} ");
            }
            Console.WriteLine();
        }

        private static int Discounts()
        {
            bool success = false;
            int price = 120;
            while (!success)
            {
                Console.WriteLine("Ange ålder:");
                success = int.TryParse(Console.ReadLine(), out int age);
                if (!success)
                {
                    Console.WriteLine("Felaktigt värde: Försök igen.");
                    continue;
                }
                if ((age < 5) || (age > 100))
                {
                    Console.WriteLine("Gratis inträde!");
                    price = 0;
                } 
                else if (age < 20)
                {
                    Console.WriteLine("Ungdomspris: 80 kr");
                    price = 80;
                }
                else if (age > 64)
                {
                    Console.WriteLine("Pensionärspris: 90 kr");
                    price = 90;

                }
                else
                {
                    Console.WriteLine("Standardpris: 120 kr");
                    price = 120;
                }
            }
            return price;
        }
    }
}
