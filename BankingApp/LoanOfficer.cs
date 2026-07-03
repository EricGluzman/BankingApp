namespace BankingApp
{
    internal partial class Program
    {
        public class LoanOfficer : Employee
        {
            private static Timer _timer;
            private static bool _timerStarted = false;


            public LoanOfficer(string name, string sur_Name, byte age, string address, EmployeeClass role, List<Customer> customers) : base(name, sur_Name, age, address, role, customers)
            {
                if (!_timerStarted)
                {
                    _timerStarted = true;
                    _ = StartPeriodicCheckAsync();
                }
            }

            public void ScheduleMeeting(Customer customer,byte minutes,byte hour,byte day, byte month, int year)
            {
                customer.SchedMeeting(new DateTime(year, month,day, hour,minutes, 0));
            }
            
            private static async Task StartPeriodicCheckAsync()
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromMinutes(5));
                    await CheckSomethingAsync();
                }
            }
            private static async Task CheckSomethingAsync()
            {
                for (int i = 0; i < Customers.Count; i++)
                {
                    if (Customers[i].Owes() != 0) Customers[i].ChangeFlag(true);
                    if (Customers[i].IsFlaged() && Customers[i].Owes() == 0) Customers[i].ChangeFlag(false);
                }
                await Task.CompletedTask;
            }
            public void LoanPayment(int payment,Customer customer)
            {
                if (payment <= 0) throw new LoanExeption("Cant Pay The Loan With Negative Money.");
                if (payment > customer.Owes())
                {
                    customer.AddBalance(Math.Abs(customer.Owes() - payment));
                    customer.ForceLoan(0);
                }
                else customer.ForceLoan(customer.Owes() - payment);
            }
            public void AddToTheLoan(int payment,Customer customer) // just adding more without offical loan 
            {
                if (payment <= 0) throw new ArgumentNullException("The Value Must Be More Than 0");
                customer.ForceLoan(customer.Owes() + payment);
            }
            public void GiveLoan(int loan,Customer customer) // adding more with another loan.
            {
                if (loan <= 0) throw new LoanExeption();
                customer.ForceLoan(customer.Owes() + loan);
            }
        }
    }
}
