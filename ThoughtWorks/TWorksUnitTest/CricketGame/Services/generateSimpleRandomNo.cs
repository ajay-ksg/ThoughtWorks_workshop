using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    public class generateSimpleRandomNo : IgenerateNumber
    {
        //todo:: move to constants
        int maxNumberOfPages = 300;
        static readonly Random random = new Random();


        public int getRandomNoInLimit(int upperBound)
        {
            return random.Next(0, upperBound);   
        }

        public int getRandomNumberlessThanNine()
        {
            
            return random.Next(0, 10);
        }
    }
}
