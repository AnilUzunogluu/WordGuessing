using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string play = "0";
            do
            {
                Console.WriteLine("Welcome to the Limited Word-Guessing Game. Please press enter to start. or 1 to close the game.");
                play = Console.ReadLine();

                if (play == "")
                {
                    //random word handling
                    string[] words = { "subway", "awkward", "chocolate", "puzzling", "pregnancy", "strength", "horizon", "zombie", "book", "jogging" };
                    Random random = new Random();
                    int randomIndex = random.Next(0, 10);
                    string selectedWord = words[randomIndex];
                    string hiddenWord = "";
                    for (int i = 0; i < selectedWord.Length; i++)
                    {
                        hiddenWord += "*";
                    }
                    //actual game
                    int counter = 0;
                    while (hiddenWord.Contains("*") && counter < 10)
                    {
                        Console.WriteLine($"Word: {hiddenWord}");
                        Console.Write("Please enter a letter >> ");
                        char guess = char.Parse(Console.ReadLine());
                        counter++;
                        if (selectedWord.Contains(guess))
                        {
                            for (int i = 0; i < selectedWord.Length; i++)
                            {
                                if (selectedWord[i] == guess)
                                {
                                    hiddenWord = hiddenWord.Remove(i, 1);
                                    hiddenWord = hiddenWord.Insert(i, guess.ToString());
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"The letter {guess} is in the word!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"The word does NOT contain the letter {guess}");
                        }
                        Console.ResetColor();
                    }
                    if (counter>= 10 && hiddenWord.Contains("*"))
                    {
                        Console.WriteLine($"\nSorry. You have lost the game. The word was {selectedWord}\n");
                    }
                    else
                    {
                        Console.WriteLine($"\nCongratulations! You won! The word was {selectedWord}\n");
                    }
                }
                else if (play == "1")
                {
                    Console.WriteLine("Sad to see you go. Closing the game now.");
                }
                else
                {
                    Console.WriteLine("Your input was NOT valid.");
                }
            } while (play != "1");
            
        }
    }
}
