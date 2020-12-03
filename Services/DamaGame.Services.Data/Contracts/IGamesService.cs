namespace DamaGame.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DamaGame.Data.Models;
    using DamaGame.Web.ViewModels.Games;

    public interface IGamesService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        string CreateGame(string selectedPlayerName);

        void FillingThePawns(GameViewModel model);
    }
}
