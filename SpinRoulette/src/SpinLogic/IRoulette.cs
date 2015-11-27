using SpinLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinLogic
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public interface IRoulette
    {
        Game GetGame(string gameId);
        TriggerResult PullTrigger(string gameId);
        Game CreateGame(uint cylinderSize);
        void RestartGame(string gameId);
        List<Game> GetAllGames();
    }
}
