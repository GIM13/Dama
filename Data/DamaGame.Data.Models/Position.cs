namespace DamaGame.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DamaGame.Data.Models.Enums;

    public class Position
    {
        public Position()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Name { get; set; }

        public Color Color { get; set; } = Color.Sans;

        public FigurePosition Figure { get; set; } = FigurePosition.FigureFreePosition;

        public bool IsBusy { get; set; } = false;

        public virtual Playground Playground { get; set; }

        public virtual ICollection<Connection> Connections { get; set; } = new List<Connection>();
    }
}
