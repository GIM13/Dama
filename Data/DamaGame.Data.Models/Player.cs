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
        [StringLength(16, MinimumLength = 4)]
        public string Name { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string PawnId { get; set; }

        public virtual Pawn Pawn { get; set; }
    }
}
