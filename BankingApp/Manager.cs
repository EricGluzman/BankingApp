namespace BankingApp
{
    internal partial class Program
    {
        public class Manager : Employee
        {
            public Manager(string name, string sur_Name, byte age, string address, EmployeeClass role, List<Customer> customers) : base(name, sur_Name, age, address, role, customers)
            {
            }
            public void AllowMinus(Customer customer,bool b)
            {
                if (customer == null) throw new ArgumentNullException("The Customer Is Null");
                customer.ChangeMinus(b);
            }
            public void Suspend(bool b, Customer customer)
            {
                if (customer == null) throw new ArgumentNullException("The Customer Is Null");
                customer.Suspended(b);
            }
            public void ViewCustomersTable()
            {
                int i = 1;
                foreach(Customer customer in Customers)
                {
                    Console.Write($"{i} ");
                    Console.WriteLine(customer.ToString());
                    i++;
                }
            }

        }
    }
}
