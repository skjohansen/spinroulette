using Microsoft.AspNet.Mvc;
using SpinLogic;
using SpinRoulette.ApiResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SpinRoulette.Test.ApiV1Controllers
{
    public class GameController
    {
        [Fact]
        public void GetGames_TwoGames_Success()
        {
            IRoulette rouletteMock = new RouletteMock() {
                AllGames = new List<SpinLogic.Model.Game>() {
                    new SpinLogic.Model.Game() { CylinderSize = 5, GameId = "2ed", NumberOfTiggerPulls = 2 },
                    new SpinLogic.Model.Game() {CylinderSize=4, GameId="eu2", NumberOfTiggerPulls=0 }
                }
            };

            SpinRoulette.ApiV1.Controllers.GamesController gc = new ApiV1.Controllers.GamesController(rouletteMock);
            var games = (ObjectResult)gc.GetGames();
            

            Assert.Equal(2, ((List<Game>)games.Value).Count);
        }
    }
}
