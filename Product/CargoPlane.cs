using System;
using System.Collections.Generic;
using System.Linq;



namespace AirPlaneCompany
{
    public class CargoPlane:Plane
    {
        private double _liftingCapacityKG;
        private byte _numberOfMechanics;
        private double _cargo;       

        public CargoPlane():base()
        {
            LiftingCapacityKG = 1000;
            _cargo = 0;
        }
        
        public CargoPlane(int liftingCapacityKG, int planenumber, List<CrewMember> crew, string model, AirPlaneCompany airPlaneCompany) :base(planenumber, crew, model,airPlaneCompany)
        {
            LiftingCapacityKG = liftingCapacityKG;
        }

        public double LiftingCapacityKG { get => _liftingCapacityKG; set { _liftingCapacityKG = value >= 1000 ? value : throw new ArgumentOutOfRangeException(); } }

        
        public double Cargo { get => _cargo;  }      

        public void AddCargo(double cargo)
        {
            if (cargo<0)
            {
                throw new ArgumentException(nameof(cargo));
            }
            if (cargo+_cargo>_liftingCapacityKG)
            {
                Console.WriteLine($"To heavy cargo, change weight to{cargo+_cargo-_liftingCapacityKG}");
            }
            else
            {
                _cargo += cargo;    
            }
        }

        public override void AddCrewMember(CrewMember crew)
        {
            if (crew == null)
            {
                throw new ArgumentNullException(nameof(crew));
            }
            if (crew.Position==Positions.Stewardesses)
            {
                throw new ArgumentException(nameof(crew));
            }
            foreach (var item in _crew)
            {
                if (item.Position == crew.Position)
                {
                    if (crew.Position == Positions.Mechanics && _numberOfMechanics < 5)
                    {
                        _crew.Add(crew);
                        crew.Plane = this;
                        _numberOfMechanics++;
                    }

                  return;
                    
                }
            }
            _crew.Add(crew);
        }

        public override void ChangeWholeCrew(List<CrewMember> crew)
        {
            bool additionalCrew = false;
            byte tempNumberOfMechanics = 0;
            if (crew == null)
            {
                throw new ArgumentNullException(nameof(crew));
            }
            foreach (var item in crew)
            {

                if (item.Position == Positions.Captain) captain = true;
                if (item.Position == Positions.Helsman) helsman = true;
                if (item.Position == Positions.SecondPilot) secondpilot = true;
                if (item.Position == Positions.Mechanics&& tempNumberOfMechanics<=5)
                {
                    tempNumberOfMechanics++;
                    additionalCrew = true;
                }
            }
            if (captain && helsman && secondpilot && additionalCrew)
            {
                _numberOfMechanics = tempNumberOfMechanics;
                _crew = crew;
            }
            
            CheckCrewStaffing();
        }

        public string CheckCrewStaffing()
        {           
            string temp=CheckCrewStaff();
            foreach (var item in _crew)
            {
                if(item.Position == Positions.Mechanics)
                {
                    
                    temp += $"{item.Position} {item.Name} ";
                }
            
            }
           
            return temp;
        }
       
        public override bool PlaneReadyToFly()
        {
            return base.PlaneReadyToFly()&&_liftingCapacityKG>Cargo&&_numberOfMechanics>=1;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\t{_liftingCapacityKG}";
        }
    }
}
