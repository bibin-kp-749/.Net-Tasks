using System.ComponentModel.DataAnnotations;

namespace Basic_CRUD_Operation.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        [Required]
        [StringLength(10,MinimumLength =4)]
        public string EmployeeName { get; set; }
        [Range(18, 56)]
        public int EmployeeAge { get; set; }
        [StringLength(10, MinimumLength = 4)]
        public string Designation {  get; set; }
    }
}
