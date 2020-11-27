namespace DamaGame.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using DamaGame.Data;
    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Data.Models.Enums;
    using DamaGame.Services.Mapping;
    using DamaGame.Web.ViewModels.Games;
    using DamaGame.Web.ViewModels.Players;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly IDeletableEntityRepository<Connection> connectionRepository;
        private readonly IDeletableEntityRepository<Dama> damaRepository;
        private readonly IDeletableEntityRepository<Pawn> pawnRepository;
        private readonly IDeletableEntityRepository<Playground> playgroundRepository;
        private readonly IDeletableEntityRepository<Position> positionRepository;
        private readonly IDeletableEntityRepository<Player> playersRepository;

        private readonly ApplicationDbContext db;

        public GamesService(
            ApplicationDbContext db,
            IDeletableEntityRepository<Game> gamesRepository,
            IDeletableEntityRepository<Connection> connectionRepository,
            IDeletableEntityRepository<Dama> damaRepository,
            IDeletableEntityRepository<Pawn> pawnRepository,
            IDeletableEntityRepository<Playground> playgroundRepository,
            IDeletableEntityRepository<Position> positionRepository,
            IDeletableEntityRepository<Player> playersRepository)
        {
            this.db = db;
            this.gamesRepository = gamesRepository;
            this.connectionRepository = connectionRepository;
            this.damaRepository = damaRepository;
            this.pawnRepository = pawnRepository;
            this.playgroundRepository = playgroundRepository;
            this.positionRepository = positionRepository;
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

        public async Task CreateGameAsync(
            GameViewModel inputGame,
            PlayerViewModel inputPlayer,
            ApplicationUser user)
        {
            var position = new Position { Name = "AA" };
            var pawn = new Pawn
            {
                TitularColor = Color.Green,
                ReserveColor = Color.Green,
                Figure = FigurePawn.FigureTriangle,
            };
            var player = new Player { Name = "AAAAaaa", User = user, Pawn = pawn };

            await this.pawnRepository.AddAsync(pawn);
            await this.pawnRepository.SaveChangesAsync();

            await this.playersRepository.AddAsync(player);
            await this.playersRepository.SaveChangesAsync();

            await this.positionRepository.AddAsync(position);
            await this.positionRepository.SaveChangesAsync();
            //var player = new Player
            //{
            //    Name = inputPlayer.Name,
            //    User = inputPlayer.User,
            //    Pawn = inputPlayer.Pawn,
            //};

            //List<Pawn> pawnsPlayer = CreateListOfPawns(player);

            //if (inputGame != null)
            //{
            //    var game = new Game
            //    {
            //        LeftPlayer = inputGame.LeftPlayer,
            //        RightPlayer = player,
            //        Playground = inputGame.Playground,
            //        PawnsLeftPlayer = inputGame.PawnsLeftPlayer,
            //        PawnsRightPlayer = pawnsPlayer,
            //    };

            //    await this.gamesRepository.AddAsync(game);
            //    await this.gamesRepository.SaveChangesAsync();
            //}
            //else
            //{
            //    var game = new Game
            //    {
            //        LeftPlayer = player,
            //        RightPlayer = player,
            //        Playground = inputGame.Playground,
            //        PawnsLeftPlayer = pawnsPlayer,
            //        PawnsRightPlayer = pawnsPlayer,
            //    };

            //    await this.gamesRepository.AddAsync(game);
            //    await this.gamesRepository.SaveChangesAsync();
            //}
        }

        private static List<Pawn> CreateListOfPawns(Player player)
        {
            var pawnsPlayer = new List<Pawn>();

            for (int i = 0; i < 9; i++)
            {
                pawnsPlayer.Add(player.Pawn);
            }

            return pawnsPlayer;
        }
    }
}
