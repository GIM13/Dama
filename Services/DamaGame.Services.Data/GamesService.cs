namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;

        private readonly IDeletableEntityRepository<Player> playersRepository;

        public GamesService(
            IDeletableEntityRepository<Game> gamesRepository,
            IDeletableEntityRepository<Player> playersRepository)
        {
            this.gamesRepository = gamesRepository;
            this.playersRepository = playersRepository;
        }

        public int GetCount()
        {
            return this.gamesRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.gamesRepository.All().To<T>().ToList();
        }

        public async Task CreateGameAsync(string selectedPlayerName)
        {
            var player = this.playersRepository
                .All()
                .Where(p => p.Name == selectedPlayerName && p.User != null && p.Pawns.Count != 0)
                .FirstOrDefault();

            var gameWithoutOpponent = this.gamesRepository
                .All()
                .Where(g => g.RightPlayer == null)
                .FirstOrDefault();

            if (gameWithoutOpponent != null)
            {
                gameWithoutOpponent.RightPlayer = player;
            }
            else
            {
                var game = new Game
                {
                    LeftPlayer = player,
                };

                await this.gamesRepository.AddAsync(game);
                await this.gamesRepository.SaveChangesAsync();
            }
        }
    }
}
