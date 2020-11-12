namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DamaGame.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Mvc;

    public interface IPlayersService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        Task<IActionResult> InsertPlayer(PlayerInputViewModel input);
    }
}
