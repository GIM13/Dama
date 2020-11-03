namespace DamaGame.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Connection
    {
        public Connection()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string RelationshipWith { get; set; }

        public virtual Position Position { get; set; }
    }
}
