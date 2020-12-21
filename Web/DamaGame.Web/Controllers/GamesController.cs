namespace DamaGame.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.Hubs;
    using DamaGame.Web.ViewModels.Games;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class GamesController : Controller
    {
        private readonly IPlayersService playersService;
        private readonly IGamesService gamesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHubContext<AllGamesHub> allGamesHub;

        public GamesController(
            IPlayersService playersService,
            IGamesService gamesService,
            UserManager<ApplicationUser> userManager,
            IHubContext<AllGamesHub> allGamesHub)
        {
            this.gamesService = gamesService;
            this.playersService = playersService;
            this.userManager = userManager;
            this.allGamesHub = allGamesHub;
        }

        public async Task<IActionResult> NewGameAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var model = new GameStartViewModel
            {
                PlayersSelectList = this.playersService.GetAllPlayersTheUser(user),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> NewGameAsync(GameStartViewModel gameStartView)
            /*[FromBody]string selectedPlayerName*/
        {
            var selectedPlayerName = gameStartView.SelectedPlayerName;
            var user = await this.userManager.GetUserAsync(this.User);

            var gameId = this.gamesService
                .CreateGame(selectedPlayerName, user)
                .ToString();

            if (gameId == string.Empty)
            {
                return this.View("PlayerWaiting");
            }

            var model = this.gamesService
                .GetAll<GameViewModel>()
                .Where(g => g.Id == gameId)
                .FirstOrDefault();

            this.gamesService.FillingThePawns(model);

            return this.View("Game", model);
        }

        public IActionResult AllGamesAsync()
        {
            var model = this.gamesService.GetUpdateForGames();

            return this.View(model);
        }

        public async Task<IActionResult> GameAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var game = this.gamesService.GetNewGame(user);

            return this.View(game);
        }
    }
}
