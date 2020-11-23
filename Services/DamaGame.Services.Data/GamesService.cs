namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;
    using DamaGame.Web.ViewModels.Games;
    using DamaGame.Web.ViewModels.Players;

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
            var testplayer = new Player { Name = "WWWWWWW" };

            await this.playersRepository.AddAsync(testplayer);
            await this.playersRepository.SaveChangesAsync();

            var player = this.playersRepository
                .All()
                .Where(p => p.Name == selectedPlayerName)
                .FirstOrDefault();

            var game = this.gamesRepository
                .All()
                .Where(g => g.RightPlayer == null)
                .FirstOrDefault();

            if (game != null)
            {
                game.RightPlayer = player;

                await this.gamesRepository.SaveChangesAsync();
            }
            else
            {
                game = new Game
                {
                    LeftPlayer = player,
                    RightPlayer = player,
                };

                await this.gamesRepository.AddAsync(game);
                await this.gamesRepository.SaveChangesAsync();
            }
        }
    }
}
