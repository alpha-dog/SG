using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess = 0;
            string playerInput;
            int guessCounter = 0;
            int mode = 20; 

            //ask for name
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("what's your name?");
            string bro = Console.ReadLine();

            //ask if they want easy, medium, or hard mode
            Console.WriteLine("Do want easy, medium, or hard mode");
            string hardness = Console.ReadLine();

            //assign hardness to 'mode' variable
            if (hardness == "easy")
            {
                mode = 5;
            }
            else if (hardness == "hard")
            {
                mode = 50;
            }
            else
            {
                mode = 20; // mode defaults to 20 guesses (medium hardness) because that was the original spec and people are most likely to mis-spell 'medium'
            }

            //generate radom number
            Random r = new Random();
            theAnswer = r.Next(1, mode); //was this a 21 in the original


            // get player input
            Console.Write(bro + ", Enter your guess (1- " + mode + "): ");

            do
            {
                //attempt to convert the string to a number
                while (true)
                {
                     
                    playerInput = Console.ReadLine();
                    int.TryParse(playerInput, out playerGuess);

                    if (playerGuess >= 1 && playerGuess <= mode)
                    {
                        guessCounter++;
                        Console.WriteLine("guess# " + guessCounter);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(bro +" wrong. enter a number between 1 and " + mode);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                if (playerGuess == theAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (guessCounter == 1)
                    {
                        Console.WriteLine(bro + " !!!!!!! WOW YOU WON ON THE FIRST TRY !!!!!!!");
                        Console.ReadLine();
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{theAnswer} was the number.  You Win! " + bro);
                        Console.ReadLine();
                        break;
                    }             
                }
                else
                {
                    if (playerGuess > theAnswer)
                    {
                        Console.WriteLine(bro + " Your guess was too High!");
                    }
                    else
                    {
                        Console.WriteLine(bro + " Your guess was too low!");
                    }
                }

            } while (true);
        }
    }
} 

