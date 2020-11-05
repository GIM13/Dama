namespace DamaGame.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using DamaGame.Data.Common.Models;

    public class Player : BaseDeletableModel<string>
    {
        public Player()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual ApplicationUser User { get; set; }

        [Range(0, 9)]
        public virtual ICollection<Pawn> Pawns { get; set; } = new List<Pawn>();
    }
}
