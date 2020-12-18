namespace DamaGame.Web.Hubs
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Games;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class AllGamesHub : Hub
    {
        public GamesListViewModel AllGamesRefresh(GamesListViewModel model)
        {
             return model;
        }
    }
}
