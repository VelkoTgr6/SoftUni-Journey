using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.LoanTypes
{
    public class MortgageLoan : Loan
    {
        private const int _interestRate = 3;
        private const double _amount = 50_000;
        public MortgageLoan() : base(_interestRate, _amount)
        {
        }
    }
}
