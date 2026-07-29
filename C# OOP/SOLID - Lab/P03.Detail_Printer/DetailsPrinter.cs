using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Employee> baseEmployees;
        private IList<Manager> managers;
       

        public DetailsPrinter(IList<Employee> employees)
        {
            baseEmployees = employees;
        }

        public void PrintDetails()
        {
            foreach (var employee in baseEmployees)
            {
                employee.Print();
            }
            foreach (var manager in managers)
            {
                manager.Print();
            }
        }
    }
}
