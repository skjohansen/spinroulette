using SpinLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpinLogic.Model;

namespace SpinRoulette.Test.ApiV1Controllers
{
    public class RouletteMock : IRoulette
    {
        public RouletteMock()
        {
            AllGames = new List<Game>();
        }

        public List<Game> AllGames { get; set; }

        public Game CreateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllGames()
        {
            return AllGames;
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
    }
}
