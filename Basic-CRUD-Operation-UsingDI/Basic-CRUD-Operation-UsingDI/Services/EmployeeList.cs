using Basic_CRUD_Operation_UsingDI.Models;

namespace Basic_CRUD_Operation_UsingDI.Services
{
    public class EmployeeList
    {
       public static List<Employee> employees = new List<Employee>
        {
            new Employee{EmployeeId=1,EmployeeName="Vishwas",EmployeeAge=31,Designation="Manager"},
            new Employee{EmployeeId=2,EmployeeName="Risal",EmployeeAge=32,Designation="Clerk"}
        };
    }
}
