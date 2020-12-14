namespace DamaGame.Web.ViewModels.Games
{
    using System.Collections.Generic;

    using DamaGame.Web.ViewModels.Players;

    public class GamesListViewModel
    {
        public PlayerViewModel WaitinPlayer { get; set; }

        public IEnumerable<GameViewModel> Games { get; set; }
    }
}
