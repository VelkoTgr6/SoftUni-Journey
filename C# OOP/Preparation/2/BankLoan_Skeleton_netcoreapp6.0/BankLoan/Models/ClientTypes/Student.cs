using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.ClientTypes
{
    public class Student : Client
    {
        private const int initInterest = 2;
        public Student(string name, string id, double income) : base(name, id, initInterest, income)
        {
        }

        public override void IncreaseInterest()
        {
            base.Interest ++;
        }
    }
}
