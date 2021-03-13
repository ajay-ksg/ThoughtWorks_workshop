using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    public interface IgenerateNumber
    {
        int getRandomNumberlessThanNine();
        int getRandomNoInLimit(int upperBound);

    }
}
