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
        public int getRandomNumberlessThanNine()
        {
            Random random = new Random();
            return random.Next(0, maxNumberOfPages)%10;
        }
    }
}
