using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    class ScoreDetails
    {
        int totalScore;
        int noOfBallsPlayed;

        public int TotalScore
        {
            get
            {
                return this.totalScore;
            }
            set
            {
                this.totalScore = value;
            }
        }

        public int NoOfBallsPlayed
        {
            get
            {
                return this.noOfBallsPlayed;
            }
            set
            {
                this.noOfBallsPlayed = value;
            }
        }
    }
}
