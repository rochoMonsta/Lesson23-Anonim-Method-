using System;

namespace AnonimMethod
{
    class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public DateTime Begin { get; private set; }
        public event EventHandler<DateTime> Started;
        public Person() { }
        public Person(string Name, string SurName, int Age)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(nameof(Name), "Wrong type of Name.");
            else
                this.Name = Name;

            if (string.IsNullOrWhiteSpace(SurName))
                throw new ArgumentNullException(nameof(SurName), "Wrong type of Surname.");
            else
                this.SurName = SurName;

            if (Age < 0)
                throw new ArgumentException(nameof(Age), "Unreal age.");
            else
                this.Age = Age;
        }
        public void DoWork()
        {
            Begin = DateTime.Now;
            Started?.Invoke(this, Begin);
        }
        public override string ToString()
        {
            return $"Person:\n\tName: {this.Name};\n\tSurname: {this.SurName};\n\tAge: {this.Age}";
        }
    }
}
