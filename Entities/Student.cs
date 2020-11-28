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
        public int ID { get; set; }
        public string FacultyNumber { get; set; }
        public string Major { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
