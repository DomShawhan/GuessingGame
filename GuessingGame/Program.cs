/*
todo: Refactor the code into methods
*/

namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Guess the Number Game");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++");

            string choice = "y";

            while (choice == "y")
            {
                Console.WriteLine();
                Console.WriteLine("I'm thinking of a number from 1 to 100.");
                Console.WriteLine("Try to guess it.");

                int theNbr = RandomNbr();
                Console.WriteLine();
                bool correct = false;
                int tries = 0;

                while (!correct)
                {
                    int nbr = UserInput();
                    
                    tries++;

                    if (nbr == theNbr)
                    {
                        correct = true;
                        Console.WriteLine($"You got it in {tries}");
                        if (tries <= 3)
                        {
                            SuccessOutput("Great Work! You are a mathematical wizard.", false);
                        }
                        else if (tries > 3 && tries <= 7)
                        {
                            SuccessOutput("Not too bad! You've got some potential.", false);
                        }
                        else
                        {
                            SuccessOutput("What took you so long? Maybe you should take some lessons.", false);
                        }
                        tries = 0;
                    }
                    else
                    {
                        if (nbr < theNbr - 10)
                        {
                            ErrorOutput("Way too low! Try again", true);
                        }
                        else if (nbr < theNbr)
                        {
                            ErrorOutput("Too low! Try again", true);
                        }
                        else if (nbr > theNbr + 10)
                        {
                            ErrorOutput("Way too high! Try again", true);
                        }
                        else
                        {
                            ErrorOutput("Too high! Try again", true);
                        }
                    }
                }
                bool tryAgainValidation = false;
                string tryAgain = "";

                while(!tryAgainValidation)
                {
                    Console.WriteLine();
                    Console.Write("Try again? (y/n)");
                    tryAgain = Console.ReadLine();
                    if(tryAgain != "y" && tryAgain != "n")
                    {
                        ErrorOutput("Only the characters 'y' and 'n' are valid inputs here.", false);
                        continue;
                    }
                    tryAgainValidation = true;
                    choice = tryAgain;
                }
            }

            Console.WriteLine("The end");
        }

        static int RandomNbr()
        {
            Random random = new Random();
            return random.Next(101);
        }

        static void ErrorOutput(string prompt, bool extraLine)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(prompt);
            if (extraLine) { Console.WriteLine(); }
            Console.ResetColor();
        }

        static void SuccessOutput(string prompt, bool extraLine)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

        static int UserInput()
        {
            bool valid = false;
            int nbr = 0;
            while (!valid)
            {
                Console.Write("Enter Number: ");
                nbr = 0;
                bool boolNbr = int.TryParse(Console.ReadLine(), out nbr);
                if (!boolNbr || nbr < 1 || nbr > 100)
                {
                    ErrorOutput("Please enter an integer between 1 and 100", false);
                } 
                else
                {
                    valid = true;
                }
            }
            return nbr;
        }
    }
}
