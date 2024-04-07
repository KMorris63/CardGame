using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! This application will very simply create one or multiple deck(s) of standard playing cards. It will then shuffle the cards and print out their values.");
            Console.WriteLine("Please enter the number of decks you would like (must be an integer between 1 and 10)");
            Deck mainDeck = new Deck(int.Parse(Console.ReadLine()));
            mainDeck.ReverseVisibility();
            Console.WriteLine(mainDeck.ToString());
            mainDeck.Shuffle();
            Console.WriteLine(mainDeck.ToString());

            // mainDeck.ReverseVisibility();
            String keepPlaying = "c";
            while (keepPlaying == "c")
            {
                mainDeck.Shuffle();
                int score = 0;
                string nextGuess = "h";

                Console.WriteLine("Game: High Low");
                Console.WriteLine("With the shuffled deck of cards, each card will be revealed one by one. Earn points by guessing whether the next card to be revealed is higher or lower in ranking than the previous card! \nEnter \"H\" to guess higher or \"L\" to guess lower.");

                Console.WriteLine("Ready? First Card!");
                Console.WriteLine(mainDeck.CardsList[0].ToString());

                for (int i = 1; i < mainDeck.CardsList.Count; i++)
                {
                    Card lastCard = mainDeck.CardsList[i - 1];
                    Card nextCard = mainDeck.CardsList[i];
                    Console.WriteLine("Is the next card ranked higher (H) or lower (L)?");
                    nextGuess = Console.ReadLine().Trim().ToLower();
                    while (!(nextGuess == "h" || nextGuess == "l"))
                    {
                        Console.WriteLine("Invalid input. Enter \"H\" for higher or \"L\" for lower.");
                        nextGuess = Console.ReadLine().Trim().ToLower();
                    }
                    Console.WriteLine(nextCard.ToString());
                    switch (nextGuess)
                    {
                        case "h":
                            if (nextCard.RankNum > lastCard.RankNum)
                            {
                                score += 1;
                                Console.WriteLine("Correct! Last card was " + lastCard.ToString() + " and next card was " + nextCard.ToString() + ". Your score is now " + score + ".");
                            }
                            else if (nextCard.RankNum < lastCard.RankNum)
                            {
                                Console.WriteLine("Incorrect. Last card was " + lastCard.ToString() + " and next card was " + nextCard.ToString() + ". Your score remains " + score + ".");
                            }
                            else
                            {
                                Console.WriteLine("Same ranking. Last card was " + lastCard.ToString() + " and next card was " + nextCard.ToString() + ". Your score remains " + score + ".");
                            }
                            break;
                        case "l":
                            if (nextCard.RankNum < lastCard.RankNum)
                            {
                                score += 1;
                                Console.WriteLine("Correct! Last card was " + lastCard.ToString() + " and next card was " + nextCard.ToString() + ". Your score is now " + score + ".");
                            }
                            else if (nextCard.RankNum > lastCard.RankNum)
                            {
                                Console.WriteLine("Incorrect. Last card was " + lastCard.ToString() + " and next card was " + nextCard.ToString() + ". Your score remains " + score + ".");
                            }
                            else
                            {
                                Console.WriteLine("Same ranking. Last card was " + lastCard.ToString() + " and next card was " + nextCard.ToString() + ". Your score remains " + score + ".");
                            }
                            break;

                    }
                }
                Console.WriteLine("Game Over! Your final score is " + score);
                Console.WriteLine("Want to play again? Enter \"C\" to continue. ");

                keepPlaying = Console.ReadLine().Trim().ToLower();
            }

            Console.WriteLine("You chose to end the game. See you next time!");

            Console.ReadKey();
        }
    }
}
