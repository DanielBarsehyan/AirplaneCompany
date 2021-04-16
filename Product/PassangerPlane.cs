using System;
using System.Collections.Generic;
using System.Linq;


namespace AirPlaneCompany
{
    class PassangerPlane:Plane
    {
        private List<Human> _passangers;
        private byte _numberOfStewardess;
        private int _passangersCapacity;

        public PassangerPlane() : base()
        {
            _passangers = new List<Human>();
            _numberOfStewardess = 0;
            _passangersCapacity = 2;
        }

        public PassangerPlane(int passangerCapacity, int planenumber, List<CrewMember> crew, string model, AirPlaneCompany airPlaneCompany) : base(planenumber, crew, model,airPlaneCompany)
        {
            PassangersCapacity = passangerCapacity;
        }

        public List<Human> Passangers { get => _passangers; }        
        public int PassangersCapacity { get => _passangersCapacity; set { _passangersCapacity = value >= 1 ? value : throw new ArgumentOutOfRangeException(); } }

        public void AddPassanger(Human passanger)
        {
            if (passanger==null)
            {
                throw new ArgumentException(nameof(passanger));
            }
            if (_passangersCapacity < _passangers.Count) _passangers.Add(passanger);
        }
        public void RemovePassangers()
        {
            _passangers.Clear();
        }
        public override void AddCrewMember(CrewMember crew)
        {
            if (crew == null)
            {
                throw new ArgumentNullException(nameof(crew));
            }
            if (crew.Position == Positions.Mechanics)
            {
                throw new ArgumentException(nameof(crew));
            }
            foreach (var item in _crew)
            {
                if (item.Position == crew.Position)
                {
                    if (crew.Position == Positions.Stewardesses && _numberOfStewardess < 5)
                    {
                        _crew.Add(crew);
                        crew.Plane = this;
                        _numberOfStewardess++;
                    }

                    return;

                }
            }
            _crew.Add(crew);
        }

        public string CheckCrewStaffing()
        {
            string temp = CheckCrewStaff();
            foreach (var item in _crew)
            {
                if (item.Position == Positions.Stewardesses)
                {
                    temp += $"{item.Position} {item.Name} ";
                   
                }

            }
          
            return temp;
        }

        public override bool PlaneReadyToFly()
        {
            return base.PlaneReadyToFly() && _passangersCapacity > _passangers.Count && _numberOfStewardess >= 1;
        }

        public override string ToString()
        {
            string temp = "";
            foreach (var item in _passangers)
            {
                temp += item.ToString();
            }
            return $"{base.ToString()}\t{_passangersCapacity} +{temp}";
        }

        public override void ChangeWholeCrew(List<CrewMember> crew)
        {
            bool additionalCrew = false;
            byte tempNumberOfStewardes = 0;
            if (crew == null)
            {
                throw new ArgumentNullException(nameof(crew));
            }
            foreach (var item in crew)
            {

                if (item.Position == Positions.Captain) captain = true;
                if (item.Position == Positions.Helsman) helsman = true;
                if (item.Position == Positions.SecondPilot) secondpilot = true;
                if (item.Position == Positions.Stewardesses && tempNumberOfStewardes <= 5)
                {
                    tempNumberOfStewardes++;
                    additionalCrew = true;
                }              
            }
            if (captain && helsman && secondpilot && additionalCrew)
            {
                _crew = crew;
                _numberOfStewardess = tempNumberOfStewardes;
            }
            CheckCrewStaffing();
        }
    }
}

