namespace DamaGame.Data.Models
{
    using System;
    using System.Collections.Generic;

    using DamaGame.Data.Common.Models;

    public class Game : BaseDeletableModel<string>
    {
        public Game()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string PlaygroundId { get; set; }

        public virtual Playground Playground { get; set; } = new Playground();

        public virtual Player LeftPlayer { get; set; } = new Player();

        public virtual Player RightPlayer { get; set; } = new Player();

        public virtual ICollection<Pawn> PawnsLeftPlayer { get; set; } = new List<Pawn>();

        public virtual ICollection<Pawn> PawnsRightPlayer { get; set; } = new List<Pawn>();
    }
}
