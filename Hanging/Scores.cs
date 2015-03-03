using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangMan
{
    public class Scores
    {
        public static void getPlayersData()
        {
            StreamReader playerName = new StreamReader("playerName.txt");
            StreamReader playerScores = new StreamReader("playerScores.txt");
            StreamReader playerGames = new StreamReader("playerGames.txt");
            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerScoresList = playerScores.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerGamesList = playerGames.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            playerName.Close();
            playerScores.Close();
            playerGames.Close();

            for (int i = 0; i < playerNameList.Count; i++)
            {
                Console.WriteLine(playerNameList[i] + " -> " + playerScoresList[i] + " точки от " +
                    playerGamesList[i] + " изиграни игри!");
            }
        }

        public static string getPlayerGames(string name)
        {
            string player = string.Empty;

            StreamReader playerName = new StreamReader("playerName.txt");
            StreamReader playerGames = new StreamReader("playerGames.txt");

            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerGamesList = playerGames.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            if (!playerNameList.Contains(name))
            {
                player = "no player with this name";
            }
            else
            {
                for (int i = 0; i < playerNameList.Count; i++)
                {
                    if (playerNameList[i] == name)
                    {
                        player = playerGamesList[i];
                    }
                }
            }

            playerName.Close();
            playerGames.Close();

            return player;
        }

        public static string GetPlayerScores(string name)
        {
            string player = string.Empty;

            StreamReader playerName = new StreamReader("playerName.txt");
            StreamReader playerScores = new StreamReader("playerScores.txt");

            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerScoresList = playerScores.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            if (!playerNameList.Contains(name))
            {
                player = "no player with this name";
            }
            else
            {
                for (int i = 0; i < playerNameList.Count; i++)
                {
                    if (playerNameList[i] == name)
                    {
                        player = playerScoresList[i];
                    }
                }
            }

            playerName.Close();
            playerScores.Close();

            return player;
        }

        public static void InsertPlayersAndScores(string name, int scores)
        {
            bool existPlayer = false;

            StreamReader playerName = new StreamReader("playerName.txt");
            StreamReader playerScores = new StreamReader("playerScores.txt");
            StreamReader playerGames = new StreamReader("playerGames.txt");
            List<string> playerNameList = playerName.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerScoresList = playerScores.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> playerGamesList = playerGames.ReadToEnd().Split(new string[] { " ", "  " },
                StringSplitOptions.RemoveEmptyEntries).ToList();
            int currentIndex = int.MinValue;

            for (int i = 0; i < playerNameList.Count; i++)
            {
                if (playerNameList[i] == name)
                {
                    currentIndex = i;
                    existPlayer = true;
                }
            }

            if (existPlayer)
            {
                int newScores = int.Parse(playerScoresList[currentIndex].ToString());
                newScores += scores;
                playerScoresList[currentIndex] = newScores.ToString();
                int newGames = int.Parse(playerGamesList[currentIndex].ToString());
                newGames += 1;
                playerGamesList[currentIndex] = newGames.ToString();
            }
            else
            {
                playerNameList.Add(name);
                playerScoresList.Add(scores.ToString());
                playerGamesList.Add("1");
            }

            playerName.Close();
            playerScores.Close();
            playerGames.Close();

            StreamWriter newPlayersToAppend = new StreamWriter("playerName.txt", false, Encoding.GetEncoding("windows-1251"));
            StreamWriter newScoresToAppend = new StreamWriter("playerScores.txt", false, Encoding.GetEncoding("windows-1251"));
            StreamWriter newGamesToAppend = new StreamWriter("playerGames.txt", false, Encoding.GetEncoding("windows-1251"));

            for (int i = 0; i < playerNameList.Count; i++)
            {
                newPlayersToAppend.Write(playerNameList[i] + " ");
                newScoresToAppend.Write(playerScoresList[i] + " ");
                newGamesToAppend.Write(playerGamesList[i] + " ");
            }

            newPlayersToAppend.Close();
            newScoresToAppend.Close();
            newGamesToAppend.Close();

        }
    }
}
