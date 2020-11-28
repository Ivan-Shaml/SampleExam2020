using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleExam2020.Entities
{
    public class Student
    {
        [Key]
        [Required]
        public int ID { get; set; }
        
        [Required]
        public string FacultyNumber { get; set; }

        [Required]
        public string Major { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
