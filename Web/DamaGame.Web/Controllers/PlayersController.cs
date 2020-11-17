namespace DamaGame.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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
            var user = await this.userManager.GetUserAsync(this.User);

            await this.playersService.InsertPlayer(input, user);

            return this.RedirectToAction("Beginning", "Beginning");
        }

        public IActionResult RemovePlayer()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RemovePlayerAsync(string name)
        {
            await this.playersService.RemovePlayer(name);

            return this.RedirectToAction("Beginning", "Beginning");
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
