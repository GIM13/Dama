namespace DamaGame.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using DamaGame.Data.Common.Models;

    public class Playground : BaseDeletableModel<string>
    {
        public Playground()
        {
            this.Id = Guid.NewGuid().ToString();

            this.FillingThePositions();
        }

        public virtual Position[] Positions { get; set; } = new Position[24];

        private void FillingThePositions()
        {
            // _______________VISUALIZATION______________
            //       A1-------------A4-------------A8
            //       |              |              |
            //       |    B2--------B4--------B7   |
            //       |    |         |         |    |
            //       |    |    C3---C4---C6   |    |
            //       |    |    |         |    |    |
            //       D1---D2---D3        E6---E7---E8
            //       |    |    |         |    |    |
            //       |    |    F3---F5---F6   |    |
            //       |    |         |         |    |
            //       |    G2--------G5--------G7   |
            //       |              |              |
            //       H1-------------H5-------------H8
            // __________________________________________
            this.Positions[0] = new Position { Name = "A1" };
            this.Positions[0].Connections.Add(new Connection() { RelationshipWith = "A4" });
            this.Positions[0].Connections.Add(new Connection() { RelationshipWith = "D1" });
            this.Positions[1] = new Position { Name = "A4" };
            this.Positions[1].Connections.Add(new Connection() { RelationshipWith = "A1" });
            this.Positions[1].Connections.Add(new Connection() { RelationshipWith = "A8" });
            this.Positions[1].Connections.Add(new Connection() { RelationshipWith = "B4" });
            this.Positions[2] = new Position { Name = "A8" };
            this.Positions[2].Connections.Add(new Connection() { RelationshipWith = "A4" });
            this.Positions[2].Connections.Add(new Connection() { RelationshipWith = "E8" });

            this.Positions[3] = new Position { Name = "B2" };
            this.Positions[3].Connections.Add(new Connection() { RelationshipWith = "B4" });
            this.Positions[3].Connections.Add(new Connection() { RelationshipWith = "D2" });
            this.Positions[4] = new Position { Name = "B4" };
            this.Positions[4].Connections.Add(new Connection() { RelationshipWith = "A4" });
            this.Positions[4].Connections.Add(new Connection() { RelationshipWith = "B2" });
            this.Positions[4].Connections.Add(new Connection() { RelationshipWith = "B7" });
            this.Positions[4].Connections.Add(new Connection() { RelationshipWith = "C4" });
            this.Positions[5] = new Position { Name = "B7" };
            this.Positions[5].Connections.Add(new Connection() { RelationshipWith = "B4" });
            this.Positions[5].Connections.Add(new Connection() { RelationshipWith = "E7" });

            this.Positions[6] = new Position { Name = "C3" };
            this.Positions[6].Connections.Add(new Connection() { RelationshipWith = "C4" });
            this.Positions[6].Connections.Add(new Connection() { RelationshipWith = "D3" });
            this.Positions[7] = new Position { Name = "C4" };
            this.Positions[7].Connections.Add(new Connection() { RelationshipWith = "C3" });
            this.Positions[7].Connections.Add(new Connection() { RelationshipWith = "C6" });
            this.Positions[7].Connections.Add(new Connection() { RelationshipWith = "B4" });
            this.Positions[8] = new Position { Name = "C6" };
            this.Positions[8].Connections.Add(new Connection() { RelationshipWith = "C4" });
            this.Positions[8].Connections.Add(new Connection() { RelationshipWith = "E6" });

            this.Positions[9] = new Position { Name = "D1" };
            this.Positions[9].Connections.Add(new Connection() { RelationshipWith = "A1" });
            this.Positions[9].Connections.Add(new Connection() { RelationshipWith = "H1" });
            this.Positions[9].Connections.Add(new Connection() { RelationshipWith = "D2" });
            this.Positions[10] = new Position { Name = "D2" };
            this.Positions[10].Connections.Add(new Connection() { RelationshipWith = "D1" });
            this.Positions[10].Connections.Add(new Connection() { RelationshipWith = "B2" });
            this.Positions[10].Connections.Add(new Connection() { RelationshipWith = "D3" });
            this.Positions[10].Connections.Add(new Connection() { RelationshipWith = "G2" });
            this.Positions[11] = new Position { Name = "D3" };
            this.Positions[11].Connections.Add(new Connection() { RelationshipWith = "C3" });
            this.Positions[11].Connections.Add(new Connection() { RelationshipWith = "F3" });
            this.Positions[11].Connections.Add(new Connection() { RelationshipWith = "D2" });

            this.Positions[12] = new Position { Name = "E6" };
            this.Positions[12].Connections.Add(new Connection() { RelationshipWith = "C6" });
            this.Positions[12].Connections.Add(new Connection() { RelationshipWith = "F6" });
            this.Positions[12].Connections.Add(new Connection() { RelationshipWith = "E7" });
            this.Positions[13] = new Position { Name = "E7" };
            this.Positions[13].Connections.Add(new Connection() { RelationshipWith = "E6" });
            this.Positions[13].Connections.Add(new Connection() { RelationshipWith = "E8" });
            this.Positions[13].Connections.Add(new Connection() { RelationshipWith = "B7" });
            this.Positions[13].Connections.Add(new Connection() { RelationshipWith = "G7" });
            this.Positions[14] = new Position { Name = "E8" };
            this.Positions[14].Connections.Add(new Connection() { RelationshipWith = "A8" });
            this.Positions[14].Connections.Add(new Connection() { RelationshipWith = "H8" });
            this.Positions[14].Connections.Add(new Connection() { RelationshipWith = "E7" });

            this.Positions[15] = new Position { Name = "F3" };
            this.Positions[15].Connections.Add(new Connection() { RelationshipWith = "F5" });
            this.Positions[15].Connections.Add(new Connection() { RelationshipWith = "D3" });
            this.Positions[16] = new Position { Name = "F5" };
            this.Positions[16].Connections.Add(new Connection() { RelationshipWith = "F3" });
            this.Positions[16].Connections.Add(new Connection() { RelationshipWith = "G5" });
            this.Positions[16].Connections.Add(new Connection() { RelationshipWith = "F6" });
            this.Positions[17] = new Position { Name = "F6" };
            this.Positions[17].Connections.Add(new Connection() { RelationshipWith = "F5" });
            this.Positions[17].Connections.Add(new Connection() { RelationshipWith = "E6" });

            this.Positions[18] = new Position { Name = "G2" };
            this.Positions[18].Connections.Add(new Connection() { RelationshipWith = "G5" });
            this.Positions[18].Connections.Add(new Connection() { RelationshipWith = "D2" });
            this.Positions[19] = new Position { Name = "G5" };
            this.Positions[19].Connections.Add(new Connection() { RelationshipWith = "G2" });
            this.Positions[19].Connections.Add(new Connection() { RelationshipWith = "G7" });
            this.Positions[19].Connections.Add(new Connection() { RelationshipWith = "F5" });
            this.Positions[19].Connections.Add(new Connection() { RelationshipWith = "H5" });
            this.Positions[20] = new Position { Name = "G7" };
            this.Positions[20].Connections.Add(new Connection() { RelationshipWith = "G5" });
            this.Positions[20].Connections.Add(new Connection() { RelationshipWith = "E7" });

            this.Positions[21] = new Position { Name = "H1" };
            this.Positions[21].Connections.Add(new Connection() { RelationshipWith = "H5" });
            this.Positions[21].Connections.Add(new Connection() { RelationshipWith = "D1" });
            this.Positions[22] = new Position { Name = "H5" };
            this.Positions[22].Connections.Add(new Connection() { RelationshipWith = "H1" });
            this.Positions[22].Connections.Add(new Connection() { RelationshipWith = "H8" });
            this.Positions[22].Connections.Add(new Connection() { RelationshipWith = "G5" });
            this.Positions[23] = new Position { Name = "H8" };
            this.Positions[23].Connections.Add(new Connection() { RelationshipWith = "H5" });
            this.Positions[23].Connections.Add(new Connection() { RelationshipWith = "E8" });
        }
    }
}
