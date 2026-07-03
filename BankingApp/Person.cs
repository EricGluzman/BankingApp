namespace BankingApp
{
    internal partial class Program
    {
        public abstract class Person
        {
            public int ID { get; private set; }
            public string Name { get; private set; }
            public string Sur_Name { get; private set; }
            public byte Age { get; private set; }
            public string Address { get; private set; }
            private static int IdCounter = 1000;

            protected Person(string name, string sur_Name, byte age, string address)
            {
                ID = IdCounter;
                Name = name;
                Sur_Name = sur_Name;
                Age = age;
                Address = address;
                IdCounter++;
            }
            protected Person(int id,string name, string sur_Name, byte age, string address)
            {
                ID = id;
                Name = name;
                Sur_Name = sur_Name;
                Age = age;
                Address = address;
                IdCounter++;
            }
            public override string ToString()
            {
                return $"User ID: {ID},Name: {Name}, SurName {Sur_Name}, Age: {Age}, Address of living: {Address} ";
            }
            public void ChangeName(string name)
            {
                if (name == null) throw new NameException();
                this.Name = name;
            }
            public void AddYear()
            {
                this.Age++;
            }
            public void ChangeAge(int age)
            {
                if (age > 128 || age < 14) throw new AgeException();
                this.Age = (byte)age;
            }
            public void ChangeAddress(string ad)
            {
                if (ad == null) throw new ArgumentNullException();
                this.Address = ad;
            }
        }
        
    }
}
