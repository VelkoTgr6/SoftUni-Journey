using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(context));

            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //Console.WriteLine(AddNewAddressToEmployee(context));

            Console.WriteLine(GetEmployeesInPeriod(context));

            //Console.WriteLine(GetAddressesByTown(context));

            //Console.WriteLine(GetEmployee147(context));

            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            //Console.WriteLine(GetLatestProjects(context));

            //Console.WriteLine(IncreaseSalaries(context));

            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            //Console.WriteLine(DeleteProjectById(context));

            //Console.WriteLine(RemoveTown(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     e.MiddleName,
                     e.JobTitle,
                     e.Salary
                 }).ToList();

            string result = string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));

            return result;
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            string result = string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} - {e.Salary:f2}"));

            return result;
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName
                    ,
                    e.LastName
                    ,
                    e.Department.Name
                    ,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            string result = string.Join(Environment.NewLine,
                employees.Select(e => $"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:F2}"));

            return result;
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15"
                ,
                TownId = 4
            };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new
                {
                    e.AddressId
                    ,
                    e.Address.AddressText
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, employees.Select(e => $"{e.AddressText}"));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        { 
            var employees = context.Employees
            .Include(e=>e.EmployeesProjects)
            .ThenInclude(ep=>ep.Project)
            .Select(e => new
            {
                e.FirstName
                , e.LastName,
                e.Manager
                ,Projects=e.EmployeesProjects
                .Select(ep => new
                {
                    ep.Project.Name,
                    ep.Project.StartDate,
                    ep.Project.EndDate
                }).ToList()
            })
            .Take(10)
            .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

                if (!employee.Projects.Any())
                {
                    continue;
                }
                else
                {
                    
                    foreach (var project in employee.Projects)
                    {
                        string projectStartDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture);

                        string projectEndDate = project.EndDate.HasValue
                            ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished";
                        if (project.StartDate.Year >= 2001 && project.StartDate.Year <= 2003)
                        {
                            sb.AppendLine($"--{project.Name} - {projectStartDate} - {projectEndDate}");
                        }
                        
                    }
                }
                
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addreses = context.Addresses.Select(a => new
            {
                a.Town.Name,
                a.AddressText,
                a.Employees.Count,
            })
            .OrderByDescending(e => e.Count)
            .ThenBy(a => a.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .ToList();

            return string.Join(Environment.NewLine, addreses.Select(a => $"{a.AddressText}, {a.Name} - {a.Count} employees"));
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.JobTitle
            }).Where(e => e.EmployeeId == 147)
            .ToList();

            var projects = context.EmployeesProjects.Select(p => new
            {
                p.EmployeeId,
                projectName = p.Project.Name
            })
            .Where(e => e.EmployeeId == 147)
            .OrderBy(p => p.projectName)
            .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employee)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                foreach (var project in projects)
                {
                    sb.AppendLine($"{project.projectName}");
                }
            }

            return sb.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments.Select(d => new
            {
                d.Name,
                d.Employees.Count,
                d.Manager.FirstName,
                d.Manager.LastName,
                employees = d.Employees
                .Where(e => e.Department.Name == d.Name)
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList()
            })
                .Where(e => e.Count > 5)
                .OrderBy(e => e.Count)
                .ThenBy(d => d.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.FirstName} {department.LastName}");
                foreach (var employee in department.employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var patternDate = "M/d/yyyy h:mm:ss tt";

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDateFormatted = p.StartDate.ToString(patternDate, CultureInfo.InvariantCulture)
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDateFormatted);
            }

            return sb.ToString().TrimEnd();
        
    }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departmentNames = new List<string> { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context.Employees
                .Where(e => departmentNames.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            // Increase salary by 12%
            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.FirstName
                , e.LastName,
                e.JobTitle,
                e.Salary
            })
                .Where(e=>e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e=>e.FirstName)
                .ThenBy(e=>e.LastName)
                .ToList();

            return string.Join(Environment.NewLine, employees.Select(e =>$"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == 2);

            if (projectToDelete != null)
            {
                var employeesProjects = context.EmployeesProjects.Where(ep => ep.ProjectId == projectToDelete.ProjectId);
                context.EmployeesProjects.RemoveRange(employeesProjects);

                context.Projects.Remove(projectToDelete);
                context.SaveChanges();
            }

            var projects = context.Projects
                .OrderBy(p => p.ProjectId) 
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, projects.Select(p => p.Name));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var addressesToDelete = context.Addresses.Where(a => a.Town.Name == "Seattle").ToList();

            var employeesToUpdate = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in employeesToUpdate)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToDelete);

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return $"{addressesToDelete.Count()} addresses in Seattle were deleted";
        }
    }

}
