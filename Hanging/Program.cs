namespace HangMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    class Program
    {
        public static void Main()
        {
            const int MAX_MISTAKES = 6;
            string file = string.Empty;
            string word = string.Empty;
            string gameInfo = string.Empty;

            Console.Write("Изберете игра: 1 - Един играч / 2 - Двама играчи : ");
            int gameType = int.Parse(Console.ReadLine());
            if (gameType == 1)
            {
                Console.Write("Изберете игра: 1 - Градове / 2 - Държави : ");
                int game = int.Parse(Console.ReadLine());
                file = ChooseGame(game);
                gameInfo = GameInfo(game);
                word = GetRandomWord(file);
            }
            else if (gameType == 2)
            {
                Console.Write("Въведете дума : ");
                word = Console.ReadLine().ToUpper();
                gameInfo = "един срещу друг";
            }
            else
            {
                throw new ArgumentException ("Невалиден вход!");
            }

            StringBuilder wordForRecognition = new StringBuilder();
            wordForRecognition = PrepareTheWord(word);
            List<char> usedChars = new List<char>();
            int counter = 0;

            while (wordForRecognition.ToString().Contains('_') && counter < MAX_MISTAKES)
            {
                Console.Clear();
                Console.WriteLine("Вие играете {0}",gameInfo);
                Console.WriteLine(word);
                Console.WriteLine("Грешни отговори : {0}/{1}", counter, MAX_MISTAKES);
                Console.Write("Използвани букви: ");
                foreach (var item in usedChars)
                {
                    Console.Write(item.ToString());
                }
                Console.WriteLine();
                Console.WriteLine(wordForRecognition);
                Console.Write("Буква : ");
                char guessChar = char.Parse(Console.ReadLine().ToUpper());
                if (!word.Contains(guessChar) || usedChars.Contains(guessChar))
                {
                    counter++;
                }
                else
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guessChar)
                        {
                            wordForRecognition[i] = guessChar;
                        }
                    }
                }
                usedChars.Add(guessChar);
                if (wordForRecognition.ToString().Contains('_') || counter < MAX_MISTAKES)
                {
                    Console.Clear();
                }
            }
            EndOfTheGame(counter, MAX_MISTAKES, word);
        }

        // ------------------------------------METHODS------------------------------------//
        public static string GameInfo(int game)
        {
            string gameInfo = string.Empty;
            if (game == 1)
            {
                gameInfo = "на Градове";
            }
            else if(game == 2)
            {
                gameInfo = "на Държави";
            }
            else
            {
                var ex = new ArgumentException("Невалидни данни!");
                return ex.Message;
            }
            return gameInfo;
        }
        public static string ChooseGame(int game)
        {
            string countriesFile = "Countries.txt";
            string citiesFile = "Cities.txt";
            if (game == 1)
            {
                return citiesFile;
            }
            else if (game == 2)
            {
                return countriesFile;
            }
            else
            {
                var ex = new ArgumentException("Невалидни данни!");
                return ex.Message;
            }
        }
        static string GetRandomWord(string file)
        {
            StreamReader text = new StreamReader(file, Encoding.GetEncoding("windows-1251"));
            var wordCollection = text.ReadToEnd();
            string[] words = wordCollection.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            Random rand = new Random();
            int randomIndex = rand.Next(0, words.Length);
            string randomWord = words[randomIndex].ToUpper();
            return randomWord;
        }
        static StringBuilder PrepareTheWord(string word)
        {
            StringBuilder wordForRecognition = new StringBuilder();
            wordForRecognition.Append(new string('_', word.Length));
            wordForRecognition[0] = word[0];
            wordForRecognition[wordForRecognition.Length - 1] = word[word.Length - 1];
            if (word.IndexOf(' ') > 0)
            {
                int index = 0;
                while (true)
                {
                    index = word.IndexOf(' ', index);
                    if (index >= 0)
                    {
                        wordForRecognition[index] = ' ';
                        wordForRecognition[index - 1] = word[index - 1];
                        wordForRecognition[index + 1] = word[index + 1];
                    }
                    else
                    {
                        break;
                    }
                    index++;
                }
            }
            StringBuilder preparedWord = new StringBuilder();
            preparedWord = wordForRecognition;
            return preparedWord;
        }
        public static void EndOfTheGame(int counter, int MAX_MISTAKES, string randomCountry)
        {
            if (counter < MAX_MISTAKES)
            {
                if (counter == 1)
                {
                    Console.WriteLine("Поздравления! Спечели играта с {0} грешка", counter);
                }
                else
                {
                    Console.WriteLine("Поздравления! Спечели играта с {0} грешки", counter);
                }
            }
            else
            {
                Console.WriteLine("Играта свърши!");
            }
            Console.WriteLine("Думата е : {0} ", randomCountry);
        }
    }
}
