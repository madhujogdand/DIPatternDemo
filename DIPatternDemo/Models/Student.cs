using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPatternDemo.Models
{
    [Table("stud")]
    public class Student
    {
        [Key]
        public int RollNo { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Course { get; set; }

        [Required]
        public decimal Fees { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
    }
}
