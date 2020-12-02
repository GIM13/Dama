namespace DamaGame.Web.ViewModels.Games
{
    using AutoMapper;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;
    using System.Collections.Generic;

    public class GameViewModel : IMapFrom<Game>, IMapTo<Game>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public virtual Playground Playground { get; set; }

        public string LeftPlayerId { get; set; }

        public virtual Player LeftPlayer { get; set; }

        public string RightPlayerId { get; set; }

        public virtual Player RightPlayer { get; set; }

        public virtual ICollection<Pawn> PawnsLeftPlayer { get; set; }

        public virtual ICollection<Pawn> PawnsRightPlayer { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Game, GameViewModel>();
        }
    }
}
