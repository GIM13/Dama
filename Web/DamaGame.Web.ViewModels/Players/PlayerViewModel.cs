namespace DamaGame.Web.ViewModels.Players
{
    using AutoMapper;
    using DamaGame.Data.Models;
    using DamaGame.Data.Models.Enums;
    using DamaGame.Services.Mapping;

    public class PlayerViewModel : IMapFrom<Player>, IMapTo<Player>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string PawnId { get; set; }

        public virtual Pawn Pawn { get; set; }

        public StatePlayer StatePlayer { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Player, PlayerViewModel>();

            configuration.CreateMap<PlayerViewModel, Player>();
        }
    }
}
