using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.LoanTypes
{
    public class StudentLoan : Loan
    {
        private const int _interestRate = 1;
        private const double _amount = 10000;
        public StudentLoan() : base(_interestRate, _amount)
        {
        }
    }
}
