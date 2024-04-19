using Basic_CRUD_Operation_UsingDI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basic_CRUD_Operation_UsingDI.Services
{
    public interface IEmployees
    {
        public IEnumerable<Employee> GetEmployees();
        public IEnumerable<Employee> AddEmployees(string name,int age,string designation);
        public IEnumerable<Employee> UpdateEmployees(int id, string name, int age, string designation);
        public IEnumerable<Employee> DeleteEmployees(int id);
    }
}
