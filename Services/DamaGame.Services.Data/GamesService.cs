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
            var player = this.db.Players
                .Where(p => p.Name == selectedPlayerName)
                .FirstOrDefault();

            var pawn = this.db.Pawns
                .Where(p => p.Player.Name == selectedPlayerName)
                .FirstOrDefault();

            var pawns = new List<Pawn>();
            for (int i = 0; i < 9; i++)
            {
                pawns.Add(pawn);
            }

            var waiting = this.gamesRepository
               .All()
               .Any(g => g.RightPlayer == null);

            if (waiting)
            {
                var game = this.gamesRepository
                   .All()
                   .Where(g => g.RightPlayer == null)
                   .FirstOrDefault();

                game.RightPlayer = player;
                game.PawnsRightPlayer = pawns;
                this.db.SaveChanges();
            }
            else
            {
                var game = new Game
                {
                    LeftPlayer = player,
                    PawnsRightPlayer = pawns,
                };

                this.db.Games.Add(game);
                this.db.SaveChanges();
            }
        }
    }
}
