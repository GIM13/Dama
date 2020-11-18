namespace DamaGame.Web.ViewModels.Players
{
    using System.ComponentModel.DataAnnotations;

    using DamaGame.Data.Models;
    using DamaGame.Data.Models.Enums;
    using DamaGame.Services.Mapping;

    public class PlayerInputViewModel : IMapFrom<Player>
    {
        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        public Color TitularColor { get; set; }

        [Required]
        public Color ReserveColor { get; set; }

        [Required]
        public FigurePawn Figure { get; set; }

        // public void CreateMappings(IProfileExpression configuration)
        // {
        //    configuration.CreateMap<Pawn, PlayerInputViewModel>().ForMember(
        //        m => m.Name,
        //        opt => opt.MapFrom(x => x.Player.Name));
        // }
    }
}
