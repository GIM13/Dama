namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DamaGame.Data.Models;
    using DamaGame.Web.ViewModels.Games;
    using DamaGame.Web.ViewModels.Players;

    public interface IGamesService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        Task CreateGameAsync(GameViewModel game, PlayerViewModel player, ApplicationUser user);
    }
}
