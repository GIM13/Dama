namespace DamaGame.Data.Models
{
    using System;
    using System.Collections.Generic;

    using DamaGame.Data.Common.Models;

    public class Playground : BaseDeletableModel<string>
    {
        public Playground()
        {
            this.Id = Guid.NewGuid().ToString();

            this.FillingThePositions();
        }

        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

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
            this.Positions.Add(new Position
            {
                Name = "A1",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "A4" },
                    new Connection { RelationshipWith = "D1" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "A4",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "A1" },
                    new Connection { RelationshipWith = "A8" },
                    new Connection { RelationshipWith = "B4" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "A8",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "A4" },
                    new Connection { RelationshipWith = "E8" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "B2",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "B4" },
                    new Connection { RelationshipWith = "D2" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "B4",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "A4" },
                    new Connection { RelationshipWith = "B2" },
                    new Connection { RelationshipWith = "B7" },
                    new Connection { RelationshipWith = "C4" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "B7",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "B4" },
                    new Connection { RelationshipWith = "E7" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "C3",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "C4" },
                    new Connection { RelationshipWith = "D3" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "C4",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "C3" },
                    new Connection { RelationshipWith = "C6" },
                    new Connection { RelationshipWith = "B4" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "C6",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "C4" },
                    new Connection { RelationshipWith = "E6" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "D1",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "A1" },
                    new Connection { RelationshipWith = "H1" },
                    new Connection { RelationshipWith = "D2" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "D2",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "B2" },
                    new Connection { RelationshipWith = "D1" },
                    new Connection { RelationshipWith = "G2" },
                    new Connection { RelationshipWith = "D3" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "D3",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "C3" },
                    new Connection { RelationshipWith = "F3" },
                    new Connection { RelationshipWith = "D2" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "E6",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "C6" },
                    new Connection { RelationshipWith = "F6" },
                    new Connection { RelationshipWith = "E7" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "E7",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "E6" },
                    new Connection { RelationshipWith = "E8" },
                    new Connection { RelationshipWith = "B7" },
                    new Connection { RelationshipWith = "G7" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "E8",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "A8" },
                    new Connection { RelationshipWith = "H8" },
                    new Connection { RelationshipWith = "E7" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "F3",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "F5" },
                    new Connection { RelationshipWith = "D3" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "F5",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "F3" },
                    new Connection { RelationshipWith = "G5" },
                    new Connection { RelationshipWith = "F6" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "F6",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "F5" },
                    new Connection { RelationshipWith = "E6" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "G2",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "G5" },
                    new Connection { RelationshipWith = "D2" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "G5",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "G2" },
                    new Connection { RelationshipWith = "G7" },
                    new Connection { RelationshipWith = "F5" },
                    new Connection { RelationshipWith = "H5" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "G7",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "G5" },
                    new Connection { RelationshipWith = "E7" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "H1",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "H5" },
                    new Connection { RelationshipWith = "D1" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "H5",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "H1" },
                    new Connection { RelationshipWith = "H8" },
                    new Connection { RelationshipWith = "G5" },
                },
            });
            this.Positions.Add(new Position
            {
                Name = "H8",
                Connections = new List<Connection>
                {
                    new Connection { RelationshipWith = "H5" },
                    new Connection { RelationshipWith = "E8" },
                },
            });
        }
    }
}
