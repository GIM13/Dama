namespace DamaGame.Services.Data
{
    using DamaGame.Data.Models;
    using DamaGame.Web.ViewModels.Players;

    public class PawnsService : IPawnsService
    {
        public Pawn CreatePawn(PlayerInputViewModel input)
        {
            return new Pawn
            {
                TitularColor = input.TitularColor,
                ReserveColor = input.ReserveColor,
                Figure = input.Figure,
            };
        }
    }
}
