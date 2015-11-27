using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinLogic
{
    public interface IRandomGenerator
    {
        int RandomNumber(int from, int to);
        string GameId(int lenght);
    }
}
