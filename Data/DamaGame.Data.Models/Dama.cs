namespace DamaGame.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Dama
    {
        public Dama()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public virtual Position FirstPosition { get; set; }

        public virtual Position SecondPosition { get; set; }

        public virtual Position ThirdPosition { get; set; }
    }
}
