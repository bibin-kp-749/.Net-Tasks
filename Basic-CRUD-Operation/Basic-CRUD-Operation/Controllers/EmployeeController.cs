using Basic_CRUD_Operation.Models;
using Basic_CRUD_Operation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Basic_CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Employees employee=new Employees();
        [HttpGet]
        public ActionResult GetDetails()
        {
            return Ok(employee.GetEmployee());
        }
        [HttpPost]
        public ActionResult PostDetails(Employee newitem)
        {
            if (newitem.EmployeeId == 0)
            {
                return BadRequest("the id doesnot contain Zero");
            }
            else
            {
                employee.AddEmployee(newitem);
                return Ok(employee.employees);
            }
        }
        
       
        [HttpPut]
        public ActionResult EditEmployee(Employee newitem)
        {
            employee.EditEmployee(newitem);
            return Ok(employee.employees);
        }
        [HttpDelete]
        public ActionResult DeleteEmployee(int id) 
        {
            employee.DeleteEmployee(id);
            return Ok(employee.employees);
        }
    }
}
