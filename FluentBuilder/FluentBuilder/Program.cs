using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = Employee.CreateBuilder().SetSurname("Surname").SetFirstname("Firstname").SetYearOfBirth(25).
                SetPhone("+380000000000").SetEmail("Email@gmail.com").SetEducation("Education").
                SetCompetencies(new List<string> { "Competencies1", "Competencies2" }).SetExperience(new List<string> { "Experience1", "Experience2" });
            Console.WriteLine(employee.ToString());
        }
    }
    class Employee
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int YearOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public List<string> Competencies { get; set; }
        public List<string> Experience { get; set; }
        public override string ToString()
        {
            string tmp = $"{Surname} {Firstname}, {YearOfBirth}\nPhone:\t{Phone}\tEmail:\t{Email}\tEducation:\t{Education}\nCompetencies:\n";
            foreach (string item in Competencies)
            {
                tmp += $"\t{item}\n";
            }
            tmp += "Experience:\n";
            foreach (string item in Experience)
            {
                tmp += $"\t{item}\n";
            }
            return tmp;
        }
        public static EmployeeBuilder CreateBuilder()
        {
            return new EmployeeBuilder();
        }
    }
    class EmployeeBuilder
    {
        Employee employee = new Employee();
        public EmployeeBuilder SetSurname(string Surname)
        {
            employee.Surname = Surname;
            return this;
        }
        public EmployeeBuilder SetFirstname(string Firstname)
        {
            employee.Firstname = Firstname;
            return this;
        }
        public EmployeeBuilder SetYearOfBirth(int YearOfBirth)
        {
            employee.YearOfBirth = YearOfBirth;
            return this;
        }
        public EmployeeBuilder SetPhone(string Phone)
        {
            employee.Phone = Phone;
            return this;
        }
        public EmployeeBuilder SetEmail(string Email)
        {
            employee.Email = Email;
            return this;
        }
        public EmployeeBuilder SetEducation(string Education)
        {
            employee.Education = Education;
            return this;
        }
        public EmployeeBuilder SetCompetencies(List<string> Competencies)
        {
            employee.Competencies = Competencies;
            return this;
        }
        public EmployeeBuilder SetExperience(List<string> Experience)
        {
            employee.Experience = Experience;
            return this;
        }
        public static implicit operator Employee(EmployeeBuilder builder)
        {
            return builder.employee;
        }
    }
}