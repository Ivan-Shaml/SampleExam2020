using Microsoft.EntityFrameworkCore;
using SampleExam2020.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleExam2020.Data
{
    public class StudentsDbContext : DbContext
    {
        
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
