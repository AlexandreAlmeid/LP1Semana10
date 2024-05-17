using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PlayerManagerMVC
{
    public class Model
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> playerList;
        public Model()
        {
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        public void Add(Player player)
        {
            playerList.Add(player);
        }

                /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            foreach (Player player in playersToList)
            {
                Console.WriteLine($"Player Name: {player.Name} | Score: {player.Score}");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        public void ListPlayersWithScoreGreaterThan()
        {
            Console.Write("Minimum Score: ");
            string score = Console.ReadLine();
            int scr = int.Parse(score);
            foreach (Player p in GetPlayersWithScoreGreaterThan(scr))
            {
                Console.WriteLine($"Player Name: {p.Name} | Score: {p.Score}");
            }
            
        }
        public void SimpleList()
        {
            ListPlayers(playerList);
        }
        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player player in playerList)
            {
                if (player.Score > minScore)
                {
                    yield return player;
                }
            }
        }
        public void Srt(int op)
        {
            switch (op)
            {
                case 1:
                    playerList.Sort();
                    break;
                case 2:
                    IComparer<Player> comp1 = new CompareByName(true);
                    playerList.Sort(comp1);
                    break;
                case 3:
                    IComparer<Player> comp2 = new CompareByName(false);
                    playerList.Sort(comp2);
                    break;
                default:
                    break;

            }
        }
    }
    public class Controller
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        public Model model;

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        public Controller(Model model)
        {
            this.model = model;
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        public void Start(ConsoleView view)
        {
            // We keep the user's option here
            string option;

            int op = int.Parse(view.Info());
            // Main program loop
            do
            {
                // Show menu and get user option
                view.ShowMenu();
                option = view.GetOption();
                model.Srt(op);

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        view.InsertPlayer();
                        break;
                    case "2":
                        model.SimpleList();
                        break;
                    case "3":
                        model.ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        view.End();
                        break;
                    default:
                        view.Error();
                        break;
                }

                // Wait for user to press a key...
                view.Wait();

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "4");
        }
        
    }
}