using System;

namespace AirPlaneCompany
{
    public enum Positions
    {
        Captain,
        SecondPilot,
        Helsman,
        Stewardesses,
        Mechanics
    }
    public class CrewMember:Human
    {
        private Positions _position;
        private Plane _plane;

        public CrewMember():base()
        {
            Position = Positions.Stewardesses;
            Age = 18;            
        }

        public CrewMember(string name, string surname, short age, Positions position, Plane plane):base(name,surname,age)
        {           
            Position = position;
            Plane = plane;
        }
        public Positions Position { get => _position; set => _position = value; }
        public  int Age { get => _age; set { _age = value >= 18 ? value : throw new ArgumentOutOfRangeException(); } }

        public Plane Plane { get => _plane; set { _plane = value !=null ? value : throw new ArgumentOutOfRangeException(); } }
        
        public override string ToString()
        {
            return $"{base.ToString()}\t{Position}";
        }
    }
}
