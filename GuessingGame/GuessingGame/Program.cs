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
            int playerGuess;
            string playerInput;

            Random r = new Random();
            theAnswer = r.Next(1, 21);

            Console.WriteLine("what's your name?");
            string bro = Console.ReadLine();
            //ReadKey for number 3? 
            // get player input
            Console.Write(bro + ", Enter your guess (1-20): ");

            do
            {


                //attempt to convert the string to a number
                while (true)
                {

                    playerInput = Console.ReadLine();
                    int.TryParse(playerInput, out playerGuess);

                    if (playerGuess >= 1 && playerGuess <= 20)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("wrong. enter a number between 1 and 20");
                    }
                }

                if (playerGuess == theAnswer)
                {
                    Console.WriteLine($"{theAnswer} was the number.  You Win!");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    if (playerGuess > theAnswer)
                    {
                        Console.WriteLine("Your guess was too High!");
                    }
                    else
                    {
                        Console.WriteLine("Your guess was too low!");
                    }
                }


            } while (true);
        }
    }
}

