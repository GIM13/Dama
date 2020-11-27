namespace DamaGame.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DamaGame.Data.Common.Models;

    public class Connection : BaseDeletableModel<string>
    {
        public Connection()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string RelationshipWith { get; set; }

        [Range(1, 64)]
        public int Weight { get; set; }

        public FigureConnection Figure { get; set; }
    }
}
