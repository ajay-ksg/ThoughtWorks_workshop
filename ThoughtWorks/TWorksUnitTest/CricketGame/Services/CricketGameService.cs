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
        public void StartGame(List<Player> players)
        {

            if (players != null && players.Count > 1)
            {
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

                //initialize local score for batsman and bowler.
                int batsManScore = -1;
                int bowlerScore = -1;


                //Play the game
                //todo:: move to a diff function. voilating SRP
                for (int over = 0; over < overs; over++)
                {
                    for (int bawl = 0; bawl < numberOfBallsInOneOver; bawl++)
                    {

                        if (batsManScore >= targetForBatsman)
                        {
                            Console.WriteLine("Batsman team has Won , As it has achieved the target");
                            return;
                        }
                        //get score for batsman
                        batsManScore = batsMan.getScore();

                        //get score for bowler
                        bowlerScore = bowler.getScore();
                        if (batsManScore == bowlerScore)
                        {
                            Console.WriteLine("BatsMan out with Score {0}, after {1} Overs and {2} bawls and Bowler team has Won!!", batsMan.ScoreDetails.TotalScore, over, bawl);
                            return;
                        }

                        //update batsman score 
                        batsMan.ScoreDetails.IncreaseScore(batsManScore);
                        batsMan.ScoreDetails.IncrementNoOfBallPlayed();



                        //update bowler score
                        bowler.ScoreDetails.IncreaseScore(bowlerScore);
                        bowler.ScoreDetails.IncrementNoOfBallPlayed();
                    }


                }

                //check the final scores. We can move ths to different service having different Winning strategies.

                if (batsMan.ScoreDetails.TotalScore > bowler.ScoreDetails.TotalScore)
                    Console.WriteLine("Batsman team has Won , With total Score {0}", batsMan.ScoreDetails.TotalScore);
                else
                    Console.WriteLine("Bowler team has Won , With total Score {0}", bowler.ScoreDetails.TotalScore);

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
