namespace DamaGame.Web.ViewModels.Players
{
    using System.Collections.Generic;

    using DamaGame.Web.ViewModels.Settings;

    public class PlayersListViewModel
    {
        public IEnumerable<PlayerInputViewModel> Players { get; set; }
    }
}
