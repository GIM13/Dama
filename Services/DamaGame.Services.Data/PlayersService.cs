namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data;
    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<Player> playersRepository;
        private ApplicationDbContext db;

        public PlayersService(
            IDeletableEntityRepository<Player> playersRepository,
            ApplicationDbContext db)
        {
            this.playersRepository = playersRepository;
            this.db = db;
        }

        public int GetCount()
        {
            return this.playersRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.playersRepository.All().To<T>().ToList();
        }

        public IEnumerable<SelectListItem> GetAllPlayersTheUser(ApplicationUser user)
        {
            var result = this.playersRepository
                .All()
                .Where(x => x.User == user)
                .Select(p => new SelectListItem { Text = p.Name })
                .ToList();

            return result;
        }

        public async Task InsertPlayer(PlayerInputViewModel input, ApplicationUser user)
        {
            var pawn = new Pawn
            {
                TitularColor = input.TitularColor,
                ReserveColor = input.ReserveColor,
                Figure = input.Figure,
            };

            var player = new Player
            {
                Name = input.Name,
                User = user,
                Pawn = pawn,
            };

            await this.playersRepository.AddAsync(player);
            await this.playersRepository.SaveChangesAsync();
        }

        public async Task RemovePlayer(string name)
        {
            var player = this.playersRepository
                .All()
                .Where(x => x.Name == name)
                .FirstOrDefault();

            this.playersRepository.Delete(player);
            await this.playersRepository.SaveChangesAsync();
        }
    }
}
