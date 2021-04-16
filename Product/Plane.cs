using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirPlaneCompany
{

    public abstract class Plane
    {
        protected int _planenumber;
        protected List<CrewMember> _crew;
        protected string _model;
        protected AirPlaneCompany _owner;
        protected bool captain ;
        protected bool helsman ;
        protected bool secondpilot ;        
        protected Plane()
        {
            Planenumber = 1;
            Model = "A380";
            _owner = new AirPlaneCompany();
            _crew = new List<CrewMember>();
            captain = false;
            helsman = false;
           secondpilot = false;
    }

    
        protected Plane(int planenumber, List<CrewMember> crew, string model,AirPlaneCompany airPlaneCompany)
        {
            Planenumber = planenumber;            
            Model = model;
            Crew = crew;
            for (int i = 0; i < crew.Count; i++)
            {
                crew[i].Plane = this;
            }
            Owner = airPlaneCompany;
        }
        public virtual void ChangeCrewMember(CrewMember newCrew, CrewMember oldCrew)
        {

            if (oldCrew == null)
            {
                throw new ArgumentNullException(nameof(oldCrew));
            }
            if (newCrew == null)
            {
                throw new ArgumentNullException(nameof(newCrew));
            }
            int tmp = 0;
            foreach (var item in _crew)
            {
                if (CheckCrewStaff().Length > 1  )
                {
                    if(item == oldCrew) tmp = _crew.IndexOf(_crew.Where(n => n == oldCrew).FirstOrDefault());
                    break;
                }                                                             
            }
            
            _crew[tmp] = newCrew;
            _crew[tmp].Plane = this;
        }
        public virtual void AddCrewMember(CrewMember crew)
        {
            if (crew == null)
            {
                throw new ArgumentNullException(nameof(crew));
            }                     
        }
        public virtual void ChangeWholeCrew(List<CrewMember> crew)
        {
            if (crew == null)
            {
                throw new ArgumentNullException(nameof(crew));
            }          
            foreach (var item in crew)
            {
                
                    if (item.Position == Positions.Captain) captain = true;
                    if (item.Position == Positions.Helsman) helsman = true;
                    if (item.Position == Positions.SecondPilot) secondpilot = true;

            }
            if (captain&&helsman&&secondpilot) _crew=crew;
            CheckCrewStaff();
        }
        protected string CheckCrewStaff()
        {
            string tmp ="";
            int temp = tmp.Length;
            foreach (var item in _crew)
            {
                if (item.Position == Positions.Captain)
                {
                    tmp += $"{Positions.Captain}  {item.Name} ";
                    captain = true;

                }
                else if (item.Position == Positions.Helsman)
                {
                    tmp += $"{Positions.Helsman}  {item.Name} ";
                    helsman = true;

                }
                else if (item.Position == Positions.SecondPilot)
                {
                    tmp += $"{Positions.SecondPilot}  {item.Name} ";
                    secondpilot = true;

                }                      
            }          
            return tmp;
        }
        public virtual bool PlaneReadyToFly()
        {
            if (_crew.Count()>=4)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Planenumber}\t{Model}\t{Crew.ToString()}";
        }

        public int Planenumber { get => _planenumber; set => _planenumber = value; }
        public  List<CrewMember> Crew { get => _crew; set { _crew = value != null ? value : throw new ArgumentNullException(); } }
        public string Model { get => _model; set => _model = value; }
        protected AirPlaneCompany Owner { get => _owner; set { _owner = value != null ? value : throw new ArgumentNullException(); } }
    }
}
