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

        public Color TitularColor { get; set; } = Color.White;

        public Color ReserveColor { get; set; } = Color.Black;

        public FigurePawn Figure { get; set; } = FigurePawn.Dog;

        public virtual Player Player { get; set; }
    }
}
