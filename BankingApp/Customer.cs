using System.Data;
using System.Runtime.InteropServices;

namespace BankingApp
{
    internal partial class Program
    {
        public class Customer : Person
        {
            public int Balance { get; private set; }
            public int LoanDept { get; private set; }
            public DateTime LoanDueTime { get; private set; }
            public DateTime NextMeeting { get; private set; }
            private bool IsAllowedToGoToMinus = false;
            private bool FlagedForLoanDept;
            private bool CanOperate = true;
            public Customer(string name, string sur_Name, byte age, string address, int balance) : base(name, sur_Name, age, address)
            {
                this.Balance = balance;
                this.LoanDept = 0;
                this.LoanDueTime = new DateTime();
                this.NextMeeting = new DateTime();
                this.FlagedForLoanDept = false;
            }

            public Customer(int id, string name, string sur_Name, byte age, string address,int balance) : base(id, name, sur_Name, age, address)
            {
                this.Balance = balance;
                this.LoanDept = 0;
                this.LoanDueTime = new DateTime();
                this.NextMeeting = new DateTime();
                this.FlagedForLoanDept = false;
            }
            public override string ToString()
            {
                return base.ToString()+$"Balane {Balance}, Loan {Owes()}.";
            }
            public void AddBalance(int balance)
            { 
                SuspendedWork(CanOperate);
                this.Balance += balance;
            }
            public void MinusBalance(int balance)
            {

                SuspendedWork(CanOperate);
                this.Balance -= balance;
            }
            public void ChangeBalance(int balance)
            {
                SuspendedWork(CanOperate);
                this.Balance = balance;
            }
            public int Owes()
            {
                if (this.Balance >= 0) return 0;
                return Math.Abs(Balance);
            }
            public void ForceLoan(int value)
            {
                SuspendedWork(CanOperate);
                this.LoanDept = value;
            }
            public void SchedMeeting(DateTime time)
            {
                this.NextMeeting = time;
            }
            public void ChangeFlag(bool flag)
            {
                this.FlagedForLoanDept = flag;
            }
            public bool IsFlaged()
            {
                if (this.FlagedForLoanDept) return true;
                else return false;
            }
            public bool IsAllowedMinus()
            {
                return IsAllowedToGoToMinus;
            }
            public void ChangeMinus(bool b)
            {
                SuspendedWork(CanOperate);
                this.IsAllowedToGoToMinus = b;
            }
            public void Suspended(bool b)
            {
                this.CanOperate = b;
            }
            public bool IsSuspended()
            {
                return !this.CanOperate;
            }
            private void SuspendedWork(bool b)
            {
                if(!b) throw new SuspendedAccountException();
            }
        }
    }
}
