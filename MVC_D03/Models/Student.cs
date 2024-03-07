using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_D03.Models
{
    
    public class Student
    {
        public int Id { get; set; }
        [Required]

        [MaxLength(20,ErrorMessage ="This name is so Long")]
        public string Name { get; set; }

        [Range(15,25)]
        public int Age { get ; set; }

        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}",ErrorMessage ="Please Enter an Vaild Email"),]
        public string Email { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set;}

        public  Department Department { get; set; }
    }
}
