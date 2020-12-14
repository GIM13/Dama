namespace DamaGame.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;

    public class GameViewModel : IMapFrom<Game>, IMapTo<Game>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Playground Playground { get; set; }

        public virtual Player LeftPlayer { get; set; }

        public virtual Player RightPlayer { get; set; }

        public virtual ICollection<Pawn> LeftPlayerPawns { get; set; } = new List<Pawn>();

        public virtual ICollection<Pawn> RightPlayerPawns { get; set; } = new List<Pawn>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Game, GameViewModel>();
        }
    }
}
