namespace DamaGame.Services.Data
{
    using System.Collections.Generic;

    public interface IPlayersService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
