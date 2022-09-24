using System;
using System.Net;

namespace MonoScraper
{
    class Program
    {
        static void Main(string[] args)
        {

            userInput();   
        }

        static double GetBtcPrice()
        {
            string json;

            using (var web = new WebClient()){
                var url = @"https://api.coindesk.com/v1/bpi/currentprice.json";
                json = web.DownloadString(url);
            }

            // JSON response
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            double btcPrice = obj.bpi.USD.rate_float.Value;

            return btcPrice;
        }

        static double Converter(int usd)
        {
            var bPrice = usd / GetBtcPrice();
            
            return bPrice;
        }

        static void userInput()
        {
            welcomeAscii();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[1] - Get Real-time Bitcoin price\n[2] - USD to BTC Converter\n");
            Console.ResetColor();
            Console.WriteLine("\nChoose option: ");
            var answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.Write("...\r");
                try
                {
                    var bPrice = GetBtcPrice();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Current BTC price: $" + bPrice + "\n");
                    Console.ResetColor();
                    exitOrContinue();
                }
                catch (Exception)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong!\nCan't get Bitcoin price...");
                    Console.ResetColor();
                    exitOrContinue();
                }

            }
            else if (answer == "2")
            {
                Console.Write("\nHow much USD to convert to BTC: $");
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    var convertedUsd = Converter(input);
                    Console.Write($"${input} = ");
                    Console.Write(convertedUsd + " BTC\n");
                    Console.ResetColor();
                    exitOrContinue();
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong!\nCan't get Bitcoin price...");
                    Console.ResetColor();
                    exitOrContinue();
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong option! Please type 1 or 2!");
                Console.ResetColor();
                userInput();
            }
        }

        static void exitOrContinue()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n[1] - Back to menu\n[2] - Exit");
            var toContinue = Console.ReadLine();
            Console.ResetColor();
            if (toContinue == "1")
            {
                Console.Clear();
                userInput();
            }
            else if (toContinue == "2")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong option! Please type 1 or 2!");
                Console.ResetColor();
                exitOrContinue();
            }
        }

        static void welcomeAscii()
        {
            
            string welcome = @"
8888ba.88ba                             d8                     
88  `8b  `8b                            88                     
88   88   88 .d8888b. 88d888b. .d8888b. .P .d8888b.            
88   88   88 88'  `88 88'  `88 88'  `88    Y8ooooo.            
88   88   88 88.  .88 88    88 88.  .88          88            
dP   dP   dP `88888P' dP    dP `88888P'    `88888P'            
                                                               
                                                               
 888888ba  d888888P  a88888b.    d888888P                   dP 
 88    `8b    88    d8'   `88       88                      88 
a88aaaa8P'    88    88              88    .d8888b. .d8888b. 88 
 88   `8b.    88    88              88    88'  `88 88'  `88 88 
 88    .88    88    Y8.   .88       88    88.  .88 88.  .88 88 
 88888888P    dP     Y88888P'       dP    `88888P' `88888P' dP";
         
            Console.WriteLine(welcome);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Github: https://github.com/Reno-Codes");
        }


    }
}


