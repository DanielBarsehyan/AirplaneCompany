using System;
using System.Collections.Generic;
using System.Linq;
namespace AirPlaneCompany
{
    class Program
    {
        static void Main(string[] args)
        {          
            AirPlaneCompany company = new AirPlaneCompany() { Name="FlyAvio"};
            
            for (int i = 0; i < 10; i++)
            {
                List<CrewMember> crew = new List<CrewMember>();
                
                CargoPlane cargoPlane = new CargoPlane() { LiftingCapacityKG = 1000 + i, Model = $"A{i * 2}", Planenumber = i * i * 3 };
                for (int j = 0; j < 5; j++)
                {
                    crew.Add(new CrewMember() { Age = 19, Name = $"JO{i * j}", Plane = cargoPlane, Position = (Positions)(j) });
                }
                cargoPlane.ChangeWholeCrew(crew);
                company.AddPlane(cargoPlane);

                PassangerPlane passangerPlane = new PassangerPlane() { PassangersCapacity = 10 + i, Model = $"A{i * 2}", Planenumber = i * i * 3 };
                for (int j = 0; j < 5; j++)
                {
                    crew.Add(new CrewMember() { Age = 19, Name = $"JO{i * j}", Plane = cargoPlane, Position = (Positions)(j) });
                }
                passangerPlane.ChangeWholeCrew(crew);
                for (int j = 0; j < passangerPlane.PassangersCapacity; j++)
                {
                    Human hooman = new Human() { Age = (18 + i*j), Name = $"Linda{j * i}" ,Surname=$"Some{i*j}"};
                    passangerPlane.AddPassanger(hooman);
                }
                company.AddPlane(passangerPlane);
            }
            Console.WriteLine(company.ToString());
        }
       
    }
}
