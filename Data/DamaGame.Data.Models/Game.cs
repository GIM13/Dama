namespace DamaGame.Data.Models
{
    using System;

    using DamaGame.Data.Common.Models;

    public class Game : BaseDeletableModel<string>
    {
        public Game()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string PlaygroundId { get; set; }

        public virtual Playground Playground { get; set; } = new Playground();

        public virtual Player LeftPlayer { get; set; }

        public virtual Player RightPlayer { get; set; }
    }
}
