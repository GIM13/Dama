namespace DamaGame.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BeginningController : BaseController
    {
        private readonly IPlayersService playersService;

        private readonly UserManager<ApplicationUser> userManager;

        public BeginningController(
            IPlayersService playersService,
            IDeletableEntityRepository<Player> playersRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.playersService = playersService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Beginning()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var players = this.playersService.GetAll<PlayerViewModel>()
                                             .Where(x => x.User == user);

            var model = new PlayersListViewModel { PlayersUser = players };

            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
