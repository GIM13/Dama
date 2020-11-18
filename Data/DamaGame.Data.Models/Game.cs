namespace DamaGame.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using DamaGame.Data.Common.Models;

    public class Game : BaseDeletableModel<string>
    {
        public Game(string leftPlayerId, string rightPlayerId)
        {
            this.Id = Guid.NewGuid().ToString();

            this.LeftPlayerId = leftPlayerId;

            this.RightPlayerId = rightPlayerId;
        }

        public string PlaygroundId { get; set; }

        public virtual Playground Playground { get; set; } = new Playground();

        public string LeftPlayerId { get; set; }

        public virtual Player LeftPlayer { get; set; }

        public string RightPlayerId { get; set; }

        public virtual Player RightPlayer { get; set; }
    }
}
