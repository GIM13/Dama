namespace DamaGame.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Games;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class GamesController : Controller
    {
        private readonly IPlayersService playersService;

        private readonly IGamesService gamesService;

        private readonly UserManager<ApplicationUser> userManager;

        public GamesController(
            IPlayersService playersService,
            IGamesService gamesService,
            UserManager<ApplicationUser> userManager)
        {
            this.gamesService = gamesService;
            this.playersService = playersService;
            this.userManager = userManager;
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

        public IActionResult AllGames()
        {
            var games = this.gamesService
                .GetAll<GameViewModel>()
                .OrderBy(x => x.CreatedOn);

            var waitinPlayer = this.playersService
                .GetAll<PlayerViewModel>()
                .Where(x => x.Waiting == true)
                .FirstOrDefault();

            var model = new GamesListViewModel
            {
                Games = games,
                WaitinPlayer = waitinPlayer,
            };

            return this.View(model);
        }

        // public IActionResult Game()
        // {
        //     var game = this.gamesService
        //         .GetAll<GameViewModel>()
        //         .Where(x => x.Id == "ot kade")
        //         .FirstOrDefault();
        //     return this.View(game);
        // }
    }
}
