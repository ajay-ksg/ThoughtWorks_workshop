using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{

    class OldSchoolGames
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int userChoice = 0;
            while (true)
            {
                game.ExecuteGame();
                Console.WriteLine("Want to quit ? Press 2\n");
                string input = Console.ReadLine();
                if(!Int32.TryParse(input, out userChoice) && userChoice == 2)
                        break;
           }
        }
    }

    class Game
    {

        public void ExecuteGame()
        {
            Console.WriteLine("Welcome to Old school Cricket Game \n Press 1 to start the game.");
            string  userInput = Console.ReadLine();
            int userInputInt = 0;
            if (Int32.TryParse(userInput, out userInputInt) && userInputInt == 1)
            {

                //we can get these details from user itself. 
                List<Player> players = new List<Player>();
                Player player1 = new Player(name:"BatsMan", scoreDetails: new ScoreDetails(), pType:PlayerType.Batsman);
                Player player2 = new Player(name: "BowlerMan", scoreDetails: new ScoreDetails(), pType: PlayerType.Bowler);

                players.Add(player1);
                players.Add(player2);

                IgenerateNumber randomNumberGenerator = new generateSimpleRandomNo();
                CricketGameService cricketGame = new CricketGameService(randomNumberGenerator);

                cricketGame.StartGame(players);
                Console.ReadKey();


            }
            else
            {
                Console.WriteLine("Please enter 1 to start the game");
            }
        }
    }
}
