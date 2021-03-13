using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{

    enum PlayerType
    {
        Batsman,
        Bowler,
        Unknown

    }
    class Player
    {
        string playerName;
        string gender;
        PlayerType playerType;
        List<int> canScore;
        ScoreDetails scoreDetails;
        IgenerateNumber randomNumberGenerator = null;
        public Player(string name,ScoreDetails scoreDetails,PlayerType pType, List<int> canScore, IgenerateNumber numberGeneratorService)
        {
            this.playerName = name;
            playerType = pType;
            this.scoreDetails = scoreDetails;
            this.canScore = canScore;
            this.randomNumberGenerator = numberGeneratorService;
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            set
            {
                this.playerName = value;
            }
        }

        public PlayerType PlayerType
        {
            get
            {
                return this.playerType;
            }

            set
            {
                this.playerType = value;
            }
        }

        public List<int> CanScore
        {
            get
            {
                return this.canScore;
            }

            set
            {
                this.canScore = value;
            }
        }


        public ScoreDetails ScoreDetails
        {
            get
            {
                return this.scoreDetails;
            }
            set
            {
                this.scoreDetails = value;
            }
        }

        internal int getScore()
        {
            int scoreIndex = randomNumberGenerator.getRandomNoInLimit(this.CanScore.Count);
            
            return this.CanScore[scoreIndex];
        }
    }
}
