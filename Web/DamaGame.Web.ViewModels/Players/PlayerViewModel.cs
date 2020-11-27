namespace DamaGame.Web.ViewModels.Players
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;

    public class PlayerViewModel : IMapFrom<Player>, IMapTo<Player>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Pawn Pawn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Player, PlayerViewModel>();

            configuration.CreateMap<PlayerViewModel, Player>();
        }
    }
}
