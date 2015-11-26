using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using SpinRoulette.ApiResources;
using Microsoft.AspNet.Http.Internal;
using SpinLogic;

namespace SpinRoulette.ApiV1.Controllers
{
    [Route("v1/[controller]")]
    public class GamesController : Controller
    {
        private IRoulette _rouletteGame;
        public GamesController() {
            _rouletteGame = new Roulette();
        }

        public GamesController(IRoulette roulette)
        {
            _rouletteGame = roulette;
        }

        #region Games
        /// <summary>
        /// GET: v1/games 
        /// Retrive all ongoing games in the system
        /// </summary>
        /// <returns>200: List of games, 404: No active games</returns>
        [HttpGet]
        public IActionResult GetGames()
        {
            // Retrive all games
            var games = _rouletteGame.GetAllGames();
            if (games.Count == 0)
            {
                return new ObjectResult(new Status() { Message = "No games found" }) { StatusCode = 404 };
            }

            // Convert games to the API obejct
            List<Game> apiGames = new List<Game>();
            games.ForEach(g => apiGames.Add(new Game() { CylinderSize = g.CylinderSize, GameId = g.GameId, NumberOfTiggerPulls = g.NumberOfTiggerPulls }));

            return new ObjectResult(apiGames) { StatusCode = 200 };
        }

        /// <summary>
        /// POST v1/games
        /// Create a new game
        /// </summary>
        /// <param name="value">Game to create, the ID will be ignored</param>
        /// <returns>200: The full game object, 400: Something went wrong</returns>
        [HttpPost]
        public IActionResult PostGames([FromBody]Game inputGame)
        {
            IRoulette rouletteGame = new Roulette();

            Game outputGame  = null;
            try {
                var createdGame = rouletteGame.CreateGame(new SpinLogic.Model.Game() { CylinderSize = inputGame.CylinderSize });
                outputGame = new Game() { CylinderSize = createdGame.CylinderSize, GameId = createdGame.GameId, NumberOfTiggerPulls = createdGame.NumberOfTiggerPulls };
            }
            catch {
                return new ObjectResult(new Status() {Message="Something went wrong when trying to create the game" }) { StatusCode = 400 };
            }

            if (outputGame == null) {
                return new ObjectResult(new Status() { Message = "Something went wrong when trying to create the game" }) { StatusCode = 400 };
            }

            return new ObjectResult(outputGame) { StatusCode = 200 };
        }
        #endregion Games

        #region Game
        /// <summary>
        /// GET v1/games/5
        /// Retive a specific game
        /// </summary>
        /// <param name="id">ID of game to retrive</param>
        /// <returns>200: Game information, 404: Game not found</returns>
        [HttpGet("{id}")]
        public IActionResult GetGame(string id)
        {
            IRoulette rouletteGame = new Roulette();

            Game outputGame = null;
            try
            {
                var loadedGame = rouletteGame.GetGame(id);
                outputGame = new Game() { CylinderSize = loadedGame.CylinderSize, GameId = loadedGame.GameId, NumberOfTiggerPulls = loadedGame.NumberOfTiggerPulls };
            }
            catch
            {
                return new ObjectResult(new Status() { Message = "No game found" }) { StatusCode = 404 };
            }

            if (outputGame == null)
            {
                return new ObjectResult(new Status() { Message = "Something went wrong when trying to create the game" }) { StatusCode = 400 };
            }

            return new ObjectResult(outputGame) { StatusCode = 200 };

        }

        /// <summary>
        /// PATCH v1/games/5 
        /// Restart a game (reload the gun)
        /// </summary>
        /// <param name="id">ID of game to restart</param>
        /// <returns>200: A game object, 404: Game not found</returns>
        [HttpPatch("{id}")]
        public IActionResult PatchGame(string id)
        {
            IRoulette rouletteGame = new Roulette();
            try
            {
                rouletteGame.RestartGame(id);
            }
            catch
            {
                return new ObjectResult(new Status() { Message = "No game found" }) { StatusCode = 404 };
            }

            Game outputGame = null;
            try
            {
                var loadedGame = rouletteGame.GetGame(id);
                outputGame = new Game() { CylinderSize = loadedGame.CylinderSize, GameId = loadedGame.GameId, NumberOfTiggerPulls = loadedGame.NumberOfTiggerPulls };
            }
            catch
            {
                return new ObjectResult(new Status() { Message = "No game found" }) { StatusCode = 404 };
            }

            if (outputGame == null)
            {
                return new ObjectResult(new Status() { Message = "Something went wrong when trying to create the game" }) { StatusCode = 400 };
            }

            return new ObjectResult(outputGame) { StatusCode = 200 };
        }

        /// <summary>
        /// POST v1/games/5 
        /// Pull the trigger
        /// </summary>
        /// <param name="id">ID of game to affect</param>
        /// <returns>200: Game information - player surived, 404: Game not found, 410: Game have been deleted which means the gun went off</returns>
        [HttpPost("{id}")]
        public IActionResult PostGame(string id)
        {
            IRoulette rouletteGame = new Roulette();

            Game outputGame = null;
            try
            {
                var triggerResult = rouletteGame.PullTrigger(id);


                if (triggerResult == TriggerResult.Bang) {
                    return new ObjectResult(new Status() { Message = "Bang" }) { StatusCode = 410 };
                }


                var loadedGame = rouletteGame.GetGame(id);
                outputGame = new Game() { CylinderSize = loadedGame.CylinderSize, GameId = loadedGame.GameId, NumberOfTiggerPulls = loadedGame.NumberOfTiggerPulls };
            }
            catch
            {
                return new ObjectResult(new Status() { Message = "No game found" }) { StatusCode = 404 };
            }

            if (outputGame == null)
            {
                return new ObjectResult(new Status() { Message = "Something went wrong when trying to create the game" }) { StatusCode = 400 };
            }

            return new ObjectResult(outputGame) { StatusCode = 200 };
            
        }
        #endregion Game
    }
}
