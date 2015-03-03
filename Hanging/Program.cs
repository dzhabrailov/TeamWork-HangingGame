namespace HangMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading;

    class Program
    {
        internal const char BODY = '\u258c';
        internal const char HEAD = '\u263A';
        internal const char DASH = '-';
        internal const char ASTERIX = '*';
        internal const char LEFT_DASH = '\\';
        internal const char RIGHT_DASH = '/';
        internal const char VERTICAL_DASH = '|';
        internal const char UNDER_SCORE = '_';
        internal const char EMPTY_SPACE = ' ';
        internal const char EQUALLY = '=';
        internal const char OPEN_BRACKET = '(';
        internal const char CLOSE_BRACKET = ')';

        internal const string GREETING = "Добре дошли!";
        internal const string CHOOSE_CATEGORY = "Моля, изберете желаната от Вас категория за игра: ";
        internal const string NUMBER_OF_CATEGORY = "<[ 1 - Държави ]> | <[ 2 - Градове ]> | <[ 3 - Други ]>";
        internal const string CATEGORY_REQUEST = "Моля въведете число за съответната категория -->> ";

        internal const string TEAM_NAME = "Powered by \"Hsu Hao\" Team";
        internal const string TELERIK_ACADEMY = "Online sudents on TelerikAcademy";

        public static int counter = 0;

        public static int[,] coordinates = 
            {
                {38, 38, 38, 37, 39, 37, 39},
                {3, 4, 5, 4, 4, 6, 6}
            };

        public static char[] bodyElements = 
            {
                HEAD,
                VERTICAL_DASH,
                VERTICAL_DASH,
                LEFT_DASH,
                RIGHT_DASH,
                RIGHT_DASH,
                LEFT_DASH,
             };

        public static void Main()
        {
            const int MAX_MISTAKES = 7;
            string file = string.Empty;
            string word = string.Empty;
            string gameInfo = string.Empty;
            PrintLogo();
            Greetings();

            Console.Write("Вашето име: ");
            string playerName = Console.ReadLine();
            int playerScores = 1;


            Console.Write("Изберете брой играчи: [1]Един играч    [2]Двама играчи : ");
            bool wrongInputPlayers = true;
            try
            {
                while (wrongInputPlayers)
                {
                    int gameType = 0;
                    while (!int.TryParse(Console.ReadLine(), out gameType))
                    {
                        Console.WriteLine("Моля, въведете число!");
                    }
                    
                    if (gameType == 1)
                    {
                        wrongInputPlayers = false;
                        Console.Write("Изберете игра       : [1]Градове       [2]Държави      : ");
                        bool wrongInputGame = true;
                        while (wrongInputGame)
                        {
                            int game = 0;
                            while (!int.TryParse(Console.ReadLine(), out game))
                            {
                                Console.WriteLine("Моля, въведете число!");
                            }
                            if (game == 1)
                            {
                                file = ChooseGame(game);
                                gameInfo = GameInfo(game);
                                word = GetRandomWord(file);
                                wrongInputGame = false;
                            }
                            else if (game == 2)
                            {
                                file = ChooseGame(game);
                                gameInfo = GameInfo(game);
                                word = GetRandomWord(file);
                                wrongInputGame = false;
                            }
                            else
                            {
                                Console.Write("Невалидни данни, моля изберете игра отново:[1]Градове       [2]Държави : ");
                            }

                        }
                    }

                    else if (gameType == 2)
                    {
                        Console.Write("Въведете дума : ");
                        word = Console.ReadLine().ToUpper();
                        gameInfo = "един срещу друг";
                        wrongInputPlayers = false;

                    }

                    else
                    {
                        Console.Write("Невалидни данни, моля изберете брой играчи отново: [1] - Градове  [2] - Държави : ");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Невалидни данни");
            }
            StringBuilder wordForRecognition = new StringBuilder();
            wordForRecognition = PrepareTheWord(word);
            List<char> usedChars = new List<char>();

            Console.Clear();
            PrintGibbetAnimation();
            Console.Clear();


            while (wordForRecognition.ToString().Contains('_') && counter < MAX_MISTAKES)
            {
                PrintGibbet();
                Console.WriteLine("Вие играете {0}", gameInfo);
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
                    if (counter == 7)
                    {

                        playerScores = 0;
                        Console.SetCursorPosition(coordinates[0, counter - 1], coordinates[1, counter - 1]);
                        Console.Write(bodyElements[counter - 1]);
                        Thread.Sleep(500);

                    }
                    DrawNextElementOnTheGibbet();
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
                    Console.SetCursorPosition(8, 7);
                    Console.Write("  ");
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
                gameInfo = "Градове";
            }
            else if (game == 2)
            {
                gameInfo = "Държави";
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



        public static void PrintGibbetAnimation()
        {
            Console.Clear();

            for (int i = 0; i < 7; i++)
            {
                if (i == 3)
                {
                    Console.SetCursorPosition(7 - i, 7);
                    Console.WriteLine(" ");
                }

                else
                {
                    Console.SetCursorPosition(7 - i, 7);
                    Console.WriteLine("_");
                    Thread.Sleep(250);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(4, 7 - i);
                Console.WriteLine("|");
                Thread.Sleep(250);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(5 + i, 2);
                Console.WriteLine("-");
                Thread.Sleep(250);
            }

            Console.SetCursorPosition(10, 2);
            Console.WriteLine("|");
            Thread.Sleep(250);

            PrintBodyAnimation();
        }

        public static void PrintBodyAnimation()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(coordinates[0, i] - 28, coordinates[1, i]);
                Console.WriteLine(bodyElements[i]);
                Thread.Sleep(200);
            }

            Console.SetCursorPosition(15, 2);
            Console.WriteLine("Нинджа ти си следващият на бесилката!");
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("Натисни Enter и да започваме!");

            bool isEnter = false;

            while (isEnter == false)
            {
                Console.SetCursorPosition(15, 4);
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    isEnter = true;
                    Console.Clear();
                }
            }
        }

        private static void PrintGibbet()
        {
            for (int i = 0; i < 7; i++)
            {
                if (i == 3)
                {
                    Console.SetCursorPosition(35 - i, 7);
                    Console.WriteLine(" ");
                }

                else
                {
                    Console.SetCursorPosition(35 - i, 7);
                    Console.WriteLine("_");
                }
            }

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(32, 7 - i);
                Console.WriteLine(VERTICAL_DASH);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(33 + i, 2);
                Console.WriteLine(DASH);
            }

            Console.SetCursorPosition(38, 2);
            Console.WriteLine(VERTICAL_DASH);
            Console.SetCursorPosition(0, 2);

        }

        private static void DrawNextElementOnTheGibbet()
        {
            Console.SetCursorPosition(coordinates[0, counter - 1], coordinates[1, counter - 1]);
            Console.Write(bodyElements[counter - 1]);
        }

        public static void PrintLogo()
        {
            //headline
            Console.Write(new string(RIGHT_DASH, 3).PadLeft(20));
            Console.Write(new string(ASTERIX, 57));
            Console.WriteLine(new string(LEFT_DASH, 3));

            //HANGING 
            #region first row
            Console.Write(new string(RIGHT_DASH, 2).PadLeft(18));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(16));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIGHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIGHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIGHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.WriteLine(new string(LEFT_DASH, 2).PadLeft(11));

            #endregion
            #region second row
            Console.Write(new string(RIGHT_DASH, 2).PadLeft(17));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(17));
            Console.Write(new string(EQUALLY, 1));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EQUALLY, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(UNDER_SCORE, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(UNDER_SCORE, 2));
            Console.WriteLine(new string(LEFT_DASH, 2).PadLeft(13));

            #endregion
            #region third row
            Console.Write(new string(RIGHT_DASH, 1).PadLeft(15));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(19));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(RIGHT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(RIGHT_DASH, 2));

            Console.WriteLine(new string(LEFT_DASH, 1).PadLeft(14));

            #endregion

            #region The Gibbet
            //the gibbet header /   | ------ |    \
            Console.Write(new string(RIGHT_DASH, 1).PadLeft(14));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(17));
            Console.Write(new string(DASH, 5));
            Console.Write(new string(VERTICAL_DASH, 1));
            Console.WriteLine(new string(LEFT_DASH, 1).PadLeft(47));

            //the gibbet (human arms and head) \   |   \☺/   /
            Console.Write(new string(LEFT_DASH, 1).PadLeft(14));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(17));
            Console.Write(new string(EMPTY_SPACE, 4));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(HEAD, 1));
            Console.Write(new string(RIGHT_DASH, 1));
            Console.WriteLine(new string(RIGHT_DASH, 1).PadLeft(46));

            //the gibbet (human body)  \     |    ()     /
            Console.Write(new string(LEFT_DASH, 1).PadLeft(15));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(16));
            Console.Write(new string(EMPTY_SPACE, 5));
            Console.Write(new string(BODY, 1));
            //Console.Write(new string(OPEN_BRACKET, 1));
            //Console.Write(new string(CLOSE_BRACKET, 1));
            Console.WriteLine(new string(RIGHT_DASH, 1).PadLeft(46));

            //the gibbet (human foots) \\     |  _/\_      //
            Console.Write(new string(LEFT_DASH, 2).PadLeft(17));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(14));
            Console.Write(new string(EMPTY_SPACE, 3));
            Console.Write(new string(UNDER_SCORE, 1));
            Console.Write(new string(RIGHT_DASH, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(UNDER_SCORE, 1));
            Console.Write(TEAM_NAME.PadLeft(39, EMPTY_SPACE));
            Console.WriteLine(new string(RIGHT_DASH, 2).PadLeft(5));

            //the gibbet bottom \\ _____|_____   //
            Console.Write(new string(LEFT_DASH, 2).PadLeft(18));
            Console.Write(new string(UNDER_SCORE, 3).PadLeft(12));
            Console.Write(new string(VERTICAL_DASH, 1));
            Console.Write(new string(UNDER_SCORE, 3));
            Console.Write(TELERIK_ACADEMY.PadLeft(43, EMPTY_SPACE));
            Console.WriteLine(new string(RIGHT_DASH, 2).PadLeft(4));

            #endregion

            //footer
            Console.Write(new string(LEFT_DASH, 3).PadLeft(20));
            Console.Write(new string(ASTERIX, 57));
            Console.WriteLine(new string(RIGHT_DASH, 3));
        }

        /// <summary>
        /// Print greetings and options
        /// </summary>
        public static void Greetings()
        {
            Console.WriteLine(GREETING.PadLeft(55, EMPTY_SPACE));
        }
    }
}
