namespace DamaGame.Web.ViewModels.Players
{
    using System.Collections.Generic;

    using AutoMapper;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;

    public class PlayerViewModel : IMapFrom<Player>, IMapTo<Player>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Pawn> Pawns { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Player, PlayerViewModel>();
        }
    }
}
