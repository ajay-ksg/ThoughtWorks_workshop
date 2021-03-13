using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    class CricketGameService
    {
        int overs;
        int targetForBatsman;

        IgenerateNumber randomNumberGeneratorService = null;

        public CricketGameService(IgenerateNumber randomNumbergenerator)
        {
            this.randomNumberGeneratorService = randomNumbergenerator;
        }
        //for now declare here .. move it to constants
        int numberOfBallsInOneOver = 6;
        public  void StartGame(List<Player> players)
        {

            if (players != null && players.Count > 1) {
                Player batsMan = null;
                Player bowler = null; 

                //get the players.
                if (players[0].PlayerType == PlayerType.Batsman)
                {
                    batsMan = players[0];
                    bowler = players[1];
                }
                else
                {
                    batsMan = players[1];
                    bowler = players[0];
                }

               
                //todo:: we can have diff service for matchDetails 
                getMatchDetails();
                int batsManScore = -1;
                int bowlerScore = -1;
                for (int over = 0; over < overs; over++)
                {
                    for (int bawl = 0; bawl < numberOfBallsInOneOver; bawl++) {
                        //get score for batsman.
                        batsManScore = randomNumberGeneratorService.getRandomNumberlessThanNine();

                        //get score for bowler
                        bowlerScore = randomNumberGeneratorService.getRandomNumberlessThanNine();

                        if (batsManScore == bowlerScore)
                        {
                            Console.WriteLine("BatsMan out with Score {0}, after {1} Overs and {2} bawls and Bowler team has Won!!", batsMan.ScoreDetails.TotalScore, over, bawl);
                            return;
                        }

                        //update batsman score 
                        batsMan.ScoreDetails.TotalScore += batsManScore;
                        batsMan.ScoreDetails.NoOfBallsPlayed += 1;


                        //update bowler score
                        bowler.ScoreDetails.TotalScore += bowlerScore;
                        bowler.ScoreDetails.NoOfBallsPlayed += 1;
                    }

                    if (batsMan.ScoreDetails.TotalScore > bowler.ScoreDetails.TotalScore)
                        Console.WriteLine("Batsman team has Won , With total Score {0}", batsMan.ScoreDetails.TotalScore);
                    else
                        Console.WriteLine("Bowler team has Won , With total Score {0}", bowler.ScoreDetails.TotalScore);

                }
            }
        }

        private void getMatchDetails()
        {
            Console.WriteLine("Enter the Overs : ");
            string over = Console.ReadLine();

            //todo:: we can segrigate the validations.
            if (!Int32.TryParse(over, out overs))
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine("Enter the Target for batsman : ");
            string target = Console.ReadLine();
            if (!Int32.TryParse(target, out targetForBatsman))
            {
                Console.WriteLine("Invalid input");
            }


        }
    }
}
