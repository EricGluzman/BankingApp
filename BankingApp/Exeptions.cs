using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class Exeptions
    {
    }
    public class NameException : Exception
    {
        public NameException() : base("User`s Name Is Null Or Invalid.") { }
        public NameException(string message) : base(message) { }
    }
    public class AgeException : Exception
    {
        public AgeException() : base("Invalid Age. Must Be Between 14-128") { }
        public AgeException(string message) : base(message) { }
    }
    public class LoanExeption : Exception
    {
        public LoanExeption() : base("Invalid Loan. The Loan Cant Be 0 Or Negative.") { }
        public LoanExeption(string message) : base(message) { }
    }
    public class BalanceException : Exception
    {
        public BalanceException() : base("Error With Balance Operations.") { }
        public BalanceException(string message) : base(message) { }
    }
}
