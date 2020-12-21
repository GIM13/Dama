namespace DamaGame.Web.Hubs
{
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Services.Data;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class AllGamesHub : Hub
    {
        private readonly IGamesService gamesService;
        private readonly UserManager<ApplicationUser> userManager;

        public AllGamesHub(
            UserManager<ApplicationUser> userManager,
            IGamesService gamesService)
        {
            this.gamesService = gamesService;
            this.userManager = userManager;
        }

        public async Task AllGamesRefreshAsync()
        {
            var newModel = this.gamesService.GetUpdateForGames();

            await this.Clients.All.SendAsync("AllGames", newModel);
        }

        public async Task NewGameAsync()
        {
            var user = await this.userManager.GetUserAsync(this.Context.User);

            var game = this.gamesService.GetNewGame(user);

            await this.Clients.All.SendAsync("Game", game);
        }
    }
}
