using System;
using System.Collections.Generic;
using System.Linq;
namespace AirPlaneCompany
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<CrewMember> t = new List<CrewMember>();
            ////t.Add(new CrewMember { Age = 18, Name = "1",Surname="Lu",Position=Positions.Captain });
            ////t.Add(new CrewMember { Age = 18, Name = "2", Surname = "Lu", Position = Positions.Helsman });
            ////t.Add(new CrewMember { Age = 18, Name = "3", Surname = "Lu", Position = Positions.SecondPilot });
            ////t.Add(new CrewMember { Age = 18, Name = "4", Surname = "Lu", Position = Positions.Mechanics });
            ////t.Add(new CrewMember { Age = 18, Name = "5", Surname = "Lu", Position = Positions.Mechanics });
            //AirPlaneCompany a = new AirPlaneCompany();
            //CargoPlane c = new CargoPlane(10100,123,t,"agfagw ",a);
            //PassangerPlane s = new PassangerPlane();
            ////c.CheckCrewStaffing();
            ////CrewMember ce = new CrewMember() { Age = 19, Surname = "horhe", Name = "gol", Position = Positions.Mechanics };
            ////CrewMember ce1 = new CrewMember() { Age = 19, Surname = "h2rhe", Name = "g1ggggggl", Position = Positions.Mechanics };

            ////c.ChangeCrewMember(ce,t[4]);
            ////c.CheckCrewStaffing();
            ////c.AddCrewMember(ce1);
            ////c.CheckCrewStaffing();

            //a.AddPlane(c);
            //Console.WriteLine(a.CompanyCargoLifnig());
            //a.AddPlane(c);
            //a.AddPlane(c);
            //a.AddPlane(c);
            //a.CompanyCargoLifnig();
            //Console.WriteLine(a.ToString());

            //a.ToString();
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
