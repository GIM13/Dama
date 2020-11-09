namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;
    using DamaGame.Web.ViewModels.Players;

    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<Player> playersRepository;

        public PlayersService(IDeletableEntityRepository<Player> settingsRepository)
        {
            this.playersRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.playersRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.playersRepository.All().To<T>().ToList();
        }

        public void InsertPlayer(PlayerInputViewModel input)
        {
            var pawn = new Pawn
            {
                TitularColor = input.TitularColor,
                ReserveColor = input.ReserveColor,
                Figure = input.Figure,
            };

            var player = new Player { Name = input.Name };

            for (int i = 0; i < 9; i++)
            {
                player.Pawns.Add(pawn);
            }

            this.playersRepository.AddAsync(player);
            this.playersRepository.SaveChangesAsync();
        }
    }
}
