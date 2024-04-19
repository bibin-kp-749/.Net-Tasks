using Basic_CRUD_Operation_UsingDI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Basic_CRUD_Operation_UsingDI.Services
{
    public class Emplyees:IEmployees
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return EmployeeList.employees;
        }
        public IEnumerable<Employee> AddEmployees(string name, int age, string designation)
        {
            int id=EmployeeList.employees.Count+1;
            EmployeeList.employees.Add(new Employee { EmployeeId = id, EmployeeName = name, EmployeeAge = age, Designation = designation });
            return EmployeeList.employees;
        }
        public IEnumerable<Employee> UpdateEmployees(int id,string name, int age, string designation)
        {
            var result=EmployeeList.employees.FirstOrDefault(x=>x.EmployeeId==id);
            result.EmployeeId= id;
            result.EmployeeName = name;
            result.EmployeeAge = age;
            result.Designation = designation;
            return EmployeeList.employees;
        }
        public IEnumerable<Employee> DeleteEmployees(int id)
        {
            EmployeeList.employees.RemoveAll(x=>x.EmployeeId==id);
            return EmployeeList.employees;
        }
    }
}
