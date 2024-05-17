using System;
using System.Collections.Generic;

namespace PlayerManagerMVC // >>> Change to PlayerManager2 for exercise 4 <<< //
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Initialize the player list (model) with two players using collection
            // initialization syntax
            Model playerList = new Model();
            // Create controller class 
            Controller control = new Controller(playerList);
            // Create console view class
            ConsoleView view = new ConsoleView(control, playerList);
            // Start the control instance
            control.Start(view);
        }
    }
}