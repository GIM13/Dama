namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;

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
    }
}
