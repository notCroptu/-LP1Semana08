﻿using System;
using System.Collections.Generic;

namespace PlayerManager4 // >>> Change to PlayerManager2 for exercise 4 <<< //
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers();
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                Console.Write("\nPress ENTER to continue...");
                Console.ReadLine();
                Console.WriteLine("\n");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "4");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            // /////////////////// //
            // COMPLETE ME PLEASE! //
            // /////////////////// //
            Console.WriteLine("Enter 1 for     Inserting New Player");
            Console.WriteLine("Enter 2 for     Listing Players");
            Console.WriteLine("Enter 3 for     Listing Players with score greater than inserted");
            Console.WriteLine("Enter 4 for     Exit Program");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            // /////////////////// //
            // COMPLETE ME PLEASE! //
            // /////////////////// //
            Console.WriteLine("Insert the name of the new Player. ");
            string name = Console.ReadLine();

            Console.WriteLine("Insert the score of the new Player. ");
            int score = int.Parse(Console.ReadLine());

            Player player = new Player(name, score);
            playerList.Add(player);

        }

        /// <summary>
        /// Show all players in a list of players. This method is no longer static
        /// because it depends on ListSorter() an instance of the program.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private void ListPlayers()
        {
            // /////////////////// //
            // COMPLETE ME PLEASE! //
            // /////////////////// //
            ListSorter();

            foreach (Player player in playerList)
            {
                Console.WriteLine($"Name={player.Name} Score={player.Score}");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            // /////////////////// //
            // COMPLETE ME PLEASE! //
            // /////////////////// //
            Console.WriteLine("Please insert the score to check if it's greater than. ");
            int minScore = int.Parse(Console.ReadLine());

            List<Player> players =  new List<Player>(GetPlayersWithScoreGreaterThan(minScore));

            foreach(Player player in players)
            {
                Console.WriteLine(player.Name);
            }
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
            // /////////////////// //
            // COMPLETE ME PLEASE! //
            // /////////////////// //

            ListSorter();

            foreach (Player player in playerList)
            {
                if (player.Score > minScore)
                {
                    yield return player;
                }
            }
        }

        /// <summary>
        /// ListSorter method asks the player the way to sort the playerList variable
        /// </summary>
        private void ListSorter()
        {
            string type = "";
            do
            {
                Console.WriteLine("Insert the method to list by. score/name ascending/name descending ");
                type = Console.ReadLine();

                switch (type)
                {
                    case "score":
                        playerList.Sort();
                        break;
                    case "name ascending":
                        playerList.Sort(new CompareByName());
                        break;
                    case "name descending":
                        playerList.Sort(new CompareByName(false));
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }
            } while ( type != "score" && type != "name ascending" && type != "name descending" );
        }
    }
}