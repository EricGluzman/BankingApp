namespace BankingApp
{
    internal partial class Program
    {
        public abstract class Employee : Person
        {
            public EmployeeClass Role { get; private set; }
            public DateTime HireDate { get; private set; }
            public int EmployeeID { get; private set; }
            private static int EmpIdCounter = 0; // this is small bank so there never will be more than 1000 emloyees...

            protected Employee(string name, string sur_Name, byte age, string address,EmployeeClass role) : base(name, sur_Name, age, address)
            {
                this.Role = role;
                this.HireDate = DateTime.Now;
                this.EmployeeID = EmpIdCounter;
                EmpIdCounter++;
            }
           
        }
    }
}
