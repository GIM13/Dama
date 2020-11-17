﻿namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DamaGame.Data.Common.Repositories;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<Player> playersRepository;

        private readonly UserManager<ApplicationUser> userManager;

        public PlayersService(
            IDeletableEntityRepository<Player> playersRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.playersRepository = playersRepository;
            this.userManager = userManager;
        }

        public int GetCount()
        {
            return this.playersRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.playersRepository.All().To<T>().ToList();
        }

        public async Task InsertPlayer(PlayerInputViewModel input, ApplicationUser user)
        {
            var pawn = new Pawn
            {
                TitularColor = input.TitularColor,
                ReserveColor = input.ReserveColor,
                Figure = input.Figure,
            };

            var player = new Player { Name = input.Name, User = user };

            for (int i = 0; i < 9; i++)
            {
                player.Pawns.Add(pawn);
            }

            await this.playersRepository.AddAsync(player);
            await this.playersRepository.SaveChangesAsync();
        }

        public async Task<string> RemovePlayer(string name)
        {
            if (!this.playersRepository.All().Any(x => x.Name == name))
            {
                return "There is no such player";
            }

            var player = this.playersRepository
                .All()
                .Where(x => x.Name == name)
                .FirstOrDefault();

            this.playersRepository.Delete(player);
            await this.playersRepository.SaveChangesAsync();

            return null;
        }
    }
}
