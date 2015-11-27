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
        public void GetGames_TwoGames_Ok200()
        {
            // Arrange
            IRoulette rouletteMock = new RouletteMock()
            {
                AllGames = new List<SpinLogic.Model.Game>() {
                    new SpinLogic.Model.Game("2ed",5,2),
                    new SpinLogic.Model.Game("eu2",4,0)
                }
            };

            // Act
            SpinRoulette.ApiV1.Controllers.GamesController sut = new ApiV1.Controllers.GamesController(rouletteMock);
            var games = (ObjectResult)sut.GetGames();


            // Assert
            Assert.Equal(200, games.StatusCode.Value);
            Assert.Equal(2, ((List<Game>)games.Value).Count);
        }

        [Fact]
        public void GetGames_NoGames_NotFound404()
        {
            // Arrange
            IRoulette rouletteMock = new RouletteMock();

            // Act
            SpinRoulette.ApiV1.Controllers.GamesController sut = new ApiV1.Controllers.GamesController(rouletteMock);
            var games = (ObjectResult)sut.GetGames();


            // Assert
            Assert.Equal(404, games.StatusCode.Value);
        }
    }
}
