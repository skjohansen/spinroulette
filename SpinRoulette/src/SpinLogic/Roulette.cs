using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpinLogic.Model;

namespace SpinLogic
{
    public class Roulette : IRoulette
    {
        public Game CreateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public Game GetGame(string gameId)
        {
            throw new NotImplementedException();
        }

        public TriggerResult PullTrigger(string gameId)
        {
            throw new NotImplementedException();
        }

        public void RestartGame(string gameId)
        {
            throw new NotImplementedException();
        }

        List<Game> IRoulette.GetAllGames()
        {
            return new List<Game> { new Game() { CylinderSize = 6, GameId = "1", NumberOfTiggerPulls = 0 }, new Game() { CylinderSize = 6, GameId = "jku2", NumberOfTiggerPulls = 2 } };
        }
    }
}
