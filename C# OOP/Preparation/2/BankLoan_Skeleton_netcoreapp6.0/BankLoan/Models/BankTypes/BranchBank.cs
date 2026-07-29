using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.BankTypes
{
    public class BranchBank : Bank
    {
        private const int _capacity = 25;
        public BranchBank(string name) : base(name, _capacity)
        {
        }
    }
}
