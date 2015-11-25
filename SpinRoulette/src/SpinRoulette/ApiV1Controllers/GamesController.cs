using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SpinRoulette.ApiResources;


namespace SpinRoulette.ApiV1.Controllers
{
    [Route("v1/[controller]")]
    public class GamesController : Controller
    {
        // GET: v1/games
        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            return new Game[] { new Game() {CylinderSize = 6, GameId = "1", NumberOfTiggerPulls = 0 }, new Game() { CylinderSize = 6, GameId = "jku2", NumberOfTiggerPulls = 2 } };

            // Status 200 + 404
        }

        // POST v1/games
        [HttpPost]
        public Game PostGames([FromBody]string value)
        {
            return new Game() { CylinderSize = 6, GameId = "1", NumberOfTiggerPulls = 0 };

            // Status 200 + 400
        }

        // GET v1/games/5
        [HttpGet("{id}")]
        public Game GetGame(string id)
        {
            return new Game() { CylinderSize = 6, GameId = "1", NumberOfTiggerPulls = 0 };

            // Status 200 + 404
        }

        // PATCH v1/games/5
        [HttpPatch("{id}")]
        public Game PatchGame(string id, [FromBody]string value)
        {
            return new Game() { CylinderSize = 6, GameId = "1", NumberOfTiggerPulls = 0 };

            // Status 200
        }

        // POST v1/games/5
        [HttpPost("{id}")]
        public Game PostGame(string id)
        {
            return new Game() { CylinderSize = 6, GameId = "1", NumberOfTiggerPulls = 0 };

            // Status 204 + 410
        }
    }
}
