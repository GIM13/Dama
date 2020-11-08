namespace DamaGame.Web.Controllers
{
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Data.Models.Enums;
    using DamaGame.Services.Data;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : BaseController
    {
        private readonly IPlayersService playersService;

        private readonly IDeletableEntityRepository<Player> repository;

        public PlayersController(IPlayersService playersService, IDeletableEntityRepository<Player> repository)
        {
            this.playersService = playersService;
            this.repository = repository;
        }

        public IActionResult AddPlayer()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddPlayer(string name)
        {
            InsertPlayer(name);

            return this.View();
        }

        public IActionResult Index()
        {
            var players = this.playersService.GetAll<PlayerInputViewModel>();
            var model = new PlayersListViewModel { Players = players };
            return this.View(model);
        }

        public async Task<IActionResult> InsertPlayer(string name)
        {
            // var pawn = new Pawn
            // {
            //    TitularColor = input.TitularColor,
            //    ReserveColor = input.ReserveColor,
            //    Figure = input.Figure,
            // };

            var player = new Player { Name = name };

            // for (int i = 0; i < 9; i++)
            // {
            //    player.Pawns.Add(pawn);
            // }

            await this.repository.AddAsync(player);
            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
