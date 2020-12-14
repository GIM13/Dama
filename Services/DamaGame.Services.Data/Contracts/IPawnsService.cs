namespace DamaGame.Services.Data
{
    using DamaGame.Data.Models;
    using DamaGame.Web.ViewModels.Players;

    public interface IPawnsService
    {
        Pawn CreatePawn(PlayerInputViewModel input);
    }
}
