// Övning 2
using System;

namespace FlowControl
{
    class Program
    {
        static void Main(string[] args)
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
                        UngdomellerPension();
                        break;
                    case "2":
                        RepeatTenTimes();
                        break;
                    case "3":
                        WriteTheThird();
                        break;
                    default:
                        Console.WriteLine("Felaktigt val: Försök igen.");
                        break;
                }
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
                var words = input.Split(" ");
                if (words.Length >= 3)
                {
                    theThird = words[2];
                    success = true;
                }
                else
                {
                    Console.WriteLine("Skriv minst tre ord. Försök igen:");
                    continue;
                }
            }
            Console.WriteLine($"Det tredje ordet är {theThird}");

        }

        private static void RepeatTenTimes()
        {
            Console.WriteLine("Ange text: ");
            string textToPrint = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i}. {textToPrint}");
            }
            Console.WriteLine();
        }


        private static void UngdomellerPension()
        {
            bool success = false;
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
                } 
                else if (age < 20)
                {
                    Console.WriteLine("Ungdomspris: 80 kr");
                }
                else if (age > 64)
                {
                    Console.WriteLine("Pensionärspris: 90 kr");
                }
                else
                {
                    Console.WriteLine("Standardpris: 120 kr");
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
            Console.WriteLine("Tryck en siffra och sedan Enter:");
        }
    }
}
