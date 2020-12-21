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
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly IDeletableEntityRepository<Player> playersRepository;
        private readonly IDeletableEntityRepository<Pawn> pawnRepository;

        public GamesService(
            ApplicationDbContext db,
            IDeletableEntityRepository<Game> gamesRepository,
            IDeletableEntityRepository<Player> playersRepository,
            IDeletableEntityRepository<Pawn> pawnRepository)
        {
            this.db = db;
            this.gamesRepository = gamesRepository;
            this.playersRepository = playersRepository;
            this.pawnRepository = pawnRepository;
        }

        public int GetCount()
        {
            return this.gamesRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.gamesRepository.All().To<T>().ToList();
        }

        public string CreateGame(string selectedPlayerName, ApplicationUser user)
        {
            var waitingPlayer = this.playersRepository
                .All()
                .Where(p => p.StatePlayer == StatePlayer.Waiting)
                .Select(x => x)
                .FirstOrDefault();

            if (waitingPlayer != null)
            {
                var waitingPlayerUser = this.playersRepository
                    .All()
                    .Where(p => p.Id == waitingPlayer.Id)
                    .Select(x => x.ApplicationUser)
                    .FirstOrDefault();

                waitingPlayer.ApplicationUser = waitingPlayerUser;
            }

            var newPlayer = this.playersRepository
                .All()
                .Select(x => x)
                .Where(p => p.Name == selectedPlayerName)
                .FirstOrDefault();

            var gameId = string.Empty;

            if (waitingPlayer == null)
            {
                newPlayer.StatePlayer = StatePlayer.Waiting;

                this.db.SaveChanges();
            }
            else
            {
                var game = new Game
                {
                    LeftPlayer = waitingPlayer,
                    RightPlayer = newPlayer,
                };

                waitingPlayer.StatePlayer = StatePlayer.InPlay;
                newPlayer.StatePlayer = StatePlayer.InPlay;

                gameId = game.Id;

                this.gamesRepository.AddAsync(game);
                this.db.SaveChanges();
            }

            return gameId;
        }

        public void FillingThePawns(GameViewModel model)
        {
            var leftPlayerPawn = this.pawnRepository
                .All()
                .Where(x => x.Id == model.LeftPlayer.PawnId)
                .FirstOrDefault();

            var rightPlayerPawn = this.pawnRepository
                .All()
                .Where(x => x.Id == model.RightPlayer.PawnId)
                .FirstOrDefault();

            for (int i = 0; i < 9; i++)
            {
                model.LeftPlayerPawns.Add(leftPlayerPawn);

                model.RightPlayerPawns.Add(rightPlayerPawn);
            }
        }

        public GamesListViewModel GetUpdateForGames()
        {
            var games = this.gamesRepository
                .All()
                .To<GameViewModel>()
                .OrderBy(x => x.CreatedOn);

            var waitinPlayer = this.playersRepository
                .All()
                .To<PlayerViewModel>()
                .Where(x => x.StatePlayer == StatePlayer.Waiting)
                .FirstOrDefault();

            var model = new GamesListViewModel
            {
                Games = games,
                WaitinPlayer = waitinPlayer,
            };

            return model;
        }

        public GameViewModel GetNewGame(ApplicationUser user)
        {
            var player = this.playersRepository
                .All()
                .To<PlayerViewModel>()
                .Where(x => x.ApplicationUser == user && x.StatePlayer == StatePlayer.InPlay)
                .FirstOrDefault();

            var game = this.gamesRepository
                .All()
                .To<GameViewModel>()
                .Where(x => x.LeftPlayer.Name == player.Name || x.RightPlayer.Name == player.Name)
                .FirstOrDefault();

            return game;
        }
    }
}
