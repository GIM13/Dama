namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Mvc;

    public interface IPlayersService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        Task InsertPlayer(PlayerInputViewModel input, ApplicationUser user);

        Task<string> RemovePlayer(string name);
    }
}
