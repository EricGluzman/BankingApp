using System.Data;

namespace BankingApp
{
    internal partial class Program
    {
        public class Customer : Person
        {
            public int Balance { get; private set; }
            public int LoanDept { get; private set; }
            public Customer(string name, string sur_Name, byte age, string address, int balance) : base(name, sur_Name, age, address)
            {
                this.Balance = balance;
                this.LoanDept = 0;
            }

            public Customer(int id, string name, string sur_Name, byte age, string address,int balance) : base(id, name, sur_Name, age, address)
            {
                this.Balance = balance;
                this.LoanDept = 0;
            }
            public override string ToString()
            {
                return base.ToString()+$"Balane {Balance}, Loan {Owes()}.";
            }
            public void AddBalance(int balance)
            {
                this.Balance += balance;
            }
            public void MinusBalance(int balance)
            {
                this.Balance -= balance;
            }
            public int Owes()
            {
                if (this.Balance >= 0) return 0;
                return Math.Abs(Balance);
            }
            public void GiveLoan(int loan)
            {
                if (loan <= 0) throw new LoanExeption();
                this.LoanDept += loan;
            }
            public void LoanPayment(int payment)
            {
                if (payment <= 0) throw new LoanExeption("Cant Pay The Loan With Negative Money.");
                if (payment > Owes())
                {
                    this.AddBalance(Math.Abs(Owes() - payment));
                    this.LoanDept = 0;
                }
            }
            public void AddToTheLoan(int payment)
            {
                if (payment <= 0) throw new NullReferenceException("The Value Must Be More Than 0");
                this.LoanDept += payment;
            }
        }
    }
}
