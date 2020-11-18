namespace DamaGame.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BeginningController : BaseController
    {
        private readonly IPlayersService playersService;

        private readonly UserManager<ApplicationUser> userManager;

        public BeginningController(
            IPlayersService playersService,
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
    }
}
