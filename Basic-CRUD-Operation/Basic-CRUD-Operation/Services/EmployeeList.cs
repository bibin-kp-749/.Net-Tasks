using Basic_CRUD_Operation.Models;
using System.Collections;
using System.Net.WebSockets;

namespace Basic_CRUD_Operation.Services
{
    public class Employees
    {
      public  List<Employee> employees = new List<Employee>
        {
            new Employee{EmployeeId=1,EmployeeName="Anil kumar",EmployeeAge=40,Designation="Manager"},
            new Employee{EmployeeId=2,EmployeeName="Saravanan",EmployeeAge=34,Designation="Accountant"},
            new Employee{EmployeeId=3,EmployeeName="Vimal",EmployeeAge=28,Designation="SalesMan"}
        };
        public IEnumerable GetEmployee()
        {
            return employees;
        }
        public void AddEmployee(Employee newitem)
        {
            int id = employees.Count + 1;
            Employee emp = new Employee { EmployeeId = id, EmployeeName = newitem.EmployeeName, EmployeeAge = newitem.EmployeeAge, Designation = newitem.Designation };
            employees.Add(emp);
        }
        public void EditEmployee(Employee newitem)
        {
            var result = employees.FirstOrDefault(x => x.EmployeeId == newitem.EmployeeId);
            result.EmployeeId = newitem.EmployeeId;
            result.EmployeeName=newitem.EmployeeName;
            result.EmployeeAge=newitem.EmployeeAge;
            result.Designation=newitem.Designation;
        }
        public void DeleteEmployee(int id)
        {
            employees.RemoveAll(s => s.EmployeeId == id);
        }
    }
}
