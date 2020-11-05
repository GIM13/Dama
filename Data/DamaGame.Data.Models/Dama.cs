namespace DamaGame.Data.Models
{
    using System;

    using DamaGame.Data.Common.Models;

    public class Dama : BaseDeletableModel<string>
    {
        public Dama()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual Position FirstPosition { get; set; }

        public virtual Position SecondPosition { get; set; }

        public virtual Position ThirdPosition { get; set; }
    }
}
