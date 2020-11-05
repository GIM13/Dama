namespace DamaGame.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DamaGame.Data.Common.Models;
    using DamaGame.Data.Models.Enums;

    public class Connection : BaseDeletableModel<string>
    {
        public Connection()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string RelationshipWith { get; set; }

        public int Weight { get; set; }

        public FigureConnection Figure { get; set; } = FigureConnection.FigureHorizontalLine;

        public virtual Position Position { get; set; }
    }
}
