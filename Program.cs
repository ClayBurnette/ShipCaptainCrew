using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipCaptainCrew
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Game...");
            RollGame game = new RollGame();
            // Introduce The Game To The User
            string intro =@" 
            The Game Rules
            Players Will Take THREE Turns Rolling
            A Collection Of Five Dice, They Hope To Match Numbers 4, 5, AND 6.
            The Player Has EXACTLY THREE Rolls To Obtain A 4, 5, AND 6 
            If The Player Obtains All Three Numbers In Three Rolls
            That Player Can Start To Accumulate Points
            The Player Cannot Accumulate Points Without Acquiring The Three Numbers 4, 5, 6, First.
            The Game Can End In A Draw
            There Is One Round Per Player";
            Console.WriteLine(intro);

            bool playAgain = true;
            while (playAgain)
            {
                for (int player = 1; player <= game.numberOfPlayers; player++)
                {
                    // Display Whos Turn
                    DisplayWhosTurnItIs(player);
                    while (game.numberOfTurns > 0)
                    {
                        // Display Remaining Roles
                        DisplayRemainingTurns(game.numberOfTurns);
                        // Press Enter To Roll
                        Console.ReadKey();
                        List<int> rolled = game.RollDice(game.numberOfDice);
                        // Display What We Rolled
                        DisplayDiceRolled(rolled);
                        // Gather Dice Data From Roll
                        for (int di = 0; di < rolled.Count - 1; di++)
                        {
                            // Remove One Die Per Match If Matched
                            if (game.runTimeManager.ContainsKey(rolled[di]))
                            {
                                if (game.runTimeManager[rolled[di]] == 0)
                                {
                                    game.numberOfDice -= 1;
                                    game.UpdateCard(rolled[di]);
                                    rolled.RemoveAt(di);
                                }
                            }
                        }
                        // If Player Gets 4, 5, 6
                        Console.WriteLine(game.ReturnCard());
                        int sum = 0;
                        foreach (int key in game.runTimeManager.Keys)
                        {
                            sum += game.runTimeManager[key];
                        }
                        if (sum == 3)
                        {
                            // The Player Is Currently Scoring
                            int score = 0;
                            foreach (int di in rolled)
                            {
                                // Add Up Remaining Dice To Score For Player
                                score += di;
                            }
                            // Update The Players Score
                            game.UpdateScore(player, score);
                            // Tell The Player How Many Points They Scored
                            Console.WriteLine("Plus: " + score.ToString() + " Points!!!");
                        }
                        // Determine The Points Aquired For Each Roll
                        game.numberOfTurns -= 1;
                    } // While (game.numberOfTurns > 0)
                    DisplayPlayersCurrentsScores(game.ReturnScore());
                    // Reset Next Player
                    game.clearStats();
                }
                // Lets See The Debugging
                // Gme Over, Print Scores
                DisplayPlayersCurrentsScores(game.ReturnScore());
                // Use Final Scores To Determine Who WON
                if (game.playerOneScore > game.playerTwoScore)
                {
                    Console.WriteLine("Player One Wins!");
                }
                else if (game.playerTwoScore > game.playerOneScore)
                {
                    Console.WriteLine("Player Two Wins!");
                }
                else
                {
                    Console.WriteLine("The Game Ends In A Draw!");
                }
                // Determine If They Want To Play Again
                Console.WriteLine("Would You Like To Play Again?");
                Console.WriteLine("Type 'Y' For Yes, Hit 'Enter' For No.");
                Console.Write(":");
                string userInput = Console.ReadLine();
                // Validatating Input
                if (!string.Equals(userInput.Trim().ToUpper(), "Y"))
                {
                    playAgain = false;
                }
            }
            Console.WriteLine("Game Over!");
            Console.WriteLine("Press Enter To Exit Game.");
            Console.ReadKey();
        }
        static void DisplayWhosTurnItIs(int player)
        {
            Console.WriteLine("It Is Player " + player.ToString() + "'s Turn;");
        }
        static void DisplayRemainingTurns(int remainingRolls)
        {
            Console.WriteLine("You Have " + remainingRolls.ToString() + " Remaining Rolls.");
            Console.WriteLine("Press Enter To 'Roll' Your Dice...");
        }
        static void DisplayDiceRolled(List<int> diceRolled)
        {
            Console.WriteLine("You Rolled:");
            string print_dice = string.Empty;
            // Iterate Device
            // Print Message To Console
            foreach (int di in diceRolled)
            {
                if (diceRolled.IndexOf(di) == diceRolled.Count - 1)
                {
                    print_dice += di.ToString();
                }
                else
                {
                    print_dice += di.ToString() + " ,  ";
                }
            }
            Console.WriteLine(print_dice);
        }
        static void DisplayPlayersCurrentsScores(string Score)
        {
            Console.WriteLine("Current Scoreboard:");
            Console.WriteLine(Score);
        }
    }
}
