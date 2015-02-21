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
            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.WriteLine("Моля, въведете число!");
                Console.WriteLine("За Държави - 1");
                Console.WriteLine("За Градове - 2");
                Console.WriteLine("За Други   - 3");
            }

            ChangeTopic(userChoice);
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
                Console.WriteLine("Невалидна категория! Опитайте пак!");

            }
        }

        /// <summary>
        /// Set Level of difficulty in section Others
        /// </summary>
        static void ChangeLevel()
        {
            Console.WriteLine("Моля, изберете нивото на трудност: 1, 2 или 3: ");
            //TODO
        }

        /// <summary>
        /// Set number of players
        /// </summary>
        static void SetNumberOfPlayers()
        {
            int numberOfPlayers = 0;
            Console.Write("Изберете брой играчи: 1 или 2 -->> ");
            while (!int.TryParse(Console.ReadLine(), out numberOfPlayers))
            {
                Console.WriteLine("Моля, въведете коректен брой играчи! 1 или 2");
            }

            if (numberOfPlayers == 1)
            {
                //TODO
                Console.WriteLine("1 играч");
            }
            else if (numberOfPlayers == 2)
            {
                //TODO
                Console.WriteLine("2 играчи");
            }

            return;
        }
    }
}
