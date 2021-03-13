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
                Console.WriteLine("Want to quit ? Press 2 else press any other key\n");
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out userChoice))
                {
                    if (userChoice == 2)
                        break;
                }
            }
        }
    }

    class Game
    {
        IgenerateNumber randomNumberGerator = new generateSimpleRandomNo();
        IPlayerScoringStrategy playerScoringStrategy = new SimpleScoringStretagy();
        public void ExecuteGame()
        {
            Console.WriteLine("                  ****************Welcome to Old school Cricket Game***************** \nPress 1 to start the game.");
            string userInput = Console.ReadLine();
            int userInputInt = 0;
            if (Int32.TryParse(userInput, out userInputInt) && userInputInt == 1)
            {
                #region Create Players 
                //we can get these details from user itself. 
                List<Player> players = new List<Player>();
                //normal player can score from 0 to 9
                string batsManType = string.Empty;


                //for bowler no different type So type will be default and empty.
                List<int> player_Bowler = playerScoringStrategy.getPlayerScoringStrategy(batsManType);


                Console.WriteLine("Enter the type of BatsMan(Please Enter full string.) \n1. Hitter\n2.Deffensive\n");
                batsManType = Console.ReadLine();


                //todo:: Move this logic to strategy builder. 
                List<int> player_BatsMan = playerScoringStrategy.getPlayerScoringStrategy(batsManType);

                //Console.WriteLine("Enter the type of second Player\n1. Hitter\n2.Deffensive\n");
                //batsManType = Console.ReadLine();


                Player player1 = new Player(name: "BatsMan", scoreDetails: new ScoreDetails(), pType: PlayerType.Batsman, canScore: player_BatsMan, numberGeneratorService: randomNumberGerator);
                Player player2 = new Player(name: "BowlerMan", scoreDetails: new ScoreDetails(), pType: PlayerType.Bowler, canScore: player_Bowler, numberGeneratorService: randomNumberGerator);

                players.Add(player1);
                players.Add(player2);

                #endregion

                IgenerateNumber randomNumberGenerator = new generateSimpleRandomNo();
                CricketGameService cricketGame = new CricketGameService(randomNumberGenerator);

                cricketGame.StartGame(players);
            }
            else
            {
                Console.WriteLine("Please enter 1 to start the game");
            }
        }
    }
}
