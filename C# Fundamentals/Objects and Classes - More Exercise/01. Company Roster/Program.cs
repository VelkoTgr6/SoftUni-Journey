using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Employee
    {
        public Employee(string name, decimal salary)// string department)
        {
            Name = name;
            Salary = salary;
            //Department = department;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        //public string Department { get; set; }
    }
    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public decimal TotalSalaries { get; set; }
        public void AddNewEmployee(string empName, decimal empSalary)
        {
            this.TotalSalaries += empSalary;

            this.Employees.Add(new Employee(empName, empSalary));
        }
        public Department(string departmentName)
        {
            this.Name = departmentName;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Department> departments = new List<Department>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string department = input[2];
                if (!departments.Any(d => d.Name == input[2]))
                {
                    departments.Add(new Department(input[2]));
                }
            
            departments.Find(d => d.Name == input[2]).AddNewEmployee(input[0], decimal.Parse(input[1]));
            }
                Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

                Console.WriteLine($"Highest Average Salary: {bestDepartment.Name}");

                foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
                {
                    Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
                }













            
        }
    }
}
