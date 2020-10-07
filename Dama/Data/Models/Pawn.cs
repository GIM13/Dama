using Data.Models.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Pawn
    {
        public Pawn(Color titularColor, Color reserveColor, FigurePawn figure)
        {
            this.TitularColor = titularColor;

            this.ReserveColor = reserveColor;

            this.Figure = figure;
        }

        public int Id { get; set; }

        [Required]
        public Color TitularColor { get; set; }

        [Required]
        public Color ReserveColor { get; set; }

        [Required]
        public FigurePawn Figure { get; set; }

        [Required]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
