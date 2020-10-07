using Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Playground
    {
        public Playground(Player leftPlayer, Player rightPlayer)
        {
            LeftPlayer = leftPlayer;

            RightPlayer = rightPlayer;

            Fields = new Field[15, 15];

            FillingTheFieldsInThePlayground();
        }

        public int Id { get; set; }

        [Required]
        public Player LeftPlayer { get; set; }

        [Required]
        public Player RightPlayer { get; set; }

        [Required]
        public Field[,] Fields { get; set; }

        private void FillingTheFieldsInThePlayground()
        {
            Fields[1, 1].State = Fields[1, 7].State = Fields[1, 13].State =
            Fields[3, 3].State = Fields[3, 7].State = Fields[3, 11].State =
            Fields[5, 5].State = Fields[5, 7].State = Fields[5, 9].State =
            Fields[7, 1].State = Fields[7, 3].State = Fields[7, 5].State =
            Fields[7, 9].State = Fields[7, 11].State = Fields[7, 13].State =
            Fields[9, 5].State = Fields[9, 7].State = Fields[9, 9].State =
            Fields[11, 3].State = Fields[11, 7].State = Fields[11, 11].State =
            Fields[13, 1].State = Fields[13, 7].State = Fields[13, 13].State =
              StateField.FreePosition;

            Fields[1, 2].State = Fields[1, 3].State = Fields[1, 4].State = Fields[1, 5].State = Fields[1, 6].State =
            Fields[1, 8].State = Fields[1, 9].State = Fields[1, 10].State = Fields[1, 11].State = Fields[1, 12].State =
            Fields[3, 4].State = Fields[3, 5].State = Fields[3, 6].State =
            Fields[3, 8].State = Fields[3, 9].State = Fields[3, 10].State =
            Fields[5, 6].State = Fields[5, 8].State =
            Fields[7, 2].State = Fields[7, 4].State = Fields[7, 10].State = Fields[7, 12].State =
            Fields[9, 6].State = Fields[9, 8].State =
            Fields[11, 4].State = Fields[11, 5].State = Fields[11, 6].State =
            Fields[11, 8].State = Fields[11, 9].State = Fields[11, 10].State =
            Fields[13, 2].State = Fields[13, 3].State = Fields[13, 4].State = Fields[13, 5].State = Fields[13, 6].State =
            Fields[13, 8].State = Fields[13, 9].State = Fields[13, 10].State = Fields[13, 11].State = Fields[13, 12].State =
              StateField.HorizontalLine;

            Fields[2, 1].State = Fields[3, 1].State = Fields[4, 1].State = Fields[5, 1].State = Fields[6, 1].State =
            Fields[8, 1].State = Fields[9, 1].State = Fields[10, 1].State = Fields[11, 1].State = Fields[12, 1].State =
            Fields[4, 3].State = Fields[5, 3].State = Fields[6, 3].State =
            Fields[8, 3].State = Fields[9, 3].State = Fields[10, 3].State =
            Fields[6, 5].State = Fields[8, 5].State =
            Fields[2, 7].State = Fields[4, 7].State = Fields[10, 7].State = Fields[12, 7].State =
            Fields[6, 9].State = Fields[8, 9].State =
            Fields[4, 11].State = Fields[5, 11].State = Fields[6, 11].State =
            Fields[8, 11].State = Fields[9, 11].State = Fields[10, 11].State =
            Fields[2, 13].State = Fields[3, 13].State = Fields[4, 13].State = Fields[5, 13].State = Fields[6, 13].State =
            Fields[8, 13].State = Fields[9, 13].State = Fields[10, 13].State = Fields[11, 13].State = Fields[12, 13].State =
              StateField.VerticalLine;
        }
    }
}
