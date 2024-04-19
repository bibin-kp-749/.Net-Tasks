using Basic_CRUD_Operation_UsingDI.Models;
using Basic_CRUD_Operation_UsingDI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_CRUD_Operation_UsingDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployees request;
        public EmployeeController(IEmployees request)
        {
            this.request = request;
        }
        [HttpGet("GetEmployee")]
        public IEnumerable<Employee> GetEmployees()
        {
            return request.GetEmployees();
        }
        [HttpPost("AddEmployees")]
        public IEnumerable<Employee> AddEmployees(string name,int age,string designation)
        {
            return request.AddEmployees(name,age,designation);
        }
        [HttpPut("UpdateEmployees")]
        public IEnumerable<Employee> UpdateEmployees(int id, string name, int age, string designation)
        {
            return request.UpdateEmployees(id,name,age,designation);
        }
        [HttpDelete("DeleteEmployees")]
        public IEnumerable<Employee> DeleteEmployees(int id)
        {
            
            return request.DeleteEmployees(id);
        }
    }
}
