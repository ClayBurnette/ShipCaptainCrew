using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipCaptainCrew
{
    public class RollGame
    {
        /// NOTES:::
        /// Five Dice
        /// Each Player has Three Rolls
        /// Minimum of Two Players
        /// Roll all dice at once
        /// 6,5,4 - all at once
        /// 6 or 5 or 4 - remove that one
        /// First to order
        /// English: Human lang def of the game
        /// The Game 
        /// Any number of players will take three turns rolling a collection of five dice hoping to match numbers 4, 5, and 6.
        /// The player has exactly THREE rolls to obtain a 4, 5, and 6 - and if that player obtains all three numbers within
        /// three rolls - that player can now start accumulating points.
        /// The player cannot accumulate points without acquiring the three numbers 4, 5, 6, first.
        /// The game can end in a draw
        /// There is only one round for each player.
        /// THIS GAME WILL MOST DEFINITELY TERMINATE AT SOME POINT IN TIME
        // Note: Game can be played with many players, but we are limiting to two.
        /// Computer language def of the game
        /// The game implying that that the memory of the players is keeping track of all previously seen numbers
        // Number of players in game
        public int numberOfPlayers { get => 2; set { } }
        // Number Of Turns
        public int numberOfTurns { get; set; }
        // Number Of Starting Dice
        public int numberOfDice { get; set; }
        // Each Player Must Be Able To Save Their Score
        public int playerOneScore { get; set; }
        public int playerTwoScore { get; set; }
        // Create A Var To Store Parts Of The Game
        // This Var Helps Us Know If The Player Landed On One Of These Numbers
        public int[] rollDice = { 4, 5, 6 };
        // Create A Var To Store All Roll Results
        // *Mutable Array*
        public Dictionary<int, int> runTimeManager;
        public RollGame()
        {
            // Intial Game Settings
            runTimeManager = new Dictionary<int, int>
            {
                { 4, 0 },
                { 5, 0 },
                { 6, 0 }
            };
            playerOneScore = 0;
            playerTwoScore = 0;
            numberOfDice = 5;
            numberOfTurns = 3;
        }
        // Add Data To Runtime Manager
        public List<int> RollDice(int numberOfDice)
        {
            // Roll Given Number Of Dice For Each Roll
            // Return Array Of Numbers Turned Up
            List<int> diceRolled = new List<int>();
            Random roll = new Random();
            for (int i = 0; i < numberOfDice; i++)
            {
                diceRolled.Add(roll.Next(1, 7));
            }
            return diceRolled;
        }
        // Whos Turn Is It?
        public int WhosTurnIsIt(int player)
        {
            switch (player)
            {
                case 1:
                    return 2;
                default:
                    return 1;
            }
        }
        // Return Players Score Card/Data
        public string ReturnCard()
        {
            string message = @"Number of hits:
            4: {0}
            5: {1}
            6: {2}
            ";
            return string.Format(message, runTimeManager[4], runTimeManager[5], runTimeManager[6]);
        }
        // Method To Update Card At Runtime
        public void UpdateCard(int diceRolled)
        {
            switch (diceRolled)
            {
                case 4:
                    runTimeManager[4] = 1;
                    break;
                case 5:
                    runTimeManager[5] = 1;
                    break;
                case 6:
                    runTimeManager[6] = 1;
                    break;
                default:
                    break;
            }
        }
        // Method To Reduce Number Of Dice
        public void RemoveDice(int numberToRemove)
        {
            numberOfDice = numberOfDice - numberToRemove;
        }
        public void clearStats()
        {
            runTimeManager[4] = 0;
            runTimeManager[5] = 0;
            runTimeManager[6] = 0;
            numberOfTurns = 3;
            numberOfDice = 5;
        }
        public void UpdateScore(int player, int points)
        {
            switch (player)
            {
                case 1:
                    playerOneScore += points;
                    break;
                default:
                    playerTwoScore += points;
                    break;
            }
        }
        public string ReturnScore()
        {
            string message = @"
            Player 1: {0}
            Player 2: {1}
            ";
            return string.Format(message, playerOneScore, playerTwoScore);
        }
    }
}
