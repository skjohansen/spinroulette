using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinRoulette.ApiResources
{
    public class Game
    {
        public string GameId { get; set; }
        public uint NumberOfTiggerPulls { get; set; }
        public uint CylinderSize { get; set; }
    }
}
