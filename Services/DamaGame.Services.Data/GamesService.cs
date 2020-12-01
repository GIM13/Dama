namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DamaGame.Data;
    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Data.Models.Enums;
    using DamaGame.Services.Mapping;
    using DamaGame.Web.ViewModels.Games;
    using DamaGame.Web.ViewModels.Players;

    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly IDeletableEntityRepository<Player> playersRepository;

        public GamesService(
            ApplicationDbContext db,
            IDeletableEntityRepository<Game> gamesRepository,
            IDeletableEntityRepository<Player> playersRepository)
        {
            this.db = db;
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

        public void CreateGame(string selectedPlayerName)
        {
            var player1 = this.playersRepository
                .All()
                .To<PlayerViewModel>()
                .To<Player>()
                .Where(p => p.Name == selectedPlayerName)
                .FirstOrDefault();

            var player2 = this.playersRepository
                .All()
                .Where(p => p.Name == "Genadi")
                .To<PlayerViewModel>()
                .To<Player>()
                .FirstOrDefault();

            // var waiting = this.gamesRepository
            //    .All()
            //    .Any(g => g.RightPlayer == null);
            if (false)
            {
                // var game = this.gamesRepository
                //    .All()
                //    .Where(g => g.RightPlayer == null)
                //    .FirstOrDefault();

                // game.RightPlayer = player;
                // await this.gamesRepository.SaveChangesAsync();
            }
            else
            {
                var game = new Game
                {
                    Test = "test6",
                    LeftPlayer = player1,
                    RightPlayer = player2,
                };

                this.db.Games.Add(game);
                this.db.SaveChanges();
            }
        }
    }
}
