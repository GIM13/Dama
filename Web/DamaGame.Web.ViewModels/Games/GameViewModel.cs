namespace DamaGame.Web.ViewModels.Games
{
    using AutoMapper;
    using DamaGame.Data.Models;
    using DamaGame.Services.Mapping;

    public class GameViewModel : IMapFrom<Game>, IMapTo<Game>, IHaveCustomMappings
    {
        public string PlaygroundId { get; set; }

        public virtual Playground Playground { get; set; }

        public string LeftPlayerId { get; set; }

        public virtual Player LeftPlayer { get; set; }

        public string RightPlayerId { get; set; }

        public virtual Player RightPlayer { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Game, GameViewModel>();
        }
    }
}
