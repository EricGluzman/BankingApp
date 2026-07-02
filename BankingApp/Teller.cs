namespace BankingApp
{
    internal partial class Program
    {
        public class Teller : Employee
        {
            public Teller(string name, string sur_Name, byte age, string address, EmployeeClass role, List<Customer> customers) : base(name, sur_Name, age, address, role,customers)
            {
            }
            public void AccountInfo(Customer customer)
            {
                if (customer == null) throw new NullReferenceException("Account Cant Be Null.");
                Console.WriteLine(customer.ToString());
            }
            public void AccountInfoByID(int id,List<Customer> customers)
            {
                if (id == 0 || customers == null) throw new NullReferenceException("Id Cant Be 0 Or Accounts List Cant Be Null.");
                for(int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].ID == id) Console.WriteLine(customers[i].ToString());
                    return;
                }
                throw new NullReferenceException("Cant Find The Account By Id.");
            }
            public void Deposit(Customer customer, int balance)
            {
                if (customer == null) throw new NullReferenceException("Account Cant Be Null");
                if (balance <= 0) throw new BalanceException("Balace Deposit Cant Be Zero Or Less.");
                customer.AddBalance(balance);
            }
            public void Withdrawal(Customer customer, int balance)
            {
                if (customer == null) throw new NullReferenceException("Account Cant Be Null");
                if (balance <= 0) throw new BalanceException("Balace Deposit Cant Be Zero Or Less.");
                if (customer.Balance < balance)
                {
                    customer.GiveLoan(Math.Abs(customer.Balance - balance));
                    customer.ChangeBalance(0);
                }
                else customer.MinusBalance(balance);
            }
            public void OpenCustomerAccount(string name,string sur_Name,byte age,string address,int balance)
            {
                if (name == null || sur_Name == null || age < 14 || age > 128 || address == null) throw new NullReferenceException("One Of The Accounts Info Is Null Or Invalid.");
                AddCustomer(name, sur_Name, age, address, balance);
            }
        }
    }
}
