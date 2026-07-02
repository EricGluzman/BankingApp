namespace BankingApp
{
    internal partial class Program
    {
        public class LoanOfficer : Employee
        {
            private static Timer _timer;
            private static int _instanceCount = 0;
            public LoanOfficer(string name, string sur_Name, byte age, string address, EmployeeClass role, List<Customer> customers) : base(name, sur_Name, age, address, role, customers)
            {
                _instanceCount++;
                if (_instanceCount == 1)
                {
                    _timer = new Timer(CheckLoanDepts,null,TimeSpan.Zero,TimeSpan.FromMinutes(5));
                }
            }
            public void ScheduleMeeting(Customer customer,byte minutes,byte hour,byte day, byte month, byte year)
            {
                customer.SchedMeeting(new DateTime((int)year, (int)month, (int)day, (int)hour, (int)minutes, 0));
            }
            public static void CheckLoanDepts(Object? state)
            {

            }
            public static void CheckDepts(List<Customer> customers)
            {
                if (customers == null) throw new NullReferenceException();
                for(int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].Owes() != 0) customers[i].Flag();
                    if (customers[i].IsFlaged() && customers[i].Owes() == 0) customers[i].RemoveFlag();
                }
            }
        }
    }
}
