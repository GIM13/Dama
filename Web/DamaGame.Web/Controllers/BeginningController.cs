namespace DamaGame.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Beginning()
        {
            return this.View();
        }
    }
}
