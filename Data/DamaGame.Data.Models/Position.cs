namespace DamaGame.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DamaGame.Data.Common.Models;
    using DamaGame.Data.Models.Enum;
    using DamaGame.Data.Models.Enums;

    public class Position : BaseDeletableModel<string>
    {
        public Position()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Name { get; set; }

        public Color Color { get; set; } = Color.Sans;

        public FigurePosition Figure { get; set; } = FigurePosition.FigureFreePosition;

        public StatePosition StatePosition { get; set; } = StatePosition.FreePosition;

        public Playground Playground { get; set; }

        public virtual ICollection<Connection> Connections { get; set; }
    }
}
