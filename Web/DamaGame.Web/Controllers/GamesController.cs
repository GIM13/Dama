namespace DamaGame.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Games;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class GamesController : Controller
    {
        private readonly IPlayersService playersService;

        private readonly IDeletableEntityRepository<Player> playersRepository;

        private readonly IDeletableEntityRepository<Game> gamesRepository;

        private readonly UserManager<ApplicationUser> userManager;

        public GamesController(
            IPlayersService playersService,
            IDeletableEntityRepository<Game> gameRepository,
            IDeletableEntityRepository<Player> playersRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.playersService = playersService;
            this.gamesRepository = gameRepository;
            this.userManager = userManager;
            this.playersRepository = playersRepository;
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
        public IActionResult NewGame(GameStartViewModel gameStartView)
        {
            var player = this.playersRepository
                .All()
                .Where(p => p.Name == gameStartView.SelectedPlayerName)
                .FirstOrDefault();

            var gameWithoutOpponent = this.gamesRepository
                .All()
                .Where(g => g.RightPlayer == null)
                .FirstOrDefault();

            var game = new Game();

            if (gameWithoutOpponent != null)
            {
                gameWithoutOpponent.RightPlayer = player;
            }
            else
            {
               game.LeftPlayer = player;
            }

            return this.View("Game", game);
        }

        public IActionResult Game()
        {
            return this.View();
        }

        public IActionResult AllGames()
        {
            return this.View();
        }
    }
}
