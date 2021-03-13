using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    class SimpleScoringStretagy : IPlayerScoringStrategy
    {

        Dictionary<String, List<int>> batsManToStrategyMap;


        public SimpleScoringStretagy()
        {
            batsManToStrategyMap = new Dictionary<string, List<int>>();
            buildStrategy();
        }

        private void buildStrategy()
        {
            //todo:: rather inserting values here we can store them to DB and fetch . 
            batsManToStrategyMap.Add("Hitter", new List<int> {0,4,6 });
            batsManToStrategyMap.Add("Deffensive", new List<int> {0,1,2,3});
        }

        public List<int> getPlayerScoringStrategy(string batsManType)
        {
            //Default score can be acheived.
            List<int> canScore = new List<int> { 0,1,2,3,4,5,6,7,8,9};

            if (this.batsManToStrategyMap.ContainsKey(batsManType))
                canScore = batsManToStrategyMap[batsManType];

            return canScore;
        }
    }
}
