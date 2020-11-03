namespace DamaGame.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using DamaGame.Data.Models.Enums;

    public class Player
    {
        public Player()
        {
            this.Id = Guid.NewGuid().ToString();

           // this.FillingThePowns(titularColor, reserveColor, figure);
        }

        public string Id { get; set; }

        public int Wins { get; set; } = 0;

        public int Losses { get; set; } = 0;

        [Required]
        public bool IsBusy { get; set; } = false;

        [ForeignKey("ApplicationUser")]
        public virtual ApplicationUser User { get; set; }

        [Range(0, 9)]
        public virtual ICollection<Pawn> Pawns { get; set; } = new List<Pawn>();

        private void FillingThePowns(Color titularColor, Color reserveColor, FigurePawn figure)
        {
            var pawn = new Pawn(titularColor, reserveColor, figure);

            for (int i = 0; i < 9; i++)
            {
                this.Pawns.Add(pawn);
            }
        }
    }
}
