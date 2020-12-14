namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IPlayersService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        Task InsertPlayer(PlayerInputViewModel input, ApplicationUser user);

        Task RemovePlayer(string name);

        IEnumerable<SelectListItem> GetAllPlayersTheUser(ApplicationUser user);

        Player CreatePlayer(string name, ApplicationUser user, Pawn pawn);
    }
}
