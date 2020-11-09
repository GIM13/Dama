namespace DamaGame.Services.Data
{
    using System.Collections.Generic;

    using DamaGame.Web.ViewModels.Players;

    public interface IPlayersService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        void InsertPlayer(PlayerInputViewModel input);
    }
}
