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
        ScoreDetails scoreDetails;
        public Player(string name,ScoreDetails scoreDetails,PlayerType pType)
        {
            this.playerName = name;
            playerType = pType;
            this.scoreDetails = scoreDetails;
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
    }
}
