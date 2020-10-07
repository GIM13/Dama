using Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Field
    {
        public int Id { get; set; }

        [Required]
        public StateField State { get; set; } = StateField.Empty;

        [Required]
        public Color Color { get; set; } = Color.Brown;

        [Required]
        public FigureField Figure { get; set; } = FigureField.FigureEmpty;
 
        [Required]
        public int PlaygroundId { get; set; }
        public Playground Playground { get; set; }
    }
}