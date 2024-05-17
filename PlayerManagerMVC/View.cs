using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PlayerManagerMVC
{
    public class ConsoleView
    {
        private Controller program;
        private Model model;
        public ConsoleView(Controller control, Model model)
        {
            program = control;
            this.model = model;
        }

        public string Info()
        {
            Console.WriteLine("Order");
            Console.WriteLine("1 - By Score.");
            Console.WriteLine("2 - By Name (Ascend).");
            Console.WriteLine("3 - By Name (Descend).");
            string opt = Console.ReadLine();
            return opt;
        }
        
        public string GetOption()
        {
            string option = Console.ReadLine();
            Console.Write("\n\n");
            return option;
        }

        public void Wait()
        {
            Console.Write("\nPress enter to continue...");
            Console.ReadLine();
            Console.WriteLine("\n");
        }

        public void End()
        {
            Console.WriteLine("Bye!");
        }

        public void Error()
        {
            Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1 - Insert new player in players list.");
            Console.WriteLine("2 - List all the players.");
            Console.WriteLine("3 - List players with a score greater than a minimum value.");
            Console.WriteLine("4 - Exit program.");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        public void InsertPlayer()
        {
            Console.Write("Player Name: ");
            string name = Console.ReadLine();
            Console.Write("Player Score: ");
            string score = Console.ReadLine();
            int scr = int.Parse(score);
            model.Add(new Player(name,scr));
        }
        public void PrintPlayer(Player player)
        {
            Console.WriteLine($"Player Name: {player.Name} | Score: {player.Score}");
        }
    }
}