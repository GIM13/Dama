namespace DamaGame.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DamaGame.Data.Models.Enums;

    public class Pawn
    {
        public Pawn(Color titularColor, Color reserveColor, FigurePawn figure)
        {
            this.Id = Guid.NewGuid().ToString();

            this.TitularColor = titularColor;

            this.ReserveColor = reserveColor;

            this.Figure = figure;
        }

        public string Id { get; set; }

        [Required]
        public Color TitularColor { get; set; }

        [Required]
        public Color ReserveColor { get; set; }

        [Required]
        public FigurePawn Figure { get; set; }

        public virtual Player Player { get; set; }
    }
}
