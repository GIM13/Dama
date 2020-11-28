namespace DamaGame.Data.Models
{
    using System;

    using DamaGame.Data.Common.Models;
    using DamaGame.Data.Models.Enums;

    public class Pawn : BaseDeletableModel<string>
    {
        public Pawn()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Color TitularColor { get; set; } = Color.Sans;

        public Color ReserveColor { get; set; } = Color.Sans;

        public FigurePawn Figure { get; set; } = FigurePawn.FigureCircle;
    }
}
