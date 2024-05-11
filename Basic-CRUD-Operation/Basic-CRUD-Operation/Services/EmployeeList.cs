using Basic_CRUD_Operation.Models;
using System.Collections;
using System.Net.WebSockets;

namespace Basic_CRUD_Operation.Services
{
    public class Employees
    {
        //Defining List of employees and add data to the list
      public  List<Employee> employees = new List<Employee>
        {
            new Employee{EmployeeId=1,EmployeeName="Anil kumar",EmployeeAge=40,Designation="Manager"},
            new Employee{EmployeeId=2,EmployeeName="Saravanan",EmployeeAge=34,Designation="Accountant"},
            new Employee{EmployeeId=3,EmployeeName="Vimal",EmployeeAge=28,Designation="SalesMan"}
        };
        //Method for Geting all Employee
        public IEnumerable GetEmployee()
        {
            return employees;
        }
        //Metod for adding new employee
        public void AddEmployee(Employee newitem)
        {
            //Employee id set as cout+1
            int id = employees.Count + 1;
            Employee emp = new Employee { EmployeeId = id, EmployeeName = newitem.EmployeeName, EmployeeAge = newitem.EmployeeAge, Designation = newitem.Designation };
            //Employee data added to the list
            employees.Add(emp);
        }
        //Method for Edit Existing employee 
        public void EditEmployee(Employee newitem)
        {
            //Retrive the employee by using Id
            var result = employees.FirstOrDefault(x => x.EmployeeId == newitem.EmployeeId);
            result.EmployeeId = newitem.EmployeeId;
            result.EmployeeName=newitem.EmployeeName;
            result.EmployeeAge=newitem.EmployeeAge;
            result.Designation=newitem.Designation;
        }
        //Method for Deleting an employee using id
        public void DeleteEmployee(int id)
        {
            employees.RemoveAll(s => s.EmployeeId == id);
        }
    }
}
