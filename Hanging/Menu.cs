using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanging
{
    class Menu : Logo
    {
        static void Main()
        {

            PrintLogo();
            Greetings();

            int userChoice = 0;
            bool wrongUserChoiceInput = true;
            while (wrongUserChoiceInput)
            {
                while (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.WriteLine("Моля, въведете число!");
                }
                if (userChoice == 1 || userChoice == 2 || userChoice == 3)
                {
                    wrongUserChoiceInput = false;
                }
                ChangeTopic(userChoice);
            }
        }

        /// <summary>
        /// Validate input values from users
        /// </summary>
        static void ValidateUserInput()
        {

        }

        /// <summary>
        /// This method selects the topic with questions
        /// </summary>
        /// 

        static void ChangeTopic(int topic)
        {



            if ((topic == 1) || (topic == 2) || (topic == 3))
            {

                if (topic == 1)
                {
                    //method countries
                    Console.WriteLine("Вие избрахте - Държави");
                    SetNumberOfPlayers();

                    return;
                }
                else if (topic == 2)
                {
                    //method towns
                    Console.WriteLine("Вие избрахте - Градове");
                    SetNumberOfPlayers();

                    return;
                }
                else if (topic == 3)
                {
                    //method others
                    Console.WriteLine("Вие избрахте - Други");
                    ChangeLevel();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Невалидна категория! Моля въведете вашата категория отново:");

            }

        }

        /// <summary>
        /// Set Level of difficulty in section Others
        /// </summary>
        static int ChangeLevel()
        {
            Console.WriteLine("Моля, изберете нивото на трудност: 1-Easy , 2-Medium , 3-Hard : ");
            int levelOfDifficulty = 0;
            bool wrongUserChoiceInput = true;
            while (wrongUserChoiceInput)
            {
                levelOfDifficulty = int.Parse(Console.ReadLine());
                if (levelOfDifficulty == 1)
                {
                    wrongUserChoiceInput = false;
                    Console.WriteLine("Избрахте ниво на трудност Easy .");
                    
                }
                else if (levelOfDifficulty == 2)
                {
                    wrongUserChoiceInput = false;
                    Console.WriteLine("Избрахте ниво на трудност Medium .");
                    
                }
                else if (levelOfDifficulty == 3)
                {
                    wrongUserChoiceInput = false;
                    Console.WriteLine("Избрахте ниво на трудност Hard .");
                    
                }
                else
                {
                    Console.WriteLine("Моля, изберете коректно ниво на трудност:");
                }
                
            }
            return levelOfDifficulty;
            //TODO
        }

        /// <summary>
        /// Set number of players
        /// </summary>
        static void SetNumberOfPlayers()
        {
            int numberOfPlayers = 0;
            Console.Write("Изберете брой играчи: 1 или 2 -->> ");
            bool wrongUserChoiceInput = true;
            while (wrongUserChoiceInput)
            {
                while (!int.TryParse(Console.ReadLine(), out numberOfPlayers))
                {
                    Console.WriteLine("Моля, въведете коректен брой играчи! 1 или 2:");
                }

                if (numberOfPlayers == 1)
                {
                    //TODO
                    wrongUserChoiceInput = false;
                    Console.WriteLine("1 играч");
                }
                else if (numberOfPlayers == 2)
                {
                    //TODO
                    wrongUserChoiceInput = false;
                    Console.WriteLine("2 играчи");
                }
                else
                {
                    Console.WriteLine("Моля, въведете коректен брой играчи! 1 или 2:");
                }

            }
        }
    }
}
