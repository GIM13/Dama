namespace DamaGame.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PlayersController : BaseController
    {
        private readonly IPlayersService playersService;

        private readonly IDeletableEntityRepository<Player> playersRepository;

        private readonly UserManager<ApplicationUser> userManager;

        public PlayersController(
            IPlayersService playersService,
            IDeletableEntityRepository<Player> playersRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.playersService = playersService;
            this.playersRepository = playersRepository;
            this.userManager = userManager;
        }

        public IActionResult AddPlayer()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayerAsync(PlayerInputViewModel input)
        {
            if (this.playersRepository.All().Any(x => x.Name == input.Name)
                || input.Name.Length < 4
                || input.Name.Length > 16)
            {
                return this.RedirectToAction("AddPlayerError", "Errors");
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.playersService.InsertPlayer(input, user);

            return this.RedirectToAction("MyPlayers");
        }

        public IActionResult RemovePlayer()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RemovePlayerAsync(string name)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.playersRepository.All().Any(x => x.Name == name && x.ApplicationUser == user))
            {
                return this.RedirectToAction("RemovePlayerError", "Errors");
            }

            await this.playersService.RemovePlayer(name);

            return this.RedirectToAction("MyPlayers");
        }

        public async Task<IActionResult> MyPlayers()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var players = this.playersService.GetAll<PlayerViewModel>()
                                             .Where(x => x.ApplicationUser == user);

            var model = new PlayersListViewModel { PlayersUser = players };

            return this.View(model);
        }

        public IActionResult Index()
        {
            var players = this.playersService.GetAll<PlayerViewModel>()
                                             .OrderByDescending(x => x.Wins - x.Losses);

            var model = new PlayersListViewModel { PlayersUser = players };

            return this.View(model);
        }
    }
}
