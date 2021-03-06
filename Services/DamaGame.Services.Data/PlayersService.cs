﻿namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Authorize]
    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<Player> playersRepository;
        private readonly IPawnsService pawnsService;

        public PlayersService(
            IDeletableEntityRepository<Player> playersRepository,
            IPawnsService pawnsService)
        {
            this.playersRepository = playersRepository;
            this.pawnsService = pawnsService;
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
                .Where(x => x.ApplicationUser == user)
                .Select(p => new SelectListItem { Text = p.Name })
                .ToList();

            return result;
        }

        public async Task InsertPlayer(PlayerInputViewModel input, ApplicationUser user)
        {
            Pawn pawn = this.pawnsService.CreatePawn(input);

            Player player = this.CreatePlayer(input.Name, user, pawn);

            await this.playersRepository.AddAsync(player);
            await this.playersRepository.SaveChangesAsync();
        }

        public Player CreatePlayer(string name, ApplicationUser user, Pawn pawn)
        {
            return new Player
            {
                Name = name,
                ApplicationUser = user,
                Pawn = pawn,
            };
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
