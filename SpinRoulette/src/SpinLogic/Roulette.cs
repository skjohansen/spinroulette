using System;
using System.Collections.Generic;
using System.Linq;
using SpinLogic.Model;

namespace SpinLogic
{
    public class Roulette : IRoulette
    {
        private static Dictionary<string, Game> RunningGames;
        private IRandomGenerator _randomGenerator;

        public Roulette(IRandomGenerator randomGenerator)
        {
            if (RunningGames == null)
            {
                RunningGames = new Dictionary<string, Game>();
            }
            _randomGenerator = randomGenerator;
        }


        public Game CreateGame(uint cylinderSize)
        {
            if (cylinderSize < 2)
            {
                throw new Exception("CylinderSize must be higher than 2");
            }

            string gameId = string.Empty;
            do
            {
                gameId = _randomGenerator.GameId(5);
            } while (RunningGames.ContainsKey(gameId));

            var bulletPosition = _randomGenerator.RandomNumber(0, (int)(cylinderSize - 1));

            RunningGames.Add(gameId, new Game(gameId, cylinderSize, (uint)bulletPosition));

            return RunningGames[gameId];
        }

        public Game GetGame(string gameId)
        {
            if (!RunningGames.ContainsKey(gameId))
            {
                throw new KeyNotFoundException();
            }

            return RunningGames[gameId];
        }

        public TriggerResult PullTrigger(string gameId)
        {
            if (!RunningGames.ContainsKey(gameId))
            {
                throw new KeyNotFoundException();
            }

            RunningGames[gameId].CurrentTriggerPosition++;
            if (RunningGames[gameId].Cylinder[RunningGames[gameId].CurrentTriggerPosition] == BulletHole.ContainsBullet)
            {
                RunningGames.Remove(gameId);
                return TriggerResult.Bang;
            }

            RunningGames[gameId].Cylinder[RunningGames[gameId].CurrentTriggerPosition] = BulletHole.Fired;
            return TriggerResult.Click;
        }

        public void RestartGame(string gameId)
        {
            if (!RunningGames.ContainsKey(gameId))
            {
                throw new KeyNotFoundException();
            }

            uint newBulletPosition = (uint)_randomGenerator.RandomNumber(0, (int)(RunningGames[gameId].CylinderSize - 1));

            RunningGames[gameId].InitGame(newBulletPosition);
        }

        List<Game> IRoulette.GetAllGames()
        {
            return RunningGames.Values.ToList();
        }
    }
}
