using Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Player
    {
        public Player(string name, Color firstColor, Color secondColor, FigurePawn figure)
        {
            this.Name = name;

            this.Pawns = new List<Pawn>();

            for (int i = 0; i < 9; i++)
            {
                var pawn = new Pawn(firstColor, secondColor, figure);

                Pawns.Add(pawn);
            }
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        public int Wins { get; set; } = 0;

        [Required]
        public int Losses { get; set; } = 0;

        [Required]
        [Range(0, 9)]
        public ICollection<Pawn> Pawns { get; set; }
    }
}
