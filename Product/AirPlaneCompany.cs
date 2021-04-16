using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneCompany
{
    public class AirPlaneCompany
    {
        List<Plane> _planes;

        public AirPlaneCompany()
        {
            Name = "Flying Pigs";
            _planes = new List<Plane>();
        }

        public AirPlaneCompany(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Plane> Planes { get => _planes; }

        public void AddPlane(Plane plane)
        {
            if (plane == null) throw new ArgumentNullException(nameof(plane));
            if (CheckPlanesForDuplicates(plane)) return;
            _planes.Add(plane);
        }
        public string HowManyPlanes()
        {
            int cargoPlanes = 0;
            int passangerPlanes = 0;
            foreach (var item in _planes)
            {
                if (WhichPlane(item) == 1)
                {
                    cargoPlanes++;
                }
                else if (WhichPlane(item) == 2)
                {
                    passangerPlanes++;
                }
            }
            return $"Cargo planes {cargoPlanes}\tPassange planes {passangerPlanes}";
        }
        public void ChangePlane(Plane newPlane,Plane oldPlane)
        {
            int tmp = 0;
            foreach (var item in _planes)
            {
                if (item == oldPlane)
                {
                    tmp = _planes.IndexOf(_planes.Where(n => n == oldPlane).FirstOrDefault());
                    break;
                }
                
            }
            _planes[tmp] = newPlane;
        }
        private int WhichPlane(Plane plane)
        {
            if (plane is CargoPlane)
            {
                return 1;
            }
            else if (plane is PassangerPlane)
            {
                return 2;
            }
            return 0;
        }
        public double CompanyCargoLifnig()
        {
            double cargoLifting = 0;
            foreach (var item in _planes)
            {
                if (WhichPlane(item) == 1)
                {
                    CargoPlane temp = (CargoPlane)item;
                    cargoLifting += temp.LiftingCapacityKG;
                }
            }
            return cargoLifting;
        }
        public int CompanyPassangersCapacity()
        {
            int passangers = 0;
            foreach (var item in _planes)
            {
                if (WhichPlane(item) == 2)
                {
                    PassangerPlane temp = (PassangerPlane)item;
                    passangers += temp.PassangersCapacity;
                }
            }
            return passangers;
        }
        public bool CheckPlanesForDuplicates(Plane plane)
        {
            foreach (var item in _planes)
            {
                if (plane==item)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            
            return $"{HowManyPlanes()}\tCompany cargo lifting capacity {CompanyCargoLifnig()}\tCompany passangers capacity {CompanyPassangersCapacity()}";
        }
    }
}
