using System.Drawing;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppInfo();

            string inputUserName = GetUserName();

            SetMessageColor(ConsoleColor.Blue, $"Good luck {inputUserName} !!!");

            Random randGuessNumber = new Random();
            int guessNumber = randGuessNumber.Next(1, 11);

            bool isGuess = false;
            int shots = 0;

            while (isGuess == false)
            {
                SetMessageColor(ConsoleColor.DarkRed, $"{inputUserName}, guess my number!!!");
                string userInput = Console.ReadLine();

                int userNumber;

                bool isNumber = int.TryParse(userInput, out userNumber);
                
                if(!isNumber )
                {
                    SetMessageColor(ConsoleColor.Red, "Please, take me a Number!!!");
                    continue;
                }

                if(userNumber > 10 || userNumber < 1)
                {
                    SetMessageColor(ConsoleColor.Red, "Put number between 1 to 10");
                    continue;
                }

                if(userNumber > guessNumber) {
                    SetMessageColor(ConsoleColor.Magenta, "My number is lower");
                    shots++;
                } else if (userNumber < guessNumber)
                {
                    SetMessageColor(ConsoleColor.Cyan, "My number is highter");
                    shots++;
                } else
                {
                    isGuess = true;
                    shots++;
                    SetMessageColor(ConsoleColor.Green, $"Congratulation {inputUserName} Guess by {shots} shots");
                }
            }

        }

        static void AppInfo()
        {
            string appName = "Guess number";
            int appVersion = 4;
            string appAuthor = "Marcin Mierzejewski";

            Console.ForegroundColor = ConsoleColor.Green;
            string info = ("${appName} Version: 0.0.{appVersion} Author {appAuthor}");
            SetMessageColor(ConsoleColor.Yellow, info);
        }

        static string GetUserName()
        {
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            return userName;
        }

        static void GreetUser(string userName)
        {
            Console.WriteLine($"Good luck {userName}");
        }

        static void SetMessageColor(ConsoleColor setColor, string message)
        {
            Console.ForegroundColor = setColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}