using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangMan
{
    public class LogicMethods
    {
        public static string GameInfo(int game)
        {
            string gameInfo = string.Empty;

            if (game == 1)
            {
                gameInfo = "на Градове";
            }

            else if (game == 2)
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

        public static string GetRandomWord(string file)
        {
            StreamReader text = new StreamReader(file, Encoding.GetEncoding("windows-1251"));
            var wordCollection = text.ReadToEnd();
            string[] words = wordCollection.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            Random rand = new Random();
            int randomIndex = rand.Next(0, words.Length);
            string randomWord = words[randomIndex].ToUpper();
            return randomWord;
        }

        public static StringBuilder PrepareTheWord(string word)
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
            Console.Clear();
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
