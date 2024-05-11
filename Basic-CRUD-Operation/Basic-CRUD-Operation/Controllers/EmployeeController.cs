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
        //Created an instance of Employee service class for performing CRUD operations
        Employees employee=new Employees();
        //ActionMethod for getting Allemployee
        [HttpGet]
        public ActionResult GetDetails()
        {
            return Ok(employee.GetEmployee());
        }
        //ActionMethod for addig new employee
        [HttpPost]
        public ActionResult PostDetails(Employee newitem)
        {
            //Checking EmployeeId is Zero
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
        
        //ActionMethod for Updating employee 
        [HttpPut]
        public ActionResult EditEmployee(Employee newitem)
        {
            employee.EditEmployee(newitem);
            return Ok(employee.employees);
        }
        //ActionMethod for deleting employee 
        [HttpDelete]
        public ActionResult DeleteEmployee(int id) 
        {
            employee.DeleteEmployee(id);
            return Ok(employee.employees);
        }
    }
}
