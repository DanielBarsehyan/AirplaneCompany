using System;


namespace AirPlaneCompany
{
    public  class Human
    {
        protected int _age;
        protected string _name;
        protected string _surname;

        public Human()
        {
            Name = "Joe";
            Surname = "Dou";
            Age = 0;
        }

        public Human(string name, string surname, short age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public virtual string Name { get => _name; set { _name = value != null ? value : throw new ArgumentNullException(); } }
        public virtual string Surname { get => _surname; set { _surname = value != null ? value : throw new ArgumentNullException(); } }
        public virtual int Age { get => _age; set { _age = value >= 0 ? value : throw new ArgumentOutOfRangeException(); } }

        public override string ToString()
        {
            return $"{Name}\t{Surname}\t{Age}";
        }
    }
}
