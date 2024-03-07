using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_D03.Models
{
    [Table("Department")]
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Remote("CheckDeptId","Department")]
        public int DeptId { get; set; }
        [Remote("CheckDeptName", "Department")]
        public string DeptName { get; set; }

        public bool Status { get; set; } = true;

        public  ICollection<Student> Students { get;} 
            = new HashSet<Student>();

    }
}
