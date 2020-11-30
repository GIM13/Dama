namespace DamaGame.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Games;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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
        public IActionResult NewGameAsync(GameStartViewModel gameStartView)
        {
            var selectedPlayerName = gameStartView.SelectedPlayerName;

            this.gamesService.CreateGame(selectedPlayerName);

            return this.RedirectToAction("Game");
        }

        public IActionResult Game()
        {
            return this.View();
        }

        public IActionResult AllGames()
        {
            var games = this.gamesService
                .GetAll<GameViewModel>();

            var model = new GamesListViewModel { Games = games };

            return this.View(model);
        }
    }
}
